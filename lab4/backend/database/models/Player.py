from typing import List, TYPE_CHECKING
from typing import Optional
from sqlalchemy import ForeignKey
from sqlalchemy import String
from sqlalchemy.orm import DeclarativeBase
from sqlalchemy.orm import Mapped
from sqlalchemy.orm import mapped_column 
from sqlalchemy.orm import relationship
from .team import Team
from ..base import Base
from enum import Enum

if TYPE_CHECKING:
    from .center import Center
    from .point_guard import PointGuard

class Type(int, Enum):
    point_guard = 0
    center = 1
class Player(Base):
    __tablename__ = "players"
    
    id: Mapped[int] = mapped_column(primary_key=True)
    name: Mapped[str] = mapped_column(String(30), unique=True)
    height: Mapped[int]
    jersey_number: Mapped[int]
    type: Mapped[int]
    games_played: Mapped[int] = mapped_column(nullable=True)
    team_id: Mapped[int] =  mapped_column(ForeignKey("teams.id", ondelete="SET NULL"), nullable=True)

    center: Mapped[Optional["Center"]] = relationship(back_populates="player", cascade="all, delete")
    point_guard: Mapped[Optional["PointGuard"]] = relationship(back_populates="player", cascade="all, delete")

    def __repr__(self) -> str:
        return f"""Player(id={self.id!r},
            name={self.name!r},
            height={self.height!r},
            jersey_number={self.jersey_number!r},
            type={self.type!r},
            team_id={self.team_id!r},
            center={self.center!r},
            point_guard={self.point_guard!r})
        """
    