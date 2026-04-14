using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public enum Type
{
    PointGuard,
    Center
}

namespace lab2.Classes
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int JerseyNumber { get; set; }
        public Type Type { get; set; }
        public virtual PointGuard? PointGuard { get; set; }
        public virtual Center? Center { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Player))
            {
                return false;
            }
            return (Name == ((Player)obj).Name
                && (Height == ((Player)obj).Height
                && (JerseyNumber == ((Player)obj).JerseyNumber
                && (Type == ((Player)obj).Type
                ))));
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Height.GetHashCode() ^ JerseyNumber.GetHashCode() ^ Type.GetHashCode();
        }

        public Player(int ID, string name, int height, int jerseyNumber, Type type)
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

        public Type getType() { return Type; }
        public void setType(Type newType) { Type = newType; }

        public PointGuard? getPointGuard() { return PointGuard; }
        public void setPointGuard(PointGuard newPointGuard) { PointGuard = newPointGuard; }

        public Center? getCenter() { return Center; }
        public void setCenter(Center newCenter) { Center = newCenter; }

        public virtual string play()
        {
            return $"{Name} enters the court.";
        }
        public virtual string train()
        {
            return $"{Name} is training.";
        }
        public virtual string printInfo()
        {
            return $"Name : {Name}" + $"\nHeight : {Height}" + $"\nJersey number : {JerseyNumber}";
        }
    }
}
