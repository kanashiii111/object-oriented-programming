from typing import List, TYPE_CHECKING
from typing import Optional
from sqlalchemy import ForeignKey
from sqlalchemy import String
from sqlalchemy.orm import DeclarativeBase
from sqlalchemy.orm import Mapped
from sqlalchemy.orm import mapped_column 
from sqlalchemy.orm import relationship
from ..base import Base

if TYPE_CHECKING:
    from .player import Player

class PointGuard(Base):
    __tablename__ = "point_guards"

    id: Mapped[int] = mapped_column(ForeignKey("players.id"), primary_key=True, autoincrement=False)
    assists: Mapped[int] = mapped_column(nullable=True)
    three_point_makes: Mapped[int] = mapped_column(nullable=True)
    assists_per_game: Mapped[float] = mapped_column(nullable=True)
    three_points_per_game: Mapped[float] = mapped_column(nullable=True)

    player: Mapped["Player"] = relationship(back_populates="point_guard")

    def __repr__(self) -> str:
        return f"PointGuard(id={self.id!r}, assists_per_game={self.assists_per_game!r}, three_points_per_game={self.three_points_per_game!r})"
    