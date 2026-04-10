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

        public int getBlocks() { return blocks; }
        public int getRebounds() { return rebounds; }
        public double getBlocksPerGame() { return blocksPerGame; }
        public double getReboundsPerGame() { return reboundsPerGame; }
        public Center(int id, string name, int height, int jerseyNumber, Type type, double bpg, double rpg) : base(id, name, height, jerseyNumber, type)
        {
            blocksPerGame = bpg;
            reboundsPerGame = rpg;
        }

        public Center(int id, string name, int height, int jerseyNumber, Type type, int blocks, int rebounds, double bpg, double rpg) : base(id, name, height, jerseyNumber, type) 
        {
            blocksPerGame = bpg;
            reboundsPerGame = rpg;
            this.blocks = blocks;
        }

        public string block() 
        {
            blocks++;
            return $"blocks: {blocks}";
        }
        public string rebound() 
        {
            rebounds++;
            return $"rebounds: {rebounds}";
        }

        public string setScreen() 
        {
            return $"{Name} sets a screen for a teammate.";
        }

        public string post() 
        {
            return $"{Name} is posting up in the paint.";
        }
        public override string play()
        {
            return $"{Name} dominates the post, blocks and dunks the ball.";
        }
        public override string train()
        {
            return $"{Name} is training playing close to basket, rebounding and blocking shots.";
        }
        public override string printInfo()
        {
            return base.printInfo() + $"\nBlocks: {blocks}" + $"\nRebounds : {rebounds}" +  $"\nBlocks per game : {blocksPerGame}" + $"\nRebounds per game : {reboundsPerGame}";
        }
    }
}
