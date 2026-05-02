from pydantic import BaseModel, ConfigDict
from typing import Optional

from .center import CenterRead, CenterCreate, CenterUpdate
from .point_guard import PointGuardRead, PointGuardCreate, PointGuardUpdate

class PlayerRead(BaseModel):
    id: int
    name: str
    height: int
    jersey_number: int
    type: int
    team_id: Optional[int] = None
    center: Optional[CenterRead] = None
    point_guard: Optional[PointGuardRead] = None
    ###
    model_config = ConfigDict(from_attributes=True)

class PlayerCreate(BaseModel):
    name: str
    height: int
    jersey_number: int
    type: int
    team_id: Optional[int] = None
    center: Optional[CenterCreate] = None
    point_guard: Optional[PointGuardCreate] = None
    ###
    model_config = ConfigDict(from_attributes=True)
    
class PlayerUpdate(BaseModel):
    id: int
    name: Optional[str] = None
    height: Optional[int] = None
    jersey_number: Optional[int] = None
    type: Optional[int] = None
    team_id: Optional[int] = None
    center: Optional[CenterUpdate] = None
    point_guard: Optional[PointGuardUpdate] = None
    ###
    model_config = ConfigDict(from_attributes=True)