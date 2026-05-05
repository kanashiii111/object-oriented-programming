package org.oop.lab3.entities;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

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

@Entity
@Table(
    name="players",
    uniqueConstraints = @UniqueConstraint(columnNames = {"name"})
)
public class Player implements Playable {

    public Player() {}

    public Player(String name, int height, int jersey_number, Type type) {
        this.name = name;
        this.height = height;
        this.jersey_number = jersey_number;
        this.type = type;
    }

    public enum Type {
        point_guard,
        center
    }

    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name="id")
    private Long id;

    @OneToOne(mappedBy="player", cascade=CascadeType.ALL, optional=true, orphanRemoval=true)
    private Center center;

    @OneToOne(mappedBy="player", cascade=CascadeType.ALL, optional=true, orphanRemoval=true)
    private PointGuard point_guard;

    @Column(name="name")
    private String name;

    @Column(name="height")
    private Integer height;

    @Column(name="jersey_number")
    private Integer jersey_number;

    @Column(name="type")
    @Enumerated(EnumType.ORDINAL)
    private Type type;

    @OnDelete(action=OnDeleteAction.SET_NULL)
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "team_id")
    private Team team;

    @Override
    public String play() {
        if (type == Type.center && center != null) {
            return center.play();
        } else if (type == Type.point_guard && point_guard != null) {
            return point_guard.play();
        }
        return String.format("%s enters the court.", name);
    }
    @Override
    public String train() {
        if (type == Type.center && center != null) {
            return center.train();
        } else if (type == Type.point_guard && point_guard != null) {
            return point_guard.train();
        }
        return String.format("%s is training", name);
    }
    public String getBasicInfo() {
        return String.format("Name: %s\nHeight: %d\nJersey number: %d\n", name, height, jersey_number);
    }
    @Override
    public String printInfo() {
        if (type == Type.center && center != null) {
            return center.printInfo();
        } else if (type == Type.point_guard && point_guard != null) {
            return point_guard.printInfo();
        }
        return String.format("Name: %s\nHeight: %d\nJersey number: %d", name, height, jersey_number);
    }

    public Long getId() { return id; }
    public Center getCenter() { return center; }
    public PointGuard getPointGuard() { return point_guard; }
    public String getName() { return name; }
    public Integer getHeight() { return height; }
    public Integer getJerseyNumber() { return jersey_number; }
    public Type getType() { return type; }
    public Team getTeam() { return team; }

    public void setId( Long id ) { this.id = id; }
    public void setCenter( Center center ) { this.center = center; }
    public void setPointGuard( PointGuard point_guard ) { this.point_guard = point_guard; }
    public void setName( String name ) { this.name = name; }
    public void setHeight( Integer height ) { this.height = height; }
    public void setJerseyNumber( Integer jersey_number ) { this.jersey_number = jersey_number; }
    public void setType( Type type ) { this.type = type; }
    public void setTeam( Team team ) { this.team = team; }
}
