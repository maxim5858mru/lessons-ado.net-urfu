namespace Laboratory_Works
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.labarotoryWorkPage1 = new System.Windows.Forms.TabPage();
            this.labarotoryWorkPage2 = new System.Windows.Forms.TabPage();
            this.labarotoryWorkPage3 = new System.Windows.Forms.TabPage();
            this.labarotoryWorkPage4 = new System.Windows.Forms.TabPage();
            this.labarotoryWorkPage5 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.labarotoryWorkPage1);
            this.tabControl.Controls.Add(this.labarotoryWorkPage2);
            this.tabControl.Controls.Add(this.labarotoryWorkPage3);
            this.tabControl.Controls.Add(this.labarotoryWorkPage4);
            this.tabControl.Controls.Add(this.labarotoryWorkPage5);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 426);
            this.tabControl.TabIndex = 0;
            // 
            // labarotoryWorkPage1
            // 
            this.labarotoryWorkPage1.Location = new System.Drawing.Point(4, 22);
            this.labarotoryWorkPage1.Name = "labarotoryWorkPage1";
            this.labarotoryWorkPage1.Padding = new System.Windows.Forms.Padding(3);
            this.labarotoryWorkPage1.Size = new System.Drawing.Size(768, 400);
            this.labarotoryWorkPage1.TabIndex = 0;
            this.labarotoryWorkPage1.Text = "Лабораторная работа №1";
            this.labarotoryWorkPage1.UseVisualStyleBackColor = true;
            // 
            // labarotoryWorkPage2
            // 
            this.labarotoryWorkPage2.Location = new System.Drawing.Point(4, 22);
            this.labarotoryWorkPage2.Name = "labarotoryWorkPage2";
            this.labarotoryWorkPage2.Padding = new System.Windows.Forms.Padding(3);
            this.labarotoryWorkPage2.Size = new System.Drawing.Size(768, 400);
            this.labarotoryWorkPage2.TabIndex = 1;
            this.labarotoryWorkPage2.Text = "Лабораторная работа №2";
            this.labarotoryWorkPage2.UseVisualStyleBackColor = true;
            // 
            // labarotoryWorkPage3
            // 
            this.labarotoryWorkPage3.Location = new System.Drawing.Point(4, 22);
            this.labarotoryWorkPage3.Name = "labarotoryWorkPage3";
            this.labarotoryWorkPage3.Size = new System.Drawing.Size(768, 400);
            this.labarotoryWorkPage3.TabIndex = 2;
            this.labarotoryWorkPage3.Text = "Лабораторная работа №3";
            this.labarotoryWorkPage3.UseVisualStyleBackColor = true;
            // 
            // labarotoryWorkPage4
            // 
            this.labarotoryWorkPage4.Location = new System.Drawing.Point(4, 22);
            this.labarotoryWorkPage4.Name = "labarotoryWorkPage4";
            this.labarotoryWorkPage4.Size = new System.Drawing.Size(768, 400);
            this.labarotoryWorkPage4.TabIndex = 3;
            this.labarotoryWorkPage4.Text = "Лабораторная работа №4";
            this.labarotoryWorkPage4.UseVisualStyleBackColor = true;
            // 
            // labarotoryWorkPage5
            // 
            this.labarotoryWorkPage5.Location = new System.Drawing.Point(4, 22);
            this.labarotoryWorkPage5.Name = "labarotoryWorkPage5";
            this.labarotoryWorkPage5.Size = new System.Drawing.Size(768, 400);
            this.labarotoryWorkPage5.TabIndex = 4;
            this.labarotoryWorkPage5.Text = "Лабораторная работа №5";
            this.labarotoryWorkPage5.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage labarotoryWorkPage1;
        private System.Windows.Forms.TabPage labarotoryWorkPage2;
        private System.Windows.Forms.TabPage labarotoryWorkPage3;
        private System.Windows.Forms.TabPage labarotoryWorkPage4;
        private System.Windows.Forms.TabPage labarotoryWorkPage5;
    }
}

