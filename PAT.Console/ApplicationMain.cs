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
        public SpecificationBase Specification;

        public void readFile(string filename)
        {
            EditorTabItem ret = null;

            do
            {
                int N = DockContainer.Documents.Length;
                for (int i = 0; i < N; i++)
                {
                    EditorTabItem item = DockContainer.Documents[i] as EditorTabItem;
                    if (item == null)
                        continue;

                    if (item.FileName == filename || (!Common.Utility.Utilities.IsWindowsOS && item.FileName.EndsWith(filename)))
                    {
                        item.Activate();
                        CurrentActiveTab = item;
                        SetAllFileNameLabel(filename);
                        ret = item;
                        break;
                    }
                }

                if (ret != null) // Get Item success
                    break;

                if (File.Exists(filename) == false)
                {
                    if (ShowMessageBox)
                    {
                        MessageBox.Show(Resources.Open_Error__the_selected_file_is_not_found_,
                            Utilities.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }

                try
                {
                    SyntaxMode ModuleSyntax = null;
                    foreach (SyntaxMode syntax in Languages)
                    {
                        foreach (string extension in syntax.Extensions)
                        {
                            if (filename.ToLower().EndsWith(extension))
                            {
                                ModuleSyntax = syntax;
                                break;
                            }
                        }

                        if (ModuleSyntax != null)
                            break;
                    }

                    if (ModuleSyntax == null)
                    {
                        if (ShowMessageBox)
                            MessageBox.Show(Resources.Error_happened_in_opening_ + filename + ".\r\n" + Resources.File_format_is_not_supported_by_PAT_, Common.Utility.Utilities.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    try
                    {
                        OpenFilter = "";
                        foreach (SyntaxMode syntax in Languages)
                        {
                            if (ModuleSyntax.Name == syntax.Name)
                                OpenFilter = syntax.Name + " (*" + syntax.ExtensionString + ")|*" + syntax.ExtensionString + "|" + OpenFilter;
                            else
                                OpenFilter += syntax.Name + " (*" + syntax.ExtensionString + ")|*" + syntax.ExtensionString + "|";
                        }

                        OpenFilter += "All File (*.*)|*.*";
                    }
                    catch (Exception) { }

                    EditorTabItem tabItem = this.AddDocument(ModuleSyntax.Name);
                    tabItem.Open(filename);
                    AddRecent(filename);
                    SetAllFileNameLabel(filename);
                    if (tabItem.TabText.EndsWith("*"))
                        tabItem.TabText = tabItem.TabText.TrimEnd('*');
                    this.StatusLabel_Status.Text = "Ready";
                    ret = tabItem;
                }
                catch (Exception ex)
                {
                    if (ShowMessageBox)
                    {
                        MessageBox.Show(Resources.Open_Error_ + ex.Message + "\r\n" + Resources.Please_make_sure_that_the_format_is_correct_,
                            Utilities.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    DevLog.d(TAG, ex.Message);
                }


            } while (false);
            return ret;
        }

        public void startVerify()
        {
            
        }

        private bool LoadModule(string moduleName)
        {
            try
            {
                if (Common.Utility.Utilities.ModuleDictionary.ContainsKey(moduleName))
                {
                    if (CurrentModule == null || moduleName != CurrentModule.ModuleName)
                    {
                        CurrentModule = Common.Utility.Utilities.ModuleDictionary[moduleName];
                    }
                }
                else
                {
                    string facadeClass = "PAT." + moduleName + ".ModuleFacade";
                    string file = Path.Combine(Path.Combine(Common.Utility.Utilities.ModuleFolderPath, moduleName), "PAT.Module." + moduleName + ".dll");

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
                }

                return true;
            }
            catch { }

            return false;
        }
    }
}
