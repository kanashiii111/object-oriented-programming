package org.oop.lab3.repositories;

import org.oop.lab3.entities.Team;
import org.springframework.data.repository.CrudRepository;

public interface TeamRepository extends CrudRepository<Team, Long>{}
