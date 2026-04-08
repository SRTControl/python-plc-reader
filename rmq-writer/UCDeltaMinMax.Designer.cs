namespace RMQWriter
{
    partial class UCDeltaMinMax
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
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelDelta = new System.Windows.Forms.Label();
            this.textBoxDelta = new System.Windows.Forms.TextBox();
            this.gbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPanel
            // 
            this.gbPanel.Controls.Add(this.textBoxMax);
            this.gbPanel.Controls.Add(this.textBoxMin);
            this.gbPanel.Controls.Add(this.labelMax);
            this.gbPanel.Controls.Add(this.labelMin);
            this.gbPanel.Controls.Add(this.labelDelta);
            this.gbPanel.Controls.Add(this.textBoxDelta);
            this.gbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbPanel.Location = new System.Drawing.Point(0, 0);
            this.gbPanel.Name = "gbPanel";
            this.gbPanel.Size = new System.Drawing.Size(120, 110);
            this.gbPanel.TabIndex = 1;
            this.gbPanel.TabStop = false;
            this.gbPanel.Text = "GRID";
            // 
            // textBoxMax
            // 
            this.textBoxMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMax.Location = new System.Drawing.Point(58, 75);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(50, 20);
            this.textBoxMax.TabIndex = 8;
            this.textBoxMax.Text = "0.00";
            this.textBoxMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMin
            // 
            this.textBoxMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMin.Location = new System.Drawing.Point(58, 49);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(50, 20);
            this.textBoxMin.TabIndex = 6;
            this.textBoxMin.Text = "0.00";
            this.textBoxMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMax.ForeColor = System.Drawing.Color.DimGray;
            this.labelMax.Location = new System.Drawing.Point(6, 79);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(27, 13);
            this.labelMax.TabIndex = 3;
            this.labelMax.Text = "Max";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMin.ForeColor = System.Drawing.Color.DimGray;
            this.labelMin.Location = new System.Drawing.Point(6, 53);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(24, 13);
            this.labelMin.TabIndex = 2;
            this.labelMin.Text = "Min";
            // 
            // labelDelta
            // 
            this.labelDelta.AutoSize = true;
            this.labelDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDelta.ForeColor = System.Drawing.Color.DimGray;
            this.labelDelta.Location = new System.Drawing.Point(6, 27);
            this.labelDelta.Name = "labelDelta";
            this.labelDelta.Size = new System.Drawing.Size(32, 13);
            this.labelDelta.TabIndex = 1;
            this.labelDelta.Text = "Delta";
            // 
            // textBoxDelta
            // 
            this.textBoxDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDelta.Location = new System.Drawing.Point(58, 23);
            this.textBoxDelta.Name = "textBoxDelta";
            this.textBoxDelta.Size = new System.Drawing.Size(50, 20);
            this.textBoxDelta.TabIndex = 0;
            this.textBoxDelta.Text = "0.00";
            this.textBoxDelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UCDeltaMinMax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPanel);
            this.Name = "UCDeltaMinMax";
            this.Size = new System.Drawing.Size(120, 110);
            this.gbPanel.ResumeLayout(false);
            this.gbPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPanel;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelDelta;
        private System.Windows.Forms.TextBox textBoxDelta;
    }
}
