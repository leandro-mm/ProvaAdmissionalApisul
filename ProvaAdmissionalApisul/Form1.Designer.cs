namespace ProvaAdmissionalApisul
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
            btnExtrairInf = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // btnExtrairInf
            // 
            btnExtrairInf.Location = new Point(51, 36);
            btnExtrairInf.Name = "btnExtrairInf";
            btnExtrairInf.Size = new Size(130, 39);
            btnExtrairInf.TabIndex = 0;
            btnExtrairInf.Text = "Extrair Informações";
            btnExtrairInf.UseVisualStyleBackColor = true;
            btnExtrairInf.Click += btnExtrairInf_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(51, 92);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(639, 272);
            textBox1.TabIndex = 1;
            textBox1.WordWrap = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(btnExtrairInf);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExtrairInf;
        private TextBox textBox1;
    }
}
