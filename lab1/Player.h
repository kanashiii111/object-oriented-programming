#pragma once
#include <string>
class Player {
public:
    std::string name;
    int height;
    int jerseyNumber;

    Player(std::string name, int height, int jerseyNumber) 
        : name(name), height(height), jerseyNumber(jerseyNumber) {}

    std::string getName() { return name; };
    int getHeight() { return height; };
    int getJerseyNumber() { return jerseyNumber; };

    virtual void play() {
        std::cout << name << " enters the court." << std::endl;
    };
    virtual void train() {
        std::cout << name << " is training." << std::endl;
    };
    virtual void printInfo() {
        std::cout << "Name: " << name << ", Height: " << height << ", Jersey number: " << jerseyNumber << std::endl;
    };   
};