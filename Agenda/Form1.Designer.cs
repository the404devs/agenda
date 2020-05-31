namespace Agenda
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.btnPref = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openAgendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTodaysTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sidePanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 352);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.Purple;
            this.sidePanel.Controls.Add(this.btnPref);
            this.sidePanel.Controls.Add(this.btnNew);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(304, 35);
            this.sidePanel.TabIndex = 1;
            // 
            // btnPref
            // 
            this.btnPref.BackColor = System.Drawing.Color.Black;
            this.btnPref.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPref.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnPref.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnPref.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPref.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPref.ForeColor = System.Drawing.Color.White;
            this.btnPref.Location = new System.Drawing.Point(192, 3);
            this.btnPref.Name = "btnPref";
            this.btnPref.Size = new System.Drawing.Size(100, 30);
            this.btnPref.TabIndex = 15;
            this.btnPref.Text = "Preferences";
            this.btnPref.UseVisualStyleBackColor = false;
            this.btnPref.Click += new System.EventHandler(this.btnPref_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Black;
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(12, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 30);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "New Task";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "world";
            this.notifyIcon1.BalloonTipTitle = "Hello";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Agenda";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAgendaToolStripMenuItem,
            this.showTodaysTasksToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 70);
            // 
            // openAgendaToolStripMenuItem
            // 
            this.openAgendaToolStripMenuItem.Name = "openAgendaToolStripMenuItem";
            this.openAgendaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openAgendaToolStripMenuItem.Text = "Open Agenda";
            this.openAgendaToolStripMenuItem.Click += new System.EventHandler(this.openAgendaToolStripMenuItem_Click);
            // 
            // showTodaysTasksToolStripMenuItem
            // 
            this.showTodaysTasksToolStripMenuItem.Name = "showTodaysTasksToolStripMenuItem";
            this.showTodaysTasksToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.showTodaysTasksToolStripMenuItem.Text = "Show Today\'s Tasks";
            this.showTodaysTasksToolStripMenuItem.Click += new System.EventHandler(this.showTodaysTasksToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(304, 391);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(320, 999999975);
            this.MinimumSize = new System.Drawing.Size(320, 210);
            this.Name = "MainView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Agenda";
            this.Deactivate += new System.EventHandler(this.MainView_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.MainView_Load);
            this.Resize += new System.EventHandler(this.MainView_Resize);
            this.sidePanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnPref;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openAgendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTodaysTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}

