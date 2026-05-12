package org.oop.lab3.controllers;

import java.util.List;

import org.oop.lab3.entities.Player;
import org.oop.lab3.repositories.PlayerRepository;
import org.oop.lab3.services.PlayerService;
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
@RequestMapping("/api/players")
public class PlayerApiController {
    @Autowired
    private PlayerService playerService;

    @Autowired
    private PlayerRepository playerRepository;

    @GetMapping
    public List<Player> getPlayers() {
        return playerService.getPlayers();
    }
    @Transactional
    @PostMapping
    public ResponseEntity<?> savePlayer(@Valid @RequestBody Player player) {
        Player saved = playerService.savePlayer(player);
        return ResponseEntity.ok(saved);
    }
    @Transactional
    @DeleteMapping("/{id}")
    public ResponseEntity<?> deletePlayer(@PathVariable Long id) {
        playerService.deletePlayerByID(id);
        return ResponseEntity.ok().build();
    }
    @Transactional
    @PutMapping
    public ResponseEntity<?> updatePlayer(@Valid @RequestBody Player player) {
        Player updated = playerService.editPlayer(player);
        return ResponseEntity.ok(updated);
    }
    @Transactional
    @GetMapping("/{id}/methods/{methodName}")
    public String callPlayerMethod(@PathVariable Long id, @PathVariable String methodName) {
        Player player = playerRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Player not found"));

        return switch (methodName) {
            case "play" -> player.play();
            case "train" -> player.train();
            case "printInfo" -> player.printInfo();
            case "block" -> player.getCenter().block();
            case "rebound" -> player.getCenter().rebound();
            case "setScreen" -> player.getCenter().setScreen();
            case "post" -> player.getCenter().post();
            case "dribble" -> player.getPointGuard().dribble();
            case "pass" -> player.getPointGuard().pass();
            default -> "Неизвестная команда";
        };
    }
}
