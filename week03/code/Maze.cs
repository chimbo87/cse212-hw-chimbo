using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        var current = (_currX, _currY);
        if (!_mazeMap.ContainsKey(current) || !_mazeMap[current][0])
            throw new InvalidOperationException("Can't go that way!");
        _currX--;
    }

    public void MoveRight()
    {
        var current = (_currX, _currY);
        if (!_mazeMap.ContainsKey(current) || !_mazeMap[current][1])
            throw new InvalidOperationException("Can't go that way!");
        _currX++;
    }

    public void MoveUp()
    {
        var current = (_currX, _currY);
        if (!_mazeMap.ContainsKey(current) || !_mazeMap[current][2])
            throw new InvalidOperationException("Can't go that way!");
        _currY--;
    }

    public void MoveDown()
    {
        var current = (_currX, _currY);
        if (!_mazeMap.ContainsKey(current) || !_mazeMap[current][3])
            throw new InvalidOperationException("Can't go that way!");
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}