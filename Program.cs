using System;
using System.Collections.Generic;

namespace BarsHomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoFirstTask();
            //DoSecondTask();
        }

        public void DoFirstTask()
        {
            var intLogger = new LocalFileLogger<int>("../../../intLogger.txt");
            var stringLogger = new LocalFileLogger<string>("../../../stringLogger.txt");
            var charListLogger = new LocalFileLogger<List<char>>("../../../charListLogger.txt");

            intLogger.LogError("kapec int perepolnen", new OverflowException());
            intLogger.LogWarning("int skoro perepolnitsya!!");
            intLogger.LogInfo("int zhiv");

            stringLogger.LogError("BbI Nanisali nloxoe clovo", new ArgumentException("Bad Word exception"));
            stringLogger.LogWarning("Don't forget to check gramma!!!");
            stringLogger.LogInfo("All works fine!");

            charListLogger.LogError("Type Error — nodumal Stirlitz...", new ArgumentException("Type error"));
            charListLogger.LogWarning("Max lisst length will be reached soon");
            charListLogger.LogInfo("No errors detected yet..");
        }

        public void DoSecondTask()
        {
            var a = new List<Entity>();
            a.Add(GenerateEntity(1, 0, "Root entity"));
            a.Add(GenerateEntity(2, 1, "Child of 1 entity"));
            a.Add(GenerateEntity(3, 1, "Child of 1 entity"));
            a.Add(GenerateEntity(4, 2, "Child of 2 entity"));
            a.Add(GenerateEntity(5, 4, "Child of 4 entity"));
            var result = Entity.ConvertToDictionary(a);
            int counter = 1;
            foreach (var list in result)
            {
                Console.WriteLine($"List №{counter}");
                foreach (var elem in list.Value)
                    Console.WriteLine(elem);
                counter++;
            }
        }

        public static Entity GenerateEntity(int id, int parentId, string name)
        {
            var result = new Entity();
            result.Id = id;
            result.ParentId = parentId;
            result.Name = name;
            return result;
        }
    }
}
