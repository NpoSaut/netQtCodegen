using System;
using System.Collections.Generic;
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
                                    LoadItems(XGenerationTask.Element("SourceItems"))))
                        .ToList(),
                document.Root.Element("GenerationActions").Elements()
                        .Select(LoadGenerationAction)
                        .ToList()
                );
            // ReSharper restore PossibleNullReferenceException
        }

        private static GenerationAction LoadGenerationAction(XElement XAction)
        {
            Dictionary<string, string> templates = XAction.Elements("Template").ToDictionary(
                XInternalTemplate => XInternalTemplate.Attribute("name").Value,
                XInternalTemplate => XInternalTemplate.Value.TrimEnd().Trim('\n').TrimIndents());

            IList<ProjectEntities.Actions.Injection> injections = XAction.Elements("Injection").Select(
                XTemplate => new ProjectEntities.Actions.Injection((string)XTemplate.Attribute("anchor"),
                                                   XTemplate.Nodes().OfType<XText>().Any()
                                                       ? XTemplate.Nodes().OfType<XText>().First().Value.Trim('\n').TrimIndents()
                                                       : templates[XTemplate.Attribute("template").Value],
                                                   (string)XTemplate.Attribute("filter")))
                                                         .ToList();

            return new GenerationAction(XAction.Name.LocalName, injections, templates);
        }

        private static List<GenerationItem> LoadItems(XElement XItemsContainer)
        {
            return XItemsContainer.Elements()
                                  .Select(XItem =>
                                          new GenerationItem(XItem.Name.LocalName, XItem.Attributes().ToDictionary(Xa => Xa.Name.LocalName, Xa => Xa.Value),
                                                             LoadItems(XItem)))
                                  .ToList();
        }
    }
}
