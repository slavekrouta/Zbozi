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

            for (int col = 1; col <= Form1.programConfig.stranka.LastColumnUsed().ColumnNumber(); col++)
            {
                string zahlavi = Form1.programConfig.stranka.Cell(1, col).Value.ToString();
                tabulka.Columns.Add(Form1.programConfig.stranka.Cell(1, col).Address.ToString(), zahlavi);
            }

            foreach (int radekKZobrazeni in radkyKZobrazeni)
            {
                var radek = Form1.programConfig.stranka.Row(radekKZobrazeni);
                var gridRadek = new DataGridViewRow();

                for (int col = 1; col <= Form1.programConfig.stranka.LastColumnUsed().ColumnNumber(); col++)
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
    }
}
