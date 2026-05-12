package org.oop.lab3.entities;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import com.fasterxml.jackson.annotation.JsonManagedReference;
import com.fasterxml.jackson.annotation.JsonPropertyOrder;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToOne;
import jakarta.persistence.Table;
import jakarta.persistence.UniqueConstraint;
import jakarta.validation.Valid;
import jakarta.validation.constraints.Max;
import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.NotNull;
import lombok.Data;

@JsonPropertyOrder({
    "id",
    "name",
    "height",
    "jersey_number",
    "team",
    "type",
    "point_guard",
    "center"
})
@Data
@Entity
@Table(
    name="players",
    uniqueConstraints = @UniqueConstraint(columnNames = {"name"})
)
public class Player implements Playable{

    public Player() {}

    public Player(String name, int height, int jersey_number, Type type) {
        this.name = name;
        this.height = height;
        this.jerseyNumber = jersey_number;
        this.type = type;
    }

    public enum Type {
        pointGuard,
        center
    }

    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name="id")
    private Long id;

    @OneToOne(mappedBy="player", cascade=CascadeType.ALL, optional=true, orphanRemoval=true)
    @JsonManagedReference
    @Valid
    private Center center;

    @OneToOne(mappedBy="player", cascade=CascadeType.ALL, optional=true, orphanRemoval=true)
    @JsonManagedReference
    @Valid
    private PointGuard pointGuard;

    @Column(name="name")
    @NotNull(message="Имя не должно быть пустым")
    @NotBlank(message="Имя не должно быть пустым")
    @NotEmpty(message="Имя не должно быть пустым")
    private String name;

    @Column(name="height")
    @Min(value = 150, message="Рост должен быть хотя бы 150")
    @Max(value = 230, message="Рост не должен быть больше 230")
    private Integer height;

    @Column(name="jersey_number")
    @Min(value = 0, message="Номер должен быть хотя бы 0")
    @Max(value = 99, message="Номер не должен быть больше 99")
    private Integer jerseyNumber;

    @Column(name="type")
    @Enumerated(EnumType.ORDINAL)
    private Type type;

    @OnDelete(action=OnDeleteAction.SET_NULL)
    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "team_id")
    private Team team;

    public String play() {
        if (center != null) {
            return center.play();
        } else {
            return pointGuard.play();
        }
    }

    public String train() {
        if (center != null) {
            return center.train();
        } else {
            return pointGuard.train();
        }
    }

    public String printInfo() {
        if (center != null) {
            return String.format("Name: %s\nHeight: %d\nJersey number: %d\n", name, height, jerseyNumber) + center.printInfo();
        } else {
            return String.format("Name: %s\nHeight: %d\nJersey number: %d\n", name, height, jerseyNumber) + pointGuard.printInfo();
        }
    }
}
