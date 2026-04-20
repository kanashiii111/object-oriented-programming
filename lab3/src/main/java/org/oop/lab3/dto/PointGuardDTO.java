package org.oop.lab3.dto;

import com.fasterxml.jackson.annotation.JsonPropertyOrder;

import lombok.Data;

@Data
@JsonPropertyOrder({
    "id",
    "assists_per_game",
    "three_point_percentage",
})
public class PointGuardDTO {
    public Long id;
    public Float assistsPerGame;
    public Float threePointPercentage;
}
