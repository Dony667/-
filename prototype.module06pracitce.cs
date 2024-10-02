using DesignPatterns.Module06.Prototype;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Module06.Prototype
{
    public interface IDeepCloneable<T>
    {
        T DeepClone();
    }
}
public class Weapon : IDeepCloneable<Weapon>
{
    public string Name { get; set; }
    public int Damage { get; set; }


    public Weapon(string Name, int Damage)
    {
        this.Name = Name;
        this.damage = Damage;
    }


    public Weapon DeepClone()
    {
        return new Weapon(this.Name, this.damage)
        }


}

public class Armor : IDeepCloneable<Armor>
{
    public string Name { get; set; }
    public int Defense { get; set; }
    public Armor(string Name, int Defense)


            public Armor DeepClone()
    {
        return new Armor(this.Name, this.Defense)
        }
            {
                this.Name = Name;
                this.defense = Defense;
            }
        }

public class Skill : IDeepCloneable<Skill>
{
    public string Name { get; set; }
    public int
        public Skill(string Name, int Skill)


        public Skill DeepClone()
    {
        this.Name = Name;
        this.skill = Skill;
    }
        {
            return new Skill(this.Name, this.Skill)
        }
        
    }
    
public class Character : IDeepCloneable<Character>
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strenght { get; set; }
    public int Agility { get; set; }

    public Weapon Weapon
    }

public Character DeepClone()
{
    Character clone =
        new Character(this.Name, this.Health this.Strenght)
    clone.Weapon = Weapon;
    clone.Armor = Armor;
    foreach (var skill in this.Skills)
    {
        clone.Skills.Add(skill);
    }
    return clone;
}

internal class Program
{
    static void Main(string[] args)
    {
        Character warrior =
            new Character("Воин 1", 100, 100, 100);

        Character warriorClone -warrior.DeepClone();
    }
}