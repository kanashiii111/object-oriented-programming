package org.oop.lab3.dto;

import org.mapstruct.Mapper;
import org.oop.lab3.entities.Team;

@Mapper(componentModel = "spring")
public interface TeamMapper {
    TeamDTO toDTO(Team team);
    Team toEntity(TeamDTO dto);
}
