using System;
using System.Collections.Generic;
using System.Linq;

public class DndCharacter
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) * 0.5);

    public static int Ability() => new List<int> { RandomNum(), RandomNum(), RandomNum(), RandomNum() }.OrderByDescending(x => x).Take(3).Sum();

    public static DndCharacter Generate() => new DndCharacter(Ability(), Ability(),Ability(), Ability(),Ability(), Ability());
    

    public DndCharacter(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
        Hitpoints = 10 + Modifier(constitution);
    }
    private static int RandomNum() => new Random().Next(1, 7);
}
