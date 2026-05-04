from fastapi import APIRouter, Depends, status
from fastapi.responses import JSONResponse, PlainTextResponse
from sqlalchemy.ext.asyncio import AsyncSession
from database.session import get_db
from database.crud import player as crud_player
from api.schemas.player import PlayerRead, PlayerCreate, PlayerUpdate

router = APIRouter(prefix="/players", tags=["Players"])

@router.get("", response_model=list[PlayerRead])
async def read_players(db: AsyncSession = Depends(get_db)):
    players = await crud_player.get_all_players(db)
    return players

@router.get("/{player_id}", response_model=PlayerRead)
async def read_player(player_id: int, db: AsyncSession = Depends(get_db)):
    player = await crud_player.get_player_by_id(db, player_id)
    if not player:
        return JSONResponse(status_code=status.HTTP_404_NOT_FOUND, content={"message": "Player not found"})
    return player

@router.get("/{player_id}/methods/{method_name}")
async def get_player_method(player_id: int, method_name:str, db: AsyncSession = Depends(get_db)):
    player = await crud_player.get_player_by_id(db, player_id)
    if not player:
        return JSONResponse(status_code=status.HTTP_404_NOT_FOUND, content={"message": "Player not found"})
    
    result = None
    sub_obj = None
    
    if method_name in ["block", "rebound"]:
        sub_obj = player.getCenter()
        if sub_obj:
            result = getattr(sub_obj, method_name)()
            
    elif method_name in ["assist", "makeThreePointShot"]:
        sub_obj = player.getPointGuard()
        if sub_obj:
            result = getattr(sub_obj, method_name)()
    
    if method_name == "play":
        return PlainTextResponse(player.play())
    elif method_name == "train":
        return PlainTextResponse(player.train())
    elif method_name == "printInfo":
        return PlainTextResponse(player.printInfo())
    elif method_name == "setScreen":
        return PlainTextResponse(player.getCenter().setScreen())
    elif method_name == "post":
        return PlainTextResponse(player.getCenter().post())
    elif method_name == "dribble":
        return PlainTextResponse(player.getPointGuard().dribble())
    elif method_name == "makePass":
        return PlainTextResponse(player.getPointGuard().makePass())
    
    if sub_obj:
        db.add(sub_obj)
        await db.commit()
        await db.refresh(sub_obj)

    return result if result else "Method not found or sub-player missing"

@router.post("", response_model=PlayerRead, status_code=status.HTTP_201_CREATED)
async def add_player(db: AsyncSession = Depends(get_db), player_data: PlayerCreate = None):
    if player_data is None:
        return JSONResponse(status_code=status.HTTP_400_BAD_REQUEST, content={"message": "Invalid player data"})
    added_player = await crud_player.create_player(db, player_data)
    return added_player

@router.delete("/{player_id}", status_code=status.HTTP_204_NO_CONTENT)
async def delete_player(player_id: int, db: AsyncSession = Depends(get_db)):
    if player_id <= 0 or player_id is None:
        return JSONResponse(status_code=status.HTTP_400_BAD_REQUEST, content={"message": "Invalid player ID"})
    success = await crud_player.delete_player_by_id(db, player_id)
    if not success:
        return JSONResponse(status_code=status.HTTP_404_NOT_FOUND, content={"message": "Player not found"})
    
@router.put("", response_model=PlayerRead, status_code=status.HTTP_200_OK)
async def update_player(player_data: PlayerUpdate, db: AsyncSession = Depends(get_db)):
    updated_player = await crud_player.update_player(db, player_data)
    if not updated_player:
        return JSONResponse(status_code=status.HTTP_404_NOT_FOUND, content={"message": "Player not found"})
    return updated_player
