package org.oop.lab3.dto;

import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.oop.lab3.entities.Center;
import org.oop.lab3.entities.Player;
import org.oop.lab3.entities.PointGuard;

@Mapper(componentModel = "spring")
public interface PlayerMapper {
    PlayerDTO toDTO(Player player);
    Player toEntity(PlayerDTO dto);

    CenterDTO toDTO(Center center);
    @Mapping(target = "player", ignore = true)
    Center toEntity(CenterDTO dto);

    PointGuardDTO toDTO(PointGuard pointGuard);
    @Mapping(target = "player", ignore = true)
    PointGuard toEntity(PointGuardDTO dto);
}
