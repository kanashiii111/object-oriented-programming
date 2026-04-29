from sqlalchemy import select
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy.orm import selectinload
from backend.api.schemas.player import PlayerCreate
from backend.database.crud.center import create_center
from backend.database.crud.point_guard import create_point_guard
from backend.database.models.player import Player, Type

async def get_all_players(db: AsyncSession):
    result = await db.execute(select(Player)
                            .options(
                            selectinload(Player.center),
                            selectinload(Player.point_guard)
                            ))
    return result.scalars().all()

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
        raise e
    
    return new_player