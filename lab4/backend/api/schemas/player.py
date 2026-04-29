from pydantic import BaseModel, ConfigDict
from typing import Optional

from .center import CenterRead, CenterCreate
from .point_guard import PointGuardRead, PointGuardCreate

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