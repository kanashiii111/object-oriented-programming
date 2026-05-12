package org.oop.lab3.entities;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import jakarta.persistence.UniqueConstraint;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.NotNull;
import lombok.Data;

@Entity
@Data
@Table(
    name="teams",
    uniqueConstraints = @UniqueConstraint(columnNames = {"name"})
)
public class Team{

    public Team() {}

    public Team(String name, String city) {
        this.name = name;
        this.city = city;
    }

    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name="id")
    private Long id;

    @Column(name="name")
    @NotNull(message="Название не должно быть пустым")
    @NotBlank(message="Название не должно быть пустым")
    @NotEmpty(message="Название не должно быть пустым")
    private String name;

    @Column(name="city")
    private String city;

    @OneToMany(mappedBy = "team", cascade = {CascadeType.PERSIST, CascadeType.MERGE}, fetch = FetchType.LAZY)
    @JsonIgnore
    private List<Player> players;
}
