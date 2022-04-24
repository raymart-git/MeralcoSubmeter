using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeralcoSubmeter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            if (!Init()) return;

            lblDiff1.Text = (Convert.ToInt32(txtCurr_Submeter1.Text) - Convert.ToInt32(txtPrev_Submeter1.Text)).ToString();
            lblDiff2.Text = (Convert.ToInt32(txtCurr_Submeter2.Text) - Convert.ToInt32(txtPrev_Submeter2.Text)).ToString();
            lblDiff3.Text = (Convert.ToInt32(txtCurr_Submeter3.Text) - Convert.ToInt32(txtPrev_Submeter3.Text)).ToString();

            int totalDiff = (Convert.ToInt32(lblDiff1.Text) + Convert.ToInt32(lblDiff2.Text) + Convert.ToInt32(lblDiff3.Text));

            lblPercentage1.Text = (Math.Round(Convert.ToDecimal(lblDiff1.Text + ".0") / totalDiff * 100)).ToString() + "%";
            lblPercentage2.Text = (Math.Round(Convert.ToDecimal(lblDiff2.Text + ".0") / totalDiff * 100)).ToString() + "%";
            lblPercentage3.Text = (Math.Round(Convert.ToDecimal(lblDiff3.Text + ".0") / totalDiff * 100)).ToString() + "%";


            lblResultBC1.Text = (Math.Round(Convert.ToDecimal(txtCurrentMonthBill.Text) * ConvertStringPercentageToDecimal(lblPercentage1.Text), 2)).ToString();
            lblResultBC2.Text = (Math.Round(Convert.ToDecimal(txtCurrentMonthBill.Text) * ConvertStringPercentageToDecimal(lblPercentage2.Text), 2)).ToString();
            lblResultBC3.Text = (Math.Round(Convert.ToDecimal(txtCurrentMonthBill.Text) * ConvertStringPercentageToDecimal(lblPercentage3.Text), 2)).ToString();
        }


        private bool Init()
        {
            string txt = string.Empty;
            if (String.IsNullOrEmpty(txtPrev_Submeter1.Text)) txt = "Previous Month Submeter1";
            else if (String.IsNullOrEmpty(txtPrev_Submeter2.Text)) txt = "Previous Month Submeter2";
            else if (String.IsNullOrEmpty(txtPrev_Submeter3.Text)) txt = "Previous Month Submeter3";
            else if (String.IsNullOrEmpty(txtCurr_Submeter1.Text)) txt = "Current Month Submeter1";
            else if (String.IsNullOrEmpty(txtCurr_Submeter2.Text)) txt = "Current Month Submeter2";
            else if (String.IsNullOrEmpty(txtCurr_Submeter3.Text)) txt = "Current Month Submeter3";

            if (String.IsNullOrEmpty(txtCurrentMonthBill.Text)) txt = "Current Month Bill";

            if (!String.IsNullOrEmpty(txt))
            {
                MessageBox.Show(string.Format("{0} cannot be empty!", txt));
                return false;
            }
            return true;
        }

        private decimal ConvertStringPercentageToDecimal(string value)
        {
            return decimal.Parse(value.Replace("%", "")) / 100;
        }
    }
}
