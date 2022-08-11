using System;
using System.Linq;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        string[] codons = new string[strand.Length / 3];
        string[] result = new string[strand.Length / 3];
        int index = 0;

        for (int i = 0; i < strand.Length; i+=3)
        {
            string str = strand.Substring(i, 3);
            codons[index] = str;
            index++;
        }
        int indx = 0;
        foreach (var item in codons)
        {
            if(item == "UAA" || item == "UAG" || item == "UGA") break;
            else
            {
                switch (item)
                {
                    case "AUG":
                        result[indx] = "Methionine";
                        indx++;
                        break;
                    case "UUU":
                    case "UUC":
                        result[indx] = "Phenylalanine";
                        indx++;
                        break;
                    case "UUA":
                    case "UUG":
                        result[indx] = "Leucine";
                        indx++;
                        break;
                    case "UCU":
                    case "UCC":
                    case "UCA":
                    case "UCG":
                        result[indx] = "Serine";
                        indx++;
                        break;
                    case "UAU":
                    case "UAC":
                        result[indx] = "Tyrosine";
                        indx++;
                        break;
                    case "UGU":
                    case "UGC":
                        result[indx] = "Cysteine";
                        indx++;
                        break;
                    case "UGG":
                        result[indx] = "Tryptophan";
                        indx++;
                        break;
                    default:
                        break;
                }
            }
        }
        return result.Where(x => x != null).ToArray();
    }
}
