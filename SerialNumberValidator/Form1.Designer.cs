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
    partial class Form1
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
            this.Text = "Serial Number Check Digit Calculator";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Instruction Label
            lblInstruction = new Label
            {
                Text = "Enter an 8-digit serial number:",
                Location = new Point(20, 20),
                Size = new Size(400, 20),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            // Serial Number TextBox
            txtSerialNumber = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(200, 30),
                Font = new Font("Arial", 14),
                MaxLength = 8
            };
            txtSerialNumber.KeyPress += TxtSerialNumber_KeyPress;

            // Calculate Button
            btnCalculate = new Button
            {
                Text = "Calculate Check Digit",
                Location = new Point(230, 48),
                Size = new Size(150, 30),
                Font = new Font("Arial", 10),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCalculate.Click += BtnCalculate_Click;

            // Clear Button
            btnClear = new Button
            {
                Text = "Clear",
                Location = new Point(390, 48),
                Size = new Size(80, 30),
                Font = new Font("Arial", 10),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClear.Click += BtnClear_Click;

            // Result Label
            lblResult = new Label
            {
                Text = "",
                Location = new Point(20, 100),
                Size = new Size(540, 40),
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Green
            };

            // Steps Label
            lblSteps = new Label
            {
                Text = "Calculation Steps:",
                Location = new Point(20, 150),
                Size = new Size(200, 20),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            // Steps TextBox (multiline)
            txtSteps = new TextBox
            {
                Location = new Point(20, 180),
                Size = new Size(540, 250),
                Font = new Font("Consolas", 9),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.WhiteSmoke
            };

            // Add controls to form
            this.Controls.Add(lblInstruction);
            this.Controls.Add(txtSerialNumber);
            this.Controls.Add(btnCalculate);
            this.Controls.Add(btnClear);
            this.Controls.Add(lblResult);
            this.Controls.Add(lblSteps);
            this.Controls.Add(txtSteps);
        }

        #endregion
    }
}

