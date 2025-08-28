using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Windows.Forms;
using static Zbozi.Zbozi;

namespace Zbozi
{
    public partial class debug : Form
    {
        public debug()
        {
            InitializeComponent();
        }

        private void debug_Load(object sender, EventArgs e)
        {
            vyskladneno.Text = Zbozi.programConfig.vyskladneno.ToString();
            posledniradek.Text = Zbozi.programConfig.stranka.Column(1).LastCellUsed().Address.RowNumber.ToString();
            radky.Text = Zbozi.programConfig.radkyPocet.ToString();
            pocetfirmy.Text = Zbozi.programConfig.data["Firmy"].Count.ToString();
            pocetzbozi.Text = Zbozi.programConfig.data["Zboží"].Count.ToString();
            pocetkody.Text = Zbozi.programConfig.data["Objednací čísla"].Count.ToString();
            path.Text = Zbozi.programConfig.souborPath;

            firmy.BeginUpdate();
            zbozi.BeginUpdate();
            kody.BeginUpdate();
            foreach (string firma in Zbozi.programConfig.data["Firmy"]) firmy.Items.Add(firma);
            foreach (string zboz in Zbozi.programConfig.data["Zboží"]) zbozi.Items.Add(zboz);
            foreach (string kod in Zbozi.programConfig.data["Objednací čísla"]) kody.Items.Add(kod);
            firmy.EndUpdate();
            zbozi.EndUpdate();
            kody.EndUpdate();
        }
        private string folderPath;
        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Vyberte složku pro uložení dat";
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    progressBar1.Visible = true;

                    string soubor = string.Empty;
                    folderPath = fbd.SelectedPath + "\\zbozidebug";
                    System.IO.Directory.CreateDirectory(folderPath);
                    foreach (var seznam in this.Controls.OfType<ListBox>())
                    {
                        soubor = string.Empty;
                        foreach (var vec in seznam.Items) soubor += vec.ToString() + Environment.NewLine;
                        File.WriteAllText(folderPath + "\\" + seznam.Name + ".txt", soubor);
                        progressBar1.PerformStep();
                    }

                    Label[] popisky = [radky, vyskladneno, posledniradek, pocetfirmy, pocetzbozi, pocetkody, path];
                    soubor = string.Empty;

                    foreach (var popisek in popisky)
                    {
                        soubor += popisek.Name + ": " + popisek.Text + Environment.NewLine;
                        progressBar1.PerformStep();
                    }
                    File.WriteAllText(folderPath + "\\popisky.txt", soubor);
                    soubor = string.Empty;

                    File.Copy(Zbozi.programConfig.souborPath, folderPath + "\\" + Zbozi.programConfig.souborName);
                    progressBar1.PerformStep();

                    ZipFile.CreateFromDirectory(folderPath, folderPath + ".zip");
                    progressBar1.PerformStep();

                    MessageBox.Show("Uloženo", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    progressBar1.Visible = false;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            firmy.BeginUpdate();
            firmy.Items.Clear();

            string hledam = textBox1.Text;
            if (string.IsNullOrEmpty(hledam))
                foreach (string vec in programConfig.data["Firmy"])
                {
                    firmy.Items.Add(vec);
                }
            else
                foreach (string vec in programConfig.data["Firmy"])
                {
                    if (vec.Contains(hledam, StringComparison.OrdinalIgnoreCase))
                    {
                        firmy.Items.Add(vec);
                    }
                }

            firmy.EndUpdate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            zbozi.BeginUpdate();
            zbozi.Items.Clear();

            string hledam = textBox2.Text;
            if (string.IsNullOrEmpty(hledam))
            {
                foreach (string vec in programConfig.data["Zboží"]) zbozi.Items.Add(vec);
            }
            else
            {
                foreach (string vec in programConfig.data["Zboží"])
                {
                    if (vec.Contains(hledam, StringComparison.OrdinalIgnoreCase)) firmy.Items.Add(vec);
                }
            }

            zbozi.EndUpdate();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            kody.BeginUpdate();
            kody.Items.Clear();

            string hledam = textBox3.Text;
            if (string.IsNullOrEmpty(hledam))
            {
                foreach (string vec in programConfig.data["Objednací čísla"]) kody.Items.Add(vec);
            }
            else
            {
                foreach (string vec in programConfig.data["Objednací čísla"])
                {
                    if (vec.Contains(hledam, StringComparison.OrdinalIgnoreCase)) kody.Items.Add(vec);
                }
            }

            kody.EndUpdate();
        }
    }
}
