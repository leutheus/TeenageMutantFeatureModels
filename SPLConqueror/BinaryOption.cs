﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SPLConqueror_Core
{
    public class BinaryOption : ConfigurationOption
    {
        /// <summary>
        /// A binary option can either be selected or selected in a specific configuration of a programm.
        /// </summary>
        public enum BinaryValue {
            Selected = 1,//"selected",
            Deselected = 2//"deselected"
        };

        /// <summary>
        /// The default value of a binary option.
        /// </summary>
        public BinaryValue DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Optional { get; set; }

        /// <summary>
        /// Constructor of a binary option. Optional is set to false and the default value is set to selected.
        /// </summary>
        /// <param name="vm">Corresponding variability model</param>
        /// <param name="name">Name of that option</param>
        public BinaryOption(VariabilityModel vm, String name)
            : base(vm, name)
        {
            this.Optional = false;
            this.DefaultValue = BinaryValue.Selected;
        }

        /// <summary>
        /// Stores the binary options as an XML node (calling base implementation)
        /// </summary>
        /// <param name="doc">The XML document to which the node will be added</param>
        /// <returns>The XML node containing the options information</returns>
        internal XmlNode saveXML(System.Xml.XmlDocument doc)
        {
            XmlNode node = base.saveXML(doc);

            //Default value
            XmlNode defaultNode = doc.CreateNode(XmlNodeType.Element, "defaultValue", "");
            if (this.DefaultValue == BinaryValue.Selected)
                defaultNode.InnerText = "Selected";
            else
                defaultNode.InnerText = "Deselected";
            node.AppendChild(defaultNode);

            //Optional
            XmlNode optionalNode = doc.CreateNode(XmlNodeType.Element, "optional", "");
            if (this.Optional)
                optionalNode.InnerText = "True";
            else
                optionalNode.InnerText = "False";
            node.AppendChild(optionalNode);

            return node;
        }


        /// <summary>
        /// Creates a binary option based on the information stored in the xml node. The binary option is assigned to the variability model. 
        /// </summary>
        /// <param name="node">Node of the xml file holding the information of the binary option.</param>
        /// <param name="vm">The variabilit model the binary option is assigned to. </param>
        /// <returns>A binary option of the variabilit model with the information stored in the xml node.</returns>
        public static BinaryOption loadFromXML(XmlElement node, VariabilityModel vm)
        {
            BinaryOption option = new BinaryOption(vm, "temp");
            option.loadFromXML(node);
            return option;
        }

        internal void loadFromXML(XmlElement node)
        {
            base.loadFromXML(node);
            foreach (XmlElement xmlInfo in node.ChildNodes)
            {
                switch (xmlInfo.Name)
                {
                    case "defaultValue":
                        if (xmlInfo.InnerText.Equals("Selected"))
                            this.DefaultValue = BinaryValue.Selected;
                        else
                            this.DefaultValue = BinaryValue.Deselected;
                        break;
                    case "optional":
                        if (xmlInfo.InnerText.Equals("True"))
                            this.Optional = true;
                        else
                            this.Optional = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Checks whether the given list of options have the same parent to decide if they all form an alternative group
        /// </summary>
        /// <param name="excludedOption">A list of options that are excluded by this option.</param>
        /// <returns>True if they are alternatives (same parent option), false otherwise</returns>
        public bool isAlternativeGroup(List<ConfigurationOption> excludedOption)
        {
            //if it is an alternative, they can't be optional
            if (this.Optional == true)
                return false;
            foreach (ConfigurationOption opt in excludedOption)
            {
                if (opt.Parent != this.Parent)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether this binary option has alternative options meaning that there are other binary options with the same parents, but cannot be present in the same configuration as this option.
        /// </summary>
        /// <returns>True if it has alternative options, false otherwise</returns>
        public bool hasAlternatives()
        {
            foreach (var bins in this.Excluded_Options)
            {
                if (isAlternativeGroup(bins))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Collects all options that are excluded by this option and that have the same parent
        /// </summary>
        /// <returns>The list of alternative options</returns>
        public List<ConfigurationOption> collectAlternativeOptions()
        {
            List<ConfigurationOption> result = new List<ConfigurationOption>();
            if (this.Optional == true)
                return result;
            foreach (var exclOptions in Excluded_Options)
            {
                if (exclOptions.Count != 1)
                    continue;
                if (exclOptions[0].Parent == this.Parent && ((BinaryOption)exclOptions[0]).Optional == false)
                    result.Add(exclOptions[0]);
            }
            return result;
        }


        /// <summary>
        /// Collects all options that are excluded by this option, but do not have the same parent
        /// </summary>
        /// <returns>The list of cross-tree excluded options.</returns>
        public List<List<ConfigurationOption>> getNonAlternativeExlcudedOptions()
        {
            List<List<ConfigurationOption>> result = new List<List<ConfigurationOption>>();
            foreach (var exclOptions in Excluded_Options)
            {
                List<ConfigurationOption> temp = new List<ConfigurationOption>();
                if (exclOptions.Count != 1)
                {
                    result.Add(temp);
                    continue;
                }
                if (exclOptions[0].Parent != this.Parent)
                {
                    result.Add(exclOptions);
                }
                if (this.Optional && exclOptions[0].Parent == this.Parent && ((BinaryOption)exclOptions[0]).Optional)
                {
                    result.Add(exclOptions);
                }
            }

            return result;
        }
    }
}
