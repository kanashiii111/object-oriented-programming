from sqlalchemy.orm import DeclarativeBase, declarative_base
from sqlalchemy_nest import declarative_nested_model_constructor

Base = declarative_base(constructor=declarative_nested_model_constructor)

# class Base(DeclarativeBase):
#     pass