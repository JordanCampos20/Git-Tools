using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateIssueAuto
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;

            string? text;

            string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            List<string> lstProjects = Directory.GetDirectories(txtFolder.Text).ToList();

            Dictionary<string, string> output = new Dictionary<string, string>();

            foreach (string proj in lstProjects)
            {
                List<string> lstSubProjects = Directory.GetDirectories(proj).ToList();

                foreach (var subproj in lstSubProjects)
                {
                    if (subproj.Contains(".git"))
                    {
                        text = string.Empty;
                        using (Process process = new Process())
                        {
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.RedirectStandardInput = true;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.Start();
                            process.StandardInput.WriteLine($"cd {proj}");
                            process.StandardInput.WriteLine($"git status");
                            process.StandardInput.WriteLine("exit");
                            while (!process.StandardOutput.EndOfStream)
                                text += "\t" + process.StandardOutput.ReadLine() + "\n";
                            output.Add(proj, text);
                            process.WaitForExit();
                            break;
                        }
                    }
                }
            }

            if (output.Count > 0)
            {
                foreach (var item in output)
                {
                    if (!item.Value.Contains("nothing to commit, working tree clean"))
                    {
                        using (StreamWriter sw = new StreamWriter(Path.Combine(Desktop, "PENDENTES.md"), true))
                        {
                            sw.WriteLine($"# {item.Key}");
                            sw.WriteLine($"{item.Value}");
                            sw.Close();
                        }
                    }
                }
            }
            btnSearch.Enabled = true;

            MessageBox.Show("Finalizado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            ClearFields();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            string project = folderBrowserDialog1.SelectedPath;

            List<string> lstFoldersInProject = Directory.GetDirectories(project).ToList();

            foreach (var folder in lstFoldersInProject)
            {
                if (folder.Contains(".git"))
                {
                    txtFolder.Text = project;
                }
            }
        }

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            if (txtFolder.Text.Length > 0)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

        private void ClearFields()
        {
            txtFolder.Text = "";
        }
    }
}
