from pydantic import BaseModel, ConfigDict
from typing import Optional

class PointGuardRead(BaseModel):
    id: int 
    assists_per_game: Optional[float] = None
    three_point_percentage: Optional[float] = None
    ###
    model_config = ConfigDict(from_attributes=True)

class PointGuardCreate(BaseModel):
    assists_per_game: Optional[float] = None
    three_point_percentage: Optional[float] = None
    ###
    model_config = ConfigDict(from_attributes=True)
    
class PointGuardUpdate(BaseModel):
    id: int
    assists_per_game: Optional[float] = None
    three_point_percentage: Optional[float] = None
    ###
    model_config = ConfigDict(from_attributes=True)
