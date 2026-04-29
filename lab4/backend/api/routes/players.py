from fastapi import APIRouter, Depends
from sqlalchemy.ext.asyncio import AsyncSession
from backend.database.session import get_db
from backend.database.crud import player as crud_player
from backend.api.schemas.player import PlayerRead, PlayerCreate

router = APIRouter(prefix="/api/players", tags=["Players"])

@router.get("/", response_model=list[PlayerRead])
async def read_players(db: AsyncSession = Depends(get_db)):
    players = await crud_player.get_all_players(db)
    return players

@router.post("/", status_code=201)
async def add_player(db: AsyncSession = Depends(get_db), player_data: PlayerCreate = None):
    added_player = await crud_player.create_player(db, player_data)
    return added_player