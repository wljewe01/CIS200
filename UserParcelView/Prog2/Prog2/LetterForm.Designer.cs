namespace Prog2
{
    partial class LetterForm
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.originLbl = new System.Windows.Forms.Label();
            this.destLbl = new System.Windows.Forms.Label();
            this.fixedCostLbl = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.costTxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // originLbl
            // 
            this.originLbl.AutoSize = true;
            this.originLbl.Location = new System.Drawing.Point(12, 20);
            this.originLbl.Name = "originLbl";
            this.originLbl.Size = new System.Drawing.Size(81, 13);
            this.originLbl.TabIndex = 0;
            this.originLbl.Text = "Origin Address: ";
            // 
            // destLbl
            // 
            this.destLbl.AutoSize = true;
            this.destLbl.Location = new System.Drawing.Point(12, 57);
            this.destLbl.Name = "destLbl";
            this.destLbl.Size = new System.Drawing.Size(107, 13);
            this.destLbl.TabIndex = 1;
            this.destLbl.Text = "Destination Address: ";
            // 
            // fixedCostLbl
            // 
            this.fixedCostLbl.AutoSize = true;
            this.fixedCostLbl.Location = new System.Drawing.Point(12, 91);
            this.fixedCostLbl.Name = "fixedCostLbl";
            this.fixedCostLbl.Size = new System.Drawing.Size(59, 13);
            this.fixedCostLbl.TabIndex = 2;
            this.fixedCostLbl.Text = "Fixed Cost:";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(18, 171);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(140, 171);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CancelButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(140, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Validating += new System.ComponentModel.CancelEventHandler(this.originAddressCombo_Validating);
            this.comboBox1.Validated += new System.EventHandler(this.originAddress_Validated);

            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(140, 57);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.Validating += new System.ComponentModel.CancelEventHandler(this.destAddressCombo_Validating);
            this.comboBox2.Validated += new System.EventHandler(this.destAddress_Validated);
            // 
            // costTxtBox
            // 
            this.costTxtBox.Location = new System.Drawing.Point(140, 91);
            this.costTxtBox.Name = "costTxtBox";
            this.costTxtBox.Size = new System.Drawing.Size(121, 20);
            this.costTxtBox.TabIndex = 7;
            this.costTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.costText_Validating);
            this.costTxtBox.Validated += new System.EventHandler(this.costText_Validated);
            // 
            // LetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.costTxtBox);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.fixedCostLbl);
            this.Controls.Add(this.destLbl);
            this.Controls.Add(this.originLbl);
            this.Name = "LetterForm";
            this.Text = "LetterForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox costTxtBox;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label fixedCostLbl;
        private System.Windows.Forms.Label destLbl;
        private System.Windows.Forms.Label originLbl;
    }
}