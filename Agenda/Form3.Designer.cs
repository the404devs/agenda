namespace Agenda
{
    partial class Settings
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.chkNotif = new System.Windows.Forms.CheckBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(12, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(121, 37);
            label2.TabIndex = 5;
            label2.Text = "Show \"Today\'s Tasks\" on startup:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(12, 57);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(121, 37);
            label1.TabIndex = 18;
            label1.Text = "Automatically delete old tasks:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNotif
            // 
            this.chkNotif.AutoSize = true;
            this.chkNotif.Location = new System.Drawing.Point(157, 21);
            this.chkNotif.Name = "chkNotif";
            this.chkNotif.Size = new System.Drawing.Size(15, 14);
            this.chkNotif.TabIndex = 6;
            this.chkNotif.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.Black;
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(42, 107);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(100, 30);
            this.btnDone.TabIndex = 16;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Black;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Location = new System.Drawing.Point(42, 143);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(100, 30);
            this.btnAbout.TabIndex = 17;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(157, 69);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(15, 14);
            this.chkDelete.TabIndex = 19;
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(184, 181);
            this.ControlBox = false;
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(label1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.chkNotif);
            this.Controls.Add(label2);
            this.MaximumSize = new System.Drawing.Size(200, 220);
            this.MinimumSize = new System.Drawing.Size(200, 220);
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnAbout;
        public System.Windows.Forms.CheckBox chkNotif;
        public System.Windows.Forms.CheckBox chkDelete;
    }
}