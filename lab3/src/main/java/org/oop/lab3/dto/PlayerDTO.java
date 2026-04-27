package org.oop.lab3.dto;

import com.fasterxml.jackson.annotation.JsonPropertyOrder;

import jakarta.validation.constraints.Max;
import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.NotNull;
import lombok.Data;

@Data
@JsonPropertyOrder({
    "id",
    "name",
    "height",
    "jerseyNumber",
    "type",
    "teamId",
    "center",
    "point_guard"
})
public class PlayerDTO {
    private Long id;
    @NotNull(message="Name must not be null")
    @NotBlank(message="Name must not be blank")
    @NotEmpty(message="Name must not be empty")
    private String name;
    @Min(value = 150, message="Height must atleast be 150")
    @Max(value = 230, message="Height must be lower than or equal to 230")
    private int height;
    @Min(value = 0, message="Jersey number must atleast be 0")
    @Max(value = 99, message="Jersey number must be lower or equal to 99")
    private int jerseyNumber;
    private String type;
    private Long teamId;

    private CenterDTO center;
    private PointGuardDTO pointGuard;

    public Long getId() { return id; }
    public void setId(Long id) { this.id = id; }

    public String getName() { return name; }
    public void setName(String name) { this.name = name; }

    public int getHeight() { return height; }
    public void setHeight(int height) { this.height = height; }

    public int getJerseyNumber() { return jerseyNumber; }
    public void setJerseyNumber(int jerseyNumber) { this.jerseyNumber = jerseyNumber; }

    public String getType() { return type; }
    public void setType(String type) { this.type = type; }

    public Long getTeamId() { return teamId; }
    public void setTeamId(Long teamId) { this.teamId = teamId; }

    public CenterDTO getCenter() { return center; }
    public void setCenter(CenterDTO center) { this.center = center; }

    public PointGuardDTO getPointGuard() { return pointGuard; }
    public void setPointGuard(PointGuardDTO pointGuard) { this.pointGuard = pointGuard; }
}
