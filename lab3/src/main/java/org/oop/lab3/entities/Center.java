package org.oop.lab3.entities;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.MapsId;
import jakarta.persistence.OneToOne;
import jakarta.persistence.Table;

@Entity
@Table(name="centers")
public class Center implements Playable{

    public Center() {}

    public Center(float blocks_per_game, float rebounds_per_game ) {
        this.blocks_per_game = blocks_per_game;
        this.rebounds_per_game = rebounds_per_game;
    }

    public Center(int blocks, float blocks_per_game, float rebounds_per_game ) {
        this.blocks = blocks;
        this.blocks_per_game = blocks_per_game;
        this.rebounds_per_game = rebounds_per_game;
    }

    public Center(int blocks, int rebounds, float blocks_per_game, float rebounds_per_game ) {
        this.blocks = blocks;
        this.rebounds = rebounds;
        this.blocks_per_game = blocks_per_game;
        this.rebounds_per_game = rebounds_per_game;
    }

    @Id
    private Long id;

    @OneToOne
    @MapsId
    @JoinColumn(name="id")
    private Player player;

    @Column(name="blocks")
    private Integer blocks;

    @Column(name="rebounds")
    private Integer rebounds;

    @Column(name="blocks_per_game")
    private Float blocks_per_game;

    @Column(name="rebounds_per_game")
    private Float rebounds_per_game;

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

    @Override
    public String play() {
        return String.format("%s dominates the post, blocks and dunks the ball.", player.getName());
    }

    @Override
    public String train() {
        return String.format("%s is training playing close to basket, rebounding and blocking shots.", player.getName());
    }

    @Override
    public String printInfo() {
        return player.getBasicInfo() + String.format("Blocks: %d\nRebounds: %d\nBPG: %f\nRPG: %f", blocks, rebounds, blocks_per_game, rebounds_per_game);
    }

    public Long getId() { return id; }
    public Player getPlayer() { return player; }
    public Integer getBlocks() { return blocks; }
    public Integer getRebounds() { return rebounds; }
    public Float getBlocksPerGame() { return blocks_per_game; }
    public Float getReboundsPerGame() { return rebounds_per_game; }

    public void setId( Long id ) { this.id = id; }
    public void setPlayer( Player player ) { this.player = player; }
    public void setBlocks( Integer blocks ) { this.blocks = blocks; }
    public void setRebounds( Integer rebounds ) { this.rebounds = rebounds; }
    public void setBlocksPerGame( Float blocks_per_game ) { this.blocks_per_game = blocks_per_game; }
    public void setReboundsPerGame( Float rebounds_per_game ) { this.rebounds_per_game = rebounds_per_game; }
}
