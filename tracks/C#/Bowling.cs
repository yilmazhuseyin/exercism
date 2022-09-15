using System;
using System.Collections.Generic;
public class BowlingGame
{
    private int _score;
    private List<int> rolls;
    private int neededPins = 10;
    private int numberOfFrames = 10;
    private bool StartFrame;
    private int NumberOfExtraRolls = 0;
    private int correctNumberOfRolls;
    private int frame;
    private int bonusRolls = 0;
    public BowlingGame()
    {
        rolls = new List<int> { };
    }
    public void Roll(int pins)
    {
        if (pins > 10 | pins < 0)
            throw new ArgumentException();
        rolls.Add(pins);
        if (!ScoringConsistent())
            throw new ArgumentException();
    }
    public bool ScoringConsistent(bool Complete = false)
    {
        StartFrame = true;
        frame = 0;
        bonusRolls = 0;
        correctNumberOfRolls = 0;
        if (rolls.Count > 21)
            return false;
        if (Complete & rolls.Count < 11)
            return false;
        for (int i = 0; i < rolls.Count; i++)
        {
            if (StartFrame)
            {
                correctNumberOfRolls++;
                frame++;
                if (rolls[i] == neededPins)
                {
                    if (frame == 10)
                    {
                        correctNumberOfRolls += 2;
                        if (rolls.Count == i + 2 + 1)
                            if (rolls[i + 1] < 10 & rolls[i + 1] + rolls[i + 2] > 10)
                                return false;
                        break;
                    }
                }
                else
                {
                    correctNumberOfRolls++;
                    StartFrame = false;
                }
            }
            else
            {
                if (rolls[i] + rolls[i - 1] > 10)
                    return false;
                StartFrame = true;
                if (frame == 10 & rolls[i] + rolls[i - 1] == 10)
                {
                    correctNumberOfRolls++;
                    break;
                }
            }
        }
        if (Complete)
            return (frame == 10 & rolls.Count == correctNumberOfRolls) ? true : false;
        else
            return (frame < 11 & rolls.Count <= correctNumberOfRolls) ? true : false;
    }
    public int? Score()
    {
        if (!ScoringConsistent(true))
            throw new ArgumentException();
        StartFrame = true;
        frame = 1;
        for (int i = 0; i < rolls.Count; i++)
        {
            if (StartFrame)
            {
                if (rolls[i] == neededPins)
                {
                    _score += rolls[i] + rolls[i + 1] + rolls[i + 2];
                    frame++;
                }
                else
                {
                    _score += rolls[i];
                    StartFrame = false;
                }
            }
            else
            {
                if (rolls[i] + rolls[i - 1] == neededPins)
                    _score += rolls[i] + rolls[i + 1];
                else
                {
                    _score += rolls[i];
                }
                StartFrame = true;
                frame++;
            }
            if (frame > 10)
                break;
        }
        return _score;
    }
}
