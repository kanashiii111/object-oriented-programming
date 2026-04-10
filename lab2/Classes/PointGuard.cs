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
        public PointGuard(int id, string name, int height, int jerseyNumber, string type, double apg, double tpp) : base(id, name, height, jerseyNumber, type)
        {
            assistsPerGame = apg;
            threePointPercentage = tpp;
            Console.WriteLine("Point Guard is created");
        }
        public void dribble() 
        {
            Console.WriteLine($"{Name} is dribbling the ball.");
        }
        public void pass()
        {
            Console.WriteLine($"{Name} is passing the ball to a teammate.");
        }
        public override void play()
        {
            Console.WriteLine($"{Name} is orchestrating the offense, making plays and hitting three-pointers.");
        }
        public override void train()
        {
            Console.WriteLine($"{Name} is training on ball handling, passing and shooting three-pointers.");
        }
        public override void printInfo()
        {
            base.printInfo();
            Console.WriteLine($"Assists per game : {assistsPerGame}");
            Console.WriteLine($"Three-point percentage : {threePointPercentage}%");
        }
    }
}
