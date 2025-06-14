namespace asyncUI
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
            btnRandom = new Button();
            labelRandom = new Label();
            loading = new ProgressBar();
            horse1 = new ProgressBar();
            horse2 = new ProgressBar();
            horse3 = new ProgressBar();
            horse4 = new ProgressBar();
            horse5 = new ProgressBar();
            btnStart = new Button();
            result1 = new Label();
            result2 = new Label();
            result3 = new Label();
            result4 = new Label();
            result5 = new Label();
            SuspendLayout();
            // 
            // btnRandom
            // 
            btnRandom.BackColor = Color.NavajoWhite;
            btnRandom.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRandom.Location = new Point(534, 47);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(621, 94);
            btnRandom.TabIndex = 0;
            btnRandom.Text = "Випадкове число";
            btnRandom.UseVisualStyleBackColor = false;
            btnRandom.Click += btnRandom_Click;
            // 
            // labelRandom
            // 
            labelRandom.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRandom.Location = new Point(12, 47);
            labelRandom.Name = "labelRandom";
            labelRandom.Size = new Size(516, 94);
            labelRandom.TabIndex = 1;
            labelRandom.Text = "0";
            labelRandom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loading
            // 
            loading.Location = new Point(12, 12);
            loading.Name = "loading";
            loading.Size = new Size(1143, 29);
            loading.TabIndex = 2;
            // 
            // horse1
            // 
            horse1.Location = new Point(12, 211);
            horse1.Name = "horse1";
            horse1.Size = new Size(1143, 29);
            horse1.TabIndex = 3;
            horse1.Tag = "1";
            // 
            // horse2
            // 
            horse2.Location = new Point(12, 287);
            horse2.Name = "horse2";
            horse2.Size = new Size(1143, 29);
            horse2.TabIndex = 4;
            horse2.Tag = "2";
            // 
            // horse3
            // 
            horse3.Location = new Point(12, 363);
            horse3.Name = "horse3";
            horse3.Size = new Size(1143, 29);
            horse3.TabIndex = 5;
            horse3.Tag = "3";
            // 
            // horse4
            // 
            horse4.Location = new Point(12, 439);
            horse4.Name = "horse4";
            horse4.Size = new Size(1143, 29);
            horse4.TabIndex = 6;
            horse4.Tag = "4";
            // 
            // horse5
            // 
            horse5.Location = new Point(12, 515);
            horse5.Name = "horse5";
            horse5.Size = new Size(1143, 29);
            horse5.TabIndex = 7;
            horse5.Tag = "5";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.LightGreen;
            btnStart.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(12, 550);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(276, 78);
            btnStart.TabIndex = 8;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // result1
            // 
            result1.AutoSize = true;
            result1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            result1.Location = new Point(12, 167);
            result1.Name = "result1";
            result1.Size = new Size(49, 41);
            result1.TabIndex = 9;
            result1.Text = "1: ";
            // 
            // result2
            // 
            result2.AutoSize = true;
            result2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            result2.Location = new Point(12, 243);
            result2.Name = "result2";
            result2.Size = new Size(49, 41);
            result2.TabIndex = 10;
            result2.Text = "2: ";
            // 
            // result3
            // 
            result3.AutoSize = true;
            result3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            result3.Location = new Point(12, 319);
            result3.Name = "result3";
            result3.Size = new Size(49, 41);
            result3.TabIndex = 11;
            result3.Text = "3: ";
            // 
            // result4
            // 
            result4.AutoSize = true;
            result4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            result4.Location = new Point(12, 395);
            result4.Name = "result4";
            result4.Size = new Size(49, 41);
            result4.TabIndex = 12;
            result4.Text = "4: ";
            // 
            // result5
            // 
            result5.AutoSize = true;
            result5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            result5.Location = new Point(12, 471);
            result5.Name = "result5";
            result5.Size = new Size(49, 41);
            result5.TabIndex = 13;
            result5.Text = "5: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 640);
            Controls.Add(result5);
            Controls.Add(result4);
            Controls.Add(result3);
            Controls.Add(result2);
            Controls.Add(result1);
            Controls.Add(btnStart);
            Controls.Add(horse5);
            Controls.Add(horse4);
            Controls.Add(horse3);
            Controls.Add(horse2);
            Controls.Add(horse1);
            Controls.Add(loading);
            Controls.Add(labelRandom);
            Controls.Add(btnRandom);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRandom;
        private Label labelRandom;
        private ProgressBar loading;
        private ProgressBar horse1;
        private ProgressBar horse2;
        private ProgressBar horse3;
        private ProgressBar horse4;
        private ProgressBar horse5;
        private Button btnStart;
        private Label result1;
        private Label result2;
        private Label result3;
        private Label result4;
        private Label result5;
    }
}
