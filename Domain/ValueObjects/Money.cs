// Domain/ValueObjects/Money.cs
public record Money(decimal Amount)
{
    public static Money operator +(Money a, Money b) => new(a.Amount + b.Amount);
    public static Money operator -(Money a, Money b) => new(a.Amount - b.Amount);
}
