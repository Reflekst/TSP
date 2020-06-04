namespace OP_TSP
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startAlgorithmButton = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.SaveFileDialog();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.findFileButton = new System.Windows.Forms.Button();
            this.pointsTextBox = new System.Windows.Forms.TextBox();
            this.TimeTextBox = new System.Windows.Forms.TextBox();
            this.pointsList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.distance = new System.Windows.Forms.TextBox();
            this.mainAlgorithm = new System.Windows.Forms.Button();
            this.workTimeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numberP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.distanceGreedy = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybierz plik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(471, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ilość punktów:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(471, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Czas:";
            // 
            // startAlgorithmButton
            // 
            this.startAlgorithmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startAlgorithmButton.Location = new System.Drawing.Point(21, 133);
            this.startAlgorithmButton.Margin = new System.Windows.Forms.Padding(6);
            this.startAlgorithmButton.Name = "startAlgorithmButton";
            this.startAlgorithmButton.Size = new System.Drawing.Size(430, 45);
            this.startAlgorithmButton.TabIndex = 3;
            this.startAlgorithmButton.Text = "Rozpocznij pracę algorytmu zachłannego";
            this.startAlgorithmButton.UseVisualStyleBackColor = true;
            this.startAlgorithmButton.Click += new System.EventHandler(this.startAlgorithmButton_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filePathTextBox.Location = new System.Drawing.Point(187, 15);
            this.filePathTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(171, 28);
            this.filePathTextBox.TabIndex = 4;
            // 
            // findFileButton
            // 
            this.findFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.findFileButton.Location = new System.Drawing.Point(370, 15);
            this.findFileButton.Margin = new System.Windows.Forms.Padding(6);
            this.findFileButton.Name = "findFileButton";
            this.findFileButton.Size = new System.Drawing.Size(81, 92);
            this.findFileButton.TabIndex = 5;
            this.findFileButton.Text = "Wyszukaj";
            this.findFileButton.UseVisualStyleBackColor = true;
            this.findFileButton.Click += new System.EventHandler(this.findFileButton_Click);
            // 
            // pointsTextBox
            // 
            this.pointsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pointsTextBox.Location = new System.Drawing.Point(655, 98);
            this.pointsTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.pointsTextBox.Name = "pointsTextBox";
            this.pointsTextBox.ReadOnly = true;
            this.pointsTextBox.Size = new System.Drawing.Size(129, 28);
            this.pointsTextBox.TabIndex = 6;
            // 
            // TimeTextBox
            // 
            this.TimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TimeTextBox.Location = new System.Drawing.Point(655, 222);
            this.TimeTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.TimeTextBox.Name = "TimeTextBox";
            this.TimeTextBox.ReadOnly = true;
            this.TimeTextBox.Size = new System.Drawing.Size(129, 28);
            this.TimeTextBox.TabIndex = 7;
            // 
            // pointsList
            // 
            this.pointsList.FormattingEnabled = true;
            this.pointsList.ItemHeight = 26;
            this.pointsList.Location = new System.Drawing.Point(21, 281);
            this.pointsList.Name = "pointsList";
            this.pointsList.Size = new System.Drawing.Size(763, 368);
            this.pointsList.TabIndex = 8;
            this.pointsList.SelectedIndexChanged += new System.EventHandler(this.pointsList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(471, 186);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Dystans:";
            // 
            // distance
            // 
            this.distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.distance.Location = new System.Drawing.Point(655, 182);
            this.distance.Margin = new System.Windows.Forms.Padding(6);
            this.distance.Name = "distance";
            this.distance.ReadOnly = true;
            this.distance.Size = new System.Drawing.Size(127, 28);
            this.distance.TabIndex = 12;
            // 
            // mainAlgorithm
            // 
            this.mainAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainAlgorithm.Location = new System.Drawing.Point(21, 205);
            this.mainAlgorithm.Margin = new System.Windows.Forms.Padding(6);
            this.mainAlgorithm.Name = "mainAlgorithm";
            this.mainAlgorithm.Size = new System.Drawing.Size(430, 45);
            this.mainAlgorithm.TabIndex = 13;
            this.mainAlgorithm.Text = "Rozpocznij pracę algorytmu zaawansowanego";
            this.mainAlgorithm.UseVisualStyleBackColor = true;
            this.mainAlgorithm.Click += new System.EventHandler(this.mainAlgorithm_Click);
            // 
            // workTimeTextBox
            // 
            this.workTimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workTimeTextBox.Location = new System.Drawing.Point(257, 79);
            this.workTimeTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.workTimeTextBox.Name = "workTimeTextBox";
            this.workTimeTextBox.Size = new System.Drawing.Size(101, 28);
            this.workTimeTextBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(15, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 31);
            this.label5.TabIndex = 14;
            this.label5.Text = "Podaj czas trwania";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(309, 38);
            this.button1.TabIndex = 16;
            this.button1.Text = "Wygeneruj losowo punkty";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numberP
            // 
            this.numberP.Location = new System.Drawing.Point(686, 15);
            this.numberP.Name = "numberP";
            this.numberP.Size = new System.Drawing.Size(96, 32);
            this.numberP.TabIndex = 17;
            this.numberP.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(475, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 31);
            this.label6.TabIndex = 18;
            this.label6.Text = "Liczba punktów";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(471, 142);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 24);
            this.label7.TabIndex = 19;
            this.label7.Text = "Dystans zachłanny:";
            // 
            // distanceGreedy
            // 
            this.distanceGreedy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.distanceGreedy.Location = new System.Drawing.Point(655, 142);
            this.distanceGreedy.Margin = new System.Windows.Forms.Padding(6);
            this.distanceGreedy.Name = "distanceGreedy";
            this.distanceGreedy.ReadOnly = true;
            this.distanceGreedy.Size = new System.Drawing.Size(127, 28);
            this.distanceGreedy.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 715);
            this.Controls.Add(this.distanceGreedy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numberP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.workTimeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mainAlgorithm);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pointsList);
            this.Controls.Add(this.TimeTextBox);
            this.Controls.Add(this.pointsTextBox);
            this.Controls.Add(this.findFileButton);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.startAlgorithmButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "TSP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startAlgorithmButton;
        private System.Windows.Forms.SaveFileDialog fileDialog;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button findFileButton;
        private System.Windows.Forms.TextBox pointsTextBox;
        private System.Windows.Forms.TextBox TimeTextBox;
        private System.Windows.Forms.ListBox pointsList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox distance;
        private System.Windows.Forms.Button mainAlgorithm;
        private System.Windows.Forms.TextBox workTimeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox numberP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox distanceGreedy;
    }
}

