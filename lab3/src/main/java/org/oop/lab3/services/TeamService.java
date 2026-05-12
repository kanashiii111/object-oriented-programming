package org.oop.lab3.services;

import java.util.ArrayList;
import java.util.List;

import org.oop.lab3.entities.Team;
import org.oop.lab3.repositories.TeamRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TeamService {
    @Autowired
    private TeamRepository teamRepository;

    public List<Team> getTeams() {
        Iterable<Team> teams = teamRepository.findAll();
        List<Team> teamsList = new ArrayList<>();
        teams.forEach(teamsList::add);
        return teamsList.stream()
            .toList();
    }

    public Team getTeamByID(Long id) {
        Team team = teamRepository.findById(id)
            .orElseThrow(() -> new RuntimeException("Team not found with id: " + id));
        return team;
    }

    public Team saveTeam(Team team) {
        return teamRepository.save(team);
    }

    public void deleteTeamById(Long id) {
        teamRepository.deleteById(id);
    }

    public Team updateTeam(Team team) {
        return teamRepository.save(team);
    }
}
