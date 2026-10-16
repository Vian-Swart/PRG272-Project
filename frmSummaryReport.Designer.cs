namespace PRG272_Project
{
    partial class frmSummaryReport
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTotalAnimals = new System.Windows.Forms.Label();
            this.lblAvgAge = new System.Windows.Forms.Label();
            this.lblAvgScore = new System.Windows.Forms.Label();
            this.lblTotalAnimalsVal = new System.Windows.Forms.Label();
            this.lblAvgAgeVal = new System.Windows.Forms.Label();
            this.lblAvgScoreVal = new System.Windows.Forms.Label();
            this.lblCritical = new System.Windows.Forms.Label();
            this.lblSerious = new System.Windows.Forms.Label();
            this.lblStable = new System.Windows.Forms.Label();
            this.lblRecovering = new System.Windows.Forms.Label();
            this.lblReleaseReady = new System.Windows.Forms.Label();
            this.lblCriticalVal = new System.Windows.Forms.Label();
            this.lblSeriousVal = new System.Windows.Forms.Label();
            this.lblStableVal = new System.Windows.Forms.Label();
            this.lblRecoveringVal = new System.Windows.Forms.Label();
            this.lblReleaseReadyVal = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(27, 24);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(119, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Animal Summary Report";
            // 
            // lblTotalAnimals
            // 
            this.lblTotalAnimals.AutoSize = true;
            this.lblTotalAnimals.Location = new System.Drawing.Point(40, 80);
            this.lblTotalAnimals.Name = "lblTotalAnimals";
            this.lblTotalAnimals.Size = new System.Drawing.Size(72, 13);
            this.lblTotalAnimals.TabIndex = 1;
            this.lblTotalAnimals.Text = "Total animals:";
            // 
            // lblAvgAge
            // 
            this.lblAvgAge.AutoSize = true;
            this.lblAvgAge.Location = new System.Drawing.Point(40, 115);
            this.lblAvgAge.Name = "lblAvgAge";
            this.lblAvgAge.Size = new System.Drawing.Size(105, 13);
            this.lblAvgAge.TabIndex = 2;
            this.lblAvgAge.Text = "Average age (years):";
            // 
            // lblAvgScore
            // 
            this.lblAvgScore.AutoSize = true;
            this.lblAvgScore.Location = new System.Drawing.Point(40, 150);
            this.lblAvgScore.Name = "lblAvgScore";
            this.lblAvgScore.Size = new System.Drawing.Size(123, 13);
            this.lblAvgScore.TabIndex = 3;
            this.lblAvgScore.Text = "Average recovery score:";
            // 
            // lblTotalAnimalsVal
            // 
            this.lblTotalAnimalsVal.AutoSize = true;
            this.lblTotalAnimalsVal.Location = new System.Drawing.Point(270, 80);
            this.lblTotalAnimalsVal.Name = "lblTotalAnimalsVal";
            this.lblTotalAnimalsVal.Size = new System.Drawing.Size(13, 13);
            this.lblTotalAnimalsVal.TabIndex = 4;
            this.lblTotalAnimalsVal.Text = "0";
            // 
            // lblAvgAgeVal
            // 
            this.lblAvgAgeVal.AutoSize = true;
            this.lblAvgAgeVal.Location = new System.Drawing.Point(270, 115);
            this.lblAvgAgeVal.Name = "lblAvgAgeVal";
            this.lblAvgAgeVal.Size = new System.Drawing.Size(13, 13);
            this.lblAvgAgeVal.TabIndex = 5;
            this.lblAvgAgeVal.Text = "0";
            // 
            // lblAvgScoreVal
            // 
            this.lblAvgScoreVal.AutoSize = true;
            this.lblAvgScoreVal.Location = new System.Drawing.Point(270, 150);
            this.lblAvgScoreVal.Name = "lblAvgScoreVal";
            this.lblAvgScoreVal.Size = new System.Drawing.Size(13, 13);
            this.lblAvgScoreVal.TabIndex = 6;
            this.lblAvgScoreVal.Text = "0";
            // 
            // lblCritical
            // 
            this.lblCritical.AutoSize = true;
            this.lblCritical.Location = new System.Drawing.Point(60, 230);
            this.lblCritical.Name = "lblCritical";
            this.lblCritical.Size = new System.Drawing.Size(47, 13);
            this.lblCritical.TabIndex = 8;
            this.lblCritical.Text = "- Critical:";
            // 
            // lblSerious
            // 
            this.lblSerious.AutoSize = true;
            this.lblSerious.Location = new System.Drawing.Point(60, 265);
            this.lblSerious.Name = "lblSerious";
            this.lblSerious.Size = new System.Drawing.Size(51, 13);
            this.lblSerious.TabIndex = 9;
            this.lblSerious.Text = "- Serious:";
            // 
            // lblStable
            // 
            this.lblStable.AutoSize = true;
            this.lblStable.Location = new System.Drawing.Point(60, 300);
            this.lblStable.Name = "lblStable";
            this.lblStable.Size = new System.Drawing.Size(46, 13);
            this.lblStable.TabIndex = 10;
            this.lblStable.Text = "- Stable:";
            // 
            // lblRecovering
            // 
            this.lblRecovering.AutoSize = true;
            this.lblRecovering.Location = new System.Drawing.Point(60, 335);
            this.lblRecovering.Name = "lblRecovering";
            this.lblRecovering.Size = new System.Drawing.Size(71, 13);
            this.lblRecovering.TabIndex = 11;
            this.lblRecovering.Text = "- Recovering:";
            // 
            // lblReleaseReady
            // 
            this.lblReleaseReady.AutoSize = true;
            this.lblReleaseReady.Location = new System.Drawing.Point(60, 370);
            this.lblReleaseReady.Name = "lblReleaseReady";
            this.lblReleaseReady.Size = new System.Drawing.Size(89, 13);
            this.lblReleaseReady.TabIndex = 12;
            this.lblReleaseReady.Text = "- Release-Ready:";
            // 
            // lblCriticalVal
            // 
            this.lblCriticalVal.AutoSize = true;
            this.lblCriticalVal.Location = new System.Drawing.Point(270, 230);
            this.lblCriticalVal.Name = "lblCriticalVal";
            this.lblCriticalVal.Size = new System.Drawing.Size(13, 13);
            this.lblCriticalVal.TabIndex = 13;
            this.lblCriticalVal.Text = "0";
            // 
            // lblSeriousVal
            // 
            this.lblSeriousVal.AutoSize = true;
            this.lblSeriousVal.Location = new System.Drawing.Point(270, 265);
            this.lblSeriousVal.Name = "lblSeriousVal";
            this.lblSeriousVal.Size = new System.Drawing.Size(13, 13);
            this.lblSeriousVal.TabIndex = 14;
            this.lblSeriousVal.Text = "0";
            // 
            // lblStableVal
            // 
            this.lblStableVal.AutoSize = true;
            this.lblStableVal.Location = new System.Drawing.Point(270, 300);
            this.lblStableVal.Name = "lblStableVal";
            this.lblStableVal.Size = new System.Drawing.Size(13, 13);
            this.lblStableVal.TabIndex = 15;
            this.lblStableVal.Text = "0";
            // 
            // lblRecoveringVal
            // 
            this.lblRecoveringVal.AutoSize = true;
            this.lblRecoveringVal.Location = new System.Drawing.Point(270, 335);
            this.lblRecoveringVal.Name = "lblRecoveringVal";
            this.lblRecoveringVal.Size = new System.Drawing.Size(13, 13);
            this.lblRecoveringVal.TabIndex = 16;
            this.lblRecoveringVal.Text = "0";
            // 
            // lblReleaseReadyVal
            // 
            this.lblReleaseReadyVal.AutoSize = true;
            this.lblReleaseReadyVal.Location = new System.Drawing.Point(270, 370);
            this.lblReleaseReadyVal.Name = "lblReleaseReadyVal";
            this.lblReleaseReadyVal.Size = new System.Drawing.Size(13, 13);
            this.lblReleaseReadyVal.TabIndex = 17;
            this.lblReleaseReadyVal.Text = "0";
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Location = new System.Drawing.Point(40, 195);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(97, 13);
            this.lblHeading.TabIndex = 18;
            this.lblHeading.Text = "Animals per Status:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 430);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 40);
            this.btnGenerate.TabIndex = 19;
            this.btnGenerate.Text = "Refresh/Export Summary";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(255, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 485);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.lblReleaseReadyVal);
            this.Controls.Add(this.lblRecoveringVal);
            this.Controls.Add(this.lblStableVal);
            this.Controls.Add(this.lblSeriousVal);
            this.Controls.Add(this.lblCriticalVal);
            this.Controls.Add(this.lblReleaseReady);
            this.Controls.Add(this.lblRecovering);
            this.Controls.Add(this.lblStable);
            this.Controls.Add(this.lblSerious);
            this.Controls.Add(this.lblCritical);
            this.Controls.Add(this.lblAvgScoreVal);
            this.Controls.Add(this.lblAvgAgeVal);
            this.Controls.Add(this.lblTotalAnimalsVal);
            this.Controls.Add(this.lblAvgScore);
            this.Controls.Add(this.lblAvgAge);
            this.Controls.Add(this.lblTotalAnimals);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmSummaryReport";
            this.Text = "frmSummaryReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTotalAnimals;
        private System.Windows.Forms.Label lblAvgAge;
        private System.Windows.Forms.Label lblAvgScore;
        private System.Windows.Forms.Label lblTotalAnimalsVal;
        private System.Windows.Forms.Label lblAvgAgeVal;
        private System.Windows.Forms.Label lblAvgScoreVal;
        private System.Windows.Forms.Label lblCritical;
        private System.Windows.Forms.Label lblSerious;
        private System.Windows.Forms.Label lblStable;
        private System.Windows.Forms.Label lblRecovering;
        private System.Windows.Forms.Label lblReleaseReady;
        private System.Windows.Forms.Label lblCriticalVal;
        private System.Windows.Forms.Label lblSeriousVal;
        private System.Windows.Forms.Label lblStableVal;
        private System.Windows.Forms.Label lblRecoveringVal;
        private System.Windows.Forms.Label lblReleaseReadyVal;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClose;
    }
}