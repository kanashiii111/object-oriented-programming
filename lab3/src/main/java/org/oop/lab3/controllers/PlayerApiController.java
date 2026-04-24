package org.oop.lab3.controllers;

import java.util.List;

import org.oop.lab3.dto.PlayerDTO;
import org.oop.lab3.services.PlayerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/players")
public class PlayerApiController {
    @Autowired
    private PlayerService playerService;

    @GetMapping
    public List<PlayerDTO> getPlayers() {
        return playerService.getPlayers();
    }
    @PostMapping
    public PlayerDTO savePlayer(@RequestBody PlayerDTO playerDTO) {
        return playerService.savePlayer(playerDTO);
    }
    @DeleteMapping
    public void deletePlayer(@RequestBody PlayerDTO playerDTO) {
        playerService.deletePlayerByID(playerDTO);
    }
    @PutMapping
    public PlayerDTO updatePlayer(@RequestBody PlayerDTO playerDTO) {
        return playerService.editPlayerByID(playerDTO);
    }
}
