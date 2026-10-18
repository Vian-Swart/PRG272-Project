using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG272_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyCustomStyling();
        }

        private void ApplyCustomStyling()
        {
            this.Text = "Baobab Ridge Wildlife Rehabilitation Records System";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 247, 245);

            if (lblTitle != null)
            {
                lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTitle.ForeColor = Color.FromArgb(44, 74, 62);
            }
        }

        private void btnOpenAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                frmAddAnimal addForm = new frmAddAnimal();
                addForm.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Error 404: The Add Animal form could not be loaded.",
                    "Form Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

         
        private void btnOpenManage_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                using (frmManageAnimals manageForm = new frmManageAnimals())
                {
                    manageForm.ShowDialog();
                }

                this.Show();
            }
            catch (Exception ex)
            {
                this.Show();

                MessageBox.Show(
                    "The Manage Animals form could not be loaded.\n" + ex.Message,
                    "Form Loading Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
   


        private void btnOpenSummary_Click(object sender, EventArgs e)
        {
            /*try
            {
                this.Hide();
                frmSummaryReport summaryForm = new frmSummaryReport();
                summaryForm.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Error 404: The Summary Report form could not be loaded.",
                    "Form Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }*/
        }

        
private void btnOpenView_Click(object sender, EventArgs e)
{
    try
    {
        this.Hide();

        using (frmManageAnimals viewForm = new frmManageAnimals())
        {
            viewForm.ShowDialog();
        }

        this.Show();
    }
    catch (Exception ex)
    {
        this.Show();

        MessageBox.Show(
            "The View All Animals form could not be loaded.\n" + ex.Message,
            "Form Loading Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
    }
}


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
