package org.oop.lab3.dto;

import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.Mappings;
import org.oop.lab3.entities.Center;
import org.oop.lab3.entities.Player;
import org.oop.lab3.entities.PointGuard;
import org.oop.lab3.entities.Team;

@Mapper(componentModel = "spring")
public interface PlayerMapper {
    @Mapping(target = "teamId", source="team.id")
    PlayerDTO toDTO(Player player);
    @Mappings({
        @Mapping(target = "team", ignore = true),
        @Mapping(target = "center", ignore = true),
        @Mapping(target = "pointGuard", ignore = true)
    })
    Player toEntity(PlayerDTO dto);

    CenterDTO toDTO(Center center);
    @Mapping(target = "player", ignore = true)
    Center toEntity(CenterDTO dto);

    PointGuardDTO toDTO(PointGuard pointGuard);
    @Mapping(target = "player", ignore = true)
    PointGuard toEntity(PointGuardDTO dto);

    TeamDTO toDTO(Team team);
    Team toEntity(TeamDTO dto);
}
