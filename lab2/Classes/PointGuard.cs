using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Classes
{
    public class PointGuard : Player
    {
        public int playerID { get; set; } 
        public virtual Player player {  get; set; }
        public double assistsPerGame { get; set; }
        public double threePointPercentage { get; set; }

        public double getAssistsPerGame() { return assistsPerGame; }
        public double getThreePointPercentage() { return threePointPercentage; }
        public PointGuard(int id, string name, int height, int jerseyNumber, Type type, double apg, double tpp) : base(id, name, height, jerseyNumber, type)
        {
            assistsPerGame = apg;
            threePointPercentage = tpp;
        }
        public string dribble() 
        {
            return $"{Name} is dribbling the ball.";
        }
        public string pass()
        {
            return $"{Name} is passing the ball to a teammate.";
        }
        public override string play()
        {
            return $"{Name} is orchestrating the offense, making plays and hitting three-pointers.";
        }
        public override string train()
        {
            return $"{Name} is training on ball handling, passing and shooting three-pointers.";
        }
        public override string printInfo()
        {
            return base.printInfo() + $"\nAssists per game : {assistsPerGame}" + $"\nThree-point percentage : {threePointPercentage}%";
        }
    }
}
