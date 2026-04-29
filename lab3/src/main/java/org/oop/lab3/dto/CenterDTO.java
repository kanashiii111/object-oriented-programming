package org.oop.lab3.dto;

import com.fasterxml.jackson.annotation.JsonPropertyOrder;

import jakarta.validation.constraints.Positive;
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
    @Positive(message="blocks must atleast be 0")
    private Integer blocks;
    @Positive(message="rebounds must atleast be 0")
    private Integer rebounds;
    @Positive(message="blocksPerGame must atleast be 0")
    private Float blocksPerGame;
    @Positive(message="reboundsPerGame must atleast be 0")
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
