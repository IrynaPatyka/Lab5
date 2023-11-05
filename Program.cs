using System;

abstract class Parent
{
    protected double pole1;
    protected int pole2;
    protected double pole3;

    public Parent(double price, int seats)
    {
        pole1 = price;
        pole2 = seats;
    }

    public abstract string Info();
    public abstract void Metod();
}

class Child1 : Parent
{
    
    public Child1(double price, int seats) : base(price, seats) { }

    public override string Info()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        return $"Загальний вагон: Ціна за квиток = {pole1}, Кількість місць = {pole2}, Загальний дохід = {pole3}";
    }

    public override void Metod()
    {
        pole3 = pole1 * pole2;
    }
}

class Child2 : Parent
{
    protected double pole4;

    public Child2(double price, int seats, double extraServicePrice) : base(price, seats)
    {
        pole4 = extraServicePrice;
    }

    public override string Info()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        return $"Плацкарний вагон: Ціна за квиток = {pole1}, Кількість місць = {pole2},  Додаткова ціна послуги на одного пасажира = {pole4}, Загальни дохід= {pole3}";
    }

    public override void Metod()
    {
        pole3 = pole1 * pole2 + pole2 * pole4 * 0.5;
    }
}

class Child3 : Parent
{
    protected double pole5;

    public Child3(double price, int seats, double extraServicePrice) : base(price, seats)
    {
        pole5 = extraServicePrice;
    }

    public override string Info()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        return $"Купейний вагон: Ціна за квиток = {pole1}, Кількість місць = {pole2}, Додаткова ціна послуги на пасажира = {pole5}, Загальний дохід  = {pole3}";
    }

    public override void Metod()
    {
        pole3 = pole2 * (pole1 + pole5);
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            int wagonType = random.Next(3); //0 - загальний, 1 - спальний, 2 - купе
            double price = random.Next(50, 150);
            int seats = random.Next(50, 150);
            double extraServicePrice = random.Next(10, 30);

            Parent wagon = null;

            if (wagonType == 0)
                wagon = new Child1(price, seats);
            else if (wagonType == 1)
                wagon = new Child2(price, seats, extraServicePrice);
            else if (wagonType == 2)
                wagon = new Child3(price, seats, extraServicePrice);

            wagon.Metod();
            Console.WriteLine(wagon.Info());
        }
    }
}
