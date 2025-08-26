using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Office2021.Excel.RichDataWebImage;
using DocumentFormat.OpenXml.Packaging;
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
                data.Clear();
                radky.Clear();
                souborVybran = false;
                souborNacteny = false;
                souborPath = string.Empty;
                vyskladneno = 0;
                radkyPocet = 0;
            }

            //public static HashSet<string> Firmy = new HashSet<string>();
            //public static Dictionary<string, HashSet<int>> radkyFirem = new Dictionary<string, HashSet<int>>();
            //public static HashSet<string> popiskyZbozi = new HashSet<string>();
            //public static Dictionary<string, HashSet<int>> radkyPopisku = new Dictionary<string, HashSet<int>>();
            //public static HashSet<string> objednaciCisla = new HashSet<string>();
            //public static Dictionary<string, HashSet<int>> radkyObjednacichCisel = new Dictionary<string, HashSet<int>>();
            public static Dictionary<string, HashSet<string>> data = new Dictionary<string, HashSet<string>>()
            {
                { "Firmy", new HashSet<string>() },
                { "Zbo��", new HashSet<string>() },
                { "Objednac� ��sla", new HashSet<string>() },
                { "Filtrovan�", new HashSet<string>() }
            };
            public static Dictionary<string, Dictionary<string, HashSet<int>>> radky = new Dictionary<string, Dictionary<string, HashSet<int>>>()
            {
                { "Firmy", new Dictionary<string, HashSet<int>>() },
                { "Zbo��", new Dictionary<string, HashSet<int>>() },
                { "Objednac� ��sla", new Dictionary<string, HashSet<int>>() },
                { "Filtrovan�", new Dictionary<string, HashSet<int>>() }
            };
            public static bool souborVybran = false;
            public static bool souborNacteny = false;
            public static int vyskladneno = 0;
            public static int radkyPocet = 0;
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
                    textVyhledavacLevy.Enabled = false;
                    textVyhledavacLevy.Text = string.Empty;
                    buttonZobrazit.Enabled = false;
                    listVeciLevy.Items.Clear();
                    listVeciPravy.Items.Clear();
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
                        else if (string.IsNullOrEmpty(programConfig.stranka.Cell(i, 15).Value.ToString().Trim()))
                        {
                            programConfig.radkyPocet++;
                            string firma = programConfig.stranka.Cell(i, 2).GetString().Trim().ToUpper();
                            lock (programConfig.data["Firmy"])
                            {
                                if (programConfig.data["Firmy"].Add(firma)) programConfig.radky["Firmy"][firma] = new HashSet<int>();
                                programConfig.radky["Firmy"][firma].Add(i);
                            }

                            string objednaciCislo = programConfig.stranka.Cell(i, 4).GetString().Trim();
                            lock (programConfig.data["Objednac� ��sla"])
                            {
                                if (programConfig.data["Objednac� ��sla"].Add(objednaciCislo)) programConfig.radky["Objednac� ��sla"][objednaciCislo] = new HashSet<int>();
                                programConfig.radky["Objednac� ��sla"][objednaciCislo].Add(i);
                            }

                            string popisek = programConfig.stranka.Cell(i, 5).GetString().Trim();
                            lock (programConfig.data["Zbo��"])
                            {
                                if (programConfig.data["Zbo��"].Add(popisek)) programConfig.radky["Zbo��"][popisek] = new HashSet<int>();
                                programConfig.radky["Zbo��"][popisek].Add(i);
                            }

                            nacteno++;
                            if (nacteno % 100 == 0 || nacteno == posledniRadekCislo - 1)
                            {
                                int pokrok = (int)((nacteno / (double)(posledniRadekCislo - 1)) * 100);
                                Invoke(() => radekNacitani.Value = pokrok);
                            }
                        }
                        else programConfig.vyskladneno++;
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
            listVeciLevy.Items.Clear();
            listRadky.Items.Clear();
            radekNacitani.Visible = false;

            if (programConfig.souborNacteny)
            {
                programConfig.data["Firmy"] = new HashSet<string>(programConfig.data["Firmy"].OrderBy(f => f));
                labelSoubor.Text = programConfig.souborName + " (Na�teno)";
                textVyhledavacLevy.Enabled = true;
                textVyhledavacPravy.Enabled = true;
                listKategorieVlevo.SelectionMode = SelectionMode.One;
                listKategorieVpravo.SelectionMode = SelectionMode.One;
                listVeciLevy.SelectionMode = SelectionMode.MultiExtended;
                listVeciPravy.SelectionMode = SelectionMode.MultiExtended;
                listRadky.SelectionMode = SelectionMode.MultiExtended;
                listKategorieVlevo.SetSelected(0, true);
                listKategorieVpravo.SetSelected(1, true);
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
        private void listKategorieVlevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            textVyhledavacLevy.Text = string.Empty;
            listVeciLevy.BeginUpdate();
            listVeciLevy.Items.Clear();
            listRadky.Items.Clear();

            foreach (string vec in programConfig.data[listKategorieVlevo.SelectedItem.ToString()])
                listVeciLevy.Items.Add(vec);

            listVeciLevy.EndUpdate();
        }
        private void listKategorieVpravo_SelectedIndexChanged(object sender, EventArgs e)
        {
            textVyhledavacPravy.Text = string.Empty;
            listVeciPravy.BeginUpdate();
            listVeciPravy.Items.Clear();
            listRadky.Items.Clear();
            programConfig.data["Filtrovan�"].Clear();
            programConfig.radky["Filtrovan�"].Clear();
            foreach (string vecLevy in listVeciLevy.SelectedItems)
            {
                foreach (string vecPravy in programConfig.data[listKategorieVpravo.SelectedItem.ToString()])
                {
                    var spolecneRadky = programConfig.radky[listKategorieVlevo.SelectedItem.ToString()][vecLevy]
                        .Intersect(programConfig.radky[listKategorieVpravo.SelectedItem.ToString()][vecPravy]);
                    if (spolecneRadky.Any())
                    {
                        if (programConfig.data["Filtrovan�"].Add(vecPravy)) programConfig.radky["Filtrovan�"][vecPravy] = new HashSet<int>();
                        foreach (int cisloRadku in spolecneRadky)
                        {
                            programConfig.radky["Filtrovan�"][vecPravy].Add(cisloRadku);
                        }
                    }
                }
            }
            programConfig.data["Filtrovan�"] = new HashSet<string>(programConfig.data["Filtrovan�"].OrderBy(v => v));
            foreach (string vec in programConfig.data["Filtrovan�"])
            {
                listVeciPravy.Items.Add(vec);
            }

            listVeciPravy.EndUpdate();
        }
        private void clickVecVlevo(object sender, EventArgs e)
        {
            // takhle: kdyz kliknu na neco vlevo, podiva se to na kategorii vpravo a projde to veci v levejch vecich a veci v kategorii vpravo a da to veci ktere jsou na radcich vlevo do praveho seznamu. az na to ze to tam da veci v prave kategorii.
            // kdyz kliknu na neco vpravo, vezme to ty spolecne radky a veci a da je to do programuConfig.data["Filtrovan�"] a radky do programuConfig.radky["Filtrovan�"] a radky do listRadky
            if (programConfig.souborNacteny)
            {
                listVeciPravy.Items.Clear();
                listRadky.Items.Clear();
                programConfig.data["Filtrovan�"].Clear();
                programConfig.radky["Filtrovan�"].Clear();
                foreach (string vecLevy in listVeciLevy.SelectedItems)
                {
                    foreach (string vecPravy in programConfig.data[listKategorieVpravo.SelectedItem.ToString()])
                    {
                        var spolecneRadky = programConfig.radky[listKategorieVlevo.SelectedItem.ToString()][vecLevy]
                            .Intersect(programConfig.radky[listKategorieVpravo.SelectedItem.ToString()][vecPravy]);
                        if (spolecneRadky.Any())
                        {
                            if (programConfig.data["Filtrovan�"].Add(vecPravy)) programConfig.radky["Filtrovan�"][vecPravy] = new HashSet<int>();
                            foreach (int cisloRadku in spolecneRadky)
                            {
                                programConfig.radky["Filtrovan�"][vecPravy].Add(cisloRadku);
                            }
                        }
                    }
                }
                programConfig.data["Filtrovan�"] = new HashSet<string>(programConfig.data["Filtrovan�"].OrderBy(v => v));
                foreach (string vec in programConfig.data["Filtrovan�"])
                {
                    listVeciPravy.Items.Add(vec);
                }
            }
        }
        private void clickVecVpravo(object sender, EventArgs e)
        {
            if (programConfig.souborNacteny)
            {
                listRadky.Items.Clear();
                programConfig.data["Filtrovan�"].Clear();
                programConfig.radky["Filtrovan�"].Clear();
                foreach (string vecPravy in listVeciPravy.SelectedItems)
                {
                    if (programConfig.data["Filtrovan�"].Add(vecPravy)) programConfig.radky["Filtrovan�"][vecPravy] = new HashSet<int>();
                    foreach (int cisloRadku in programConfig.radky[listKategorieVpravo.SelectedItem.ToString()][vecPravy])
                    {
                        programConfig.radky["Filtrovan�"][vecPravy].Add(cisloRadku);
                    }
                }
                HashSet<int> vsechnyRadky = new HashSet<int>();
                foreach (var radkyVeci in programConfig.radky["Filtrovan�"].Values)
                {
                    foreach (int cisloRadku in radkyVeci)
                    {
                        vsechnyRadky.Add(cisloRadku);
                    }
                }
                int[] radkyPole = vsechnyRadky.ToArray();
                Array.Sort(radkyPole);
                foreach (int cisloRadku in radkyPole)
                {
                    listRadky.Items.Add(cisloRadku.ToString());
                }
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
            if (textVyhledavacLevy.Text == "debug")
            {
                debug debugForm = new debug();
                debugForm.Show();
                textVyhledavacLevy.Text = string.Empty;
                return;
            }
            listVeciLevy.BeginUpdate();
            listVeciPravy.BeginUpdate();
            listVeciLevy.Items.Clear();
            listVeciPravy.Items.Clear();
            listRadky.Items.Clear();

            string hledam = textVyhledavacLevy.Text;
            if (string.IsNullOrEmpty(hledam))
                foreach (string vec in programConfig.data[listKategorieVlevo.SelectedItem.ToString()])
                {
                    listVeciLevy.Items.Add(vec);
                }
            else
                foreach (string vec in programConfig.data[listKategorieVlevo.SelectedItem.ToString()])
                {
                    if (vec.Contains(hledam, StringComparison.OrdinalIgnoreCase))
                    {
                        listVeciLevy.Items.Add(vec);
                    }
                }

            listVeciLevy.EndUpdate();
            listVeciPravy.EndUpdate();
        }

        private void textVyhledavacPravy_TextChanged(object sender, EventArgs e)
        {
            listVeciPravy.BeginUpdate();
            listVeciPravy.Items.Clear();
            listRadky.Items.Clear();

            string hledam = textVyhledavacPravy.Text;
            if (string.IsNullOrEmpty(hledam))
                foreach (string vec in programConfig.data["Filtrovan�"])
                {
                    listVeciPravy.Items.Add(vec);
                }
            else 
                foreach (string vec in programConfig.data["Filtrovan�"])
                {
                    if (vec.Contains(hledam, StringComparison.OrdinalIgnoreCase))
                    {
                        listVeciPravy.Items.Add(vec);
                    }
                }

            listVeciPravy.EndUpdate();
        }
    }
}