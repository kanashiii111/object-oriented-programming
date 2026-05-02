from contextlib import asynccontextmanager
from fastapi import FastAPI
import uvicorn
from database.session import init_db
from api.routes import players, teams

@asynccontextmanager
async def lifespan(app: FastAPI):
    print("Очистка и инициализация БД...")
    await init_db()
    yield
    print("Завершение работы приложения...")

app = FastAPI(title="oop.lab4 api", lifespan=lifespan)

app.include_router(players.router)
app.include_router(teams.router)

@app.get("/")
def root():
    return {"message": "Welcome to oop lab4 API"}

if __name__ == "__main__":
    uvicorn.run("main:app", port=5000, reload=True)
