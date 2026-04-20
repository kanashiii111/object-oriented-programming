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
public class PointGuard{

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

    public Long getId() { return id; }
    public Player getPlayer() { return player; }
    public Float getAssistsPerGame() { return assists_per_game; }
    public Float getThreePointPercentage() { return three_point_percentage; }

    public void setId( long id ) { this.id = id; }
    public void setPlayer( Player player ) { this.player = player; }
    public void setAssistsPerGame( Float assists_per_game ) { this.assists_per_game = assists_per_game; }
    public void setThreePointPercentage( Float three_point_percentage ) { this.three_point_percentage = three_point_percentage; }
}
