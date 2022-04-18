using static MultiThreadingTask.Requester;
using System.Threading;

namespace MultiThreadingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение запущено");


            var handler = new DummyRequestHandler();

            var command = "";

            while (command != "/exit")
            {
                Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
                command = Console.ReadLine();
                var id = Guid.NewGuid().ToString("D");
                Console.WriteLine("Введите аргументы сообщения. Если аргументы не нужны - введите /end");
                var arg = Console.ReadLine();
                var _args = new List<string>();
                while (arg != "/end")
                {
                    _args.Add(arg);
                    Console.WriteLine("Введите следующий аргумент сообщения. Для окончания добавления аргументов введите /end");
                    arg = Console.ReadLine();
                }
                Console.WriteLine($"Было послано сообщение \'{command}\'. Присвоен идентификатор {id}");
                ThreadPool.QueueUserWorkItem(callback =>
                {
                    try
                    {
                        Console.WriteLine($"Сообщение с идентификатором {id} получило ответ - {handler.HandleRequest(command, _args.ToArray())}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Сообщение с идентификатором {id} упало с ошибкой: {ex.Message}");
                    }
                }
                );
            }
        }

    }
}
