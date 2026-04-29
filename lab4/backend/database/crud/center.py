from sqlalchemy import select
from sqlalchemy.ext.asyncio import AsyncSession
from backend.database.models.center import Center

# async def get_all_players(db: AsyncSession):
#     result = await db.execute(select(Center))
#     return result.scalars().all()

async def create_center(db: AsyncSession, player_id: int,  **center_data):
    new_center = Center(id=player_id, **center_data)

    print(f"new center: {new_center}")
    
    db.add(new_center)
    return new_center