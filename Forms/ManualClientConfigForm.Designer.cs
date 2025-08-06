namespace TriangleAuto.Forms
{
    partial class ManualClientConfigForm
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
            this.lblHPAddress = new System.Windows.Forms.Label();
            this.txtHPAddress = new System.Windows.Forms.TextBox();
            this.lblNameAddress = new System.Windows.Forms.Label();
            this.txtNameAddress = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblExample = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblHexPrefix1 = new System.Windows.Forms.Label();
            this.lblHexPrefix2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHPAddress
            // 
            this.lblHPAddress.AutoSize = true;
            this.lblHPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHPAddress.Location = new System.Drawing.Point(12, 60);
            this.lblHPAddress.Name = "lblHPAddress";
            this.lblHPAddress.Size = new System.Drawing.Size(74, 15);
            this.lblHPAddress.TabIndex = 0;
            this.lblHPAddress.Text = "HP Address:";
            // 
            // txtHPAddress
            // 
            this.txtHPAddress.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHPAddress.Location = new System.Drawing.Point(128, 57);
            this.txtHPAddress.MaxLength = 8;
            this.txtHPAddress.Name = "txtHPAddress";
            this.txtHPAddress.Size = new System.Drawing.Size(100, 23);
            this.txtHPAddress.TabIndex = 1;
            this.txtHPAddress.TextChanged += new System.EventHandler(this.txtHPAddress_TextChanged);
            // 
            // lblNameAddress
            // 
            this.lblNameAddress.AutoSize = true;
            this.lblNameAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAddress.Location = new System.Drawing.Point(12, 95);
            this.lblNameAddress.Name = "lblNameAddress";
            this.lblNameAddress.Size = new System.Drawing.Size(89, 15);
            this.lblNameAddress.TabIndex = 2;
            this.lblNameAddress.Text = "Name Address:";
            // 
            // txtNameAddress
            // 
            this.txtNameAddress.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameAddress.Location = new System.Drawing.Point(128, 92);
            this.txtNameAddress.MaxLength = 8;
            this.txtNameAddress.Name = "txtNameAddress";
            this.txtNameAddress.Size = new System.Drawing.Size(100, 23);
            this.txtNameAddress.TabIndex = 3;
            this.txtNameAddress.TextChanged += new System.EventHandler(this.txtNameAddress_TextChanged);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSet.ForeColor = System.Drawing.Color.White;
            this.btnSet.Location = new System.Drawing.Point(15, 140);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 28);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(96, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExample.ForeColor = System.Drawing.Color.Gray;
            this.lblExample.Location = new System.Drawing.Point(240, 70);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(107, 13);
            this.lblExample.TabIndex = 6;
            this.lblExample.Text = "Example: 015D23C8";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(12, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(350, 35);
            this.lblInstructions.TabIndex = 7;
            this.lblInstructions.Text = "Enter the memory addresses for HP and character name. Use a memory scanner like C" +
    "heat Engine to find these addresses.";
            // 
            // lblHexPrefix1
            // 
            this.lblHexPrefix1.AutoSize = true;
            this.lblHexPrefix1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHexPrefix1.Location = new System.Drawing.Point(107, 60);
            this.lblHexPrefix1.Name = "lblHexPrefix1";
            this.lblHexPrefix1.Size = new System.Drawing.Size(19, 15);
            this.lblHexPrefix1.TabIndex = 8;
            this.lblHexPrefix1.Text = "0x";
            // 
            // lblHexPrefix2
            // 
            this.lblHexPrefix2.AutoSize = true;
            this.lblHexPrefix2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHexPrefix2.Location = new System.Drawing.Point(107, 95);
            this.lblHexPrefix2.Name = "lblHexPrefix2";
            this.lblHexPrefix2.Size = new System.Drawing.Size(19, 15);
            this.lblHexPrefix2.TabIndex = 9;
            this.lblHexPrefix2.Text = "0x";
            // 
            // ManualClientConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 180);
            this.Controls.Add(this.lblHexPrefix2);
            this.Controls.Add(this.lblHexPrefix1);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblExample);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.txtNameAddress);
            this.Controls.Add(this.lblNameAddress);
            this.Controls.Add(this.txtHPAddress);
            this.Controls.Add(this.lblHPAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManualClientConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manual Client Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHPAddress;
        private System.Windows.Forms.TextBox txtHPAddress;
        private System.Windows.Forms.Label lblNameAddress;
        private System.Windows.Forms.TextBox txtNameAddress;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblExample;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblHexPrefix1;
        private System.Windows.Forms.Label lblHexPrefix2;
    }
}