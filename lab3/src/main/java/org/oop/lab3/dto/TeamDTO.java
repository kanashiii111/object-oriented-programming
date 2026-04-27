package org.oop.lab3.dto;

import com.fasterxml.jackson.annotation.JsonPropertyOrder;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.NotNull;
import lombok.Data;

@Data
@JsonPropertyOrder({
    "id",
    "name",
    "city"
})
public class TeamDTO {
    private Long id;
    @NotNull(message="Team must not be null")
    @NotBlank(message="Team must not be blank")
    @NotEmpty(message="Team must not be empty")
    private String name;
    @NotNull(message="City must not be null")
    @NotBlank(message="City must not be blank")
    @NotEmpty(message="City must not be empty")
    private String city;

    public Long getId() { return id; }
    public void setId(Long id) { this.id = id; }

    public String getName() { return name; }
    public void setName(String name) { this.name = name; }

    public String getCity() { return city; }
    public void setCity(String city) { this.city = city; } 
}
