package org.oop.lab3.services;

import java.util.ArrayList;
import java.util.List;

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

    public List<Player> getPlayers() {
        Iterable<Player> players = playerRepository.findAll();
        List<Player> playersList= new ArrayList<>();
        players.forEach(playersList::add);
        return playersList.stream()
            .toList();
    }

    public Player getPlayerByID(Long id) {
        Player player = playerRepository.findById(id)
            .orElseThrow(() -> new RuntimeException("Player not found with id: " + id));
        return player;
    }

    public List<Player> getPlayersByTeamId(long teamId) {
        Team team = teamRepository.findById(teamId).
            orElseThrow(() -> new RuntimeException("Team not found with id: " + teamId));

        return team.getPlayers();
    }

    public Player savePlayer(Player new_player) {
        Team team = teamRepository.findById(new_player.getTeam().getId()).orElseThrow(() -> new RuntimeException("Team not found"));
        new_player.setTeam(team);

        if (new_player.getType() == Player.Type.pointGuard) {

            // КОНСТРУКТОРЫ СЮДА РАЗНЫЕ ДОБАВИТЬ НАДО И ЕЩЕ ЧТОБЫ РАБОТАЛО НЕ ТОЛЬКО ДЛЯ АПИ
            Float apg = new_player.getPointGuard().getAssistsPerGame();
            Float tpp = new_player.getPointGuard().getThreePointPercentage();

            if (apg == null || tpp == null) {
                throw new RuntimeException("PointGuard needs both apg and tpp");
            }

            PointGuard pg = new PointGuard(apg, tpp);

            new_player.setPointGuard(pg);
            new_player.getPointGuard().setPlayer(new_player);

        } else {

            Integer blocks = new_player.getCenter().getBlocks();
            Integer rebounds = new_player.getCenter().getRebounds();
            Float bpg = new_player.getCenter().getBlocksPerGame();
            Float rpg = new_player.getCenter().getReboundsPerGame();
            Center center = null;

            if (blocks != null && rebounds != null && bpg != null && rpg != null) {
                center = new Center(blocks, rebounds, bpg, rpg);
            } else if (blocks != null && bpg != null && rpg != null) {
                center = new Center(blocks, bpg, rpg);
            } else if (bpg != null && rpg != null) {
                center = new Center(bpg, rpg);
            } else {
                throw new RuntimeException("Center needs atleast bpg and rpg");
            }

            new_player.setCenter(center);
            new_player.getCenter().setPlayer(new_player);

        }
        return playerRepository.save(new_player);
    }

    public void deletePlayerByID(Long id) {
        playerRepository.deleteById(id);
    }

    public Player editPlayer(Player newPlayerData) {
        Player player = playerRepository.findById(newPlayerData.getId())
            .orElseThrow(() -> new RuntimeException("Player not found"));

        player.setName(newPlayerData.getName());
        player.setHeight(newPlayerData.getHeight());
        player.setJerseyNumber(newPlayerData.getJerseyNumber());

        Player.Type type = newPlayerData.getType();

        if (type == Player.Type.center) {
            // Center center = player.getCenter();
            // if (center == null) center = new Center();

            // center.setBlocks(newPlayerData.getCenter().getBlocks());
            // center.setRebounds(newPlayerData.getCenter().getRebounds());
            // center.setBlocksPerGame(newPlayerData.getCenter().getBlocksPerGame());
            // center.setReboundsPerGame(newPlayerData.getCenter().getReboundsPerGame());

            Integer blocks = newPlayerData.getCenter().getBlocks();
            Integer rebounds = newPlayerData.getCenter().getRebounds();
            Float bpg = newPlayerData.getCenter().getBlocksPerGame();
            Float rpg = newPlayerData.getCenter().getReboundsPerGame();
            Center center = null;

            if (blocks != null && rebounds != null && bpg != null && rpg != null) {
                center = new Center(blocks, rebounds, bpg, rpg);
            } else if (blocks != null && bpg != null && rpg != null) {
                center = new Center(blocks, bpg, rpg);
            } else if (bpg != null && rpg != null) {
                center = new Center(bpg, rpg);
            } else {
                throw new RuntimeException("Center needs atleast bpg and rpg");
            }

            center.setPlayer(player);
            player.setCenter(center);
            player.setPointGuard(null);
        } else if (type == Player.Type.pointGuard) {
            PointGuard pg = player.getPointGuard();
            if (pg == null) pg = new PointGuard();

            pg.setAssistsPerGame(newPlayerData.getPointGuard().getAssistsPerGame());
            pg.setThreePointPercentage(newPlayerData.getPointGuard().getThreePointPercentage());
            pg.setPlayer(player);
            player.setPointGuard(pg);
            player.setCenter(null);
        }

        player.setType(type);

        Team team = teamRepository.findById(newPlayerData.getTeam().getId()).orElse(null);
        player.setTeam(team);

        return playerRepository.save(player);
    }
}
