using System;

namespace PRG272_Project
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenSummary = new System.Windows.Forms.Button();
            this.btnOpenManage = new System.Windows.Forms.Button();
            this.btnOpenView = new System.Windows.Forms.Button();
            this.btnOpenAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(50, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Baobab Ridge Wildlife Rehabilitation Records System";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenSummary);
            this.panel1.Controls.Add(this.btnOpenManage);
            this.panel1.Controls.Add(this.btnOpenView);
            this.panel1.Controls.Add(this.btnOpenAdd);
            this.panel1.Location = new System.Drawing.Point(42, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 131);
            this.panel1.TabIndex = 1;
            // 
            // btnOpenSummary
            // 
            this.btnOpenSummary.Location = new System.Drawing.Point(221, 85);
            this.btnOpenSummary.Name = "btnOpenSummary";
            this.btnOpenSummary.Size = new System.Drawing.Size(154, 23);
            this.btnOpenSummary.TabIndex = 3;
            this.btnOpenSummary.Text = "Generate Summary Report";
            this.btnOpenSummary.UseVisualStyleBackColor = true;
            this.btnOpenSummary.Click += new System.EventHandler(this.btnOpenSummary_Click);
            // 
            // btnOpenManage
            // 
            this.btnOpenManage.Location = new System.Drawing.Point(23, 85);
            this.btnOpenManage.Name = "btnOpenManage";
            this.btnOpenManage.Size = new System.Drawing.Size(154, 23);
            this.btnOpenManage.TabIndex = 2;
            this.btnOpenManage.Text = "Update / Delete Animal";
            this.btnOpenManage.UseVisualStyleBackColor = true;
            this.btnOpenManage.Click += new System.EventHandler(this.btnOpenManage_Click);
            // 
            // btnOpenView
            // 
            this.btnOpenView.Location = new System.Drawing.Point(221, 17);
            this.btnOpenView.Name = "btnOpenView";
            this.btnOpenView.Size = new System.Drawing.Size(154, 23);
            this.btnOpenView.TabIndex = 1;
            this.btnOpenView.Text = "View All Animals";
            this.btnOpenView.UseVisualStyleBackColor = true;
            this.btnOpenView.Click += new System.EventHandler(this.btnOpenView_Click);
            // 
            // btnOpenAdd
            // 
            this.btnOpenAdd.Location = new System.Drawing.Point(23, 17);
            this.btnOpenAdd.Name = "btnOpenAdd";
            this.btnOpenAdd.Size = new System.Drawing.Size(154, 23);
            this.btnOpenAdd.TabIndex = 0;
            this.btnOpenAdd.Text = "Add New Animal";
            this.btnOpenAdd.UseVisualStyleBackColor = true;
            this.btnOpenAdd.Click += new System.EventHandler(this.btnOpenAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(541, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 248);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Baobab Ridge Wildlife Management Dashboard";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenView;
        private System.Windows.Forms.Button btnOpenAdd;
        private System.Windows.Forms.Button btnOpenSummary;
        private System.Windows.Forms.Button btnOpenManage;
        private System.Windows.Forms.Button btnExit;
    }
}

