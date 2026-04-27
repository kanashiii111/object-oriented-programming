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
    private Long id;
    private Integer blocks;
    private Integer rebounds;
    private Float blocksPerGame;
    private Float reboundsPerGame;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Integer getBlocks() {
        return blocks;
    }

    public void setBlocks(Integer blocks) {
        this.blocks = blocks;
    }

    public Integer getRebounds() {
        return rebounds;
    }

    public void setRebounds(Integer rebounds) {
        this.rebounds = rebounds;
    }

    public Float getBlocksPerGame() {
        return blocksPerGame;
    }

    public void setBlocksPerGame(Float blocksPerGame) {
        this.blocksPerGame = blocksPerGame;
    }

    public Float getReboundsPerGame() {
        return reboundsPerGame;
    }

    public void setReboundsPerGame(Float reboundsPerGame) {
        this.reboundsPerGame = reboundsPerGame;
    }


}
