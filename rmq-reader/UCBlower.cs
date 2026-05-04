using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMQReader
{
    public partial class UCBlower : UserControl
    {
        public String Caption { get { return gbPanel.Text; } set { gbPanel.Text = value; } }
        public String VaneMR { get { return textBoxVaneMR.Text; } set { textBoxVaneMR.Text = value; } }
        public String VaneSP { get { return textBoxVaneSP.Text; } set { textBoxVaneSP.Text = value; } }
        public String Power { get { return textBoxPower.Text; } set { textBoxPower.Text = value; } }
        public bool InOperation { get { return cbInOperation.Checked; } set { cbInOperation.Checked = value; } }
        public bool StartStop { get { return cbStartStop.Checked; } set { cbStartStop.Checked = value; } }


        public String VanePositionDeltaMAX { get { return textBoxDeltaMAX.Text; } set { textBoxDeltaMAX.Text = value; } }
        public String VanePositionMIN { get { return textBoxPositionMIN.Text; } set { textBoxPositionMIN.Text = value; } }
        public String VanePositionMAX { get { return textBoxPositionMAX.Text; } set { textBoxPositionMAX.Text = value; } }

        public UCBlower()
        {
            InitializeComponent();
        }
    }
}
