namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            River dnipro = new River(30.5, 50.4, "Dnister", "The deepest river in Ukraine", 20.0, 2201);
            Mountain hoverla = new Mountain(24.5, 48.1, "Hoverla", "The highest mountain in Ukraine", 2061);

            Console.WriteLine(dnipro.GetInfo());
            Console.WriteLine(hoverla.GetInfo());
        }
    }
}
