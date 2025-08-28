using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Zbozi
{
    public partial class zobrazeniRadku : Form
    {
        public zobrazeniRadku(int[] cislaRadku)
        {
            InitializeComponent();
            radkyKZobrazeni = cislaRadku;
        }

        private int[] radkyKZobrazeni;

        private void zobrazeniRadku_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(nacistRadky));
        }

        private void nacistRadky()
        {
            tabulka.SuspendLayout();

            // Add row number column first
            tabulka.Columns.Add("cisloradku", "Číslo řádku");

            // Add the rest of the columns from the worksheet
            for (int col = 1; col <= Zbozi.programConfig.stranka.LastColumnUsed().ColumnNumber(); col++)
            {
                string zahlavi = Zbozi.programConfig.stranka.Cell(1, col).Value.ToString();
                tabulka.Columns.Add(Zbozi.programConfig.stranka.Cell(1, col).Address.ToString(), zahlavi);
            }

            foreach (int radekKZobrazeni in radkyKZobrazeni)
            {
                var radek = Zbozi.programConfig.stranka.Row(radekKZobrazeni);
                var gridRadek = new DataGridViewRow();

                var bunkaCIsloRadku = new DataGridViewTextBoxCell();
                bunkaCIsloRadku.Value = radekKZobrazeni;
                gridRadek.Cells.Add(bunkaCIsloRadku);


                for (int col = 1; col <= Zbozi.programConfig.stranka.LastColumnUsed().ColumnNumber(); col++)
                {
                    var bunka = radek.Cell(col);
                    var gridBunka = new DataGridViewTextBoxCell();

                    if (bunka.DataType == XLDataType.DateTime) gridBunka.Value = bunka.GetDateTime().ToString("dd.MM.yyyy");
                    else if (bunka.DataType == XLDataType.Number) gridBunka.Value = Math.Round(bunka.GetDouble(), 2);
                    else if (bunka.DataType == XLDataType.Boolean) gridBunka.Value = bunka.GetBoolean() ? "Ano" : "Ne";
                    else gridBunka.Value = bunka.Value.ToString();

                    gridRadek.Cells.Add(gridBunka);
                }

                tabulka.Rows.Add(gridRadek);
            }

            tabulka.ResumeLayout();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ulozit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn sloupec in tabulka.Columns)
            {
                dt.Columns.Add(sloupec.HeaderText);
            }
            foreach (DataGridViewRow radek in tabulka.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < tabulka.Columns.Count; i++)
                {
                    dr[i] = radek.Cells[i].Value;
                }
                dt.Rows.Add(dr);
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Export");
                            wb.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Soubor byl úspěšně uložen.", "Uloženo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Při ukládání souboru došlo k chybě:\n" + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
