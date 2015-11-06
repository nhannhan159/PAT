using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using PAT.Common.Utility;

namespace PAT.GUI.LatexFunction
{
    public partial class ExportLatexFile : Form
    {
        private static string ROOT_LATEX_PATH = Utilities.ROOT_WORKING_PATH + "\\latex";
        private static string TMP_LATEX_PATH = ROOT_LATEX_PATH + "\\tmp";
        private string pathFolder, pathFinal, pathNode;

        string[] listfile = new string[9];
        string[] listfile_after = new string[9];
        string[] listfile_2;


        public ExportLatexFile()
        {
            InitializeComponent();

            // Init GUI
            lblPath.Text = "Import from path: " + TMP_LATEX_PATH;
        }


        private void btn_import_Click(object sender, EventArgs e)
        {
            do
            {
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.SelectedPath = TMP_LATEX_PATH;
                if (f.ShowDialog() == DialogResult.OK)
                    pathFolder = f.SelectedPath;

                if (pathFolder == null)
                    break;

                listfile = Directory.GetFiles(pathFolder);
                sort();

                foreach (string file in listfile_after)
                {
                    if (file != null)
                        listBox1.Items.Add(file);
                }
            } while (false);
        }

        public void sort()
        {
            for (int i = 0; i < listfile.Length; i++)
            {
                if (listfile[i].Contains("unicast_fm")) listfile_after[0] = listfile[i];
                else if (listfile[i].Contains("unicast_cm")) listfile_after[1] = listfile[i];
                else if (listfile[i].Contains("unicast_sm")) listfile_after[2] = listfile[i];
                else if (listfile[i].Contains("broadcast_fm")) listfile_after[3] = listfile[i];
                else if (listfile[i].Contains("broadcast_cm")) listfile_after[4] = listfile[i];
                else if (listfile[i].Contains("broadcast_sm")) listfile_after[5] = listfile[i];
                else if (listfile[i].Contains("multicast_fm")) listfile_after[6] = listfile[i];
                else if (listfile[i].Contains("multicast_cm")) listfile_after[7] = listfile[i];
                else if (listfile[i].Contains("multicast_sm")) listfile_after[8] = listfile[i];
            }
            for (int i = 0; i < listfile_after.Length - 1; i++)
            {
                for (int j = i + 1; j < listfile_after.Length; j++)
                {
                    if (listfile_after[i] == null)
                    {
                        if (listfile_after[j] != null)
                        {
                            listfile_after[i] = listfile_after[j];
                            listfile_after[j] = null;
                        }
                    }
                }
            }

        }

