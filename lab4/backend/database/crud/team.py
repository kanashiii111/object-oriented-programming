from sqlalchemy import select, inspect
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy.orm import selectinload
from api.schemas.team import TeamCreate, TeamUpdate, TeamRead
from database.models.team import Team

async def get_all_teams(db: AsyncSession):
    result = await db.execute(select(Team))
    return result.scalars().all()

async def get_team_by_id(db:AsyncSession, team_id):
    result = await db.execute(select(Team).where(Team.id == team_id))
    return result.scalar_one_or_none()

async def create_team(db: AsyncSession, team_schema: TeamCreate):
    team_data = team_schema.model_dump()
    new_team = Team(**team_data)
    db.add(new_team)
    try:
        await db.commit()
        await db.refresh(new_team)
    except Exception as e:
        await db.rollback()
        raise e
    return new_team

async def delete_team_by_id(db: AsyncSession, team_id: int):
    result = await db.execute(select(Team).where(Team.id == team_id))
    team = result.scalar_one_or_none()
    if team is None:
        return False
    await db.delete(team)
    try:
        await db.commit()
    except Exception as e:
        await db.rollback()
        raise e
    return True

async def update_team(db: AsyncSession, team_schema: TeamUpdate):
    team_id = team_schema.model_dump().get("id")
    result = await db.execute(select(Team).where(Team.id == team_id))
    team = result.scalar_one_or_none()
    if team is None:
        return None
    new_team = Team(**team_schema.model_dump())
    team = await db.merge(new_team)
    try:
        await db.commit()
        await db.refresh(team)
    except Exception as e:
        await db.rollback()
        raise e
    result = await db.execute(select(Team).where(Team.id == team_id))
    team = result.scalar_one_or_none()
    return team