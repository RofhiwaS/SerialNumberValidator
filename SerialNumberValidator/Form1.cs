using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialNumberValidator
{
    public partial class Form1 : Form
    {
        private TextBox txtSerialNumber;
        private Button btnCalculate;
        private Button btnClear;
        private Label lblResult;
        private Label lblSteps;
        private TextBox txtSteps;
        private Label lblInstruction;

        public Form1()
        {
            InitializeComponent();
        }
   

        private void TxtSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnCalculate_Click(sender, e);
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            string serialNumber = txtSerialNumber.Text.Trim();

            if (serialNumber.Length != 8)
            {
                MessageBox.Show("Please enter exactly 8 digits.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerialNumber.Focus();
                return;
            }

            string steps;
            int checkDigit = CalculateCheckDigit(serialNumber, out steps);

            lblResult.Text = $"Check Digit: {checkDigit}";
            txtSteps.Text = steps;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtSerialNumber.Clear();
            lblResult.Text = "";
            txtSteps.Clear();
            txtSerialNumber.Focus();
        }

        private int CalculateCheckDigit(string serialNumber, out string steps)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string currentNumber = serialNumber;
            int iteration = 0;

            sb.AppendLine($"Starting Serial Number: {FormatNumber(currentNumber)}");
            sb.AppendLine();

            while (currentNumber.Length > 1)
            {
                iteration++;
                string nextNumber = ""; 
                sb.AppendLine($"Iteration {iteration}:");
                sb.Append("Add consecutive digits: ");

                for (int i = 0; i < currentNumber.Length - 1; i++)
                {
                    int digit1 = int.Parse(currentNumber[i].ToString());
                    int digit2 = int.Parse(currentNumber[i + 1].ToString());
                    int sum = digit1 + digit2;
                    int resultDigit = sum % 10;
                    nextNumber += resultDigit.ToString();

                    if (i > 0) sb.Append(", ");
                    sb.Append($"{digit1}+{digit2}={sum}");
                    if (sum >= 10)
                    {
                        sb.Append($" → {resultDigit}");
                    }
                }

                sb.AppendLine();
                sb.AppendLine($"Result: {FormatNumber(nextNumber)}");
                sb.AppendLine();

                currentNumber = nextNumber;
            }

            sb.AppendLine($"Final Check Digit: {currentNumber}");

            steps = sb.ToString();
            return int.Parse(currentNumber);
        }

        private string FormatNumber(string number)
        {
            return string.Join("  ", number.ToCharArray());
        }
    }

}