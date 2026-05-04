namespace RMQReader
{
    partial class UCBlower
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbPanel = new System.Windows.Forms.GroupBox();
            this.cbStartStop = new System.Windows.Forms.CheckBox();
            this.cbInOperation = new System.Windows.Forms.CheckBox();
            this.textBoxPower = new System.Windows.Forms.TextBox();
            this.textBoxVaneSP = new System.Windows.Forms.TextBox();
            this.labelAirflow = new System.Windows.Forms.Label();
            this.labelVane = new System.Windows.Forms.Label();
            this.textBoxVaneMR = new System.Windows.Forms.TextBox();
            this.textBoxPositionMIN = new System.Windows.Forms.TextBox();
            this.textBoxPositionMAX = new System.Windows.Forms.TextBox();
            this.textBoxDeltaMAX = new System.Windows.Forms.TextBox();
            this.gbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPanel
            // 
            this.gbPanel.Controls.Add(this.textBoxDeltaMAX);
            this.gbPanel.Controls.Add(this.textBoxPositionMAX);
            this.gbPanel.Controls.Add(this.textBoxPositionMIN);
            this.gbPanel.Controls.Add(this.cbStartStop);
            this.gbPanel.Controls.Add(this.cbInOperation);
            this.gbPanel.Controls.Add(this.textBoxPower);
            this.gbPanel.Controls.Add(this.textBoxVaneSP);
            this.gbPanel.Controls.Add(this.labelAirflow);
            this.gbPanel.Controls.Add(this.labelVane);
            this.gbPanel.Controls.Add(this.textBoxVaneMR);
            this.gbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbPanel.Location = new System.Drawing.Point(0, 0);
            this.gbPanel.Name = "gbPanel";
            this.gbPanel.Size = new System.Drawing.Size(170, 130);
            this.gbPanel.TabIndex = 1;
            this.gbPanel.TabStop = false;
            this.gbPanel.Text = "BLOWER";
            // 
            // cbStartStop
            // 
            this.cbStartStop.AutoSize = true;
            this.cbStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbStartStop.ForeColor = System.Drawing.Color.DimGray;
            this.cbStartStop.Location = new System.Drawing.Point(58, 98);
            this.cbStartStop.Name = "cbStartStop";
            this.cbStartStop.Size = new System.Drawing.Size(81, 17);
            this.cbStartStop.TabIndex = 8;
            this.cbStartStop.Text = "Start / Stop";
            this.cbStartStop.UseVisualStyleBackColor = true;
            // 
            // cbInOperation
            // 
            this.cbInOperation.AutoSize = true;
            this.cbInOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbInOperation.ForeColor = System.Drawing.Color.DimGray;
            this.cbInOperation.Location = new System.Drawing.Point(58, 75);
            this.cbInOperation.Name = "cbInOperation";
            this.cbInOperation.Size = new System.Drawing.Size(82, 17);
            this.cbInOperation.TabIndex = 7;
            this.cbInOperation.Text = "In Operaton";
            this.cbInOperation.UseVisualStyleBackColor = true;
            // 
            // textBoxPower
            // 
            this.textBoxPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPower.Location = new System.Drawing.Point(58, 49);
            this.textBoxPower.Name = "textBoxPower";
            this.textBoxPower.Size = new System.Drawing.Size(50, 20);
            this.textBoxPower.TabIndex = 6;
            this.textBoxPower.Text = "0.00";
            this.textBoxPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxVaneSP
            // 
            this.textBoxVaneSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxVaneSP.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.textBoxVaneSP.Location = new System.Drawing.Point(114, 23);
            this.textBoxVaneSP.Name = "textBoxVaneSP";
            this.textBoxVaneSP.Size = new System.Drawing.Size(50, 20);
            this.textBoxVaneSP.TabIndex = 5;
            this.textBoxVaneSP.Text = "0.00";
            this.textBoxVaneSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAirflow
            // 
            this.labelAirflow.AutoSize = true;
            this.labelAirflow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAirflow.ForeColor = System.Drawing.Color.DimGray;
            this.labelAirflow.Location = new System.Drawing.Point(6, 53);
            this.labelAirflow.Name = "labelAirflow";
            this.labelAirflow.Size = new System.Drawing.Size(37, 13);
            this.labelAirflow.TabIndex = 2;
            this.labelAirflow.Text = "Power";
            // 
            // labelVane
            // 
            this.labelVane.AutoSize = true;
            this.labelVane.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVane.ForeColor = System.Drawing.Color.DimGray;
            this.labelVane.Location = new System.Drawing.Point(6, 27);
            this.labelVane.Name = "labelVane";
            this.labelVane.Size = new System.Drawing.Size(32, 13);
            this.labelVane.TabIndex = 1;
            this.labelVane.Text = "Vane";
            // 
            // textBoxVaneMR
            // 
            this.textBoxVaneMR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxVaneMR.Location = new System.Drawing.Point(58, 23);
            this.textBoxVaneMR.Name = "textBoxVaneMR";
            this.textBoxVaneMR.Size = new System.Drawing.Size(50, 20);
            this.textBoxVaneMR.TabIndex = 0;
            this.textBoxVaneMR.Text = "0.00";
            this.textBoxVaneMR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPositionMIN
            // 
            this.textBoxPositionMIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPositionMIN.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxPositionMIN.Location = new System.Drawing.Point(9, 73);
            this.textBoxPositionMIN.Name = "textBoxPositionMIN";
            this.textBoxPositionMIN.Size = new System.Drawing.Size(43, 20);
            this.textBoxPositionMIN.TabIndex = 9;
            this.textBoxPositionMIN.Text = "0.00";
            this.textBoxPositionMIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPositionMAX
            // 
            this.textBoxPositionMAX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPositionMAX.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxPositionMAX.Location = new System.Drawing.Point(9, 96);
            this.textBoxPositionMAX.Name = "textBoxPositionMAX";
            this.textBoxPositionMAX.Size = new System.Drawing.Size(43, 20);
            this.textBoxPositionMAX.TabIndex = 10;
            this.textBoxPositionMAX.Text = "0.00";
            this.textBoxPositionMAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDeltaMAX
            // 
            this.textBoxDeltaMAX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDeltaMAX.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxDeltaMAX.Location = new System.Drawing.Point(114, 50);
            this.textBoxDeltaMAX.Name = "textBoxDeltaMAX";
            this.textBoxDeltaMAX.Size = new System.Drawing.Size(50, 20);
            this.textBoxDeltaMAX.TabIndex = 11;
            this.textBoxDeltaMAX.Text = "0.00";
            this.textBoxDeltaMAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UCBlower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPanel);
            this.Name = "UCBlower";
            this.Size = new System.Drawing.Size(170, 130);
            this.gbPanel.ResumeLayout(false);
            this.gbPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPanel;
        private System.Windows.Forms.TextBox textBoxPower;
        private System.Windows.Forms.TextBox textBoxVaneSP;
        private System.Windows.Forms.Label labelAirflow;
        private System.Windows.Forms.Label labelVane;
        private System.Windows.Forms.TextBox textBoxVaneMR;
        private System.Windows.Forms.CheckBox cbStartStop;
        private System.Windows.Forms.CheckBox cbInOperation;
        private System.Windows.Forms.TextBox textBoxDeltaMAX;
        private System.Windows.Forms.TextBox textBoxPositionMAX;
        private System.Windows.Forms.TextBox textBoxPositionMIN;
    }
}
