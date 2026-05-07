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

    def __init__(self, id, assists_per_game, three_points_per_game, assists= None, three_point_makes = None):
        self.id = id

        if assists == None and three_point_makes == None:
            self.assists = 111
            self.three_point_makes = 111
        elif assists == None and not (three_point_makes == None):
            self.assists = 222
            self.three_point_makes = three_point_makes 
        elif not (assists == None) and three_point_makes == None:
            self.assists = assists
            self.three_point_makes = 333
            
        self.assists_per_game = assists_per_game
        self.three_points_per_game = three_points_per_game
    
    def play(self):
        return str.format("{name} is orchestrating the offense, making plays and hitting three-pointers.", name=self.getPlayer().getName())
    
    def train(self):
        return str.format("{name} is training on ball handling, passing and shooting three-pointers.", name=self.getPlayer().getName())
    
    def printInfo(self):
        return self.getPlayer().getBasicInfo() + f"\nAssists: {self.assists}\nThreePointMakes: {self.three_point_makes}\nAPG: {self.assists_per_game}\nTPP: {self.three_points_per_game}"
    def assist(self):
        self.assists += 1
        return str.format("Assists: {assists}", assists=self.assists)
    
    def makeThreePointShot(self):
        self.three_point_makes += 1
        return str.format("Three point makes: {three_point_makes}", three_point_makes=self.three_point_makes)
    
    def makePass(self):
        return str.format("{name} is passing the ball to a teammate.", name=self.getPlayer().getName())
    
    def dribble(self):
        return str.format("{name} is dribbling the ball.", name=self.getPlayer().getName())

    def __repr__(self) -> str:
        return f"PointGuard(id={self.id!r}, assists_per_game={self.assists_per_game!r}, three_points_per_game={self.three_points_per_game!r})"
    
    def getPlayer(self):
        return self.player