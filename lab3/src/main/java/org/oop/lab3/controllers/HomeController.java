package org.oop.lab3.controllers;

import java.util.List;

import org.oop.lab3.dto.PlayerDTO;
import org.oop.lab3.services.PlayerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/home")
public class HomeController {
    @Autowired
    private PlayerService playerService;
    
    @GetMapping
    public String homePage(Model uiModel) {
        List<PlayerDTO> players = playerService.getPlayers();
        uiModel.addAttribute("players", players);
        return "home";
    }
}
