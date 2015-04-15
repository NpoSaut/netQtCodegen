using System;
using System.Linq;
using System.Xml.Linq;
using Codegen.Formatting;
using Codegen.ProjectEntities;
using Codegen.ProjectEntities.Actions;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.ProjectLoaders
{
    public class XmlProjectLoader : IProjectLoader
    {
        private readonly string _fileName;
        public XmlProjectLoader(string FileName) { _fileName = FileName; }

        /// <summary>Загружает проект кодогенерации</summary>
        public GenerationProject Load()
        {
            XDocument document = XDocument.Load(_fileName);

            if (document.Root == null)
                throw new ApplicationException();

            // ReSharper disable PossibleNullReferenceException
            return new GenerationProject(
                document.Root.Element("GenerationTasks").Elements()
                        .Select(XGenerationTask =>
                                new GenerationTask(
                                    XGenerationTask.Element("Globals").Elements()
                                                   .ToDictionary(XGlobalVariable => XGlobalVariable.Name.LocalName, XGlobalVariable => XGlobalVariable.Value),
                                    XGenerationTask.Element("Actions").Elements()
                                                   .Select(XAction => new GenerationActionCalling(XAction.Name.LocalName, (string)XAction.Attribute("file")))
                                                   .ToList(),
                                    XGenerationTask.Elements("SourceItems").Elements()
                                                   .Select(XItem => new GenerationItem(XItem.Attributes().ToDictionary(Xa => Xa.Name.LocalName, Xa => Xa.Value)))
                                                   .ToList()))
                        .ToList(),
                document.Root.Element("GenerationActions").Elements()
                        .Select(XAction =>
                                new GenerationAction(XAction.Name.LocalName,
                                                     XAction.Elements("InjectionTemplate")
                                                            .Select(XTemplate => new InjectionTemplate((string)XTemplate.Attribute("anchor"),
                                                                                                       XTemplate.Value.TrimEnd().Trim('\n').TrimIndents()))
                                                            .ToList()))
                        .ToList()
                );
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
