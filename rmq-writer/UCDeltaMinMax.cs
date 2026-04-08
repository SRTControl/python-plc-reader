using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMQWriter
{
    public partial class UCDeltaMinMax : UserControl
    {
        public String Caption { get { return gbPanel.Text; } set { gbPanel.Text = value; } }
        public Double Delta { get { return Convert.ToDouble(textBoxDelta.Text); } set { textBoxDelta.Text = $"{value:F2}"; } }
        public Double Min { get { return Convert.ToDouble(textBoxMin.Text); } set { textBoxMin.Text = $"{value:F2}"; } }
        public Double Max { get { return Convert.ToDouble(textBoxMax.Text); } set { textBoxMax.Text = $"{value:F2}"; } }
        
        public UCDeltaMinMax()
        {
            InitializeComponent();

            Delta = 0.00;
            Min = 0.00;
            Max = 0.00;
        }
    }
}
