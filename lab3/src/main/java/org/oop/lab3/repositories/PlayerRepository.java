package org.oop.lab3.repositories;

import java.util.List;

import org.oop.lab3.entities.Player;
import org.springframework.data.repository.CrudRepository;

public interface PlayerRepository extends CrudRepository<Player, Long>{
    List<Player> findByTeamId(Long teamId);
}
