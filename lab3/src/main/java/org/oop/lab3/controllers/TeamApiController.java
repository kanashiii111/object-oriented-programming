package org.oop.lab3.controllers;

import java.util.List;

import org.oop.lab3.entities.*;
import org.oop.lab3.services.*;
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
    @Autowired
    private PlayerService playerService;

    @GetMapping
    public List<Team> getTeams() {
        return teamService.getTeams();
    }
    @GetMapping("/{id}/players")
    public List<Player> getTeamPlayers(@PathVariable Long id) {
        return playerService.getPlayersByTeamId(id);
    }
    @Transactional
    @PostMapping
    public ResponseEntity<?> saveTeam(@Valid @RequestBody Team team) {
        Team saved = teamService.saveTeam(team);
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
    public ResponseEntity<?> updateTeam(@Valid @RequestBody Team team) {
        Team updated = teamService.updateTeam(team);
        return ResponseEntity.ok(updated);
    }
}
