using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Office2021.Excel.RichDataWebImage;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Zbozi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class programConfig
        {
            private static string _souborPath;
            public static string souborPath
            {
                get => _souborPath;
                set
                {
                    _souborPath = value;
                    if (!string.IsNullOrEmpty(value) && value.Contains('\\'))
                    {
                        souborName = value.Split('\\').Last();
                    }
                    else if (!string.IsNullOrEmpty(value.Trim()) && !value.Contains('\\'))
                    {
                        souborName = value;
                    }
                    else
                    {
                        souborName = string.Empty;
                    }
                }
            }

            public static string souborName { get; private set; }

            public static XLWorkbook sesit { get; set; }
            public static IXLWorksheet stranka { get; set; }
            public static void Dispose()
            {
                sesit?.Dispose();
                sesit = null;
                stranka = null;
                Firmy.Clear();
                radkyFirem.Clear();
                popiskyZbozi.Clear();
                radkyPopisku.Clear();
                souborVybran = false;
                souborNacteny = false;
                souborPath = string.Empty;
                objednaciCisla.Clear();
                radkyObjednacichCisel.Clear();
            }

            public static HashSet<string> Firmy = new HashSet<string>();
            public static Dictionary<string, List<int>> radkyFirem = new Dictionary<string, List<int>>();
            public static HashSet<string> popiskyZbozi = new HashSet<string>();
            public static Dictionary<string, List<int>> radkyPopisku = new Dictionary<string, List<int>>();
            public static HashSet<string> objednaciCisla = new HashSet<string>();
            public static Dictionary<string, List<int>> radkyObjednacichCisel = new Dictionary<string, List<int>>();
            public static bool souborVybran = false;
            public static bool souborNacteny = false;
        }
        private void clickVybratSoubor(object sender, EventArgs e)
        {
            if (!programConfig.souborVybran) vybratSoubor();
            else
            {
                if (MessageBox.Show("Opravdu chcete znovu vybrat soubor? V�echna data budou ztracena.", "Znovu vybrat soubor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    programConfig.Dispose();
                    labelSoubor.Text = "Soubor Nevybr�n";
                    textVyhledavac.Enabled = false;
                    textVyhledavac.Text = string.Empty;
                    buttonZobrazit.Enabled = false;
                    listVeci.Items.Clear();
                    listRadky.Items.Clear();
                    vybratSoubor();
                }
            }
        }
        private void clickNacistData(object sender, EventArgs e)
        {
            nacistData();
        }
        private void buttonZobrazit_Click(object sender, EventArgs e)
        {
            int[] cislaRadku = new int[listRadky.SelectedItems.Count];
            for (int i = 0; i < listRadky.SelectedItems.Count; i++)
            {
                if (int.TryParse(listRadky.SelectedItems[i].ToString(), out int cisloRadku)) cislaRadku[i] = cisloRadku;
                else
                {
                    MessageBox.Show($"��dek '{listRadky.SelectedItems[i]}' nen� platn� ��slo ��dku.", "Chyba p�i zpracov�n� ��dku", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            zobrazeniRadku zobrazeni = new zobrazeniRadku(cislaRadku);
            zobrazeni.ShowDialog();
        }
        private void vybratSoubor()
        {
            OpenFileDialog dialogVybratSoubor = new OpenFileDialog();
            dialogVybratSoubor.Filter = "V�echny podporovan�(*.xlsx; *.xlsm)|*.xlsx;*.xlsm|Excel 2007-x (*.xlsx)|*.xlsx|Excel 2007-x s makry (*.xlsm)|*.xlsm";
            dialogVybratSoubor.Title = "Vyberte Excelov� se�it";
            dialogVybratSoubor.Multiselect = false;

            if (dialogVybratSoubor.ShowDialog() == DialogResult.OK)
            {
                if (dialogVybratSoubor.FileName.EndsWith(".xlsm"))
                {
                    if (MessageBox.Show($"Soubor {dialogVybratSoubor.FileName.Split('\\').Last()} obsahuje makra. P�i pr�ci se souborem na n� nebude br�n ohled. P�ejete si pokra�ovat?", "Soubor obsahuje makra", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                        //if (programConfig.souborVybran && programConfig.souborNacteny)
                        //{
                        //    labelSoubor.Text = "Soubor Nevybr�n";
                        //    programConfig.Dispose();
                        //}
                        //else if (programConfig.souborNacteny)
                        //{
                        //    labelSoubor.Text = programConfig.souborName + " (Na�teno)";
                        //}
                        //else
                        //{
                        //    labelSoubor.Text = programConfig.souborName + " (Vybr�no)";
                        //} IDK co tohle m�lo d�lat, ale vypad� to, �e to bylo zbyte�n�. Spou�t�lo se to kdy� u�ivatel vybral Ne
                }
                
                programConfig.souborPath = dialogVybratSoubor.FileName;
                programConfig.souborVybran = true;
                labelSoubor.Text = programConfig.souborName + " (Vybr�no)";

                if (MessageBox.Show("P�ejete si nyn� na��st tabulku a z n� data?", "Na��st data?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nacistData();
                }
                else
                {
                    buttonSoubor.Text = "Na��st Data";
                    buttonSoubor.Click -= clickVybratSoubor;
                    buttonSoubor.Click += clickNacistData;
                }
            }
        }
        private async Task nacistData()
        {
            labelSoubor.Text = $"Otev�r�m soubor {programConfig.souborName}...";

            buttonSoubor.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            radekNacitani.Value = 0;
            radekNacitani.Visible = true;

            await Task.Run(() =>
            {
                try
                {
                    programConfig.sesit = new XLWorkbook(programConfig.souborPath);
                    programConfig.stranka = programConfig.sesit.Worksheet(1);

                    int posledniRadekCislo = programConfig.stranka.Column(1).LastCellUsed().Address.RowNumber;
                    int nacteno = 0;
                    
                    for (int i = 2; i <= posledniRadekCislo; i++)
                    {
                        if (string.IsNullOrEmpty(programConfig.stranka.Cell(i, 1).Value.ToString().Trim()) || string.IsNullOrEmpty(programConfig.stranka.Cell(i, 2).Value.ToString().Trim()))
                        {
                            Invoke(() =>
                            {
                                MessageBox.Show("Na ��dku " + i + " je pr�zdn� bu�ka. ��dek p�eskakuji.", "Pr�zdn� bu�ka");
                            });
                        }
                        else
                        {
                            string firma = programConfig.stranka.Cell(i, 2).GetString().Trim().ToUpper();
                            lock (programConfig.Firmy)
                            {
                                if (programConfig.Firmy.Add(firma)) programConfig.radkyFirem[firma] = new List<int>();
                                programConfig.radkyFirem[firma].Add(i);
                            }

                            string objednaciCislo = programConfig.stranka.Cell(i, 4).GetString().Trim();
                            lock (programConfig.objednaciCisla)
                            {
                                if (programConfig.objednaciCisla.Add(objednaciCislo)) programConfig.radkyObjednacichCisel[objednaciCislo] = new List<int>();
                                programConfig.radkyObjednacichCisel[objednaciCislo].Add(i);
                            }

                            string popisek = programConfig.stranka.Cell(i, 5).GetString().Trim();
                            lock (programConfig.popiskyZbozi)
                            {
                                if (programConfig.popiskyZbozi.Add(popisek)) programConfig.radkyPopisku[popisek] = new List<int>();
                                programConfig.radkyPopisku[popisek].Add(i);
                            }

                            nacteno++;
                            if (nacteno % 100 == 0 || nacteno == posledniRadekCislo - 1)
                            {
                                int pokrok = (int)((nacteno / (double)(posledniRadekCislo - 1)) * 100);
                                Invoke(() => radekNacitani.Value = pokrok);
                            }
                        }
                    }

                    programConfig.souborNacteny = true;
                }
                catch (System.InvalidOperationException ex)
                {
                    Invoke(() =>
                    {
                        MessageBox.Show("Se�it pravd�podobn� obsahuje pozn�mky (kter� mohly b�t vytvo�en� programem LibreOffice Calc). Bu� pozn�mky odeberte, nebo p�eve�te v Excelu na koment��e a klikn�te na Zkusit Znovu.\nChyba: " + ex.Message,
                            "Vyskytla se chyba");
                    });
                    programConfig.souborNacteny = false;
                }
                catch (Exception ex)
                {
                    Invoke(() =>
                    {
                        MessageBox.Show("Chyba p�i na��t�n� souboru: " + ex.Message);
                    });
                    programConfig.souborNacteny = false;
                }
            });

            Cursor.Current = Cursors.Default;
            buttonSoubor.Enabled = true;
            buttonSoubor.Text = "Vybrat Soubor";
            buttonSoubor.Click -= clickNacistData;
            buttonSoubor.Click += clickVybratSoubor;
            listVeci.Items.Clear();
            listRadky.Items.Clear();
            radekNacitani.Visible = false;

            if (programConfig.souborNacteny)
            {
                programConfig.Firmy = new HashSet<string>(programConfig.Firmy.OrderBy(f => f));
                labelSoubor.Text = programConfig.souborName + " (Na�teno)";
                textVyhledavac.Enabled = true;
                listKategorie.SetSelected(0, true);
            }
            else
            {
                labelSoubor.Text = "Soubor Nevybr�n";
                programConfig.Dispose();
            }

            //nactiSoubor:;
            //    try
            //    {
            //        programConfig.sesit = new XLWorkbook(programConfig.souborPath);
            //        labelSoubor.Text = "Vyb�r�m se�it...";
            //        programConfig.stranka = programConfig.sesit.Worksheet(1);
            //    }
            //    catch (System.InvalidOperationException ex)
            //    {
            //        if (MessageBox.Show("Se�it pravd�podobn� obsahuje pozn�mky (kter� mohly b�t vytvo�en� programem LibreOffice Calc). Bu� pozn�mky odeberte, nebo p�eve�te v Excelu na koment��e a klikn�te na Zkusit Znovu.\nChyba: " + ex.Message, "Vyskytla se chyba", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
            //        {
            //            goto nactiSoubor;
            //        }
            //        else
            //        {
            //            labelSoubor.Text = "Soubor Nevybr�n";
            //            programConfig.souborPath = string.Empty;
            //            programConfig.Firmy.Clear();
            //        }
            //    }
        }
        private void listKategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            textVyhledavac.Text = string.Empty;
            listVeci.BeginUpdate();
            listVeci.Items.Clear();
            listRadky.Items.Clear();

            if (listKategorie.SelectedItem == "Firmy")
            {
                foreach (string firma in programConfig.Firmy)
                    listVeci.Items.Add(firma);
            }
            else if (listKategorie.SelectedItem == "Zbo��")
            {
                foreach (string popisek in programConfig.popiskyZbozi)
                    listVeci.Items.Add(popisek);
            }
            else
            {
                listVeci.Items.Add("Nen� vybr�na ��dn� kategorie.");
            }
            listVeci.EndUpdate();
        }
        private void clickVec(object sender, EventArgs e)
        {
            if (programConfig.souborNacteny)
            {
                listRadky.Items.Clear();

                if (listKategorie.SelectedItem.ToString() == "Firmy" || listKategorie.SelectedItem == null)
                {

                    foreach (string vec in listVeci.SelectedItems)
                    {
                        foreach (int cisloRadku in programConfig.radkyFirem[vec])
                        {
                            listRadky.Items.Add(cisloRadku);
                        }
                    }
                }
                else if (listKategorie.SelectedItem.ToString() == "Zbo��")
                {
                    foreach (string vec in listVeci.SelectedItems)
                    {
                        foreach (int cisloRadku in programConfig.radkyPopisku[vec])
                        {
                            listRadky.Items.Add(cisloRadku);
                        }
                    }
                }
            }
            else
            {
                listRadky.Items.Clear();
                foreach (string slovo in "Nen� na�ten ��dn� soubor!".Split()) listRadky.Items.Add(slovo);
            }
        }
        private void listRadky_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listRadky.SelectedItems.Count > 0) buttonZobrazit.Enabled = true;
            else buttonZobrazit.Enabled = false;

            if (listRadky.SelectedItems.Count == 1) buttonZobrazit.Text = "Zobrazit ��dek";
            else buttonZobrazit.Text = "Zobrazit ��dky";
        }
        private void textVyhledavac_TextChanged(object sender, EventArgs e)
        {
            listVeci.BeginUpdate();
            listVeci.Items.Clear();

            string hledam = textVyhledavac.Text;
            if (listKategorie.SelectedItem.ToString() == "Firmy")
            {
                foreach (string firma in programConfig.Firmy)
                {
                    if (firma.Contains(hledam, StringComparison.OrdinalIgnoreCase))
                    {
                        listVeci.Items.Add(firma);
                    }
                }
            }
            else if (listKategorie.SelectedItem.ToString() == "Zbo��")
            {
                foreach (string popisek in programConfig.popiskyZbozi)
                {
                    if (popisek.Contains(hledam, StringComparison.OrdinalIgnoreCase))
                    {
                        listVeci.Items.Add(popisek);
                    }
                }
            }

            listVeci.EndUpdate();
        }
    }
}