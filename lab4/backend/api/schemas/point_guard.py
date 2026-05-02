from pydantic import BaseModel, ConfigDict
from typing import Optional

class PointGuardRead(BaseModel):
    id: int 
    assists: Optional[int] = None
    three_point_makes: Optional[int] = None
    assists_per_game: Optional[float] = None
    three_points_per_game: Optional[float] = None
    ###
    model_config = ConfigDict(from_attributes=True)

class PointGuardCreate(BaseModel):
    assists: Optional[int] = None
    three_point_makes: Optional[int] = None
    assists_per_game: Optional[float] = None
    three_points_per_game: Optional[float] = None
    ###
    model_config = ConfigDict(from_attributes=True)
    
class PointGuardUpdate(BaseModel):
    id: int
    assists: Optional[int] = None
    three_point_makes: Optional[int] = None
    assists_per_game: Optional[float] = None
    three_points_per_game: Optional[float] = None
    ###
    model_config = ConfigDict(from_attributes=True)
