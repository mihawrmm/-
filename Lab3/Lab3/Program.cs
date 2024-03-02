using System;

// Абстрактний базовий клас Pair
public abstract class Pair
{
    // Віртуальні арифметичні операції
    public abstract Pair Add(Pair other);
    public abstract Pair Subtract(Pair other);
    public abstract Pair Multiply(Pair other);
    public abstract Pair Divide(Pair other);
    public abstract double GetValue(); // Метод для отримання значення числа
    public abstract void Display(); // Метод для виведення значення числа
}

// Похідний клас Fazzynumber (Нечіткі числа)
public class Fazzynumber : Pair
{
    private double value;

    public Fazzynumber(double value)
    {
        this.value = value;
    }

    // Реалізація арифметичних операцій для нечітких чисел
    public override Pair Add(Pair other)
    {
        double result = value + other.GetValue();
        return new Fazzynumber(result);
    }

    public override Pair Subtract(Pair other)
    {
        double result = value - other.GetValue();
        return new Fazzynumber(result);
    }

    public override Pair Multiply(Pair other)
    {
        double result = value * other.GetValue();
        return new Fazzynumber(result);
    }

    public override Pair Divide(Pair other)
    {
        double result = value / other.GetValue();
        return new Fazzynumber(result);
    }

    public override double GetValue()
    {
        return value;
    }

    public override void Display()
    {
        Console.WriteLine($"Fazzynumber: {value}");
    }
}

// Похідний клас Fraction (дробові числа)
public class Fraction : Pair
{
    private double value;

    public Fraction(double value)
    {
        this.value = value;
    }

    // Реалізація арифметичних операцій для дробових чисел
    public override Pair Add(Pair other)
    {
        double result = value + other.GetValue();
        return new Fraction(result);
    }

    public override Pair Subtract(Pair other)
    {
        double result = value - other.GetValue();
        return new Fraction(result);
    }

    public override Pair Multiply(Pair other)
    {
        double result = value * other.GetValue();
        return new Fraction(result);
    }

    public override Pair Divide(Pair other)
    {
        double result = value / other.GetValue();
        return new Fraction(result);
    }

    public override double GetValue()
    {
        return value;
    }

    public override void Display()
    {
        Console.WriteLine($"Fraction: {value}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть значення для Fazzynumber:");
        double fazzynumberValue = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть значення для Fraction (у форматі чисельник/знаменник):");
        string fractionInput = Console.ReadLine();
        string[] fractionParts = fractionInput.Split('/');

        double numerator = Convert.ToDouble(fractionParts[0]);
        double denominator = Convert.ToDouble(fractionParts[1]);
        double fractionValue = numerator / denominator;

        Pair pair1 = new Fazzynumber(fazzynumberValue);
        Pair pair2 = new Fraction(fractionValue);

        // Виклики арифметичних операцій
        Pair sum = pair1.Add(pair2);
        Pair difference = pair1.Subtract(pair2);
        Pair product = pair1.Multiply(pair2);
        Pair quotient = pair1.Divide(pair2);

        // Виведення результатів на консоль
        Console.WriteLine("Сума:");
        sum.Display();

        Console.WriteLine("Різниця:");
        difference.Display();

        Console.WriteLine("Добуток:");
        product.Display();

        Console.WriteLine("Частка:");
        quotient.Display();
    }
}
