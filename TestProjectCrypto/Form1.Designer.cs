namespace TestProjectCrypto
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.test = new System.Windows.Forms.Label();
            this.BybitListBox = new System.Windows.Forms.ListBox();
            this.BinanceListBox = new System.Windows.Forms.ListBox();
            this.KucoinListBox = new System.Windows.Forms.ListBox();
            this.BitgetListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(12, 9);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(59, 13);
            this.test.TabIndex = 0;
            this.test.Text = "Bybit price:";
            // 
            // BybitListBox
            // 
            this.BybitListBox.FormattingEnabled = true;
            this.BybitListBox.Location = new System.Drawing.Point(331, -1);
            this.BybitListBox.Name = "BybitListBox";
            this.BybitListBox.Size = new System.Drawing.Size(75, 628);
            this.BybitListBox.TabIndex = 1;
            // 
            // BinanceListBox
            // 
            this.BinanceListBox.FormattingEnabled = true;
            this.BinanceListBox.Location = new System.Drawing.Point(412, -1);
            this.BinanceListBox.Name = "BinanceListBox";
            this.BinanceListBox.Size = new System.Drawing.Size(80, 628);
            this.BinanceListBox.TabIndex = 2;
            // 
            // KucoinListBox
            // 
            this.KucoinListBox.FormattingEnabled = true;
            this.KucoinListBox.Location = new System.Drawing.Point(498, -1);
            this.KucoinListBox.Name = "KucoinListBox";
            this.KucoinListBox.Size = new System.Drawing.Size(79, 628);
            this.KucoinListBox.TabIndex = 3;
            // 
            // BitgetListBox
            // 
            this.BitgetListBox.FormattingEnabled = true;
            this.BitgetListBox.Location = new System.Drawing.Point(583, -1);
            this.BitgetListBox.Name = "BitgetListBox";
            this.BitgetListBox.Size = new System.Drawing.Size(83, 628);
            this.BitgetListBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Binance price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kucoint price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bitget price:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 617);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BitgetListBox);
            this.Controls.Add(this.KucoinListBox);
            this.Controls.Add(this.BinanceListBox);
            this.Controls.Add(this.BybitListBox);
            this.Controls.Add(this.test);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label test;
        private System.Windows.Forms.ListBox BybitListBox;
        private System.Windows.Forms.ListBox BinanceListBox;
        private System.Windows.Forms.ListBox KucoinListBox;
        private System.Windows.Forms.ListBox BitgetListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

