from contextlib import asynccontextmanager
from fastapi import FastAPI
from backend.database.session import init_db
from backend.api.routes import players

@asynccontextmanager
async def lifespan(app: FastAPI):
    print("Очистка и инициализация БД...")
    await init_db()
    yield
    print("Завершение работы приложения...")

app = FastAPI(title="oop.lab4 api", lifespan=lifespan)

app.include_router(players.router)

@app.get("/")
def root():
    return {"message": "Welcome to oop lab4 API"}


