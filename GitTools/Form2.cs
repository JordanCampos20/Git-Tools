using System.Diagnostics;

namespace CreateIssueAuto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnValidations();
            btnSave.Enabled = false;

            string text = string.Empty;

            string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Dictionary<string, string> output = new Dictionary<string, string>();

            for (int i = Convert.ToInt32(txtNrIssuesMin.Text); i <= Convert.ToInt32(txtNrIssuesMax.Text); i++)
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    process.StandardInput.WriteLine($"cd \"{txtFolder.Text}\"");
                    process.StandardInput.WriteLine($"gh issue create -a \"@me\" -t \"{txtTitle.Text} {i}\" -b \"{txtBody.Text} {i}\"");
                    process.StandardInput.WriteLine("exit");
                    while (!process.StandardOutput.EndOfStream)
                        text += "\t" + process.StandardOutput.ReadLine() + "\n";
                    output.Add(txtFolder.Text, text);
                    process.WaitForExit();
                }
            }

            if (output.Count > 0)
            {
                foreach (var item in output)
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(Desktop, "create-issues.md"), true))
                    {
                        sw.WriteLine($"# {item.Key}");
                        sw.WriteLine($"{item.Value}");
                        sw.Close();
                    }
                }
            }

            btnSave.Enabled = true;

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
            txtNrIssuesMin.Text = "0";
            txtNrIssuesMax.Text = "0";
            txtFolder.Text = "";
            txtTitle.Text = "";
            txtBody.Text = "";
        }

        private void OnValidations()
        {
            if (!double.TryParse(txtNrIssuesMin.Text, out _))
            {
                MessageBox.Show("Minimo não é número");
                return;
            }
            if (!double.TryParse(txtNrIssuesMax.Text, out _))
            {
                MessageBox.Show("Maximo não é número");
                return;
            }

            if (txtTitle.Text.Length == 0)
            {
                MessageBox.Show("Sem Titulo");
                return;
            }

            if (txtBody.Text.Length == 0)
            {
                MessageBox.Show("Sem corpo");
                return;
            }

            if (Convert.ToInt32(txtNrIssuesMin.Text) > Convert.ToInt32(txtNrIssuesMax.Text))
            {
                MessageBox.Show("Minimo maior que maximo");
                return;
            }
            else
            {
                if (Convert.ToInt32(txtNrIssuesMin.Text) == 0)
                {
                    MessageBox.Show("Minimo não pode ser zero");
                    return;
                }
            }
        }
    }
}
