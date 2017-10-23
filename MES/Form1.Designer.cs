namespace MES
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
            this.AutorTextBox = new System.Windows.Forms.RichTextBox();
            this.ObjectTextBox = new System.Windows.Forms.RichTextBox();
            this.DynamicTextBox = new System.Windows.Forms.RichTextBox();
            this.QuestionsTextBox = new System.Windows.Forms.RichTextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.FonText = new System.Windows.Forms.RichTextBox();
            this.Otvet = new System.Windows.Forms.RichTextBox();
            this.Go = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AutorTextBox
            // 
            this.AutorTextBox.Location = new System.Drawing.Point(12, 12);
            this.AutorTextBox.Name = "AutorTextBox";
            this.AutorTextBox.Size = new System.Drawing.Size(566, 57);
            this.AutorTextBox.TabIndex = 0;
            this.AutorTextBox.Text = "";
            // 
            // ObjectTextBox
            // 
            this.ObjectTextBox.Location = new System.Drawing.Point(12, 75);
            this.ObjectTextBox.Name = "ObjectTextBox";
            this.ObjectTextBox.Size = new System.Drawing.Size(205, 260);
            this.ObjectTextBox.TabIndex = 1;
            this.ObjectTextBox.Text = "";
            // 
            // DynamicTextBox
            // 
            this.DynamicTextBox.Location = new System.Drawing.Point(223, 75);
            this.DynamicTextBox.Name = "DynamicTextBox";
            this.DynamicTextBox.Size = new System.Drawing.Size(355, 214);
            this.DynamicTextBox.TabIndex = 2;
            this.DynamicTextBox.Text = "";
            // 
            // QuestionsTextBox
            // 
            this.QuestionsTextBox.Location = new System.Drawing.Point(12, 341);
            this.QuestionsTextBox.Name = "QuestionsTextBox";
            this.QuestionsTextBox.Size = new System.Drawing.Size(382, 149);
            this.QuestionsTextBox.TabIndex = 3;
            this.QuestionsTextBox.Text = "";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(409, 457);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(169, 33);
            this.OpenFileButton.TabIndex = 4;
            this.OpenFileButton.Text = "Открыть файл";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // FonText
            // 
            this.FonText.Location = new System.Drawing.Point(223, 296);
            this.FonText.Name = "FonText";
            this.FonText.ReadOnly = true;
            this.FonText.Size = new System.Drawing.Size(355, 39);
            this.FonText.TabIndex = 5;
            this.FonText.Text = "";
            // 
            // Otvet
            // 
            this.Otvet.Location = new System.Drawing.Point(379, 296);
            this.Otvet.Name = "Otvet";
            this.Otvet.Size = new System.Drawing.Size(65, 39);
            this.Otvet.TabIndex = 6;
            this.Otvet.Text = "";
            // 
            // Go
            // 
            this.Go.Enabled = false;
            this.Go.Location = new System.Drawing.Point(409, 398);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(169, 33);
            this.Go.TabIndex = 7;
            this.Go.Text = "ЛЕЦ ГО";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // Next
            // 
            this.Next.Enabled = false;
            this.Next.Location = new System.Drawing.Point(409, 341);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(169, 33);
            this.Next.TabIndex = 8;
            this.Next.Text = "Далее";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 502);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.Otvet);
            this.Controls.Add(this.FonText);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.QuestionsTextBox);
            this.Controls.Add(this.DynamicTextBox);
            this.Controls.Add(this.ObjectTextBox);
            this.Controls.Add(this.AutorTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox AutorTextBox;
        private System.Windows.Forms.RichTextBox ObjectTextBox;
        private System.Windows.Forms.RichTextBox DynamicTextBox;
        private System.Windows.Forms.RichTextBox QuestionsTextBox;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.RichTextBox FonText;
        private System.Windows.Forms.RichTextBox Otvet;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.Button Next;
    }
}

