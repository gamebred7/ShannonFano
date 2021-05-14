namespace ShannonFano
{
    partial class ShannonFano
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShannonFano));
            this.coderTextBox = new System.Windows.Forms.TextBox();
            this.decoderTextBox = new System.Windows.Forms.TextBox();
            this.coderButton = new System.Windows.Forms.Button();
            this.decoderButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rocketPicture = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startsize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endsize = new System.Windows.Forms.Label();
            this.procent = new System.Windows.Forms.Label();
            this.endfilesize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timelabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.rocketPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // coderTextBox
            // 
            this.coderTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.coderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coderTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.coderTextBox.Location = new System.Drawing.Point(324, 74);
            this.coderTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.coderTextBox.Name = "coderTextBox";
            this.coderTextBox.Size = new System.Drawing.Size(292, 23);
            this.coderTextBox.TabIndex = 0;
            // 
            // decoderTextBox
            // 
            this.decoderTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.decoderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decoderTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.decoderTextBox.Location = new System.Drawing.Point(324, 118);
            this.decoderTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.decoderTextBox.Name = "decoderTextBox";
            this.decoderTextBox.Size = new System.Drawing.Size(292, 23);
            this.decoderTextBox.TabIndex = 1;
            // 
            // coderButton
            // 
            this.coderButton.BackColor = System.Drawing.Color.BlueViolet;
            this.coderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.coderButton.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coderButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.coderButton.Location = new System.Drawing.Point(638, 68);
            this.coderButton.Margin = new System.Windows.Forms.Padding(4);
            this.coderButton.Name = "coderButton";
            this.coderButton.Size = new System.Drawing.Size(129, 30);
            this.coderButton.TabIndex = 2;
            this.coderButton.Text = "Кодировать";
            this.coderButton.UseVisualStyleBackColor = false;
            this.coderButton.Click += new System.EventHandler(this.CoderButtonClick);
            // 
            // decoderButton
            // 
            this.decoderButton.BackColor = System.Drawing.Color.BlueViolet;
            this.decoderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.decoderButton.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decoderButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.decoderButton.Location = new System.Drawing.Point(638, 112);
            this.decoderButton.Margin = new System.Windows.Forms.Padding(4);
            this.decoderButton.Name = "decoderButton";
            this.decoderButton.Size = new System.Drawing.Size(129, 30);
            this.decoderButton.TabIndex = 3;
            this.decoderButton.Text = "Декодировать";
            this.decoderButton.UseVisualStyleBackColor = false;
            this.decoderButton.Click += new System.EventHandler(this.DecoderButtonClick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.Control;
            this.label.Location = new System.Drawing.Point(339, 19);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(256, 37);
            this.label.TabIndex = 4;
            this.label.Text = "Выберите файл";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.resultLabel.Location = new System.Drawing.Point(368, 239);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 20);
            this.resultLabel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // rocketPicture
            // 
            this.rocketPicture.BackColor = System.Drawing.Color.Transparent;
            this.rocketPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rocketPicture.Image = ((System.Drawing.Image)(resources.GetObject("rocketPicture.Image")));
            this.rocketPicture.Location = new System.Drawing.Point(-20, 0);
            this.rocketPicture.Name = "rocketPicture";
            this.rocketPicture.Size = new System.Drawing.Size(372, 232);
            this.rocketPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rocketPicture.TabIndex = 6;
            this.rocketPicture.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.InfoText;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(39, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Было:";
            // 
            // startsize
            // 
            this.startsize.AutoSize = true;
            this.startsize.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startsize.Location = new System.Drawing.Point(90, 239);
            this.startsize.Name = "startsize";
            this.startsize.Size = new System.Drawing.Size(0, 17);
            this.startsize.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(185, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Стало:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(245, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(39, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Процент сжатия:";
            // 
            // endsize
            // 
            this.endsize.AutoSize = true;
            this.endsize.Location = new System.Drawing.Point(245, 239);
            this.endsize.Name = "endsize";
            this.endsize.Size = new System.Drawing.Size(0, 17);
            this.endsize.TabIndex = 12;
            // 
            // procent
            // 
            this.procent.AutoSize = true;
            this.procent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.procent.Location = new System.Drawing.Point(163, 265);
            this.procent.Name = "procent";
            this.procent.Size = new System.Drawing.Size(0, 17);
            this.procent.TabIndex = 13;
            // 
            // endfilesize
            // 
            this.endfilesize.AutoSize = true;
            this.endfilesize.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.endfilesize.Location = new System.Drawing.Point(245, 239);
            this.endfilesize.Name = "endfilesize";
            this.endfilesize.Size = new System.Drawing.Size(0, 17);
            this.endfilesize.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(39, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Время выполнения:";
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timelabel.Location = new System.Drawing.Point(188, 293);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(0, 17);
            this.timelabel.TabIndex = 16;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(324, 164);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(443, 23);
            this.progressBar1.TabIndex = 17;
            // 
            // ShannonFano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(796, 363);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.endfilesize);
            this.Controls.Add(this.procent);
            this.Controls.Add(this.endsize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startsize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.label);
            this.Controls.Add(this.decoderButton);
            this.Controls.Add(this.coderButton);
            this.Controls.Add(this.decoderTextBox);
            this.Controls.Add(this.coderTextBox);
            this.Controls.Add(this.rocketPicture);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShannonFano";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Shannon-Fano Algorithm";
            ((System.ComponentModel.ISupportInitialize)(this.rocketPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox coderTextBox;
        private System.Windows.Forms.TextBox decoderTextBox;
        private System.Windows.Forms.Button coderButton;
        private System.Windows.Forms.Button decoderButton;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox rocketPicture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label startsize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label endsize;
        private System.Windows.Forms.Label procent;
        private System.Windows.Forms.Label endfilesize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

