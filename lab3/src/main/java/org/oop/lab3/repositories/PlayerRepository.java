package org.oop.lab3.repositories;

import org.oop.lab3.entities.Player;
import org.springframework.data.repository.CrudRepository;

public interface PlayerRepository extends CrudRepository<Player, Long>{}
