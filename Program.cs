using Codegen.Processing;
using Codegen.ProjectEntities;
using Codegen.ProjectLoaders;

namespace Codegen
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var loader = new XmlProjectLoader(@"C:\Users\plyusnin\Qt\QtTrol\generation-task.xml");
            GenerationProject proj = loader.Load();

            IProjectProcessor projectProcessor = new ProjectProcessor();
            projectProcessor.Process(proj);
        }
    }
}
