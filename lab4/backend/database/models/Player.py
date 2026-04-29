from typing import List
from typing import Optional
from sqlalchemy import ForeignKey
from sqlalchemy import String
from sqlalchemy.orm import DeclarativeBase
from sqlalchemy.orm import Mapped
from sqlalchemy.orm import mapped_column 
from sqlalchemy.orm import relationship
from Team import Team

class Base(DeclarativeBase):
    pass

class Player(Base):
    __tablename__ = "players"
    
    id = Mapped[int] = mapped_column(primary_key=True)
    name = Mapped[str] = mapped_column(String(30), unique=True)
    height = Mapped[int]
    jerseyNumber = Mapped[int]
    type = Mapped[str]
    team = Mapped["Team"] = relationship(back_populates="player")
    