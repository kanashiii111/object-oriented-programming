#pragma once
#include <iostream>
#include "Player.h"
class PointGuard : public Player {
private:
    int assistsPerGame;
    double threePointPercentage;
public:
    PointGuard(std::string name, int jerseyNumber, int height, int apg, double tpp) 
        : Player(name, height, jerseyNumber) {
        this->assistsPerGame = apg;
        this->threePointPercentage = tpp;
        std::cout << "Point guard " << name << " is created" << std::endl;
    };

    void dribble() {
        std::cout << getName() << " is dribbling." << std::endl;
    };
    void pass() {
        std::cout << getName() << " passes the ball." << std::endl;
    };
    void play() override {
        std::cout << getName() << " organizes the attack, passes and shoots the ball." << std::endl;
    }
    void train() override {
        std::cout << getName() << " is training his dribbling and pass." << std::endl;
    }
    void printInfo() override {
        std::cout << "Name: " << name << ", assist per game: " << assistsPerGame 
                  << ", three point percentage: " << threePointPercentage << "%" << std::endl;
    }
};