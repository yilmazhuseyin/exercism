using System;
public enum Direction
{
    North = 1,
    East = 2,
    South = 3,
    West = 4
}
public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;

    }
    public Direction Direction { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public void Move(string instructions)
    {
        var direction = (int)Direction;

        foreach (var i in instructions)
        {
            switch (i)
            {
                case 'R' when direction == 4:
                    direction = 1;
                    break;
                case 'R':
                    direction++;
                    break;
                case 'L' when direction == 1:
                    direction = 4;
                    break;
                case 'L':
                    direction--;
                    break;
                case 'A' when (Direction)direction == Direction.North:
                    Y++;
                    break;
                case 'A' when (Direction)direction == Direction.South:
                    Y--;
                    break;
                case 'A' when (Direction)direction == Direction.East:
                    X++;
                    break;
                case 'A' when (Direction)direction == Direction.West:
                    X--;
                    break;
            }
        }
        Direction = (Direction)direction;
    }
}
