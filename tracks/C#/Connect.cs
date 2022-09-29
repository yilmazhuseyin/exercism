using System;
using System.Collections.Generic;
public enum ConnectWinner
{
    White,
    Black,
    None
}
public class Connect
{
    enum HexStatus
    {
        Empty,
        WhiteTentative,
        WhiteConnected,
        BlackTentative,
        BlackConnected,
    }
    int width;
    int height;
    HexStatus[,] board;
    public Connect(string[] input)
    {
        for (int i = 0; i < input.Length; i++)
            input[i] = input[i].Replace(" ", "");
        width = input[0].Length;
        height = input.Length;
        board = new HexStatus[height, width];
        for (int row = 0; row < height; row++) for (int coloumn = 0; coloumn < width; coloumn++) board[row, coloumn] = CharToHexStatus(input[row][coloumn]);
    }
    public ConnectWinner Result()
    {
        var previousBoard = new HexStatus[height, width];
        Array.Copy(board, previousBoard, height * width);
        for (int coloumn = 0; coloumn < width; coloumn++)
            if (board[0, coloumn] == HexStatus.WhiteTentative) board[0, coloumn] = HexStatus.WhiteConnected;
        while (!IsEqual(board, previousBoard))
        {
            Array.Copy(board, previousBoard, height * width);
            for (int row = 0; row < height; row++)
                for (int coloumn = 0; coloumn < width; coloumn++)
                {
                    if (board[row, coloumn] == HexStatus.WhiteTentative && TouchesConnected(board, row, coloumn, HexStatus.WhiteConnected)) board[row, coloumn] = HexStatus.WhiteConnected;
                    if (row == height - 1 && board[row, coloumn] == HexStatus.WhiteConnected) return ConnectWinner.White;
                }
        }
        for (int row = 0; row < height; row++)
            if (board[row, 0] == HexStatus.BlackTentative)
                board[row, 0] = HexStatus.BlackConnected;
        while (!IsEqual(board, previousBoard))
        {
            Array.Copy(board, previousBoard, height * width);
            for (int row = 0; row < height; row++)
                for (int coloumn = 0; coloumn < width; coloumn++)
                {
                    if (board[row, coloumn] == HexStatus.BlackTentative && TouchesConnected(board, row, coloumn, HexStatus.BlackConnected))
                        board[row, coloumn] = HexStatus.BlackConnected;
                    if (coloumn == width - 1 && board[row, coloumn] == HexStatus.BlackConnected)
                        return ConnectWinner.Black;
                }
        }
        return ConnectWinner.None;
    }
    HexStatus CharToHexStatus(char character) =>
        character switch
        {
            'O' => HexStatus.WhiteTentative,
            'X' => HexStatus.BlackTentative,
            _ => HexStatus.Empty
        };
    bool IsEqual(HexStatus[,] board1, HexStatus[,] board2)
    {
        for (int row = 0; row < height; row++)
            for (int coloumn = 0; coloumn < width; coloumn++)
                if (board1[row, coloumn] != board2[row, coloumn])
                    return false;
        return true;
    }
    private bool TouchesConnected(HexStatus[,] board, int row, int coloumn, HexStatus status)
    {
        var statusOfConnectedHexes = new List<HexStatus>();
        if (row != 0)
        {
            statusOfConnectedHexes.Add(board[row - 1, coloumn]);
            if (coloumn != width - 1)
                statusOfConnectedHexes.Add(board[row - 1, coloumn + 1]);
        }
        if (row != height - 1)
        {
            statusOfConnectedHexes.Add(board[row + 1, coloumn]);
            if (coloumn != 0)
                statusOfConnectedHexes.Add(board[row + 1, coloumn - 1]);
        }
        if (coloumn != 0)
            statusOfConnectedHexes.Add(board[row, coloumn - 1]);
        if (coloumn != width - 1)
            statusOfConnectedHexes.Add(board[row, coloumn + 1]);
        return statusOfConnectedHexes.Contains(status);
    }
}
