using System;

public class BankAccount
{
    private float _balance = 0;
    private bool _isOpen = false;
    private object myLock = new object();

    public void Open()
    {
        _balance = 0;
        _isOpen = true;
    }

    public void Close() => _isOpen = false;
    
    public float Balance
    {
        get
        {
            if (_isOpen) return _balance;
            else throw new InvalidOperationException();
        }
    }

    public void UpdateBalance(float change)
    {
        lock(myLock) _balance += change;
    }
}
