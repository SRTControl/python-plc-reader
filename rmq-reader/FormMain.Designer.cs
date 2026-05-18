namespace RMQReader
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
            this.T3G3 = new RMQReader.UCGrid();
            this.T3G4 = new RMQReader.UCGrid();
            this.T3G5 = new RMQReader.UCGrid();
            this.T3G6 = new RMQReader.UCGrid();
            this.T3G7 = new RMQReader.UCGrid();
            this.T4G7 = new RMQReader.UCGrid();
            this.T4G6 = new RMQReader.UCGrid();
            this.T4G5 = new RMQReader.UCGrid();
            this.T4G4 = new RMQReader.UCGrid();
            this.T4G3 = new RMQReader.UCGrid();
            this.T5G7 = new RMQReader.UCGrid();
            this.T5G6 = new RMQReader.UCGrid();
            this.T5G5 = new RMQReader.UCGrid();
            this.T5G4 = new RMQReader.UCGrid();
            this.T5G3 = new RMQReader.UCGrid();
            this.Blower7 = new RMQReader.UCBlower();
            this.Blower8 = new RMQReader.UCBlower();
            this.Common = new System.Windows.Forms.GroupBox();
            this.textBoxPressureMAX = new System.Windows.Forms.TextBox();
            this.textBoxPressureMIN = new System.Windows.Forms.TextBox();
            this.textBoxPressureDeltaMAX = new System.Windows.Forms.TextBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.cbDOMasterInOperation = new System.Windows.Forms.CheckBox();
            this.textBoxPH3 = new System.Windows.Forms.TextBox();
            this.labelPH3 = new System.Windows.Forms.Label();
            this.textBoxPH2 = new System.Windows.Forms.TextBox();
            this.labelPH2 = new System.Windows.Forms.Label();
            this.textBoxPH1 = new System.Windows.Forms.TextBox();
            this.labelPH1 = new System.Windows.Forms.Label();
            this.textBoxRainGauge = new System.Windows.Forms.TextBox();
            this.labelRainGauge = new System.Windows.Forms.Label();
            this.textBoxAirTemperature = new System.Windows.Forms.TextBox();
            this.labelAirTemperature = new System.Windows.Forms.Label();
            this.textBoxPressure = new System.Windows.Forms.TextBox();
            this.labelPressure = new System.Windows.Forms.Label();
            this.textBoxTimeStamp = new System.Windows.Forms.TextBox();
            this.labelTimestamp = new System.Windows.Forms.Label();
            this.textBoxQueueName = new System.Windows.Forms.TextBox();
            this.Blower6 = new RMQReader.UCBlower();
            this.Blower5 = new RMQReader.UCBlower();
            this.cbLogger = new System.Windows.Forms.CheckBox();
            this.Common.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnection
            // 
            this.buttonConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnection.Location = new System.Drawing.Point(9, 683);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(170, 30);
            this.buttonConnection.TabIndex = 0;
            this.buttonConnection.Text = "CONNECT";
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnection_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Location = new System.Drawing.Point(713, 683);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(170, 30);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // T3G3
            // 
            this.T3G3.AirflowMR = "0.00";
            this.T3G3.AirflowSP = "0.00";
            this.T3G3.Caption = "GRID";
            this.T3G3.DOMR = "0.00";
            this.T3G3.DOSP = "0.00";
            this.T3G3.Location = new System.Drawing.Point(9, 275);
            this.T3G3.Name = "T3G3";
            this.T3G3.NH3MR = "0.00";
            this.T3G3.NH3SP = "0.00";
            this.T3G3.Size = new System.Drawing.Size(170, 130);
            this.T3G3.TabIndex = 5;
            this.T3G3.ValveMR = "0.00";
            this.T3G3.ValveSP = "0.00";
            // 
            // T3G4
            // 
            this.T3G4.AirflowMR = "0.00";
            this.T3G4.AirflowSP = "0.00";
            this.T3G4.Caption = "GRID";
            this.T3G4.DOMR = "0.00";
            this.T3G4.DOSP = "0.00";
            this.T3G4.Location = new System.Drawing.Point(185, 275);
            this.T3G4.Name = "T3G4";
            this.T3G4.NH3MR = "0.00";
            this.T3G4.NH3SP = "0.00";
            this.T3G4.Size = new System.Drawing.Size(170, 130);
            this.T3G4.TabIndex = 6;
            this.T3G4.ValveMR = "0.00";
            this.T3G4.ValveSP = "0.00";
            // 
            // T3G5
            // 
            this.T3G5.AirflowMR = "0.00";
            this.T3G5.AirflowSP = "0.00";
            this.T3G5.Caption = "GRID";
            this.T3G5.DOMR = "0.00";
            this.T3G5.DOSP = "0.00";
            this.T3G5.Location = new System.Drawing.Point(361, 275);
            this.T3G5.Name = "T3G5";
            this.T3G5.NH3MR = "0.00";
            this.T3G5.NH3SP = "0.00";
            this.T3G5.Size = new System.Drawing.Size(170, 130);
            this.T3G5.TabIndex = 7;
            this.T3G5.ValveMR = "0.00";
            this.T3G5.ValveSP = "0.00";
            // 
            // T3G6
            // 
            this.T3G6.AirflowMR = "0.00";
            this.T3G6.AirflowSP = "0.00";
            this.T3G6.Caption = "GRID";
            this.T3G6.DOMR = "0.00";
            this.T3G6.DOSP = "0.00";
            this.T3G6.Location = new System.Drawing.Point(537, 275);
            this.T3G6.Name = "T3G6";
            this.T3G6.NH3MR = "0.00";
            this.T3G6.NH3SP = "0.00";
            this.T3G6.Size = new System.Drawing.Size(170, 130);
            this.T3G6.TabIndex = 8;
            this.T3G6.ValveMR = "0.00";
            this.T3G6.ValveSP = "0.00";
            // 
            // T3G7
            // 
            this.T3G7.AirflowMR = "0.00";
            this.T3G7.AirflowSP = "0.00";
            this.T3G7.Caption = "GRID";
            this.T3G7.DOMR = "0.00";
            this.T3G7.DOSP = "0.00";
            this.T3G7.Location = new System.Drawing.Point(713, 275);
            this.T3G7.Name = "T3G7";
            this.T3G7.NH3MR = "0.00";
            this.T3G7.NH3SP = "0.00";
            this.T3G7.Size = new System.Drawing.Size(170, 130);
            this.T3G7.TabIndex = 9;
            this.T3G7.ValveMR = "0.00";
            this.T3G7.ValveSP = "0.00";
            // 
            // T4G7
            // 
            this.T4G7.AirflowMR = "0.00";
            this.T4G7.AirflowSP = "0.00";
            this.T4G7.Caption = "GRID";
            this.T4G7.DOMR = "0.00";
            this.T4G7.DOSP = "0.00";
            this.T4G7.Location = new System.Drawing.Point(713, 411);
            this.T4G7.Name = "T4G7";
            this.T4G7.NH3MR = "0.00";
            this.T4G7.NH3SP = "0.00";
            this.T4G7.Size = new System.Drawing.Size(170, 130);
            this.T4G7.TabIndex = 14;
            this.T4G7.ValveMR = "0.00";
            this.T4G7.ValveSP = "0.00";
            // 
            // T4G6
            // 
            this.T4G6.AirflowMR = "0.00";
            this.T4G6.AirflowSP = "0.00";
            this.T4G6.Caption = "GRID";
            this.T4G6.DOMR = "0.00";
            this.T4G6.DOSP = "0.00";
            this.T4G6.Location = new System.Drawing.Point(537, 411);
            this.T4G6.Name = "T4G6";
            this.T4G6.NH3MR = "0.00";
            this.T4G6.NH3SP = "0.00";
            this.T4G6.Size = new System.Drawing.Size(170, 130);
            this.T4G6.TabIndex = 13;
            this.T4G6.ValveMR = "0.00";
            this.T4G6.ValveSP = "0.00";
            // 
            // T4G5
            // 
            this.T4G5.AirflowMR = "0.00";
            this.T4G5.AirflowSP = "0.00";
            this.T4G5.Caption = "GRID";
            this.T4G5.DOMR = "0.00";
            this.T4G5.DOSP = "0.00";
            this.T4G5.Location = new System.Drawing.Point(361, 411);
            this.T4G5.Name = "T4G5";
            this.T4G5.NH3MR = "0.00";
            this.T4G5.NH3SP = "0.00";
            this.T4G5.Size = new System.Drawing.Size(170, 130);
            this.T4G5.TabIndex = 12;
            this.T4G5.ValveMR = "0.00";
            this.T4G5.ValveSP = "0.00";
            // 
            // T4G4
            // 
            this.T4G4.AirflowMR = "0.00";
            this.T4G4.AirflowSP = "0.00";
            this.T4G4.Caption = "GRID";
            this.T4G4.DOMR = "0.00";
            this.T4G4.DOSP = "0.00";
            this.T4G4.Location = new System.Drawing.Point(185, 411);
            this.T4G4.Name = "T4G4";
            this.T4G4.NH3MR = "0.00";
            this.T4G4.NH3SP = "0.00";
            this.T4G4.Size = new System.Drawing.Size(170, 130);
            this.T4G4.TabIndex = 11;
            this.T4G4.ValveMR = "0.00";
            this.T4G4.ValveSP = "0.00";
            // 
            // T4G3
            // 
            this.T4G3.AirflowMR = "0.00";
            this.T4G3.AirflowSP = "0.00";
            this.T4G3.Caption = "GRID";
            this.T4G3.DOMR = "0.00";
            this.T4G3.DOSP = "0.00";
            this.T4G3.Location = new System.Drawing.Point(9, 411);
            this.T4G3.Name = "T4G3";
            this.T4G3.NH3MR = "0.00";
            this.T4G3.NH3SP = "0.00";
            this.T4G3.Size = new System.Drawing.Size(170, 130);
            this.T4G3.TabIndex = 10;
            this.T4G3.ValveMR = "0.00";
            this.T4G3.ValveSP = "0.00";
            // 
            // T5G7
            // 
            this.T5G7.AirflowMR = "0.00";
            this.T5G7.AirflowSP = "0.00";
            this.T5G7.Caption = "GRID";
            this.T5G7.DOMR = "0.00";
            this.T5G7.DOSP = "0.00";
            this.T5G7.Location = new System.Drawing.Point(713, 547);
            this.T5G7.Name = "T5G7";
            this.T5G7.NH3MR = "0.00";
            this.T5G7.NH3SP = "0.00";
            this.T5G7.Size = new System.Drawing.Size(170, 130);
            this.T5G7.TabIndex = 19;
            this.T5G7.ValveMR = "0.00";
            this.T5G7.ValveSP = "0.00";
            // 
            // T5G6
            // 
            this.T5G6.AirflowMR = "0.00";
            this.T5G6.AirflowSP = "0.00";
            this.T5G6.Caption = "GRID";
            this.T5G6.DOMR = "0.00";
            this.T5G6.DOSP = "0.00";
            this.T5G6.Location = new System.Drawing.Point(537, 547);
            this.T5G6.Name = "T5G6";
            this.T5G6.NH3MR = "0.00";
            this.T5G6.NH3SP = "0.00";
            this.T5G6.Size = new System.Drawing.Size(170, 130);
            this.T5G6.TabIndex = 18;
            this.T5G6.ValveMR = "0.00";
            this.T5G6.ValveSP = "0.00";
            // 
            // T5G5
            // 
            this.T5G5.AirflowMR = "0.00";
            this.T5G5.AirflowSP = "0.00";
            this.T5G5.Caption = "GRID";
            this.T5G5.DOMR = "0.00";
            this.T5G5.DOSP = "0.00";
            this.T5G5.Location = new System.Drawing.Point(361, 547);
            this.T5G5.Name = "T5G5";
            this.T5G5.NH3MR = "0.00";
            this.T5G5.NH3SP = "0.00";
            this.T5G5.Size = new System.Drawing.Size(170, 130);
            this.T5G5.TabIndex = 17;
            this.T5G5.ValveMR = "0.00";
            this.T5G5.ValveSP = "0.00";
            // 
            // T5G4
            // 
            this.T5G4.AirflowMR = "0.00";
            this.T5G4.AirflowSP = "0.00";
            this.T5G4.Caption = "GRID";
            this.T5G4.DOMR = "0.00";
            this.T5G4.DOSP = "0.00";
            this.T5G4.Location = new System.Drawing.Point(185, 547);
            this.T5G4.Name = "T5G4";
            this.T5G4.NH3MR = "0.00";
            this.T5G4.NH3SP = "0.00";
            this.T5G4.Size = new System.Drawing.Size(170, 130);
            this.T5G4.TabIndex = 16;
            this.T5G4.ValveMR = "0.00";
            this.T5G4.ValveSP = "0.00";
            // 
            // T5G3
            // 
            this.T5G3.AirflowMR = "0.00";
            this.T5G3.AirflowSP = "0.00";
            this.T5G3.Caption = "GRID";
            this.T5G3.DOMR = "0.00";
            this.T5G3.DOSP = "0.00";
            this.T5G3.Location = new System.Drawing.Point(9, 547);
            this.T5G3.Name = "T5G3";
            this.T5G3.NH3MR = "0.00";
            this.T5G3.NH3SP = "0.00";
            this.T5G3.Size = new System.Drawing.Size(170, 130);
            this.T5G3.TabIndex = 15;
            this.T5G3.ValveMR = "0.00";
            this.T5G3.ValveSP = "0.00";
            // 
            // Blower7
            // 
            this.Blower7.Caption = "BLOWER";
            this.Blower7.InOperation = false;
            this.Blower7.Location = new System.Drawing.Point(361, 12);
            this.Blower7.Name = "Blower7";
            this.Blower7.Power = "0.00";
            this.Blower7.Size = new System.Drawing.Size(170, 130);
            this.Blower7.StartStop = false;
            this.Blower7.TabIndex = 20;
            this.Blower7.VaneMR = "0.00";
            this.Blower7.VanePositionDeltaMAX = "0.00";
            this.Blower7.VanePositionMAX = "0.00";
            this.Blower7.VanePositionMIN = "0.00";
            this.Blower7.VaneSP = "0.00";
            // 
            // Blower8
            // 
            this.Blower8.Caption = "BLOWER";
            this.Blower8.InOperation = false;
            this.Blower8.Location = new System.Drawing.Point(537, 12);
            this.Blower8.Name = "Blower8";
            this.Blower8.Power = "0.00";
            this.Blower8.Size = new System.Drawing.Size(170, 130);
            this.Blower8.StartStop = false;
            this.Blower8.TabIndex = 21;
            this.Blower8.VaneMR = "0.00";
            this.Blower8.VanePositionDeltaMAX = "0.00";
            this.Blower8.VanePositionMAX = "0.00";
            this.Blower8.VanePositionMIN = "0.00";
            this.Blower8.VaneSP = "0.00";
            // 
            // Common
            // 
            this.Common.Controls.Add(this.textBoxPressureMAX);
            this.Common.Controls.Add(this.textBoxPressureMIN);
            this.Common.Controls.Add(this.textBoxPressureDeltaMAX);
            this.Common.Controls.Add(this.pictureBoxLogo);
            this.Common.Controls.Add(this.cbDOMasterInOperation);
            this.Common.Controls.Add(this.textBoxPH3);
            this.Common.Controls.Add(this.labelPH3);
            this.Common.Controls.Add(this.textBoxPH2);
            this.Common.Controls.Add(this.labelPH2);
            this.Common.Controls.Add(this.textBoxPH1);
            this.Common.Controls.Add(this.labelPH1);
            this.Common.Controls.Add(this.textBoxRainGauge);
            this.Common.Controls.Add(this.labelRainGauge);
            this.Common.Controls.Add(this.textBoxAirTemperature);
            this.Common.Controls.Add(this.labelAirTemperature);
            this.Common.Controls.Add(this.textBoxPressure);
            this.Common.Controls.Add(this.labelPressure);
            this.Common.Controls.Add(this.textBoxTimeStamp);
            this.Common.Controls.Add(this.labelTimestamp);
            this.Common.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Common.Location = new System.Drawing.Point(9, 144);
            this.Common.Name = "Common";
            this.Common.Size = new System.Drawing.Size(522, 130);
            this.Common.TabIndex = 22;
            this.Common.TabStop = false;
            this.Common.Text = "COMMON";
            // 
            // textBoxPressureMAX
            // 
            this.textBoxPressureMAX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPressureMAX.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxPressureMAX.Location = new System.Drawing.Point(290, 101);
            this.textBoxPressureMAX.Name = "textBoxPressureMAX";
            this.textBoxPressureMAX.Size = new System.Drawing.Size(50, 20);
            this.textBoxPressureMAX.TabIndex = 25;
            this.textBoxPressureMAX.Text = "0.00";
            this.textBoxPressureMAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPressureMIN
            // 
            this.textBoxPressureMIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPressureMIN.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxPressureMIN.Location = new System.Drawing.Point(290, 75);
            this.textBoxPressureMIN.Name = "textBoxPressureMIN";
            this.textBoxPressureMIN.Size = new System.Drawing.Size(50, 20);
            this.textBoxPressureMIN.TabIndex = 24;
            this.textBoxPressureMIN.Text = "0.00";
            this.textBoxPressureMIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPressureDeltaMAX
            // 
            this.textBoxPressureDeltaMAX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPressureDeltaMAX.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxPressureDeltaMAX.Location = new System.Drawing.Point(290, 49);
            this.textBoxPressureDeltaMAX.Name = "textBoxPressureDeltaMAX";
            this.textBoxPressureDeltaMAX.Size = new System.Drawing.Size(50, 20);
            this.textBoxPressureDeltaMAX.TabIndex = 23;
            this.textBoxPressureDeltaMAX.Text = "0.00";
            this.textBoxPressureDeltaMAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLogo.Image = global::RMQReader.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(366, 18);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(150, 100);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 22;
            this.pictureBoxLogo.TabStop = false;
            // 
            // cbDOMasterInOperation
            // 
            this.cbDOMasterInOperation.AutoSize = true;
            this.cbDOMasterInOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDOMasterInOperation.ForeColor = System.Drawing.Color.DimGray;
            this.cbDOMasterInOperation.Location = new System.Drawing.Point(191, 25);
            this.cbDOMasterInOperation.Name = "cbDOMasterInOperation";
            this.cbDOMasterInOperation.Size = new System.Drawing.Size(84, 17);
            this.cbDOMasterInOperation.TabIndex = 21;
            this.cbDOMasterInOperation.Text = "In Operation";
            this.cbDOMasterInOperation.UseVisualStyleBackColor = true;
            // 
            // textBoxPH3
            // 
            this.textBoxPH3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPH3.Location = new System.Drawing.Point(234, 101);
            this.textBoxPH3.Name = "textBoxPH3";
            this.textBoxPH3.Size = new System.Drawing.Size(50, 20);
            this.textBoxPH3.TabIndex = 20;
            this.textBoxPH3.Text = "0.00";
            this.textBoxPH3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPH3
            // 
            this.labelPH3.AutoSize = true;
            this.labelPH3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPH3.ForeColor = System.Drawing.Color.DimGray;
            this.labelPH3.Location = new System.Drawing.Point(188, 105);
            this.labelPH3.Name = "labelPH3";
            this.labelPH3.Size = new System.Drawing.Size(27, 13);
            this.labelPH3.TabIndex = 19;
            this.labelPH3.Text = "pH3";
            // 
            // textBoxPH2
            // 
            this.textBoxPH2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPH2.Location = new System.Drawing.Point(234, 75);
            this.textBoxPH2.Name = "textBoxPH2";
            this.textBoxPH2.Size = new System.Drawing.Size(50, 20);
            this.textBoxPH2.TabIndex = 18;
            this.textBoxPH2.Text = "0.00";
            this.textBoxPH2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPH2
            // 
            this.labelPH2.AutoSize = true;
            this.labelPH2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPH2.ForeColor = System.Drawing.Color.DimGray;
            this.labelPH2.Location = new System.Drawing.Point(188, 79);
            this.labelPH2.Name = "labelPH2";
            this.labelPH2.Size = new System.Drawing.Size(27, 13);
            this.labelPH2.TabIndex = 17;
            this.labelPH2.Text = "pH2";
            // 
            // textBoxPH1
            // 
            this.textBoxPH1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPH1.Location = new System.Drawing.Point(234, 49);
            this.textBoxPH1.Name = "textBoxPH1";
            this.textBoxPH1.Size = new System.Drawing.Size(50, 20);
            this.textBoxPH1.TabIndex = 16;
            this.textBoxPH1.Text = "0.00";
            this.textBoxPH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPH1
            // 
            this.labelPH1.AutoSize = true;
            this.labelPH1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPH1.ForeColor = System.Drawing.Color.DimGray;
            this.labelPH1.Location = new System.Drawing.Point(188, 53);
            this.labelPH1.Name = "labelPH1";
            this.labelPH1.Size = new System.Drawing.Size(27, 13);
            this.labelPH1.TabIndex = 15;
            this.labelPH1.Text = "pH1";
            // 
            // textBoxRainGauge
            // 
            this.textBoxRainGauge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRainGauge.Location = new System.Drawing.Point(114, 101);
            this.textBoxRainGauge.Name = "textBoxRainGauge";
            this.textBoxRainGauge.Size = new System.Drawing.Size(50, 20);
            this.textBoxRainGauge.TabIndex = 14;
            this.textBoxRainGauge.Text = "0.00";
            this.textBoxRainGauge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelRainGauge
            // 
            this.labelRainGauge.AutoSize = true;
            this.labelRainGauge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRainGauge.ForeColor = System.Drawing.Color.DimGray;
            this.labelRainGauge.Location = new System.Drawing.Point(12, 105);
            this.labelRainGauge.Name = "labelRainGauge";
            this.labelRainGauge.Size = new System.Drawing.Size(61, 13);
            this.labelRainGauge.TabIndex = 13;
            this.labelRainGauge.Text = "RainGauge";
            // 
            // textBoxAirTemperature
            // 
            this.textBoxAirTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAirTemperature.Location = new System.Drawing.Point(114, 75);
            this.textBoxAirTemperature.Name = "textBoxAirTemperature";
            this.textBoxAirTemperature.Size = new System.Drawing.Size(50, 20);
            this.textBoxAirTemperature.TabIndex = 12;
            this.textBoxAirTemperature.Text = "0.00";
            this.textBoxAirTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAirTemperature
            // 
            this.labelAirTemperature.AutoSize = true;
            this.labelAirTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAirTemperature.ForeColor = System.Drawing.Color.DimGray;
            this.labelAirTemperature.Location = new System.Drawing.Point(12, 79);
            this.labelAirTemperature.Name = "labelAirTemperature";
            this.labelAirTemperature.Size = new System.Drawing.Size(79, 13);
            this.labelAirTemperature.TabIndex = 11;
            this.labelAirTemperature.Text = "AirTemperature";
            // 
            // textBoxPressure
            // 
            this.textBoxPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPressure.Location = new System.Drawing.Point(114, 49);
            this.textBoxPressure.Name = "textBoxPressure";
            this.textBoxPressure.Size = new System.Drawing.Size(50, 20);
            this.textBoxPressure.TabIndex = 10;
            this.textBoxPressure.Text = "0.00";
            this.textBoxPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPressure.ForeColor = System.Drawing.Color.DimGray;
            this.labelPressure.Location = new System.Drawing.Point(12, 53);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(48, 13);
            this.labelPressure.TabIndex = 9;
            this.labelPressure.Text = "Pressure";
            // 
            // textBoxTimeStamp
            // 
            this.textBoxTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTimeStamp.Location = new System.Drawing.Point(58, 23);
            this.textBoxTimeStamp.Name = "textBoxTimeStamp";
            this.textBoxTimeStamp.Size = new System.Drawing.Size(106, 20);
            this.textBoxTimeStamp.TabIndex = 8;
            this.textBoxTimeStamp.Text = "0.00";
            this.textBoxTimeStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTimestamp
            // 
            this.labelTimestamp.AutoSize = true;
            this.labelTimestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimestamp.ForeColor = System.Drawing.Color.DimGray;
            this.labelTimestamp.Location = new System.Drawing.Point(12, 27);
            this.labelTimestamp.Name = "labelTimestamp";
            this.labelTimestamp.Size = new System.Drawing.Size(21, 13);
            this.labelTimestamp.TabIndex = 7;
            this.labelTimestamp.Text = "TS";
            // 
            // textBoxQueueName
            // 
            this.textBoxQueueName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxQueueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQueueName.Location = new System.Drawing.Point(185, 685);
            this.textBoxQueueName.Name = "textBoxQueueName";
            this.textBoxQueueName.Size = new System.Drawing.Size(522, 26);
            this.textBoxQueueName.TabIndex = 23;
            this.textBoxQueueName.Text = "plc_control_queue";
            // 
            // Blower6
            // 
            this.Blower6.Caption = "BLOWER";
            this.Blower6.InOperation = false;
            this.Blower6.Location = new System.Drawing.Point(185, 12);
            this.Blower6.Name = "Blower6";
            this.Blower6.Power = "0.00";
            this.Blower6.Size = new System.Drawing.Size(170, 130);
            this.Blower6.StartStop = false;
            this.Blower6.TabIndex = 25;
            this.Blower6.VaneMR = "0.00";
            this.Blower6.VanePositionDeltaMAX = "0.00";
            this.Blower6.VanePositionMAX = "0.00";
            this.Blower6.VanePositionMIN = "0.00";
            this.Blower6.VaneSP = "0.00";
            // 
            // Blower5
            // 
            this.Blower5.Caption = "BLOWER";
            this.Blower5.InOperation = false;
            this.Blower5.Location = new System.Drawing.Point(9, 12);
            this.Blower5.Name = "Blower5";
            this.Blower5.Power = "0.00";
            this.Blower5.Size = new System.Drawing.Size(170, 130);
            this.Blower5.StartStop = false;
            this.Blower5.TabIndex = 24;
            this.Blower5.VaneMR = "0.00";
            this.Blower5.VanePositionDeltaMAX = "0.00";
            this.Blower5.VanePositionMAX = "0.00";
            this.Blower5.VanePositionMIN = "0.00";
            this.Blower5.VaneSP = "0.00";
            // 
            // cbLogger
            // 
            this.cbLogger.AutoSize = true;
            this.cbLogger.Checked = true;
            this.cbLogger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLogger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLogger.ForeColor = System.Drawing.Color.DimGray;
            this.cbLogger.Location = new System.Drawing.Point(537, 257);
            this.cbLogger.Name = "cbLogger";
            this.cbLogger.Size = new System.Drawing.Size(59, 17);
            this.cbLogger.TabIndex = 26;
            this.cbLogger.Text = "Logger";
            this.cbLogger.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 721);
            this.Controls.Add(this.cbLogger);
            this.Controls.Add(this.Blower6);
            this.Controls.Add(this.Blower5);
            this.Controls.Add(this.textBoxQueueName);
            this.Controls.Add(this.Common);
            this.Controls.Add(this.Blower8);
            this.Controls.Add(this.Blower7);
            this.Controls.Add(this.T5G7);
            this.Controls.Add(this.T5G6);
            this.Controls.Add(this.T5G5);
            this.Controls.Add(this.T5G4);
            this.Controls.Add(this.T5G3);
            this.Controls.Add(this.T4G7);
            this.Controls.Add(this.T4G6);
            this.Controls.Add(this.T4G5);
            this.Controls.Add(this.T4G4);
            this.Controls.Add(this.T4G3);
            this.Controls.Add(this.T3G7);
            this.Controls.Add(this.T3G6);
            this.Controls.Add(this.T3G5);
            this.Controls.Add(this.T3G4);
            this.Controls.Add(this.T3G3);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonConnection);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RMQReader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Common.ResumeLayout(false);
            this.Common.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnection;
        private System.Windows.Forms.Button buttonClose;
        private UCGrid T3G3;
        private UCGrid T3G4;
        private UCGrid T3G5;
        private UCGrid T3G6;
        private UCGrid T3G7;
        private UCGrid T4G7;
        private UCGrid T4G6;
        private UCGrid T4G5;
        private UCGrid T4G4;
        private UCGrid T4G3;
        private UCGrid T5G7;
        private UCGrid T5G6;
        private UCGrid T5G5;
        private UCGrid T5G4;
        private UCGrid T5G3;
        private UCBlower Blower7;
        private UCBlower Blower8;
        private System.Windows.Forms.GroupBox Common;
        private System.Windows.Forms.TextBox textBoxRainGauge;
        private System.Windows.Forms.Label labelRainGauge;
        private System.Windows.Forms.TextBox textBoxAirTemperature;
        private System.Windows.Forms.Label labelAirTemperature;
        private System.Windows.Forms.TextBox textBoxPressure;
        private System.Windows.Forms.Label labelPressure;
        private System.Windows.Forms.TextBox textBoxTimeStamp;
        private System.Windows.Forms.Label labelTimestamp;
        private System.Windows.Forms.TextBox textBoxPH3;
        private System.Windows.Forms.Label labelPH3;
        private System.Windows.Forms.TextBox textBoxPH2;
        private System.Windows.Forms.Label labelPH2;
        private System.Windows.Forms.TextBox textBoxPH1;
        private System.Windows.Forms.Label labelPH1;
        private System.Windows.Forms.CheckBox cbDOMasterInOperation;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox textBoxQueueName;
        private System.Windows.Forms.TextBox textBoxPressureMAX;
        private System.Windows.Forms.TextBox textBoxPressureMIN;
        private System.Windows.Forms.TextBox textBoxPressureDeltaMAX;
        private UCBlower Blower6;
        private UCBlower Blower5;
        private System.Windows.Forms.CheckBox cbLogger;
    }
}

