package org.oop.lab3.entities;

import com.fasterxml.jackson.annotation.JsonBackReference;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.MapsId;
import jakarta.persistence.OneToOne;
import jakarta.persistence.Table;
import jakarta.validation.constraints.Min;
import lombok.Data;

@Entity
@Data
@Table(name="centers")
public class Center implements Playable{

    public Center() {}

    public Center(float blocksPerGame, float reboundsPerGame ) {
        this.blocks = 0;
        this.rebounds = 0;
        this.blocksPerGame = blocksPerGame;
        this.reboundsPerGame = reboundsPerGame;
    }

    public Center(int blocks, float blocksPerGame, float reboundsPerGame ) {
        this.blocks = blocks;
        this.rebounds = 1;
        this.blocksPerGame = blocksPerGame;
        this.reboundsPerGame = reboundsPerGame;
    }

    public Center(int blocks, int rebounds, float blocksPerGame, float reboundsPerGame ) {
        this.blocks = blocks;
        this.rebounds = rebounds;
        this.blocksPerGame = blocksPerGame;
        this.reboundsPerGame = reboundsPerGame;
    }

    @Id
    private Long id;

    @OneToOne
    @MapsId
    @JoinColumn(name="id")
    @JsonBackReference
    private Player player;

    @Column(name="blocks")
    @Min(value = 0, message = "Блоки должны быть хотя бы 0")
    private Integer blocks;

    @Column(name="rebounds")
    @Min(value = 0, message = "Подборы должны быть хотя бы 0")
    private Integer rebounds;

    @Column(name="blocks_per_game")
    @Min(value = 0, message = "Блоки за игру должны быть хотя бы 0")
    private Float blocksPerGame;

    @Column(name="rebounds_per_game")
    @Min(value = 0, message = "Подборы за игру должны быть хотя бы 0")
    private Float reboundsPerGame;

    public String block() {
        blocks++;
        return String.format("blocks: %d", blocks);
    }

    public String rebound() {
        rebounds++;
        return String.format("rebounds: %d", rebounds);
    }

    public String setScreen() {
        return String.format("%s sets a screen", player.getName());
    }

    public String post() {
        return String.format("%s is posting up in the paint", player.getName());
    }

    public String play() {
        return String.format("%s dominates the post, blocks and dunks the ball.", player.getName());
    }

    public String train() {
        return String.format("%s is training playing close to basket, rebounding and blocking shots.", player.getName());
    }

    public String printInfo() {
        return String.format("Blocks: %d\nRebounds: %d\nBPG: %f\nRPG: %f", blocks, rebounds, blocksPerGame, reboundsPerGame);
    }
}
