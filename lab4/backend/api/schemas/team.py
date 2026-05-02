from pydantic import BaseModel, ConfigDict
from typing import Optional

class TeamRead(BaseModel):
    id: int 
    name: str
    city: Optional[str] = None 
    ###
    model_config = ConfigDict(from_attributes=True)

class TeamCreate(BaseModel):
    name: str
    city: Optional[str] = None 
    ###
    model_config = ConfigDict(from_attributes=True)
    
class TeamUpdate(BaseModel):
    id: int
    name: str
    city: Optional[str] = None 
    ###
    model_config = ConfigDict(from_attributes=True)
