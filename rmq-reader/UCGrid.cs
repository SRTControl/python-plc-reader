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
    public partial class UCGrid : UserControl
    {
        public String Caption { get { return gbPanel.Text; } set { gbPanel.Text = value; } }
        public String ValveMR { get { return textBoxValveMR.Text; } set { textBoxValveMR.Text = value; } }
        public String ValveSP { get { return textBoxValveSP.Text; } set { textBoxValveSP.Text = value; } }
        public String AirflowMR { get { return textBoxAirflowMR.Text; } set { textBoxAirflowMR.Text = value; } }
        public String AirflowSP { get { return textBoxAirflowSP.Text; } set { textBoxAirflowSP.Text = value; } }
        public String DOMR { get { return textBoxDOMR.Text; } set { textBoxDOMR.Text = value; } }
        public String DOSP { get { return textBoxDOSP.Text; } set { textBoxDOSP.Text = value; } }
        public String NH3MR { get { return textBoxNH3MR.Text; } set { textBoxNH3MR.Text = value; } }
        public String NH3SP { get { return textBoxNH3SP.Text; } set { textBoxNH3SP.Text = value; } }

        public UCGrid()
        {
            InitializeComponent();
        }
    }
}
