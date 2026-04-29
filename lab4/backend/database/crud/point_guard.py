from sqlalchemy import select
from sqlalchemy.ext.asyncio import AsyncSession
from backend.database.models.point_guard import PointGuard

async def create_point_guard(db: AsyncSession, player_id: int,  **point_guard_data):
    new_point_guard = PointGuard(id=player_id, **point_guard_data)
    
    db.add(new_point_guard)
    return new_point_guard