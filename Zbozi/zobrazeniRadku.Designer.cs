namespace Zbozi
{
    partial class zobrazeniRadku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabulka = new DataGridView();
            ok = new Button();
            ulozit = new Button();
            ((System.ComponentModel.ISupportInitialize)tabulka).BeginInit();
            SuspendLayout();
            // 
            // tabulka
            // 
            tabulka.AllowUserToAddRows = false;
            tabulka.AllowUserToDeleteRows = false;
            tabulka.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabulka.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabulka.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabulka.Location = new Point(12, 12);
            tabulka.Name = "tabulka";
            tabulka.ReadOnly = true;
            tabulka.RowHeadersVisible = false;
            tabulka.Size = new Size(660, 100);
            tabulka.TabIndex = 0;
            // 
            // ok
            // 
            ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ok.Location = new Point(616, 126);
            ok.Name = "ok";
            ok.Size = new Size(56, 23);
            ok.TabIndex = 1;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // ulozit
            // 
            ulozit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ulozit.Location = new Point(546, 126);
            ulozit.Name = "ulozit";
            ulozit.Size = new Size(64, 23);
            ulozit.TabIndex = 1;
            ulozit.Text = "Uložit...";
            ulozit.UseVisualStyleBackColor = true;
            ulozit.Click += ulozit_Click;
            // 
            // zobrazeniRadku
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 161);
            Controls.Add(ulozit);
            Controls.Add(ok);
            Controls.Add(tabulka);
            MinimumSize = new Size(700, 200);
            Name = "zobrazeniRadku";
            Text = "zobrazeniRadku";
            Load += zobrazeniRadku_Load;
            ((System.ComponentModel.ISupportInitialize)tabulka).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabulka;
        private Button ok;
        private Button ulozit;
    }
}