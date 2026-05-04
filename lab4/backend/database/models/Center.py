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
    
    def play(self):
        return str.format("{name} dominates the post, blocks and dunks the ball.", name=self.getPlayer().getName())
    
    def train(self):
        return str.format("{name} is training playing close to basket, rebounding and blocking shots.", name=self.getPlayer().getName())
    
    def printInfo(self):
        return self.getPlayer().getBasicInfo() + f"\nBlocks: {self.blocks}\nRebounds: {self.rebounds}\nBlocks per game: {self.blocks_per_game}\nRebounds per game: {self.rebounds_per_game}"
        
    def block(self):
        self.blocks += 1
        return str.format("blocks: {blocks}", blocks=self.blocks)
    
    def rebound(self):
        self.rebounds += 1
        return str.format("rebounds: {rebounds}", rebounds=self.rebounds)
    
    def setScreen(self):
        return str.format("{name} sets a screen.", name=self.getPlayer().getName())
    
    def post(self):
        return str.format("{name} is posting up in the paint.", name=self.getPlayer().getName())

    def __repr__(self) -> str:
        return f"Center(id={self.id!r}, blocks={self.blocks!r}, rebounds={self.rebounds!r}, blocks_per_game={self.blocks_per_game!r}, rebounds_per_game={self.rebounds_per_game!r})"
    
    def getPlayer(self):
        return self.player