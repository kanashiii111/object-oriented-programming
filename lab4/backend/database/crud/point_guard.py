from sqlalchemy import select
from sqlalchemy.ext.asyncio import AsyncSession
from database.models.point_guard import PointGuard

async def create_point_guard(db: AsyncSession, player_id: int,  **point_guard_data):
    new_point_guard = PointGuard(id=player_id, **point_guard_data)
    
    db.add(new_point_guard)
    return new_point_guard

async def delete_point_guard(db: AsyncSession, player_id: int):
    result = await db.execute(select(PointGuard).where(PointGuard.id == player_id))
    point_guard = result.scalar_one_or_none()
    if point_guard:
        await db.delete(point_guard)
