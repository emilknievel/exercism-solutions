using System;

public struct CurrencyAmount(decimal amount, string currency)
{
    private readonly decimal _amount = amount;
    private readonly string _currency = currency;

    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        if (a._currency != b._currency) throw new ArgumentException("Currencies must be the same.");
        return a._amount == b._amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
    {
        if (a._currency != b._currency) throw new ArgumentException("Currencies must be the same.");
        return a._amount != b._amount;
    }

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        if (a._currency != b._currency) throw new ArgumentException("Currencies must be the same.");
        return a._amount < b._amount;
    }

    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        if (a._currency != b._currency) throw new ArgumentException("Currencies must be the same.");
        return a._amount > b._amount;
    }

    public static bool operator <=(CurrencyAmount a, CurrencyAmount b)
    {
        if (a._currency != b._currency) throw new ArgumentException("Currencies must be the same.");
        return a._amount <= b._amount;
    }

    public static bool operator >=(CurrencyAmount a, CurrencyAmount b)
    {
        if (a._currency != b._currency) throw new ArgumentException("Currencies must be the same.");
        return a._amount >= b._amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        if (a._currency != b._currency) throw new ArgumentException("Currencies must be the same.");
        return new CurrencyAmount(a._amount + b._amount, a._currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        if (a._currency != b._currency) throw new ArgumentException("Currencies must be the same.");
        return new CurrencyAmount(a._amount - b._amount, a._currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount a, decimal factor) => new(a._amount * factor, a._currency);

    public static CurrencyAmount operator *(decimal factor, CurrencyAmount a) => new(factor * a._amount, a._currency);

    public static CurrencyAmount operator /(CurrencyAmount a, decimal divisor) => new(a._amount / divisor, a._currency);

    public static explicit operator double(CurrencyAmount currencyAmount) => (double)currencyAmount._amount;

    public static implicit operator decimal(CurrencyAmount currencyAmount) => currencyAmount._amount;
}
