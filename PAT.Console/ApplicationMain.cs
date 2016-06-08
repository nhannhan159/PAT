using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using PAT.Common;
using PAT.Common.Classes.ModuleInterface;

namespace PAT.Console
{
    class ApplicationMain
    {
        private ModuleFacadeBase CurrentModule;
        private SpecificationBase Specification;
        private SpecificationWorker SpecWorker;

        private string ModuleName;
        private string Text;
        private string FileName;

        public ApplicationMain(string fileName)
        {
            this.FileName = fileName;
            this.Text = System.IO.File.ReadAllText(this.FileName);
            this.ModuleName = "PN";
        }

        public void startVerify()
        {
            if (this.LoadModule(this.ModuleName))
            {
                this.Specification = ParseSpecification();
                this.SpecWorker = new SpecificationWorker(this.Specification);
                this.SpecWorker.startVerification(this.SpecWorker.mSpec.AssertionDatabase.First().Key);
            } else
            {
                System.Console.WriteLine("Error had occur!");
            }
        }

        private SpecificationBase ParseSpecification()
        {
            SpecificationBase spec = null;
            try
            {
                string moduleName = this.ModuleName;
                string fileFullName = (new FileInfo(this.FileName)).FullName;
                spec = CurrentModule.ParseSpecification(this.Text, "", fileFullName);
                if (spec != null && spec.Errors.Count == 0)
                    return spec;
                else
                    return null;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }

            return null;
        }

        private bool LoadModule(string moduleName)
        {
            try
            {
                string facadeClass = "PAT." + moduleName + ".ModuleFacade";
                string file = (new FileInfo("PAT.Module." + moduleName + ".dll")).FullName;

                Assembly assembly = Assembly.LoadFrom(file);
                CurrentModule = (ModuleFacadeBase)assembly.CreateInstance(
                                                           facadeClass,
                                                           true,
                                                           BindingFlags.CreateInstance,
                                                           null, null,
                                                           null, null);

                if (CurrentModule.GetType().Namespace != "PAT." + moduleName)
                {
                    CurrentModule = null;
                    return false;
                }
                CurrentModule.ReadConfiguration();

                return true;
            }
            catch { }

            return false;
        }

    }
}
