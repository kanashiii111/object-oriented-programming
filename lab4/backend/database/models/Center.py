from typing import List, Optional, TYPE_CHECKING
from sqlalchemy import ForeignKey
from sqlalchemy import String
from sqlalchemy.orm import DeclarativeBase
from sqlalchemy.orm import Mapped
from sqlalchemy.orm import mapped_column 
from sqlalchemy.orm import relationship
from ..base import Base

if TYPE_CHECKING:
    from .player import Player
class Center(Base):
    __tablename__ = "centers"

    id: Mapped[int] = mapped_column(ForeignKey("players.id"), primary_key=True)
    blocks: Mapped[int] = mapped_column(nullable=True)
    rebounds: Mapped[int] = mapped_column(nullable=True)
    blocks_per_game: Mapped[float] = mapped_column(nullable=True)
    rebounds_per_game: Mapped[float] = mapped_column(nullable=True)

    player: Mapped["Player"] = relationship(back_populates="center")

    def __repr__(self) -> str:
        return f"Center(id={self.id!r}, blocks={self.blocks!r}, rebounds={self.rebounds!r}, blocks_per_game={self.blocks_per_game!r}, rebounds_per_game={self.rebounds_per_game!r})"
    