using System;
using System.Linq;

public enum Allergen
{
    Eggs = 1, 
    Peanuts = 2, 
    Shellfish = 4, 
    Strawberries = 8, 
    Tomatoes = 16, 
    Chocolate = 32, 
    Pollen = 64, 
    Cats = 128
}

public class Allergies
{
    private readonly int _mask;

    public Allergies(int mask) => _mask = mask;

    public bool IsAllergicTo(Allergen allergen) => ((int)allergen & _mask) == (int)allergen;
    
    public Allergen[] List() => Enum.GetValues(typeof(Allergen)).OfType<Allergen>().Where(x=>IsAllergicTo(x)).ToArray();
}
