using System;
using System.Diagnostics;
using Codegen.Processing;
using Codegen.ProjectEntities;
using Codegen.ProjectLoaders;

namespace Codegen
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string projectFileName;
            if (args.Length == 1)
                projectFileName = args[0];
            else
            {
                Console.WriteLine("Задайте имя файла проекта в параметрах запуска, или введите сейчас:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                projectFileName = Console.ReadLine();
                Console.ResetColor();
                if (string.IsNullOrWhiteSpace(projectFileName))
                    return;
            }

            try
            {
                var loader = new XmlProjectLoader(projectFileName);
                GenerationProject project = loader.Load();

                IProjectProcessor projectProcessor = new ProjectProcessor();
                projectProcessor.Process(project);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Проект успешно обработан.");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                    throw;

                Console.WriteLine("Во время выполнения программы возникло исключение:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e);
                Console.ResetColor();
                Console.ReadLine();
            }
        }
    }
}
