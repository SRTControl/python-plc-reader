namespace RMQMonitor
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonConnection = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxQueueName = new System.Windows.Forms.TextBox();
            this.textBoxTimeStamp = new System.Windows.Forms.TextBox();
            this.labelTimestamp = new System.Windows.Forms.Label();
            this.AF33 = new System.Windows.Forms.TextBox();
            this.AF34 = new System.Windows.Forms.TextBox();
            this.AF35 = new System.Windows.Forms.TextBox();
            this.AF36 = new System.Windows.Forms.TextBox();
            this.AF37 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AF47 = new System.Windows.Forms.TextBox();
            this.AF46 = new System.Windows.Forms.TextBox();
            this.AF45 = new System.Windows.Forms.TextBox();
            this.AF44 = new System.Windows.Forms.TextBox();
            this.AF43 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.AF57 = new System.Windows.Forms.TextBox();
            this.AF56 = new System.Windows.Forms.TextBox();
            this.AF55 = new System.Windows.Forms.TextBox();
            this.AF54 = new System.Windows.Forms.TextBox();
            this.AF53 = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonConnection
            // 
            this.buttonConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnection.Location = new System.Drawing.Point(12, 419);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(150, 30);
            this.buttonConnection.TabIndex = 1;
            this.buttonConnection.Text = "CONNECT";
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnection_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Location = new System.Drawing.Point(168, 419);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(131, 30);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxQueueName
            // 
            this.textBoxQueueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQueueName.Location = new System.Drawing.Point(12, 387);
            this.textBoxQueueName.Name = "textBoxQueueName";
            this.textBoxQueueName.Size = new System.Drawing.Size(284, 26);
            this.textBoxQueueName.TabIndex = 24;
            this.textBoxQueueName.Text = "plc_monitor_queue";
            // 
            // textBoxTimeStamp
            // 
            this.textBoxTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTimeStamp.Location = new System.Drawing.Point(51, 12);
            this.textBoxTimeStamp.Name = "textBoxTimeStamp";
            this.textBoxTimeStamp.Size = new System.Drawing.Size(149, 22);
            this.textBoxTimeStamp.TabIndex = 26;
            this.textBoxTimeStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTimestamp
            // 
            this.labelTimestamp.AutoSize = true;
            this.labelTimestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimestamp.ForeColor = System.Drawing.Color.Black;
            this.labelTimestamp.Location = new System.Drawing.Point(10, 15);
            this.labelTimestamp.Name = "labelTimestamp";
            this.labelTimestamp.Size = new System.Drawing.Size(39, 16);
            this.labelTimestamp.TabIndex = 25;
            this.labelTimestamp.Text = "TIME";
            // 
            // AF33
            // 
            this.AF33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF33.Location = new System.Drawing.Point(51, 52);
            this.AF33.Name = "AF33";
            this.AF33.Size = new System.Drawing.Size(50, 22);
            this.AF33.TabIndex = 27;
            this.AF33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF34
            // 
            this.AF34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF34.Location = new System.Drawing.Point(51, 80);
            this.AF34.Name = "AF34";
            this.AF34.Size = new System.Drawing.Size(50, 22);
            this.AF34.TabIndex = 28;
            this.AF34.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF35
            // 
            this.AF35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF35.Location = new System.Drawing.Point(51, 108);
            this.AF35.Name = "AF35";
            this.AF35.Size = new System.Drawing.Size(50, 22);
            this.AF35.TabIndex = 29;
            this.AF35.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF36
            // 
            this.AF36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF36.Location = new System.Drawing.Point(51, 136);
            this.AF36.Name = "AF36";
            this.AF36.Size = new System.Drawing.Size(50, 22);
            this.AF36.TabIndex = 30;
            this.AF36.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF37
            // 
            this.AF37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF37.Location = new System.Drawing.Point(51, 164);
            this.AF37.Name = "AF37";
            this.AF37.Size = new System.Drawing.Size(50, 22);
            this.AF37.TabIndex = 31;
            this.AF37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "AF33";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "AF34";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "AF35";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "AF36";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "AF37";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(109, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "AF47";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(109, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 45;
            this.label7.Text = "AF46";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(109, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 44;
            this.label8.Text = "AF45";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(109, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 16);
            this.label9.TabIndex = 43;
            this.label9.Text = "AF44";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(109, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 16);
            this.label10.TabIndex = 42;
            this.label10.Text = "AF43";
            // 
            // AF47
            // 
            this.AF47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF47.Location = new System.Drawing.Point(150, 164);
            this.AF47.Name = "AF47";
            this.AF47.Size = new System.Drawing.Size(50, 22);
            this.AF47.TabIndex = 41;
            this.AF47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF46
            // 
            this.AF46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF46.Location = new System.Drawing.Point(150, 136);
            this.AF46.Name = "AF46";
            this.AF46.Size = new System.Drawing.Size(50, 22);
            this.AF46.TabIndex = 40;
            this.AF46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF45
            // 
            this.AF45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF45.Location = new System.Drawing.Point(150, 108);
            this.AF45.Name = "AF45";
            this.AF45.Size = new System.Drawing.Size(50, 22);
            this.AF45.TabIndex = 39;
            this.AF45.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF44
            // 
            this.AF44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF44.Location = new System.Drawing.Point(150, 80);
            this.AF44.Name = "AF44";
            this.AF44.Size = new System.Drawing.Size(50, 22);
            this.AF44.TabIndex = 38;
            this.AF44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF43
            // 
            this.AF43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF43.Location = new System.Drawing.Point(150, 52);
            this.AF43.Name = "AF43";
            this.AF43.Size = new System.Drawing.Size(50, 22);
            this.AF43.TabIndex = 37;
            this.AF43.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(205, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 16);
            this.label11.TabIndex = 56;
            this.label11.Text = "AF57";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(205, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 55;
            this.label12.Text = "AF56";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(205, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 16);
            this.label13.TabIndex = 54;
            this.label13.Text = "AF55";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(205, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 16);
            this.label14.TabIndex = 53;
            this.label14.Text = "AF54";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(205, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 16);
            this.label15.TabIndex = 52;
            this.label15.Text = "AF53";
            // 
            // AF57
            // 
            this.AF57.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF57.Location = new System.Drawing.Point(246, 164);
            this.AF57.Name = "AF57";
            this.AF57.Size = new System.Drawing.Size(50, 22);
            this.AF57.TabIndex = 51;
            this.AF57.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF56
            // 
            this.AF56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF56.Location = new System.Drawing.Point(246, 136);
            this.AF56.Name = "AF56";
            this.AF56.Size = new System.Drawing.Size(50, 22);
            this.AF56.TabIndex = 50;
            this.AF56.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF55
            // 
            this.AF55.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF55.Location = new System.Drawing.Point(246, 108);
            this.AF55.Name = "AF55";
            this.AF55.Size = new System.Drawing.Size(50, 22);
            this.AF55.TabIndex = 49;
            this.AF55.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF54
            // 
            this.AF54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF54.Location = new System.Drawing.Point(246, 80);
            this.AF54.Name = "AF54";
            this.AF54.Size = new System.Drawing.Size(50, 22);
            this.AF54.TabIndex = 48;
            this.AF54.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AF53
            // 
            this.AF53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AF53.Location = new System.Drawing.Point(246, 52);
            this.AF53.Name = "AF53";
            this.AF53.Size = new System.Drawing.Size(50, 22);
            this.AF53.TabIndex = 47;
            this.AF53.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCount.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textBoxCount.Location = new System.Drawing.Point(208, 12);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(88, 22);
            this.textBoxCount.TabIndex = 57;
            this.textBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 461);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.AF57);
            this.Controls.Add(this.AF56);
            this.Controls.Add(this.AF55);
            this.Controls.Add(this.AF54);
            this.Controls.Add(this.AF53);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.AF47);
            this.Controls.Add(this.AF46);
            this.Controls.Add(this.AF45);
            this.Controls.Add(this.AF44);
            this.Controls.Add(this.AF43);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AF37);
            this.Controls.Add(this.AF36);
            this.Controls.Add(this.AF35);
            this.Controls.Add(this.AF34);
            this.Controls.Add(this.AF33);
            this.Controls.Add(this.textBoxTimeStamp);
            this.Controls.Add(this.labelTimestamp);
            this.Controls.Add(this.textBoxQueueName);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RMQMonitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnection;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxQueueName;
        private System.Windows.Forms.TextBox textBoxTimeStamp;
        private System.Windows.Forms.Label labelTimestamp;
        private System.Windows.Forms.TextBox AF33;
        private System.Windows.Forms.TextBox AF34;
        private System.Windows.Forms.TextBox AF35;
        private System.Windows.Forms.TextBox AF36;
        private System.Windows.Forms.TextBox AF37;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox AF47;
        private System.Windows.Forms.TextBox AF46;
        private System.Windows.Forms.TextBox AF45;
        private System.Windows.Forms.TextBox AF44;
        private System.Windows.Forms.TextBox AF43;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox AF57;
        private System.Windows.Forms.TextBox AF56;
        private System.Windows.Forms.TextBox AF55;
        private System.Windows.Forms.TextBox AF54;
        private System.Windows.Forms.TextBox AF53;
        private System.Windows.Forms.TextBox textBoxCount;
    }
}

