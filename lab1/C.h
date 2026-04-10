#include "Player.h"
class Center : public Player {
private:
    double blocksPerGame;
    int blocks = 0;
    int rebounds = 0;
    double reboundsPerGame;
public:
    Center(std::string name, int jerseyNumber, int height, double bpg, double rpg) 
        : Player(name, height, jerseyNumber) {
        this->blocksPerGame = bpg;
        this->reboundsPerGame = rpg;
        std::cout << "Center " << name << " is created." << std::endl;
    };

    Center(std::string name, int jerseyNumber, int height, double bpg, double rpg, int blocks) 
        : Player(name, height, jerseyNumber) {
        this->blocksPerGame = bpg;
        this->reboundsPerGame = rpg;
        this->blocks = blocks;
        std::cout << "Center " << name << " is created." << std::endl;
    };

    void block() {
        blocks++;
        std::cout << "blocks: " << blocks << std::endl;
    }
    
    void rebound() {
        rebounds++;
        std::cout << rebounds << std::endl;
    }

    void setScreen() {
        std::cout << getName() << " sets the screen." << std::endl;
    };
    void post() {
        std::cout << getName() << " plays in post." << std::endl;
    };
    void play() override {
        std::cout << getName() << " dominates the post, blocks and dunks the ball." << std::endl;
    };
    void train() override {
        std::cout << getName() << " is training playing close to basket, rebounding and blocking shots." << std::endl;
    }
    void printInfo() override {
        std::cout << "Name: " << name << ", blocks per game: " << blocksPerGame << ", rebounds per game: " << reboundsPerGame << std::endl;
    }
};