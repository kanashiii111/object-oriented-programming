#include <iostream>
#include "Player.h"
#include "PG.h"
#include "C.h"


int main() {
    Center* center = new Center("shaq", 24, 210, 2.3, 78, 5);
    PointGuard* pg = new PointGuard("ja", 12, 190, 2, 2);
    

    std::cout << "\nC\n" << std::endl;

    center->play();
    center->train();
    center->printInfo();
    center->post();
    center->setScreen();

    std::cout << "\nPG\n" << std::endl;

    pg->play();
    pg->train();
    pg->printInfo();
    pg->dribble();
    pg->pass();

    center->block();
    center->block();

    Player* players[3] = {center, pg, new Center("center", 55, 199, 112, 122, 200000)};
    static_cast<Center*>(players[0])->block();


    delete center;
    delete pg;
}