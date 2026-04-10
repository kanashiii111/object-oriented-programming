using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Classes
{
    public class Center : Player
    {
        public int playerID { get; set; }
        public virtual Player player { get; set; }
        public double blocksPerGame { get; set; }
        public double reboundsPerGame { get; set; }
        public int blocks { get; set; } = 0;
        public int rebounds { get; set; } = 0;
        public Center(int id, string name, int height, int jerseyNumber, string type, double bpg, double rpg) : base(id, name, height, jerseyNumber, type)
        {
            blocksPerGame = bpg;
            reboundsPerGame = rpg;
            Console.WriteLine("Center is created");
        }

        public Center(int id, string name, int height, int jerseyNumber, string type, int blocks, int rebounds, double bpg, double rpg) : base(id, name, height, jerseyNumber, type) 
        {
            blocksPerGame = bpg;
            reboundsPerGame = rpg;
            this.blocks = blocks;
            Console.WriteLine("Center is created with blocks");
        }

        public void block() 
        {
            blocks++;
            Console.WriteLine($"blocks: {blocks}");
        }
        public void rebound() 
        {
            rebounds++;
            Console.WriteLine($"rebounds: {rebounds}");
        }

        public void setScreen() 
        {
            Console.WriteLine($"{Name} sets a screen for a teammate.");
        }

        public void post() 
        {
            Console.WriteLine($"{Name} is posting up in the paint.");
        }
        public override void play()
        {
            Console.WriteLine($"{Name} dominates the post, blocks and dunks the ball.");
        }
        public override void train()
        {
            Console.WriteLine($"{Name} is training playing close to basket, rebounding and blocking shots.");
        }
        public override void printInfo()
        {
            base.printInfo();
            Console.WriteLine($"Blocks per game : {blocksPerGame}");
            Console.WriteLine($"Rebounds per game : {reboundsPerGame}");
        }
    }
}
