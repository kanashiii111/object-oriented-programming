package org.oop.lab3.services;

import java.util.ArrayList;
import java.util.List;

import org.oop.lab3.dto.TeamDTO;
import org.oop.lab3.dto.TeamMapper;
import org.oop.lab3.entities.Team;
import org.oop.lab3.repositories.TeamRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TeamService {
    @Autowired
    private TeamRepository teamRepository;
    @Autowired
    private TeamMapper teamMapper;

    public List<TeamDTO> getTeams() {
        Iterable<Team> teams = teamRepository.findAll();
        List<Team> teamsList= new ArrayList<>();
        teams.forEach(teamsList::add);
        return teamsList.stream()
            .map(teamMapper::toDTO)
            .toList();
    }

    public TeamDTO getTeamByID(Long id) {
        Team team = teamRepository.findById(id)
            .orElseThrow(() -> new RuntimeException("Team not found with id: " + id));
        return teamMapper.toDTO(team);
    }

    public TeamDTO saveTeam(TeamDTO dto) {
        Team team = teamMapper.toEntity(dto);
        return teamMapper.toDTO(teamRepository.save(team));
    }

    public void deleteTeamById(Long id) {
        teamRepository.deleteById(id);
    }

    public TeamDTO updateTeam(TeamDTO dto) {
        Team team = teamMapper.toEntity(dto);
        return teamMapper.toDTO(teamRepository.save(team));
    }
}
