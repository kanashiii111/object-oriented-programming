package org.oop.lab3.services;

import java.util.ArrayList;
import java.util.List;

import org.oop.lab3.dto.PlayerDTO;
import org.oop.lab3.dto.PlayerMapper;
import org.oop.lab3.entities.Center;
import org.oop.lab3.entities.Player;
import org.oop.lab3.entities.PointGuard;
import org.oop.lab3.entities.Team;
import org.oop.lab3.repositories.PlayerRepository;
import org.oop.lab3.repositories.TeamRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class PlayerService {
    @Autowired
    private PlayerRepository playerRepository;
    @Autowired
    private TeamRepository teamRepository;
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

    public PlayerDTO getPlayerByID(Long id) {
        Player player = playerRepository.findById(id)
            .orElseThrow(() -> new RuntimeException("Player not found with id: " + id));
        return playerMapper.toDTO(player);
    }

    public PlayerDTO savePlayer(PlayerDTO dto) {
        Player player = playerMapper.toEntity(dto);
    
        if (dto.getTeamId() != null) {
            Team team = teamRepository.findById(dto.getTeamId()).orElseThrow(() -> new RuntimeException("Team not found"));
            player.setTeam(team);
        }
        
        if (player.getType() == Player.Type.point_guard) {
            player.setPointGuard( new PointGuard(0.0f, 0.0f));
            player.getPointGuard().setPlayer(player);
        } else {
            player.setCenter( new Center(0, 0, 0.0f, 0.0f));
            player.getCenter().setPlayer(player);
        }
        return playerMapper.toDTO(playerRepository.save(player));
    }

    public void deletePlayer(PlayerDTO dto) {
        Player player = playerMapper.toEntity(dto);
        playerRepository.deleteById(player.getId());
    }

    public void deletePlayerByID(Long id) {
        playerRepository.deleteById(id);
    }

    public PlayerDTO editPlayer(PlayerDTO dto) {
        Player player = playerRepository.findById(dto.getId())
            .orElseThrow(() -> new RuntimeException("Player not found"));
        
        player.setName(dto.getName());
        player.setHeight(dto.getHeight());
        player.setJerseyNumber(dto.getJerseyNumber());
        
        String type = dto.getType();
        Player.Type trueType = (type.equals("center")) ? Player.Type.center : Player.Type.point_guard;
        player.setType(trueType);

        if (player.getType() == Player.Type.center && dto.getCenter() != null) {
            Center center = player.getCenter();
            if (center == null) center = new Center();
            
            center.setBlocks(dto.getCenter().getBlocks());
            center.setRebounds(dto.getCenter().getRebounds());
            center.setBlocksPerGame(dto.getCenter().getBlocksPerGame());
            center.setReboundsPerGame(dto.getCenter().getReboundsPerGame());
            center.setPlayer(player);
            player.setCenter(center);
        } 
        else if (player.getType() == Player.Type.point_guard && dto.getPointGuard() != null) {
            PointGuard pg = player.getPointGuard();
            if (pg == null) pg = new PointGuard();
            
            pg.setAssistsPerGame(dto.getPointGuard().getAssistsPerGame());
            pg.setThreePointPercentage(dto.getPointGuard().getThreePointPercentage());
            pg.setPlayer(player);
            player.setPointGuard(pg);
        }

        if (dto.getTeamId() != null) {
            Team team = teamRepository.findById(dto.getTeamId()).orElse(null);
            player.setTeam(team);
        } else {
            player.setTeam(null);
        }
        
        return playerMapper.toDTO(playerRepository.save(player));
    }
}
