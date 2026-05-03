namespace RMQWriter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxQueueName = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonConnection = new System.Windows.Forms.Button();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.ucBL5 = new RMQWriter.UCDeltaMinMax();
            this.ucBL6 = new RMQWriter.UCDeltaMinMax();
            this.ucBL7 = new RMQWriter.UCDeltaMinMax();
            this.ucBL8 = new RMQWriter.UCDeltaMinMax();
            this.ucCM = new RMQWriter.UCDeltaMinMax();
            this.SuspendLayout();
            // 
            // textBoxQueueName
            // 
            this.textBoxQueueName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxQueueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQueueName.Location = new System.Drawing.Point(188, 251);
            this.textBoxQueueName.Name = "textBoxQueueName";
            this.textBoxQueueName.Size = new System.Drawing.Size(200, 26);
            this.textBoxQueueName.TabIndex = 26;
            this.textBoxQueueName.Text = "plc_writer_queue";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Location = new System.Drawing.Point(394, 249);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 30);
            this.buttonClose.TabIndex = 25;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonConnection
            // 
            this.buttonConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnection.Location = new System.Drawing.Point(12, 249);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(170, 30);
            this.buttonConnection.TabIndex = 24;
            this.buttonConnection.Text = "CONNECT";
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnection_Click);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 10000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // ucBL5
            // 
            this.ucBL5.Caption = "BLOWER 5";
            this.ucBL5.Delta = 0D;
            this.ucBL5.Location = new System.Drawing.Point(12, 12);
            this.ucBL5.Max = 0D;
            this.ucBL5.Min = 0D;
            this.ucBL5.Name = "ucBL5";
            this.ucBL5.Size = new System.Drawing.Size(120, 110);
            this.ucBL5.TabIndex = 27;
            // 
            // ucBL6
            // 
            this.ucBL6.Caption = "BLOWER 6";
            this.ucBL6.Delta = 0D;
            this.ucBL6.Location = new System.Drawing.Point(138, 12);
            this.ucBL6.Max = 0D;
            this.ucBL6.Min = 0D;
            this.ucBL6.Name = "ucBL6";
            this.ucBL6.Size = new System.Drawing.Size(120, 110);
            this.ucBL6.TabIndex = 28;
            // 
            // ucBL7
            // 
            this.ucBL7.Caption = "BLOWER 7";
            this.ucBL7.Delta = 0D;
            this.ucBL7.Location = new System.Drawing.Point(268, 12);
            this.ucBL7.Max = 0D;
            this.ucBL7.Min = 0D;
            this.ucBL7.Name = "ucBL7";
            this.ucBL7.Size = new System.Drawing.Size(120, 110);
            this.ucBL7.TabIndex = 29;
            // 
            // ucBL8
            // 
            this.ucBL8.Caption = "BLOWER 8";
            this.ucBL8.Delta = 0D;
            this.ucBL8.Location = new System.Drawing.Point(394, 12);
            this.ucBL8.Max = 0D;
            this.ucBL8.Min = 0D;
            this.ucBL8.Name = "ucBL8";
            this.ucBL8.Size = new System.Drawing.Size(120, 110);
            this.ucBL8.TabIndex = 30;
            // 
            // ucCM
            // 
            this.ucCM.Caption = "COMMON";
            this.ucCM.Delta = 0D;
            this.ucCM.Location = new System.Drawing.Point(12, 128);
            this.ucCM.Max = 0D;
            this.ucCM.Min = 0D;
            this.ucCM.Name = "ucCM";
            this.ucCM.Size = new System.Drawing.Size(120, 110);
            this.ucCM.TabIndex = 31;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 291);
            this.Controls.Add(this.ucCM);
            this.Controls.Add(this.ucBL8);
            this.Controls.Add(this.ucBL7);
            this.Controls.Add(this.ucBL6);
            this.Controls.Add(this.ucBL5);
            this.Controls.Add(this.textBoxQueueName);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RMQWriter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQueueName;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonConnection;
        private System.Windows.Forms.Timer timerMain;
        private UCDeltaMinMax ucBL5;
        private UCDeltaMinMax ucBL6;
        private UCDeltaMinMax ucBL7;
        private UCDeltaMinMax ucBL8;
        private UCDeltaMinMax ucCM;
    }
}

