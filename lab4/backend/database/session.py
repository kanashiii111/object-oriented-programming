from sqlalchemy.ext.asyncio import create_async_engine, async_sessionmaker, AsyncSession
import asyncio
from .base import Base
from .models import *

engine = create_async_engine("postgresql+asyncpg://superuser:superuser@postgres:5432/players_db")
async_session_factory = async_sessionmaker(bind=engine, expire_on_commit=False)

async def init_db():
    max_retries = 10
    retry_count = 0
    
    while retry_count < max_retries:
        try:
            async with engine.begin() as conn:
                await conn.run_sync(Base.metadata.drop_all)
                await conn.run_sync(Base.metadata.create_all)
            return
        except Exception as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise
            print(f"Database connection failed, retrying... ({retry_count}/{max_retries})")
            await asyncio.sleep(2)

async def get_db():
    async with async_session_factory() as session:
        try:
            yield session
        finally:
            await session.close()
