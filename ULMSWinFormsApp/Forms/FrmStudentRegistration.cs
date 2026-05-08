using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }


        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrEmpty(txtStudentId.Text) ||
                string.IsNullOrEmpty(txtFullName.Text) ||
                string.IsNullOrEmpty(txtAge.Text))
            {
                MessageBox.Show("Please fill in all required fields.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            // Safe age conversion
            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Please enter a valid numeric age.",
                                "Invalid Age",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            Student student = new Student
            {
                StudentId = txtStudentId.Text,
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Age = age,
                Programme = cmbProgramme.Text
            };
            txtStudentOutput.Text = "Student saved successfully!\n\n" +
                        "Student ID: " + student.StudentId + "\n" +
                        "Full Name: " + student.FullName + "\n" +
                        "Email: " + student.Email + "\n" +
                        "Age: " + student.Age + "\n" +
                        "Programme: " + student.Programme;
        }

        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            cmbProgramme.SelectedIndex = -1;
            txtStudentOutput.Clear();
            txtStudentId.Focus();
        }

        //Add Back button to return to dashboard
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
