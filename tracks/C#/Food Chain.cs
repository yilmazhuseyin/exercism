using System;
using System.Collections.Generic;
using System.Linq;

public static class FoodChain
{
    static List<Animal> animals = new List<Animal>() {
        newAnimal("fly","I don't know why she swallowed the fly. Perhaps she'll die."),
        newAnimal("spider","It wriggled and jiggled and tickled inside her."),
        newAnimal("bird","How absurd to swallow a bird!"),
        newAnimal("cat","Imagine that, to swallow a cat!"),
        newAnimal("dog","What a hog, to swallow a dog!"),
        newAnimal("goat","Just opened her throat and swallowed a goat!"),
        newAnimal("cow","I don't know how she swallowed a cow!"),
        newAnimal("horse","She's dead, of course!"),
    };

    public static string Recite(int verseNumber) => Recite(verseNumber, verseNumber);
    public static string Recite(int startVerse, int endVerse)
    {
        string result = String.Empty;
        var lastVerse = animals[0].verse;
        var specialVerses = new List<string>();

        for (int i = startVerse - 1; i < endVerse; i++)
        {
            specialVerses.Clear();
            var firstVerse = $"I know an old lady who swallowed a {animals[i].name}";
            var secondVerse = $"{firstVerse}.\n{animals[i].verse}";
            var verse = $"{firstVerse}.\n{lastVerse}";

            for (int k = i; k > 0; k--)
            {
                if (k == 2) specialVerses.Add($"She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.");
                else specialVerses.Add($"She swallowed the {animals[k].name} to catch the {animals[k - 1].name}.");
            }

            var thirdVerse = $"{secondVerse}\n{String.Join("\n", specialVerses)}\n{lastVerse}";

            if (i == 0 && endVerse > 1) result += $"{verse}\n\n";
            else if (i == 0) result += verse;
            else if (i < endVerse - 1) result += $"{thirdVerse}\n\n";
            else if (i == 7) result += $"{secondVerse}";
            else result += thirdVerse;
        }
        return result;
    }

    public static Animal newAnimal(string n, string v) => new Animal() { name = n, verse = v };
}

public class Animal
{
    public string name { get; set; }
    public string verse { get; set; }
}
