using System;

public struct CurrencyAmount
{
    private decimal _amount;
    private string _currency;
    public CurrencyAmount(decimal amount, string currency)
    {
        _amount = amount;
        _currency = currency;
    }

    public static bool operator == (CurrencyAmount a, CurrencyAmount b) => ValidateOperator(a, b, a._amount == b._amount);

    public static bool operator != (CurrencyAmount a, CurrencyAmount b) => ValidateOperator(a, b, a._amount != b._amount);
   
    public static bool operator > (CurrencyAmount a, CurrencyAmount b) => ValidateOperator(a, b, a._amount > b._amount);

    public static bool operator < (CurrencyAmount a, CurrencyAmount b) => ValidateOperator(a, b, a._amount < b._amount);

    public static bool operator >= (CurrencyAmount a, CurrencyAmount b) => ValidateOperator(a, b, a._amount >= b._amount);

    public static bool operator <= (CurrencyAmount a, CurrencyAmount b) => ValidateOperator(a, b, a._amount <= b._amount);
  
    public static CurrencyAmount operator + (CurrencyAmount a) => a;

    public static CurrencyAmount operator - (CurrencyAmount a) => new CurrencyAmount(-a._amount, a._currency);

    public static CurrencyAmount operator + (CurrencyAmount a, CurrencyAmount b) => ValidateOperator(a, b, a._amount + b._amount);

    public static CurrencyAmount operator - (CurrencyAmount a, CurrencyAmount b) => ValidateOperator(a, b, a._amount - b._amount);

    public static CurrencyAmount operator * (CurrencyAmount a, CurrencyAmount b) => ValidateOperator(a, b, a._amount * b._amount);

    public static CurrencyAmount operator / (CurrencyAmount a, CurrencyAmount b) => (b._amount == 0) ? throw new DivideByZeroException() : ValidateOperator(a, b, a._amount / b._amount);

    public static implicit operator double(CurrencyAmount c) => (double)c._amount;

    public static implicit operator decimal(CurrencyAmount c) => c._amount;

    private static CurrencyAmount ValidateOperator(CurrencyAmount a, CurrencyAmount b, decimal newAmount) => (IsSame(a, b)) ? new CurrencyAmount(newAmount, a._currency) : throw new ArgumentException();

    private static bool ValidateOperator(CurrencyAmount a, CurrencyAmount b, bool result) =>(IsSame(a, b)) ? result : throw new ArgumentException();

    private static bool IsSame(CurrencyAmount a, CurrencyAmount b) => (a._currency == b._currency) ? true : throw new ArgumentException();
}
