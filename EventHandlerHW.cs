using System;

namespace EventHandlerHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var subscriber = new Subscriber();
            subscriber.SomeMethod();
        }
    }

    class Subscriber
    {
        public void SomeMethod()
        {
            var publisher = new Publisher();
            EventHandler<char> handler = (o, a) => Console.WriteLine("Ввёденo: {0}", a);
            publisher.OnKeyPressed += handler;
            publisher.Run();
        }
    }

    class Publisher
    {
        public EventHandler<char> OnKeyPressed;

        public void Run()
        {
            while(true)
            {
                var symbol = Convert.ToChar(Console.ReadLine().ToLower());
                if (symbol == 'c')
                    break;
                else
                    OnKeyPressed?.Invoke(this, symbol);
            }
        }
    }
}
