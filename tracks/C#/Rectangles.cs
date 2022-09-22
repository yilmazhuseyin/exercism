public static class Rectangles
{
    public static int Count(string[] rows)
    {
        int rec = 0;

        for (int i = 0; i < rows.Length; i++) for (int k = 0; k < rows[i].Length; k++) if (rows[i][k] == '+') rec += Rec(rows, i, k);

        return rec;
    }

    private static int Rec(string[] rows, int i, int l)
    {
        int count = 0;
        bool first = false;

        for (int k = l + 1; k < rows[i].Length && !first; k++) switch (rows[i][k])
            {
                case '-': break;
                case '+':
                    bool second = false;
                    for (int x = i + 1; x < rows.Length && !second; x++)
                        switch (rows[x][k])
                        {
                            case '|': break;
                            case '+':
                                if (rows[x][l] == '+')
                                {
                                    bool connected = true;
                                    for (int b = k - 1; b > l && connected; b--) connected = rows[x][b] == '-' || rows[x][b] == '+';
                                    
                                    for (int a = x - 1; a > i && connected; a--) connected = rows[a][l] == '|' || rows[a][l] == '+';
                                    
                                    if (connected) count++;
                                }
                                break;
                            default: second = true; break;
                        }
                    break;
                default: first = true; break;
            }

        return count; 
    }


}
