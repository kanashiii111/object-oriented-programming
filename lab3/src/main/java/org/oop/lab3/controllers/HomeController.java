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
import org.springframework.web.bind.annotation.PathVariable;

@Controller
public class HomeController {
    @Autowired
    private PlayerService playerService;
    @Autowired
    private TeamService teamService;
    
    @GetMapping("/home")
    public String homePage(Model model) {
        List<PlayerDTO> players = playerService.getPlayers();
        List<TeamDTO> teams = teamService.getTeams();
        model.addAttribute("players", players);
        model.addAttribute("teams", teams);
        return "home_page";
    }

    @GetMapping("/create/player")
    public String createPlayerPage(Model model) {
        List<TeamDTO> teams = teamService.getTeams();
        model.addAttribute("teams", teams);
        return "create_player_page";
    }

    @GetMapping("/edit/player/{id}")
    public String editPlayerPage(@PathVariable Long id, Model model) {
        PlayerDTO player = playerService.getPlayerByID(id);
        List<TeamDTO> teams = teamService.getTeams();
        model.addAttribute("player", player);
        model.addAttribute("teams", teams);
        return "edit_player_page";
    }

    @GetMapping("/methods/player/{id}")
    public String playerMethodsPage(@PathVariable Long id, Model model) {
        PlayerDTO player = playerService.getPlayerByID(id);
        model.addAttribute("player", player);
        return "player_methods_page";
    }

    // --------- team ----------

    @GetMapping("/create/team")
    public String createTeamPage() {
        return "create_team_page";
    }

    @GetMapping("/edit/team/{id}")
    public String editTeamPage(@PathVariable Long id, Model model) {
        TeamDTO team = teamService.getTeamByID(id);
        model.addAttribute("team", team);
        return "edit_team_page";
    }
}
