namespace Zbozi
{
    partial class Form1
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
            buttonSoubor = new Button();
            labelSoubor = new Label();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            listKategorie = new ListBox();
            splitContainer2 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            radekNacitani = new ProgressBar();
            textVyhledavac = new TextBox();
            listVeci = new ListBox();
            splitContainer3 = new SplitContainer();
            listRadky = new ListBox();
            buttonZobrazit = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
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
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 38);
            panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 56);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listKategorie);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(370, 143);
            splitContainer1.SplitterDistance = 69;
            splitContainer1.TabIndex = 2;
            // 
            // listKategorie
            // 
            listKategorie.Dock = DockStyle.Fill;
            listKategorie.FormattingEnabled = true;
            listKategorie.ItemHeight = 15;
            listKategorie.Items.AddRange(new object[] { "Firmy", "Zboží" });
            listKategorie.Location = new Point(0, 0);
            listKategorie.Name = "listKategorie";
            listKategorie.Size = new Size(69, 143);
            listKategorie.TabIndex = 0;
            listKategorie.SelectedIndexChanged += listKategorie_SelectedIndexChanged;
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
            splitContainer4.FixedPanel = FixedPanel.Panel1;
            splitContainer4.IsSplitterFixed = true;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(radekNacitani);
            splitContainer4.Panel1.Controls.Add(textVyhledavac);
            splitContainer4.Panel1MinSize = 23;
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(listVeci);
            splitContainer4.Size = new Size(198, 143);
            splitContainer4.SplitterDistance = 25;
            splitContainer4.TabIndex = 0;
            // 
            // radekNacitani
            // 
            radekNacitani.Dock = DockStyle.Fill;
            radekNacitani.Location = new Point(0, 0);
            radekNacitani.Name = "radekNacitani";
            radekNacitani.Size = new Size(198, 25);
            radekNacitani.Style = ProgressBarStyle.Continuous;
            radekNacitani.TabIndex = 3;
            radekNacitani.Visible = false;
            // 
            // textVyhledavac
            // 
            textVyhledavac.Dock = DockStyle.Fill;
            textVyhledavac.Enabled = false;
            textVyhledavac.Location = new Point(0, 0);
            textVyhledavac.Name = "textVyhledavac";
            textVyhledavac.PlaceholderText = "Hledat...";
            textVyhledavac.Size = new Size(198, 23);
            textVyhledavac.TabIndex = 0;
            textVyhledavac.TextChanged += textVyhledavac_TextChanged;
            // 
            // listVeci
            // 
            listVeci.Dock = DockStyle.Fill;
            listVeci.FormattingEnabled = true;
            listVeci.HorizontalScrollbar = true;
            listVeci.ItemHeight = 15;
            listVeci.Items.AddRange(new object[] { "Nejdříve vyberte a načtěte soubor" });
            listVeci.Location = new Point(0, 0);
            listVeci.Name = "listVeci";
            listVeci.SelectionMode = SelectionMode.MultiExtended;
            listVeci.Size = new Size(198, 114);
            listVeci.TabIndex = 0;
            listVeci.SelectedIndexChanged += clickVec;
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
            listRadky.SelectionMode = SelectionMode.MultiExtended;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 211);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            MinimumSize = new Size(410, 250);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel1.PerformLayout();
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
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
        private ListBox listKategorie;
        private ListBox listVeci;
        private SplitContainer splitContainer2;
        private ListBox listRadky;
        private Button buttonZobrazit;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private TextBox textVyhledavac;
        private ProgressBar radekNacitani;
    }
}
