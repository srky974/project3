namespace project3
{
    partial class frmsalonekle
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
            this.txtsalonadi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnekle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtsalonadi
            // 
            this.txtsalonadi.Location = new System.Drawing.Point(98, 46);
            this.txtsalonadi.Multiline = true;
            this.txtsalonadi.Name = "txtsalonadi";
            this.txtsalonadi.Size = new System.Drawing.Size(109, 40);
            this.txtsalonadi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(5, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "SALON ADI";
            // 
            // btnekle
            // 
            this.btnekle.BackColor = System.Drawing.Color.White;
            this.btnekle.ForeColor = System.Drawing.Color.Red;
            this.btnekle.Location = new System.Drawing.Point(131, 102);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(76, 30);
            this.btnekle.TabIndex = 2;
            this.btnekle.Text = "EKLE";
            this.btnekle.UseVisualStyleBackColor = false;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // frmsalonekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project3.Properties.Resources.s7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(336, 204);
            this.Controls.Add(this.btnekle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtsalonadi);
            this.Name = "frmsalonekle";
            this.Text = "Salon Ekle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmsalonekle_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtsalonadi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnekle;
    }
}