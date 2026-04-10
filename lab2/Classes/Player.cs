using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab2.Classes
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int JerseyNumber { get; set; }

        public string Type { get; set; }

        public virtual PointGuard? PointGuard { get; set; }
        public virtual Center? Center { get; set; }

        public Player(int ID, string name, int height, int jerseyNumber, string type)
        {
            this.ID = ID;
            Name = name;
            Height = height;
            JerseyNumber = jerseyNumber;
            Type = type;
        }

        public int getID() { return ID; }
        public void setID(int newID) { ID = newID; }
        public string getName() { return Name; }
        public void setName(string newName) { Name = newName; }
        public int getHeight() { return Height; }
        public void setHeight(int newHeight) { Height = newHeight; }
        public int getJerseyNumber() { return JerseyNumber; }
        public void setJerseyNumber(int newJerseyNumber) { JerseyNumber = newJerseyNumber; }

        public virtual void play()
        {
            Console.WriteLine($"{Name} enters the court.");
        }
        public virtual void train()
        {
            Console.WriteLine($"{Name} is training.");
        }
        public virtual void printInfo()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Height : {Height}");
            Console.WriteLine($"Jersey number : {JerseyNumber}");
        }
    }
}
