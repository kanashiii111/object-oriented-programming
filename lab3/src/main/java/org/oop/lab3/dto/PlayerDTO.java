package org.oop.lab3.dto;

import com.fasterxml.jackson.annotation.JsonPropertyOrder;

import lombok.Data;

@Data
@JsonPropertyOrder({
    "id",
    "name",
    "height",
    "jerseyNumber",
    "type",
    "center",
    "point_guard"
})
public class PlayerDTO {
    public Long id;
    public String name;
    public int height;
    public int jerseyNumber;
    public String type;

    public CenterDTO center;
    public PointGuardDTO pointGuard;
}
