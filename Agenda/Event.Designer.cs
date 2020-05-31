namespace Agenda
{
    partial class Event
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnDismiss = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblMark = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 25);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(5, 27);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 21);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "date";
            // 
            // lblDesc
            // 
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc.ForeColor = System.Drawing.Color.White;
            this.lblDesc.Location = new System.Drawing.Point(6, 54);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(163, 62);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "desc";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(173, 27);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 21);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "time";
            // 
            // btnDismiss
            // 
            this.btnDismiss.BackColor = System.Drawing.Color.Black;
            this.btnDismiss.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDismiss.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnDismiss.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnDismiss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDismiss.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDismiss.ForeColor = System.Drawing.Color.White;
            this.btnDismiss.Location = new System.Drawing.Point(175, 86);
            this.btnDismiss.Name = "btnDismiss";
            this.btnDismiss.Size = new System.Drawing.Size(100, 30);
            this.btnDismiss.TabIndex = 15;
            this.btnDismiss.Text = "Mark Done";
            this.btnDismiss.UseVisualStyleBackColor = false;
            this.btnDismiss.Click += new System.EventHandler(this.btnDismiss_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Black;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(175, 50);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "Edit Task";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblMark
            // 
            this.lblMark.AutoSize = true;
            this.lblMark.BackColor = System.Drawing.Color.Transparent;
            this.lblMark.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMark.ForeColor = System.Drawing.Color.Red;
            this.lblMark.Location = new System.Drawing.Point(256, -6);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(26, 37);
            this.lblMark.TabIndex = 17;
            this.lblMark.Text = "!";
            this.lblMark.Visible = false;
            this.lblMark.MouseEnter += new System.EventHandler(this.lblMark_MouseEnter);
            // 
            // Event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblMark);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDismiss);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblName);
            this.Name = "Event";
            this.Size = new System.Drawing.Size(280, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnDismiss;
        private System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Label lblMark;
    }
}
