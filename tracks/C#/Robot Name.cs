using System;
using System.Collections.Generic;

public class Robot
{
    public static List<string> RobotList = new List<string>();
    
    public Robot() => Name = GenerateName();
    
    public string Name { get; private set; }

    public void Reset() => Name = GenerateName();

    public string GenerateName()
    {
        Random rnd = new Random();
        string name;
        do
        {
            name = $"{(char)rnd.Next(65, 91)}{(char)rnd.Next(65, 91)}{rnd.Next(100, 1000)}";
        } while (RobotList.Contains(name));

        RobotList.Add(name);
        return name;
    }
}
