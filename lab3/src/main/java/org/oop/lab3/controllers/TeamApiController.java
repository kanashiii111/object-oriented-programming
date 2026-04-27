package org.oop.lab3.controllers;

import java.util.List;

import org.oop.lab3.dto.TeamDTO;
import org.oop.lab3.services.TeamService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import jakarta.validation.Valid;

@RestController
@RequestMapping("/api/teams")
public class TeamApiController {
    @Autowired
    private TeamService teamService;

    @GetMapping
    public List<TeamDTO> getTeams() {
        return teamService.getTeams();
    }
    @Transactional
    @PostMapping
    public ResponseEntity<?> saveTeam(@Valid @RequestBody TeamDTO dto) {
        TeamDTO saved = teamService.saveTeam(dto);
        return ResponseEntity.ok(saved);
    }
    @Transactional
    @DeleteMapping("/{id}")
    public ResponseEntity<?> deleteTeam(@PathVariable Long id) {
        teamService.deleteTeamById(id);
        return ResponseEntity.ok().build();

    }
    @Transactional
    @PutMapping
    public ResponseEntity<?> updateTeam(@Valid @RequestBody TeamDTO dto) {
        TeamDTO updated = teamService.updateTeam(dto);
        return ResponseEntity.ok(updated);
    }
}
