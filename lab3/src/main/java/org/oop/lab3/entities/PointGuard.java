package org.oop.lab3.entities;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.MapsId;
import jakarta.persistence.OneToOne;
import jakarta.persistence.Table;

@Entity
@Table(name="point_guards")
public class PointGuard implements Playable {

    public PointGuard() {}

    public PointGuard(float assists_per_game, float three_point_percentage) {
        this.assists_per_game = assists_per_game;
        this.three_point_percentage = three_point_percentage;
    }

    @Id
    private Long id;

    @OneToOne
    @MapsId
    @JoinColumn(name="id")
    private Player player;

    @Column(name="assists_per_game")
    private Float assists_per_game;

    @Column(name="three_point_percentage")
    private Float three_point_percentage;

    public String dribble() {
        return String.format("%s is dribbling the ball", player.getName());
    }

    public String pass() {
        return String.format("%s is passing the ball to a teammate.", player.getName());
    }

    @Override
    public String play() {
        return String.format("%s is orchestrating the offense, making plays and hitting three-pointers.", player.getName());
    }

    @Override
    public String train() {
        return String.format("%s is training on ball handling, passing and shooting three-pointers.", player.getName());
    }

    @Override
    public String printInfo() {
        return player.getBasicInfo() + String.format("APG: %f\nTPP: %f", assists_per_game, three_point_percentage);
    }

    public Long getId() { return id; }
    public Player getPlayer() { return player; }
    public Float getAssistsPerGame() { return assists_per_game; }
    public Float getThreePointPercentage() { return three_point_percentage; }

    public void setId( long id ) { this.id = id; }
    public void setPlayer( Player player ) { this.player = player; }
    public void setAssistsPerGame( Float assists_per_game ) { this.assists_per_game = assists_per_game; }
    public void setThreePointPercentage( Float three_point_percentage ) { this.three_point_percentage = three_point_percentage; }
}
