package org.oop.lab3.dto;

import com.fasterxml.jackson.annotation.JsonPropertyOrder;

import jakarta.validation.Valid;
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
    @NotNull(message="Имя не должно быть пустым")
    @NotBlank(message="Имя не должно быть пустым")
    @NotEmpty(message="Имя не должно быть пустым")
    private String name;
    @Min(value = 150, message="Рост должен быть хотя бы 150")
    @Max(value = 230, message="Рост не должен быть больше 230")
    private int height;
    @Min(value = 0, message="Номер должен быть хотя бы 0")
    @Max(value = 99, message="Номер не должен быть больше 99")
    private int jerseyNumber;
    private String type;
    private Long teamId;

    @Valid
    private CenterDTO center;
    @Valid
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
