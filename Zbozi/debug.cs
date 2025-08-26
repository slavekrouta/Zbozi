using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Zbozi.Form1;

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
            vyskladneno.Text = Form1.programConfig.vyskladneno.ToString();
            radek.Text = Form1.programConfig.stranka.Column(1).LastCellUsed().Address.RowNumber.ToString();
            radky.Text = Form1.programConfig.radkyPocet.ToString();
            cntfirmy.Text = Form1.programConfig.data["Firmy"].Count.ToString();
            cntzbozi.Text = Form1.programConfig.data["Zboží"].Count.ToString();
            cntkody.Text = Form1.programConfig.data["Objednací čísla"].Count.ToString();
            path.Text = Form1.programConfig.souborPath;

            firmy.BeginUpdate();
            zbozi.BeginUpdate();
            kody.BeginUpdate();
            foreach (string firma in Form1.programConfig.data["Firmy"]) firmy.Items.Add(firma);
            foreach (string zboz in Form1.programConfig.data["Zboží"]) zbozi.Items.Add(zboz);
            foreach (string kod in Form1.programConfig.data["Objednací čísla"]) kody.Items.Add(kod);
            firmy.EndUpdate();
            zbozi.EndUpdate();
            kody.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
