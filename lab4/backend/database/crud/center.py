from sqlalchemy import select
from sqlalchemy.ext.asyncio import AsyncSession
from database.models.center import Center

async def create_center(db: AsyncSession, player_id: int,  **center_data):
    new_center = Center(id=player_id, **center_data)
    
    db.add(new_center)
    return new_center

async def delete_center(db: AsyncSession, player_id: int):
    result = await db.execute(select(Center).where(Center.id == player_id))
    center = result.scalar_one_or_none()
    if center:
        await db.delete(center)
