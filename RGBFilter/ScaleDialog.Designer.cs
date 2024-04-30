namespace RGBFilter
{
    partial class ScaleDialog
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
            this.checkBoxRed = new System.Windows.Forms.CheckBox();
            this.checkBoxGreen = new System.Windows.Forms.CheckBox();
            this.checkBoxBlue = new System.Windows.Forms.CheckBox();
            this.textBoxScaleFactor = new System.Windows.Forms.TextBox();
            this.groupBoxScalingFactor = new System.Windows.Forms.GroupBox();
            this.groupBoxValuesToScale = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxScalingFactor.SuspendLayout();
            this.groupBoxValuesToScale.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxRed
            // 
            this.checkBoxRed.AutoSize = true;
            this.checkBoxRed.Checked = true;
            this.checkBoxRed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRed.Location = new System.Drawing.Point(42, 33);
            this.checkBoxRed.Name = "checkBoxRed";
            this.checkBoxRed.Size = new System.Drawing.Size(46, 17);
            this.checkBoxRed.TabIndex = 0;
            this.checkBoxRed.Text = "Red";
            this.checkBoxRed.UseVisualStyleBackColor = true;
            // 
            // checkBoxGreen
            // 
            this.checkBoxGreen.AutoSize = true;
            this.checkBoxGreen.Checked = true;
            this.checkBoxGreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGreen.Location = new System.Drawing.Point(42, 56);
            this.checkBoxGreen.Name = "checkBoxGreen";
            this.checkBoxGreen.Size = new System.Drawing.Size(55, 17);
            this.checkBoxGreen.TabIndex = 1;
            this.checkBoxGreen.Text = "Green";
            this.checkBoxGreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxBlue
            // 
            this.checkBoxBlue.AutoSize = true;
            this.checkBoxBlue.Checked = true;
            this.checkBoxBlue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBlue.Location = new System.Drawing.Point(41, 79);
            this.checkBoxBlue.Name = "checkBoxBlue";
            this.checkBoxBlue.Size = new System.Drawing.Size(47, 17);
            this.checkBoxBlue.TabIndex = 2;
            this.checkBoxBlue.Text = "Blue";
            this.checkBoxBlue.UseVisualStyleBackColor = true;
            // 
            // textBoxScaleFactor
            // 
            this.textBoxScaleFactor.Location = new System.Drawing.Point(42, 29);
            this.textBoxScaleFactor.Name = "textBoxScaleFactor";
            this.textBoxScaleFactor.Size = new System.Drawing.Size(55, 20);
            this.textBoxScaleFactor.TabIndex = 3;
            this.textBoxScaleFactor.Text = "1.00";
            this.textBoxScaleFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxScaleFactor_KeyPress);
            // 
            // groupBoxScalingFactor
            // 
            this.groupBoxScalingFactor.Controls.Add(this.textBoxScaleFactor);
            this.groupBoxScalingFactor.Location = new System.Drawing.Point(12, 12);
            this.groupBoxScalingFactor.Name = "groupBoxScalingFactor";
            this.groupBoxScalingFactor.Size = new System.Drawing.Size(204, 73);
            this.groupBoxScalingFactor.TabIndex = 4;
            this.groupBoxScalingFactor.TabStop = false;
            this.groupBoxScalingFactor.Text = "Scaling factor";
            // 
            // groupBoxValuesToScale
            // 
            this.groupBoxValuesToScale.Controls.Add(this.checkBoxGreen);
            this.groupBoxValuesToScale.Controls.Add(this.checkBoxRed);
            this.groupBoxValuesToScale.Controls.Add(this.checkBoxBlue);
            this.groupBoxValuesToScale.Location = new System.Drawing.Point(12, 91);
            this.groupBoxValuesToScale.Name = "groupBoxValuesToScale";
            this.groupBoxValuesToScale.Size = new System.Drawing.Size(204, 125);
            this.groupBoxValuesToScale.TabIndex = 5;
            this.groupBoxValuesToScale.TabStop = false;
            this.groupBoxValuesToScale.Text = "Select which values to scale";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(131, 233);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(22, 233);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // ScaleDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(228, 276);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxValuesToScale);
            this.Controls.Add(this.groupBoxScalingFactor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScaleDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scale Pixel Values";
            this.groupBoxScalingFactor.ResumeLayout(false);
            this.groupBoxScalingFactor.PerformLayout();
            this.groupBoxValuesToScale.ResumeLayout(false);
            this.groupBoxValuesToScale.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxRed;
        private System.Windows.Forms.CheckBox checkBoxGreen;
        private System.Windows.Forms.CheckBox checkBoxBlue;
        private System.Windows.Forms.TextBox textBoxScaleFactor;
        private System.Windows.Forms.GroupBox groupBoxScalingFactor;
        private System.Windows.Forms.GroupBox groupBoxValuesToScale;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}