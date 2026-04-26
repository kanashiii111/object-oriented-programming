package org.oop.lab3.controllers;

import java.util.List;

import org.oop.lab3.dto.PlayerDTO;
import org.oop.lab3.dto.TeamDTO;
import org.oop.lab3.services.PlayerService;
import org.oop.lab3.services.TeamService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/home")
public class HomeController {
    @Autowired
    private PlayerService playerService;
    @Autowired
    private TeamService teamService;
    
    @GetMapping
    public String homePage(Model uiModel) {
        List<PlayerDTO> players = playerService.getPlayers();
        List<TeamDTO> teams = teamService.getTeams();
        uiModel.addAttribute("players", players);
        uiModel.addAttribute("teams", teams);
        return "home_page";
    }

    @GetMapping("/create/player")
    public String createPlayerPage(Model uiModel) {
        List<TeamDTO> teams = teamService.getTeams();
        uiModel.addAttribute("player", new PlayerDTO());
        uiModel.addAttribute("teams", teams);
        return "create_player_page";
    }

    @PostMapping("/create/player")
    public String createPlayerSubmit(@ModelAttribute("player") PlayerDTO playerDTO) {
        playerService.savePlayer(playerDTO);
        return "redirect:/home";
    }

    @PostMapping("/delete/player/{id}")
    public String deletePlayerSubmit(@PathVariable Long id) {
        playerService.deletePlayerByID(id);
        return "redirect:/home";
    }

    // --------- team ----------

    @GetMapping("/create/team")
    public String createTeamPage(Model uiModel) {
        uiModel.addAttribute("team", new TeamDTO());
        return "create_team_page";
    }

    @PostMapping("/create/team")
    public String createTeamSubmit(@ModelAttribute("team") TeamDTO teamDTO) {
        teamService.saveTeam(teamDTO);
        return "redirect:/home";
    }

    @PostMapping("/delete/team/{id}")
    public String deleteTeamSubmit(@PathVariable Long id) {
        teamService.deleteTeamById(id);
        return "redirect:/home";
    }
}
