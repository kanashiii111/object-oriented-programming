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
    private Long id;
    private Float assistsPerGame;
    private Float threePointPercentage;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Float getAssistsPerGame() {
        return assistsPerGame;
    }

    public void setAssistsPerGame(Float assistsPerGame) {
        this.assistsPerGame = assistsPerGame;
    }

    public Float getThreePointPercentage() {
        return threePointPercentage;
    }

    public void setThreePointPercentage(Float threePointPercentage) {
        this.threePointPercentage = threePointPercentage;
    }
}
