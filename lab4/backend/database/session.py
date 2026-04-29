from sqlalchemy.ext.asyncio import create_async_engine, async_sessionmaker, AsyncSession
from .base import Base
from .models import *

engine = create_async_engine("postgresql+asyncpg://superuser:superuser@localhost:5432/players_db")
async_session_factory = async_sessionmaker(bind=engine, expire_on_commit=False)

async def init_db():
    async with engine.begin() as conn:
        await conn.run_sync(Base.metadata.drop_all)
        await conn.run_sync(Base.metadata.create_all)

async def get_db():
    async with async_session_factory() as session:
        try:
            yield session
        finally:
            await session.close()