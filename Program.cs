using System.Diagnostics.Contracts;

public interface IAbility
{
    void Use(string characterName);
}

public class PhysicalAttack : IAbility
{
    public void Use(string characterName)
    {
        Console.WriteLine($"\n{characterName} использует физическую атаку!");
    }
}

public class FireAttack : IAbility
{
    public void Use(string characterName)
    {
        if (characterName == "Маг")
            Console.WriteLine($"\n{characterName} использует огненное заклинание!");
        else
            Console.WriteLine($"{characterName} использует огненную атаку!");
    }
}

public class IceAttack : IAbility
{
    public void Use(string characterName)
    {
        if (characterName == "Маг")
            Console.WriteLine($"{characterName} использует ледяное заклинание!");
        else
            Console.WriteLine($"{characterName} использует ледяную атаку!");
    }
}

public abstract class Character
{
    protected IAbility ability;
    public string Name { get; protected set; }

    protected Character(IAbility ability)
    {
        this.ability = ability;
    }

    public void UseAbility()
    {
        ability.Use(Name);
    }
}

public class Warrior : Character
{
    public Warrior(IAbility ability) : base(ability)
    {
        Name = "Воин";
    }
}

public class Mage : Character
{
    public Mage(IAbility ability) : base(ability)
    {
        Name = "Маг";
    }
}

public class Archer : Character
{
    public Archer(IAbility ability) : base(ability)
    {
        Name = "Лучник";
    }
}

class Program
{
    static void Main()
    {
        IAbility physicalAttack = new PhysicalAttack();
        IAbility fireAttack = new FireAttack();
        IAbility iceAttack = new IceAttack();


        Character warriorPhysical = new Warrior(physicalAttack);
        warriorPhysical.UseAbility();
        Character warriorFire = new Warrior(fireAttack);
        warriorFire.UseAbility();


        Character mageFire = new Mage(fireAttack);
        mageFire.UseAbility();
        Character mageIce = new Mage(iceAttack);
        mageIce.UseAbility();


        Character archerPhysical = new Archer(physicalAttack);
        archerPhysical.UseAbility();
        Character archerIce = new Archer(iceAttack);
        archerIce.UseAbility();


        Console.ReadLine();
    }
}