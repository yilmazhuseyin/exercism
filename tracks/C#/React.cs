using System;
using System.Collections.Generic;
using System.Linq;
public class Reactor
{
    public InputCell CreateInputCell(int value) => new InputCell(value);
    public ComputeCell CreateComputeCell(IEnumerable<Cell> cells, Func<int[], int> function) => new ComputeCell(cells, function);
}
public abstract class Cell
{
    private int _value;
    public event EventHandler<int> Changed;
    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (_value != value)
            {
                _value = value;
                if (Changed != null) Changed.Invoke(this, _value);
            }
        }
    }
}
public class InputCell : Cell
{
    public InputCell(int value) => base.Value = value;
}
public class ComputeCell : Cell
{
    public Func<int[], int> Function { set; get; }
    public IEnumerable<Cell> Cells { set; get; }
    public ComputeCell(IEnumerable<Cell> cells, Func<int[], int> function)
    {
        Cells = cells;
        Function = function;
        SetValue();
        foreach (Cell cell in cells) if (cell.Value != base.Value) cell.Changed += CallBack;
    }
    public void SetValue() => base.Value = Function(Cells.Select(c => c.Value).ToArray());
    public void CallBack(object sender, int value) => SetValue();
}
