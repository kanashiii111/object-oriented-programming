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
import lombok.EqualsAndHashCode;

@Entity
@Data
@EqualsAndHashCode(callSuper=false)
@Table(name="point_guards")
public class PointGuard implements Playable {

    public PointGuard() {}

    public PointGuard(float assists_per_game, float three_point_percentage) {
        this.assistsPerGame = assists_per_game;
        this.threePointPercentage = three_point_percentage;
    }

    @Id
    private Long id;

    @OneToOne
    @MapsId
    @JoinColumn(name="id")
    @JsonBackReference
    private Player player;

    @Column(name="assists_per_game")
    @Min(value = 0, message = "Ассисты за игру должны быть хотя бы 0")
    private Float assistsPerGame;

    @Column(name="three_point_percentage")
    @Min(value = 0, message = "Процент трехочковых должен быть хотя бы 0")
    private Float threePointPercentage;

    public String dribble() {
        return String.format("%s is dribbling the ball", player.getName());
    }

    public String pass() {
        return String.format("%s is passing the ball to a teammate.", player.getName());
    }

    public String play() {
        return String.format("%s is orchestrating the offense, making plays and hitting three-pointers.", player.getName());
    }

    public String train() {
        return String.format("%s is training on ball handling, passing and shooting three-pointers.", player.getName());
    }

    public String printInfo() {
        return String.format("APG: %f\nTPP: %f", assistsPerGame, threePointPercentage);
    }
}
