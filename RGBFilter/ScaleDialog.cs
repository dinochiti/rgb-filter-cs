using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGBFilter
{
    public partial class ScaleDialog : Form
    {
        public ScaleDialog()
        {
            InitializeComponent();
        }

        public double scaleFactor
        {
            get
            {
                return Convert.ToDouble(textBoxScaleFactor.Text);
            }
        }

        public bool scaleRed
        {
            get
            {
                return checkBoxRed.Checked;
            }
        }

        public bool scaleGreen
        {
            get
            {
                return checkBoxGreen.Checked;
            }
        }

        public bool scaleBlue
        {
            get
            {
                return checkBoxBlue.Checked;
            }
        }

        private void textBoxScaleFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a digit or a decimal separator
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Ignore the key press
            }

            // Allow only one decimal point
            TextBox textBox = (TextBox)sender;
            if ((e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true; // Ignore the key press
            }
        }
    }
}
