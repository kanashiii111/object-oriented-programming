package org.oop.lab3.services;

import java.util.ArrayList;
import java.util.List;

import org.oop.lab3.dto.PlayerDTO;
import org.oop.lab3.dto.PlayerMapper;
import org.oop.lab3.entities.Center;
import org.oop.lab3.entities.Player;
import org.oop.lab3.entities.PointGuard;
import org.oop.lab3.repositories.PlayerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class PlayerService {
    @Autowired
    private PlayerRepository playerRepository;
    @Autowired
    private PlayerMapper playerMapper;

    public List<PlayerDTO> getPlayers() {
        Iterable<Player> players = playerRepository.findAll();
        List<Player> playersList= new ArrayList<>();
        players.forEach(playersList::add);
        return playersList.stream()
            .map(playerMapper::toDTO)
            .toList();
    }

    public PlayerDTO savePlayer(PlayerDTO dto) {
        Player player = playerMapper.toEntity(dto);
        
        if (player.getType() == Player.Type.point_guard) {
            player.setPointGuard( new PointGuard(0.0f, 0.0f));
            player.getPointGuard().setPlayer(player);
        } else {
            player.setCenter( new Center(0, 0, 0.0f, 0.0f));
            player.getCenter().setPlayer(player);
        }
        return playerMapper.toDTO(playerRepository.save(player));
    }

    public void deletePlayerByID(PlayerDTO dto) {
        Player player = playerMapper.toEntity(dto);
        playerRepository.deleteById(player.getId());
    }

    public PlayerDTO editPlayerByID(PlayerDTO dto) {
        Player player = playerMapper.toEntity(dto);
        return playerMapper.toDTO(playerRepository.save(player));
    }
}
