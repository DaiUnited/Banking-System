namespace DoAn
{
    partial class ChangePinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePinForm));
            this.txtXacNhanMaPin = new System.Windows.Forms.TextBox();
            this.txtMaPinMoi = new System.Windows.Forms.TextBox();
            this.txtMaPinCu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtXacNhanMaPin
            // 
            this.txtXacNhanMaPin.Location = new System.Drawing.Point(227, 139);
            this.txtXacNhanMaPin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtXacNhanMaPin.Multiline = true;
            this.txtXacNhanMaPin.Name = "txtXacNhanMaPin";
            this.txtXacNhanMaPin.Size = new System.Drawing.Size(212, 28);
            this.txtXacNhanMaPin.TabIndex = 14;
            // 
            // txtMaPinMoi
            // 
            this.txtMaPinMoi.Location = new System.Drawing.Point(227, 86);
            this.txtMaPinMoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaPinMoi.Multiline = true;
            this.txtMaPinMoi.Name = "txtMaPinMoi";
            this.txtMaPinMoi.Size = new System.Drawing.Size(212, 28);
            this.txtMaPinMoi.TabIndex = 13;
            // 
            // txtMaPinCu
            // 
            this.txtMaPinCu.Location = new System.Drawing.Point(227, 35);
            this.txtMaPinCu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaPinCu.Multiline = true;
            this.txtMaPinCu.Name = "txtMaPinCu";
            this.txtMaPinCu.Size = new System.Drawing.Size(212, 28);
            this.txtMaPinCu.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 147);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Xác nhận lại mã PIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mã PIN mới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã PIN hiện tại";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(227, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 39);
            this.button1.TabIndex = 15;
            this.button1.Text = "Thiết lập Mã PIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangePinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(490, 258);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtXacNhanMaPin);
            this.Controls.Add(this.txtMaPinMoi);
            this.Controls.Add(this.txtMaPinCu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ChangePinForm";
            this.Text = "ChangePinForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXacNhanMaPin;
        private System.Windows.Forms.TextBox txtMaPinMoi;
        private System.Windows.Forms.TextBox txtMaPinCu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}