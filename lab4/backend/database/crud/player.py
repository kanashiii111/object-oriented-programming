from sqlalchemy import select, inspect
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy.orm import selectinload
from api.schemas.player import PlayerCreate, PlayerUpdate
from database.crud.center import create_center, delete_center
from database.crud.point_guard import create_point_guard, delete_point_guard
from database.models.player import Player, Type
import logging

logging.basicConfig(
    level=logging.DEBUG,
    filemode="w",
    filename="player_crud.log",
    format='%(asctime)s - %(name)s - %(levelname)s - %(message)s'
)

logger = logging.getLogger(__name__)

async def get_all_players(db: AsyncSession):
    result = await db.execute(select(Player)
                            .options(
                            selectinload(Player.center),
                            selectinload(Player.point_guard)
                            ))
    return result.scalars().all()

async def get_player_by_id(db: AsyncSession, player_id: int):
    result = await db.execute(select(Player).where(Player.id == player_id).options(
        selectinload(Player.center),
        selectinload(Player.point_guard)
    ))
    return result.scalar_one_or_none()

async def create_player(db: AsyncSession, player_schema: PlayerCreate):
    player_data = player_schema.model_dump()
    role_data = player_data.pop("center", None) or player_data.pop("point_guard", None)
    player_type = player_data.get("type")

    new_player = Player(**player_data)

    db.add(new_player)
    await db.flush()

    try:
        if player_type == Type.center:
            await create_center(db, player_id=new_player.id, **role_data)
        elif player_type == Type.point_guard:
            await create_point_guard(db, player_id=new_player.id, **role_data)
        
        await db.commit()
        result = await db.execute(
            select(Player)
            .where(Player.id == new_player.id)
            .options(
                selectinload(Player.center),
                selectinload(Player.point_guard)
            )
        )
        return result.scalar_one()
        
    except Exception as e:
        await db.rollback()
        logger.debug(f"Error creating player: {e}")
        raise e
    
    return new_player

async def delete_player_by_id(db: AsyncSession, player_id: int):
    result = await db.execute(select(Player).where(Player.id == player_id).options(
        selectinload(Player.center),
        selectinload(Player.point_guard)
    ))
    player = result.scalar_one_or_none()
    
    if player:
        await db.delete(player)
        try:
            await db.commit()
            return True
        except Exception as e:
            await db.rollback()
            raise e
    return False

async def update_player(db: AsyncSession, player_schema: PlayerUpdate):
    player_id = player_schema.model_dump().get("id")
    try:
        result = await db.execute(select(Player).where(Player.id == player_id).options(
            selectinload(Player.center),
            selectinload(Player.point_guard)
        ))
    except Exception as e:
        logger.debug(f"Error fetching player with id {player_id}: {e}")
        return None
    player = result.scalar_one_or_none()
    
    logger.debug(f"Fetched player for update: {player}")
    logger.debug(f"is player persistent: {inspect(player).persistent}")

    if not player:
        return None
    
    try:
        new_player = Player(**player_schema.model_dump())
        if new_player.type == Type.center and player.point_guard:
            await delete_point_guard(db, player_id=player.id)
            player.point_guard = None
        elif new_player.type == Type.point_guard and player.center:
            await delete_center(db, player_id=player.id)
            player.center = None
        player = await db.merge(new_player)
    except Exception as e:
        logger.debug(f"Error updating player attributes: {e}")
        return None
        
    logger.debug(f"Updated/Merged player: {player}")
    logger.debug(f"is merged player persistent: {inspect(player).persistent}")
    
    try:
        await db.commit()
        await db.refresh(player)
    except Exception as e:
        await db.rollback()
        logger.debug(f"Error committing updated player: {e}")
        return None

    result = await db.execute(
        select(Player).where(Player.id == player_id).options(
            selectinload(Player.center),
            selectinload(Player.point_guard)
        ))
    return result.scalar_one()
