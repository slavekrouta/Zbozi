namespace Zbozi
{
    partial class debug
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
            label1 = new Label();
            firmy = new ListBox();
            label2 = new Label();
            zbozi = new ListBox();
            label3 = new Label();
            kody = new ListBox();
            label4 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            radky = new Label();
            label6 = new Label();
            path = new Label();
            label8 = new Label();
            cntfirmy = new Label();
            label10 = new Label();
            cntzbozi = new Label();
            label12 = new Label();
            cntkody = new Label();
            label5 = new Label();
            radek = new Label();
            label7 = new Label();
            vyskladneno = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "firmy";
            // 
            // firmy
            // 
            firmy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            firmy.FormattingEnabled = true;
            firmy.ItemHeight = 15;
            firmy.Location = new Point(12, 57);
            firmy.Name = "firmy";
            firmy.Size = new Size(122, 379);
            firmy.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(140, 9);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 0;
            label2.Text = "zbozi";
            // 
            // zbozi
            // 
            zbozi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            zbozi.FormattingEnabled = true;
            zbozi.ItemHeight = 15;
            zbozi.Location = new Point(140, 57);
            zbozi.Name = "zbozi";
            zbozi.Size = new Size(122, 379);
            zbozi.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(268, 9);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 0;
            label3.Text = "kody";
            // 
            // kody
            // 
            kody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            kody.FormattingEnabled = true;
            kody.ItemHeight = 15;
            kody.Location = new Point(268, 57);
            kody.Name = "kody";
            kody.Size = new Size(122, 379);
            kody.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(448, 57);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 0;
            label4.Text = "pouzite radky:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(713, 413);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "ulozit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(122, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(140, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(122, 23);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(268, 28);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(122, 23);
            textBox3.TabIndex = 3;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // radky
            // 
            radky.AutoSize = true;
            radky.Location = new Point(541, 57);
            radky.Name = "radky";
            radky.Size = new Size(37, 15);
            radky.TabIndex = 0;
            radky.Text = "pocet";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(448, 147);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 0;
            label6.Text = "path souboru:";
            // 
            // path
            // 
            path.AutoSize = true;
            path.Location = new Point(541, 147);
            path.Name = "path";
            path.Size = new Size(31, 15);
            path.TabIndex = 0;
            path.Text = "path";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(448, 102);
            label8.Name = "label8";
            label8.Size = new Size(71, 15);
            label8.TabIndex = 0;
            label8.Text = "pocet firem:";
            // 
            // cntfirmy
            // 
            cntfirmy.AutoSize = true;
            cntfirmy.Location = new Point(541, 102);
            cntfirmy.Name = "cntfirmy";
            cntfirmy.Size = new Size(37, 15);
            cntfirmy.TabIndex = 0;
            cntfirmy.Text = "pocet";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(448, 117);
            label10.Name = "label10";
            label10.Size = new Size(70, 15);
            label10.TabIndex = 0;
            label10.Text = "pocet zbozi:";
            // 
            // cntzbozi
            // 
            cntzbozi.AutoSize = true;
            cntzbozi.Location = new Point(541, 117);
            cntzbozi.Name = "cntzbozi";
            cntzbozi.Size = new Size(37, 15);
            cntzbozi.TabIndex = 0;
            cntzbozi.Text = "pocet";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(448, 132);
            label12.Name = "label12";
            label12.Size = new Size(70, 15);
            label12.TabIndex = 0;
            label12.Text = "pocet kodu:";
            // 
            // cntkody
            // 
            cntkody.AutoSize = true;
            cntkody.Location = new Point(541, 132);
            cntkody.Name = "cntkody";
            cntkody.Size = new Size(37, 15);
            cntkody.TabIndex = 0;
            cntkody.Text = "pocet";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(448, 87);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 0;
            label5.Text = "posledni radek:";
            // 
            // radek
            // 
            radek.AutoSize = true;
            radek.Location = new Point(541, 87);
            radek.Name = "radek";
            radek.Size = new Size(31, 15);
            radek.TabIndex = 0;
            radek.Text = "cislo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(448, 72);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 0;
            label7.Text = "vyskladneno:";
            // 
            // vyskladneno
            // 
            vyskladneno.AutoSize = true;
            vyskladneno.Location = new Point(541, 72);
            vyskladneno.Name = "vyskladneno";
            vyskladneno.Size = new Size(37, 15);
            vyskladneno.TabIndex = 0;
            vyskladneno.Text = "pocet";
            // 
            // debug
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(kody);
            Controls.Add(label3);
            Controls.Add(zbozi);
            Controls.Add(label2);
            Controls.Add(path);
            Controls.Add(cntkody);
            Controls.Add(cntzbozi);
            Controls.Add(cntfirmy);
            Controls.Add(radek);
            Controls.Add(vyskladneno);
            Controls.Add(radky);
            Controls.Add(label6);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(firmy);
            Controls.Add(label1);
            Name = "debug";
            Text = "debug";
            Load += debug_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox firmy;
        private Label label2;
        private ListBox zbozi;
        private Label label3;
        private ListBox kody;
        private Label label4;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label radky;
        private Label label6;
        private Label path;
        private Label label8;
        private Label cntfirmy;
        private Label label10;
        private Label cntzbozi;
        private Label label12;
        private Label cntkody;
        private Label label5;
        private Label radek;
        private Label label7;
        private Label vyskladneno;
    }
}