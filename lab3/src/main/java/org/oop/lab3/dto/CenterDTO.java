package org.oop.lab3.dto;

import com.fasterxml.jackson.annotation.JsonPropertyOrder;

import lombok.Data;

@Data
@JsonPropertyOrder({
    "id",
    "blocks",
    "rebounds",
    "blocks_per_game",
    "rebounds_per_game",
})
public class CenterDTO {
    public Long id;
    public Integer blocks;
    public Integer rebounds;
    public Float blocksPerGame;
    public Float reboundsPerGame;
}
