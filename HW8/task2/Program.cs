using System;

//Який принцип S.O.L.I.D. порушено? Виправте!

/*Зверніть увагу на клас EmailSender. Крім того, що за допомогою методу Send, він відправляє повідомлення, 
він ще і вирішує як буде вестися лог. В даному прикладі лог ведеться через консоль.
Якщо трапиться так, що нам доведеться міняти спосіб логування, то ми будемо змушені внести правки в клас EmailSender.
Хоча, здавалося б, ці правки не стосуються відправки повідомлень. Очевидно, EmailSender виконує кілька обов'язків і, 
щоб клас не був прив'язаний тільки до одного способу вести лог, потрібно винести логування з цього класу.*/

// Порушений принцип: SRP (Single Responsibility Principle).

class Email
{
    public String Theme { get; set; }
    public String From { get; set; }
    public String To { get; set; }
}

// added
interface ILogger
{
    void Log(string message);
}

// added
class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class EmailSender
{
    private readonly ILogger logger; // added

    // added
    public EmailSender(ILogger logger)
    {
        this.logger = logger;
    }

    public void Send(Email email)
    {
        // ... sending...

        // було:
        // Console.WriteLine("Email from '" + email.From + "' to '" + email.To + "' was send");

        logger.Log("Email from '" + email.From + "' to '" + email.To + "' was send");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Email e1 = new Email() { From = "Me",    To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email() { From = "Vasya", To = "Me",    Theme = "vacuum cleaners!" };
        Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email() { From = "Vasya", To = "Me",    Theme = "washing machines!" };
        Email e5 = new Email() { From = "Me",    To = "Vasya", Theme = "Yes" };
        Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

        ILogger logger = new ConsoleLogger();        // added
        EmailSender es = new EmailSender(logger);    // changed

        es.Send(e1);
        es.Send(e2);
        es.Send(e3);
        es.Send(e4);
        es.Send(e5);
        es.Send(e6);

        Console.ReadKey();
    }
}