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
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(3, -1);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(98, 13);
            this.test.TabIndex = 0;
            this.test.Text = "Current BTC Price: ";
            // 
            // BybitListBox
            // 
            this.BybitListBox.FormattingEnabled = true;
            this.BybitListBox.Location = new System.Drawing.Point(214, -1);
            this.BybitListBox.Name = "BybitListBox";
            this.BybitListBox.Size = new System.Drawing.Size(75, 628);
            this.BybitListBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 617);
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
    }
}

