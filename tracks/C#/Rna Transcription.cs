using System;
using System.Collections.Generic;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        List<char> result = new List<char>();

        for (int i = 0; i < nucleotide.Length; i++)
        {
            if (nucleotide[i] == 'G') result.Add('C');
            else if (nucleotide[i] == 'C') result.Add('G');
            else if (nucleotide[i] == 'T') result.Add('A');
            else if (nucleotide[i] == 'A') result.Add('U');
        }

        return String.Join("", result);

    }
}
