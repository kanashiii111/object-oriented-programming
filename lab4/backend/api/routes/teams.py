from fastapi import APIRouter, Depends, status
from fastapi.responses import JSONResponse
from sqlalchemy.ext.asyncio import AsyncSession
from database.session import get_db
from database.crud import team as crud_team
from api.schemas.team import TeamCreate, TeamRead, TeamUpdate

router = APIRouter(prefix="/teams", tags=["Teams"])

@router.get("", response_model=list[TeamRead])
async def read_teams(db: AsyncSession = Depends(get_db)):
    teams = await crud_team.get_all_teams(db)
    return teams

@router.post("", response_model=TeamRead, status_code=status.HTTP_201_CREATED)
async def add_team(db: AsyncSession = Depends(get_db), team_data: TeamCreate = None):
    if team_data is None:
        return JSONResponse(status_code=status.HTTP_400_BAD_REQUEST, content={"message": "Invalid team data"})
    added_team = await crud_team.create_team(db, team_data)
    return added_team

@router.delete("/{team_id}", status_code=status.HTTP_204_NO_CONTENT)
async def delete_team(team_id: int, db: AsyncSession = Depends(get_db)):
    if team_id <= 0 or team_id is None:
        return JSONResponse(status_code=status.HTTP_400_BAD_REQUEST, content={"message": "Invalid team ID"})
    success = await crud_team.delete_team_by_id(db, team_id)
    if not success:
        return JSONResponse(status_code=status.HTTP_404_NOT_FOUND, content={"message": "Team not found"})

@router.put("", response_model=TeamRead, status_code=status.HTTP_200_OK)
async def update_team(team_data: TeamUpdate, db: AsyncSession = Depends(get_db)):
    updated_team = await crud_team.update_team(db, team_data)
    if not updated_team:
        return JSONResponse(status_code=status.HTTP_404_NOT_FOUND, content={"message": "Team not found"})
    return updated_team
