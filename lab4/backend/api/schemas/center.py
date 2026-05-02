from pydantic import BaseModel, ConfigDict
from typing import Optional

class CenterRead(BaseModel):
    id: int 
    blocks: Optional[int] = None
    rebounds: Optional[int] = None
    blocks_per_game: Optional[float] = None
    rebounds_per_game: Optional[float] = None

    model_config = ConfigDict(from_attributes=True)

class CenterCreate(BaseModel):
    blocks: Optional[int] = None
    rebounds: Optional[int] = None
    blocks_per_game: Optional[float] = None
    rebounds_per_game: Optional[float] = None

    model_config = ConfigDict(from_attributes=True)
    
class CenterUpdate(BaseModel):
    id: int
    blocks: Optional[int] = None
    rebounds: Optional[int] = None
    blocks_per_game: Optional[float] = None
    rebounds_per_game: Optional[float] = None

    model_config = ConfigDict(from_attributes=True)