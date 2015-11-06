using PAT.GUI.Docking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PAT.GUI.Helper
{
    public abstract class GenerationHelper
    {
        protected string mFileName;
        protected EditorTabItem mTabItem;
        protected bool mLoaded;

        public GenerationHelper(String name, EditorTabItem tabItem)
        {
            mFileName = name;
            mTabItem = tabItem;
            mLoaded = false;
        }

        public abstract XmlDocument GenerateXML(params bool[] values);

        public abstract bool canExport();

        public string GetGeneratedFileName()
        {
            return mFileName;
        }

    }
}
