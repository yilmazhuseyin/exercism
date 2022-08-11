using System;
using System.Collections.Generic;

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var commandList = new List<string>();
        if ((commandValue & 0b1) != 0) commandList.Add("wink");
        if ((commandValue & 0b10) != 0) commandList.Add("double blink");
        if ((commandValue & 0b100) != 0) commandList.Add("close your eyes");
        if ((commandValue & 0b1000) != 0) commandList.Add("jump");
        if ((commandValue & 0b10000) != 0) commandList.Reverse();
        return commandList.ToArray();
    }
}