        private void readfilefromListBox(ListBox listbox)
        {
            try
            {
                ListBox.ObjectCollection Itemlist = listbox.Items;
                foreach (var item in Itemlist)
                {

                    FileStream mywriteFile = new FileStream(pathNode, FileMode.Append);
                    StreamWriter swFile = new StreamWriter(mywriteFile);

                    String pathread = item.ToString();
                    String[] str;
                    str = File.ReadAllLines(pathread);
                    foreach (String s in str)
                        swFile.WriteLine(s);

                    swFile.Close();
                    mywriteFile.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void readfilefromListBoxFinal(ListBox listbox)
        {
            try
            {
                ListBox.ObjectCollection Itemlist = listbox.Items;
                listfile_2 = new string[Itemlist.Count];
                int count = 0;
                foreach (var item in Itemlist)
                {
                    listfile_2[count] = item.ToString();
                    count++;
                }

                int i = 0, d = 0;
                while (i < listfile_2.Length)
                {
                    createBeginTable();
                    for (int j = i; j <= i + 2; j++)
                    {
                        if (listfile_2[j] != null)
                        {
                            FileStream mywriteFile = new FileStream(pathFinal, FileMode.Append);
                            StreamWriter swFile = new StreamWriter(mywriteFile);
                            String[] str;

                            str = File.ReadAllLines(listfile_2[j]);
                            foreach (String s in str)
                                swFile.WriteLine(s);

                            swFile.Close();
                            mywriteFile.Close();
                            d++;
                        }
                    }
                    if (d == 3)
                    {
                        if (listfile_2[i + 3] != null)
                        {
                            createEndTable();
                            FileStream myFile = new FileStream(pathFinal, FileMode.Append);
                            StreamWriter sFile = new StreamWriter(myFile);
                            sFile.Write(String.Format("\\pagebreak\n"));
                            sFile.Close();
                            myFile.Close();
                            d = 0; i = i + 3;
                        }
                        else
                        {
                            createEndTable();
                        }
                    }
                    else break;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save1 = new SaveFileDialog();
                save1.Filter = "Latex files (*.tex)|*.tex|All files (*.*)|*.*";
                if (save1.ShowDialog() == DialogResult.OK)
                {
                    pathNode = save1.FileName;
                }
                if (pathNode != null)
                {
                    readfilefromListBox(listBox1);
                    MessageBox.Show("Complete latex file for this test case !!!");
                    Close();
                }

            }
            catch (ApplicationException ae)
            {
                MessageBox.Show("" + ae);
            }
        }

        private void btn_importfull_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string s = openFileDialog1.FileName;
                listBox2.Items.AddRange(openFileDialog1.FileNames);

            }
            //if (dr == DialogResult.Cancel)
            //{

            //}
        }

        private void MoveListBoxItems(ListBox source, ListBox destination)
        {
            ListBox.SelectedObjectCollection sourceItems = source.SelectedItems;
            foreach (var item in sourceItems)
            {
                destination.Items.Add(item);
            }
            while (source.SelectedItems.Count > 0)
            {
                source.Items.Remove(source.SelectedItems[0]);
            }
        }

        private void btn_forward_Click_1(object sender, EventArgs e)
        {
            MoveListBoxItems(listBox2, listBox3);
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            MoveListBoxItems(listBox3, listBox2);
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save1 = new SaveFileDialog();
                save1.Filter = "Latex files (*.tex)|*.tex|All files (*.*)|*.*";
                if (save1.ShowDialog() == DialogResult.OK)
                {
                    pathFinal = save1.FileName;
                }
                if (pathFinal != null)
                {
                    createBeginFile();
                    readfilefromListBoxFinal(listBox3);
                    createEndFile();
                    MessageBox.Show("Complete final latex file !!!");
                    Close();
                }

            }
            catch (ApplicationException ae)
            {
                MessageBox.Show("" + ae);
            }
        }

        public void createBeginFile()
        {
            FileStream myFile = new FileStream(pathFinal, FileMode.Create);
            StreamWriter srFile = new StreamWriter(myFile);
            srFile.Write(String.Format(""));
            srFile.Write(String.Format("\\documentclass[12pt]{{article}}\n\n"));
            srFile.Write(String.Format("\\usepackage{{makecell}}\n"));
            srFile.Write(String.Format("\\usepackage{{graphicx,multirow}}\n"));
            srFile.Write(String.Format("\\usepackage{{tabularx}}\n"));
            srFile.Write(String.Format("\\usepackage[table]{{xcolor}}\n\n"));
            srFile.Write(String.Format("\\begin{{document}}\n\n"));
            srFile.Write(String.Format("\\newcommand{{\\na}}{{Non Abstraction}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\ca}}{{Channels Abstraction}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\sa}}{{Sensors Abstraction}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\vl}}{{\\cellcolor{{green!20}}Valid}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\nv}}{{\\cellcolor{{red!20}}Not valid}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\dl}}{{\\textit{{deadlockfree}}}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\rd}}{{\textit{{chk-reach-dest}}}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\sen}}{{\\textit{{chk-sensor-congestion}}}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\chan}}{{\\textit{{chk-channel-congestion}}}}\n\n"));
            srFile.Write(String.Format("\\newcommand{{\\uc}}{{\\textit{{Unicast}}}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\bc}}{{\\textit{{Broadcast}}}}\n"));
            srFile.Write(String.Format("\\newcommand{{\\mc}}{{\\textit{{Multicast}}}}\n\n"));
            srFile.Write(String.Format("\\newcommand{{\\fm}}{{Full Memory at }}\n"));
            srFile.Write(String.Format("\\newcommand{{\\tio}}{{Timeout at }}\n"));
            srFile.Write(String.Format("\\renewcommand\\theadfont{{\\bfseries}}\n"));
            srFile.Write(String.Format("%\\renewcommand\\theadgape{{\\Gape[4pt]}}\n"));
            srFile.Write(String.Format("%\\renewcommand\\cellgape{{\\Gape[4pt]}}\n\n"));


            srFile.Close();
            myFile.Close();
        }

        private void createBeginTable()
        {
            FileStream myFile = new FileStream(pathFinal, FileMode.Append);
            StreamWriter srFile = new StreamWriter(myFile);
            srFile.Write(String.Format("\\begin{{table}}\n\n"));
            srFile.Write(String.Format("\\centering\n"));
            srFile.Write(String.Format("\\resizebox{{1.2\\textwidth}}{{!}} {{\n"));
            srFile.Write(String.Format("\\begin{{tabular}}{{|c|c|c|c|c|c|c|c|c|c|}}\n\n"));
            srFile.Write(String.Format("% title\n"));
            srFile.Write(String.Format("\\hline\n"));
            srFile.Write(String.Format("\\thead{{Number of \\\\Sensors}} & \\thead{{Number of \\\\Packets}} & \\thead{{Bandwidth / \\\\Buffer}} & \\thead{{Sending Mode}} & \\thead{{Model}} & \\thead{{Property}} & \\thead{{Used \\\\memory}} & \\thead{{Total \\\\transitions}} & \\thead{{Visited \\\\states}} & \\thead{{Result}}\\\\\n"));
            srFile.Write(String.Format("\\hline\n\n"));
            srFile.Close();
            myFile.Close();
        }

        private void createEndTable()
        {
            FileStream myFile = new FileStream(pathFinal, FileMode.Append);
            StreamWriter swFile = new StreamWriter(myFile);
            swFile.Write(String.Format("\n\\end{{tabular}}\n"));
            swFile.Write(String.Format("}}\n"));
            swFile.Write(String.Format("\t\\caption{{Experiment result}}\n"));
            swFile.Write(String.Format("\t\\label{{table:experiments}}\n\n"));
            swFile.Write(String.Format("\\end{{table}}\n\n"));
            swFile.Close();
            myFile.Close();
        }

        private void createEndFile()
        {
            createEndTable();
            FileStream myFile = new FileStream(pathFinal, FileMode.Append);
            StreamWriter swFile = new StreamWriter(myFile);
            swFile.Write(String.Format("\\end{{document}}\n\n"));
            swFile.Close();
            myFile.Close();
        }

        private void btn_temp_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", TMP_LATEX_PATH);
        }
    }
}
