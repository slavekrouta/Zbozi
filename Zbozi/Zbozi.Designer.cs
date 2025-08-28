namespace Zbozi
{
    partial class Zbozi
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zbozi));
            buttonSoubor = new Button();
            labelSoubor = new Label();
            panel1 = new Panel();
            radekNacitani = new ProgressBar();
            splitContainer1 = new SplitContainer();
            splitContainer7 = new SplitContainer();
            listKategorieVlevo = new ListBox();
            listKategorieVpravo = new ListBox();
            splitContainer2 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            textVyhledavacLevy = new TextBox();
            listVeciLevy = new ListBox();
            splitContainer6 = new SplitContainer();
            textVyhledavacPravy = new TextBox();
            listVeciPravy = new ListBox();
            splitContainer3 = new SplitContainer();
            listRadky = new ListBox();
            buttonZobrazit = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer7).BeginInit();
            splitContainer7.Panel1.SuspendLayout();
            splitContainer7.Panel2.SuspendLayout();
            splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
            splitContainer6.Panel1.SuspendLayout();
            splitContainer6.Panel2.SuspendLayout();
            splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSoubor
            // 
            buttonSoubor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSoubor.Location = new Point(255, 7);
            buttonSoubor.Name = "buttonSoubor";
            buttonSoubor.Size = new Size(103, 24);
            buttonSoubor.TabIndex = 1;
            buttonSoubor.Text = "Vybrat Soubor";
            buttonSoubor.UseVisualStyleBackColor = true;
            buttonSoubor.Click += clickVybratSoubor;
            // 
            // labelSoubor
            // 
            labelSoubor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelSoubor.AutoSize = true;
            labelSoubor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSoubor.ForeColor = Color.White;
            labelSoubor.Location = new Point(12, 11);
            labelSoubor.Name = "labelSoubor";
            labelSoubor.Size = new Size(104, 15);
            labelSoubor.TabIndex = 0;
            labelSoubor.Text = "Soubor Nevybrán";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(buttonSoubor);
            panel1.Controls.Add(labelSoubor);
            panel1.Controls.Add(radekNacitani);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 38);
            panel1.TabIndex = 1;
            // 
            // radekNacitani
            // 
            radekNacitani.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radekNacitani.Location = new Point(0, 32);
            radekNacitani.Name = "radekNacitani";
            radekNacitani.Size = new Size(370, 5);
            radekNacitani.Style = ProgressBarStyle.Continuous;
            radekNacitani.TabIndex = 3;
            radekNacitani.Visible = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 56);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer7);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(370, 143);
            splitContainer1.SplitterDistance = 69;
            splitContainer1.TabIndex = 2;
            // 
            // splitContainer7
            // 
            splitContainer7.Dock = DockStyle.Fill;
            splitContainer7.IsSplitterFixed = true;
            splitContainer7.Location = new Point(0, 0);
            splitContainer7.Name = "splitContainer7";
            splitContainer7.Orientation = Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            splitContainer7.Panel1.Controls.Add(listKategorieVlevo);
            // 
            // splitContainer7.Panel2
            // 
            splitContainer7.Panel2.Controls.Add(listKategorieVpravo);
            splitContainer7.Size = new Size(69, 143);
            splitContainer7.SplitterDistance = 68;
            splitContainer7.TabIndex = 2;
            // 
            // listKategorieVlevo
            // 
            listKategorieVlevo.Dock = DockStyle.Fill;
            listKategorieVlevo.FormattingEnabled = true;
            listKategorieVlevo.ItemHeight = 15;
            listKategorieVlevo.Items.AddRange(new object[] { "Firmy", "Zboží", "Objednací čísla" });
            listKategorieVlevo.Location = new Point(0, 0);
            listKategorieVlevo.Name = "listKategorieVlevo";
            listKategorieVlevo.SelectionMode = SelectionMode.None;
            listKategorieVlevo.Size = new Size(69, 68);
            listKategorieVlevo.TabIndex = 0;
            listKategorieVlevo.SelectedIndexChanged += listKategorieVlevo_SelectedIndexChanged;
            // 
            // listKategorieVpravo
            // 
            listKategorieVpravo.Dock = DockStyle.Fill;
            listKategorieVpravo.FormattingEnabled = true;
            listKategorieVpravo.ItemHeight = 15;
            listKategorieVpravo.Items.AddRange(new object[] { "Firmy", "Zboží", "Objednací čísla" });
            listKategorieVpravo.Location = new Point(0, 0);
            listKategorieVpravo.Name = "listKategorieVpravo";
            listKategorieVpravo.SelectionMode = SelectionMode.None;
            listKategorieVpravo.Size = new Size(69, 71);
            listKategorieVpravo.TabIndex = 1;
            listKategorieVpravo.SelectedIndexChanged += listKategorieVpravo_SelectedIndexChanged;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(297, 143);
            splitContainer2.SplitterDistance = 198;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(splitContainer5);
            splitContainer4.Panel1MinSize = 23;
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(splitContainer6);
            splitContainer4.Size = new Size(198, 143);
            splitContainer4.SplitterDistance = 97;
            splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.FixedPanel = FixedPanel.Panel1;
            splitContainer5.IsSplitterFixed = true;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Name = "splitContainer5";
            splitContainer5.Orientation = Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(textVyhledavacLevy);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(listVeciLevy);
            splitContainer5.Size = new Size(97, 143);
            splitContainer5.SplitterDistance = 25;
            splitContainer5.TabIndex = 0;
            // 
            // textVyhledavacLevy
            // 
            textVyhledavacLevy.Dock = DockStyle.Fill;
            textVyhledavacLevy.Enabled = false;
            textVyhledavacLevy.Font = new Font("Segoe UI", 9F);
            textVyhledavacLevy.Location = new Point(0, 0);
            textVyhledavacLevy.Name = "textVyhledavacLevy";
            textVyhledavacLevy.PlaceholderText = "Hledat...";
            textVyhledavacLevy.Size = new Size(97, 23);
            textVyhledavacLevy.TabIndex = 0;
            textVyhledavacLevy.TextChanged += textVyhledavac_TextChanged;
            // 
            // listVeciLevy
            // 
            listVeciLevy.Dock = DockStyle.Fill;
            listVeciLevy.FormattingEnabled = true;
            listVeciLevy.HorizontalScrollbar = true;
            listVeciLevy.ItemHeight = 15;
            listVeciLevy.Items.AddRange(new object[] { "Nejdříve vyberte a načtěte soubor" });
            listVeciLevy.Location = new Point(0, 0);
            listVeciLevy.Name = "listVeciLevy";
            listVeciLevy.SelectionMode = SelectionMode.None;
            listVeciLevy.Size = new Size(97, 114);
            listVeciLevy.TabIndex = 0;
            listVeciLevy.SelectedIndexChanged += clickVecVlevo;
            // 
            // splitContainer6
            // 
            splitContainer6.Dock = DockStyle.Fill;
            splitContainer6.FixedPanel = FixedPanel.Panel1;
            splitContainer6.IsSplitterFixed = true;
            splitContainer6.Location = new Point(0, 0);
            splitContainer6.Name = "splitContainer6";
            splitContainer6.Orientation = Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            splitContainer6.Panel1.Controls.Add(textVyhledavacPravy);
            // 
            // splitContainer6.Panel2
            // 
            splitContainer6.Panel2.Controls.Add(listVeciPravy);
            splitContainer6.Size = new Size(97, 143);
            splitContainer6.SplitterDistance = 25;
            splitContainer6.TabIndex = 0;
            // 
            // textVyhledavacPravy
            // 
            textVyhledavacPravy.Dock = DockStyle.Fill;
            textVyhledavacPravy.Enabled = false;
            textVyhledavacPravy.Font = new Font("Segoe UI", 9F);
            textVyhledavacPravy.Location = new Point(0, 0);
            textVyhledavacPravy.Name = "textVyhledavacPravy";
            textVyhledavacPravy.PlaceholderText = "Hledat...";
            textVyhledavacPravy.Size = new Size(97, 23);
            textVyhledavacPravy.TabIndex = 1;
            textVyhledavacPravy.TextChanged += textVyhledavacPravy_TextChanged;
            // 
            // listVeciPravy
            // 
            listVeciPravy.Dock = DockStyle.Fill;
            listVeciPravy.FormattingEnabled = true;
            listVeciPravy.HorizontalScrollbar = true;
            listVeciPravy.ItemHeight = 15;
            listVeciPravy.Items.AddRange(new object[] { "Nejdříve vyberte a načtěte soubor" });
            listVeciPravy.Location = new Point(0, 0);
            listVeciPravy.Name = "listVeciPravy";
            listVeciPravy.SelectionMode = SelectionMode.None;
            listVeciPravy.Size = new Size(97, 114);
            listVeciPravy.TabIndex = 1;
            listVeciPravy.SelectedIndexChanged += clickVecVpravo;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.FixedPanel = FixedPanel.Panel2;
            splitContainer3.IsSplitterFixed = true;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(listRadky);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(buttonZobrazit);
            splitContainer3.Size = new Size(95, 143);
            splitContainer3.SplitterDistance = 112;
            splitContainer3.TabIndex = 0;
            // 
            // listRadky
            // 
            listRadky.Dock = DockStyle.Fill;
            listRadky.FormattingEnabled = true;
            listRadky.HorizontalScrollbar = true;
            listRadky.ItemHeight = 15;
            listRadky.Location = new Point(0, 0);
            listRadky.Name = "listRadky";
            listRadky.SelectionMode = SelectionMode.None;
            listRadky.Size = new Size(95, 112);
            listRadky.Sorted = true;
            listRadky.TabIndex = 1;
            listRadky.SelectedIndexChanged += listRadky_SelectedIndexChanged;
            // 
            // buttonZobrazit
            // 
            buttonZobrazit.Dock = DockStyle.Fill;
            buttonZobrazit.Enabled = false;
            buttonZobrazit.Font = new Font("Segoe UI", 9F);
            buttonZobrazit.Location = new Point(0, 0);
            buttonZobrazit.Name = "buttonZobrazit";
            buttonZobrazit.Size = new Size(95, 27);
            buttonZobrazit.TabIndex = 2;
            buttonZobrazit.Text = "Zobrazit Řádek";
            buttonZobrazit.UseVisualStyleBackColor = true;
            buttonZobrazit.Click += buttonZobrazit_Click;
            // 
            // Zbozi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 211);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(410, 250);
            Name = "Zbozi";
            Text = "Zboží";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer7.Panel1.ResumeLayout(false);
            splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer7).EndInit();
            splitContainer7.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel1.PerformLayout();
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            splitContainer6.Panel1.ResumeLayout(false);
            splitContainer6.Panel1.PerformLayout();
            splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
            splitContainer6.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button buttonSoubor;
        private Label labelSoubor;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private ListBox listKategorieVlevo;
        private ListBox listVeciLevy;
        private SplitContainer splitContainer2;
        private ListBox listRadky;
        private Button buttonZobrazit;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private TextBox textVyhledavacLevy;
        private ProgressBar radekNacitani;
        private SplitContainer splitContainer5;
        private SplitContainer splitContainer6;
        private TextBox textVyhledavacPravy;
        private ListBox listVeciPravy;
        private SplitContainer splitContainer7;
        private ListBox listKategorieVpravo;
    }
}
