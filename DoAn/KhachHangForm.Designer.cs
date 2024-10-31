namespace DoAn
{
    partial class KhachHangForm
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
            this.lblTenChuThe = new System.Windows.Forms.Label();
            this.lblSoDu = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnTruyVanSoDu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTenChuThe
            // 
            this.lblTenChuThe.AutoSize = true;
            this.lblTenChuThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTenChuThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTenChuThe.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblTenChuThe.Location = new System.Drawing.Point(243, 9);
            this.lblTenChuThe.Name = "lblTenChuThe";
            this.lblTenChuThe.Size = new System.Drawing.Size(259, 29);
            this.lblTenChuThe.TabIndex = 0;
            this.lblTenChuThe.Text = "Xin chào: Tên chủ thẻ";
            // 
            // lblSoDu
            // 
            this.lblSoDu.AutoSize = true;
            this.lblSoDu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSoDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblSoDu.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblSoDu.Location = new System.Drawing.Point(243, 60);
            this.lblSoDu.Name = "lblSoDu";
            this.lblSoDu.Size = new System.Drawing.Size(142, 29);
            this.lblSoDu.TabIndex = 1;
            this.lblSoDu.Text = "Số dư: Tiền";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkOrange;
            this.button1.Image = global::DoAn.Properties.Resources.plus;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-1, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "Nạp tiền";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnNapTien_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PowderBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Image = global::DoAn.Properties.Resources.Report;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(146, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Rút tiền";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnRutTien_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.PowderBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Olive;
            this.button3.Image = global::DoAn.Properties.Resources.refresh;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(293, 119);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 50);
            this.button3.TabIndex = 4;
            this.button3.Text = "Chuyển tiền";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnChuyenTien_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.PowderBlue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.CadetBlue;
            this.button4.Image = global::DoAn.Properties.Resources.edit;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(440, 119);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 50);
            this.button4.TabIndex = 5;
            this.button4.Text = "Mã PIN";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnThayDoiMaPin_Click);
            // 
            // btnTruyVanSoDu
            // 
            this.btnTruyVanSoDu.BackColor = System.Drawing.Color.PowderBlue;
            this.btnTruyVanSoDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTruyVanSoDu.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnTruyVanSoDu.Image = global::DoAn.Properties.Resources.approve;
            this.btnTruyVanSoDu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTruyVanSoDu.Location = new System.Drawing.Point(587, 119);
            this.btnTruyVanSoDu.Name = "btnTruyVanSoDu";
            this.btnTruyVanSoDu.Size = new System.Drawing.Size(141, 50);
            this.btnTruyVanSoDu.TabIndex = 6;
            this.btnTruyVanSoDu.Text = "Truy vấn số dư";
            this.btnTruyVanSoDu.UseVisualStyleBackColor = false;
            this.btnTruyVanSoDu.Click += new System.EventHandler(this.btnTruyVanSoDu_Click);
            // 
            // KhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoAn.Properties.Resources.bank2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(726, 196);
            this.Controls.Add(this.btnTruyVanSoDu);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblSoDu);
            this.Controls.Add(this.lblTenChuThe);
            this.Name = "KhachHangForm";
            this.Text = "KhachHangForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTenChuThe;
        private System.Windows.Forms.Label lblSoDu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnTruyVanSoDu;
    }
}