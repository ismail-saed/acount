using System;

public class Account
{
    public string Name { get; protected set; }
    public double Balance { get; protected set; }

    public Account(string name = "Unnamed Account", double balance = 0.0)
    {
        Name = name;
        Balance = balance;
    }

    public virtual bool Deposit(double amount)
    {
        if (amount < 0) return false;
        Balance += amount;
        return true;
    }

    public virtual bool Withdraw(double amount)
    {
        if (Balance - amount >= 0)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}

public class SavingsAccount : Account
{
    public double InterestRate { get; protected set; }

    public SavingsAccount(string name = "Unnamed Savings Account", double balance = 0.0, double interestRate = 0.0)
        : base(name, balance)
    {
        InterestRate = interestRate;
    }

    public override bool Deposit(double amount)
    {
        if (amount < 0) return false;
        amount += amount * (InterestRate / 100.0);
        return base.Deposit(amount);
    }
}

public class CheckingAccount : Account
{
    private const double PerWithdrawalFee = 1.50;
    public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0)
        : base(name, balance)
    {
    }

    public override bool Withdraw(double amount)
    {
        amount += PerWithdrawalFee;
        return base.Withdraw(amount);
    }
}

public class TrustAccount : SavingsAccount
{
    private const double BonusThreshold = 5000.00;
    private const double BonusAmount = 50.00;
    private const int MaxWithdrawals = 3;
    private const double MaxWithdrawPercent = 0.20; 
    private int numWithdrawals = 0;

    public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double interestRate = 0.0)
        : base(name, balance, interestRate)
    {
    }

    public override bool Deposit(double amount)
    {
        if (amount >= BonusThreshold)
        {
            amount += BonusAmount;
        }
        return base.Deposit(amount);
    }

    public override bool Withdraw(double amount)
    {
        if (numWithdrawals >= MaxWithdrawals || amount >= (Balance * MaxWithdrawPercent))
        {
            return false;
        }
        if (base.Withdraw(amount))
        {
            numWithdrawals++;
            return true;
        }
        return false;
    }
}