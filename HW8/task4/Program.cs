using System;

/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/

// Порушений принцип: ISP (Interface Segregation Principle).

// Було:
// interface IItem
// {
//     void ApplyDiscount(String discount);
//     void ApplyPromocode(String promocode);
//     void SetColor(byte color);
//     void SetSize(byte size);
//     void SetPrice(double price);
// }

// Тепер розбиваємо на кілька дрібніших інтерфейсів:

interface IDiscountable
{
    void ApplyDiscount(String discount);
    void ApplyPromocode(String promocode);
}

interface IColored
{
    void SetColor(byte color);
}

interface ISized
{
    void SetSize(byte size);
}

interface IPriced
{
    void SetPrice(double price);
}

class Book : IPriced, IDiscountable
{
    private double price;
    private String? discount;
    private String? promocode;

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public void ApplyDiscount(String discount)
    {
        this.discount = discount;
    }

    public void ApplyPromocode(String promocode)
    {
        this.promocode = promocode;
    }

    public override string ToString()
    {
        return $"Book: price = {price}, discount = {discount}, promocode = {promocode}";
    }
}

class Outerwear : IPriced, IDiscountable, IColored, ISized
{
    private double price;
    private String? discount;
    private String? promocode;
    private byte color;
    private byte size;

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public void ApplyDiscount(String discount)
    {
        this.discount = discount;
    }

    public void ApplyPromocode(String promocode)
    {
        this.promocode = promocode;
    }

    public void SetColor(byte color)
    {
        this.color = color;
    }

    public void SetSize(byte size)
    {
        this.size = size;
    }

    public override string ToString()
    {
        return $"Outerwear: price = {price}, color = {color}, size = {size}, discount = {discount}, promocode = {promocode}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();
        book.SetPrice(300);
        book.ApplyDiscount("10%");
        book.ApplyPromocode("BOOK2025");

        Outerwear jacket = new Outerwear();
        jacket.SetPrice(1500);
        jacket.SetColor(5);   
        jacket.SetSize(42);   
        jacket.ApplyDiscount("15%");
        jacket.ApplyPromocode("SPRING");

        Console.WriteLine(book);
        Console.WriteLine(jacket);

        Console.ReadKey();
    }
}