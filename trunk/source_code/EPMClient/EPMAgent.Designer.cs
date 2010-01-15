namespace EPMClient
{
    partial class EPMAgent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EPMAgent));
            this.lblProjects = new System.Windows.Forms.Label();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.lblTasks = new System.Windows.Forms.Label();
            this.lvTasks = new EPMClient.ListViewEx();
            this.colTaskName = new System.Windows.Forms.ColumnHeader();
            this.colProjectName = new System.Windows.Forms.ColumnHeader();
            this.colTaskDayLeft = new System.Windows.Forms.ColumnHeader();
            this.lvProjects = new EPMClient.ListViewEx();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colDone = new System.Windows.Forms.ColumnHeader();
            this.colDayLeft = new System.Windows.Forms.ColumnHeader();
            this.tabProjects = new System.Windows.Forms.TabPage();
            this.lvProjects1 = new EPMClient.ListViewEx();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.lvTasks1 = new EPMClient.ListViewEx();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.tabProjects.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.notifyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProjects
            // 
            this.lblProjects.AutoSize = true;
            this.lblProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjects.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblProjects.Location = new System.Drawing.Point(6, 12);
            this.lblProjects.Name = "lblProjects";
            this.lblProjects.Size = new System.Drawing.Size(73, 13);
            this.lblProjects.TabIndex = 1;
            this.lblProjects.Text = "My Projects";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.tabHome);
            this.mainTabControl.Controls.Add(this.tabProjects);
            this.mainTabControl.Controls.Add(this.tabTasks);
            this.mainTabControl.ImageList = this.tabImageList;
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(687, 496);
            this.mainTabControl.TabIndex = 2;
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.lblTasks);
            this.tabHome.Controls.Add(this.lvTasks);
            this.tabHome.Controls.Add(this.lblProjects);
            this.tabHome.Controls.Add(this.lvProjects);
            this.tabHome.ImageIndex = 0;
            this.tabHome.Location = new System.Drawing.Point(4, 55);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(679, 437);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // lblTasks
            // 
            this.lblTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTasks.AutoSize = true;
            this.lblTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasks.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblTasks.Location = new System.Drawing.Point(6, 205);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(61, 13);
            this.lblTasks.TabIndex = 3;
            this.lblTasks.Text = "My Tasks";
            // 
            // lvTasks
            // 
            this.lvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTaskName,
            this.colProjectName,
            this.colTaskDayLeft});
            this.lvTasks.ControlPadding = 2;
            this.lvTasks.GridLines = true;
            this.lvTasks.Location = new System.Drawing.Point(3, 221);
            this.lvTasks.Name = "lvTasks";
            this.lvTasks.Size = new System.Drawing.Size(667, 195);
            this.lvTasks.TabIndex = 2;
            this.lvTasks.UseCompatibleStateImageBehavior = false;
            this.lvTasks.View = System.Windows.Forms.View.Details;
            // 
            // colTaskName
            // 
            this.colTaskName.Text = "Task Name";
            this.colTaskName.Width = 227;
            // 
            // colProjectName
            // 
            this.colProjectName.Text = "Project";
            this.colProjectName.Width = 148;
            // 
            // colTaskDayLeft
            // 
            this.colTaskDayLeft.Text = "Day Left";
            this.colTaskDayLeft.Width = 129;
            // 
            // lvProjects
            // 
            this.lvProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDone,
            this.colDayLeft});
            this.lvProjects.ControlPadding = 2;
            this.lvProjects.GridLines = true;
            this.lvProjects.Location = new System.Drawing.Point(3, 28);
            this.lvProjects.Name = "lvProjects";
            this.lvProjects.Size = new System.Drawing.Size(667, 153);
            this.lvProjects.TabIndex = 0;
            this.lvProjects.UseCompatibleStateImageBehavior = false;
            this.lvProjects.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 223;
            // 
            // colDone
            // 
            this.colDone.Text = "Done";
            this.colDone.Width = 151;
            // 
            // colDayLeft
            // 
            this.colDayLeft.Text = "Day Left";
            this.colDayLeft.Width = 128;
            // 
            // tabProjects
            // 
            this.tabProjects.Controls.Add(this.lvProjects1);
            this.tabProjects.ImageIndex = 1;
            this.tabProjects.Location = new System.Drawing.Point(4, 55);
            this.tabProjects.Name = "tabProjects";
            this.tabProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabProjects.Size = new System.Drawing.Size(679, 437);
            this.tabProjects.TabIndex = 1;
            this.tabProjects.Text = "My Projects";
            this.tabProjects.UseVisualStyleBackColor = true;
            // 
            // lvProjects1
            // 
            this.lvProjects1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProjects1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvProjects1.ControlPadding = 2;
            this.lvProjects1.GridLines = true;
            this.lvProjects1.Location = new System.Drawing.Point(6, 6);
            this.lvProjects1.Name = "lvProjects1";
            this.lvProjects1.Size = new System.Drawing.Size(667, 415);
            this.lvProjects1.TabIndex = 1;
            this.lvProjects1.UseCompatibleStateImageBehavior = false;
            this.lvProjects1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 223;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Done";
            this.columnHeader2.Width = 151;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Day Left";
            this.columnHeader3.Width = 128;
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.lvTasks1);
            this.tabTasks.ImageIndex = 2;
            this.tabTasks.Location = new System.Drawing.Point(4, 55);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Size = new System.Drawing.Size(679, 437);
            this.tabTasks.TabIndex = 2;
            this.tabTasks.Text = "My Tasks";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // lvTasks1
            // 
            this.lvTasks1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTasks1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvTasks1.ControlPadding = 2;
            this.lvTasks1.GridLines = true;
            this.lvTasks1.Location = new System.Drawing.Point(6, 6);
            this.lvTasks1.Name = "lvTasks1";
            this.lvTasks1.Size = new System.Drawing.Size(667, 415);
            this.lvTasks1.TabIndex = 3;
            this.lvTasks1.UseCompatibleStateImageBehavior = false;
            this.lvTasks1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Task Name";
            this.columnHeader4.Width = 227;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Project";
            this.columnHeader5.Width = 148;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Day Left";
            this.columnHeader6.Width = 129;
            // 
            // tabImageList
            // 
            this.tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabImageList.ImageStream")));
            this.tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabImageList.Images.SetKeyName(0, "home.png");
            this.tabImageList.Images.SetKeyName(1, "projects.png");
            this.tabImageList.Images.SetKeyName(2, "tasks.png");
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.Image = global::EPMClient.Properties.Resources.exit22;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(607, 529);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 33);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.Image = global::EPMClient.Properties.Resources.logout;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(509, 529);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(92, 33);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "EPM Agent";
            this.notifyIcon.Visible = true;
            // 
            // notifyContextMenu
            // 
            this.notifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.toolStripMenuItem1,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyContextMenu.Name = "notifyContextMenu";
            this.notifyContextMenu.Size = new System.Drawing.Size(119, 98);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // EPMAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 574);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.mainTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EPMAgent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPM Agent";
            this.Load += new System.EventHandler(this.EPMAgent_Load);
            this.mainTabControl.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            this.tabProjects.ResumeLayout(false);
            this.tabTasks.ResumeLayout(false);
            this.notifyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EPMClient.ListViewEx lvProjects;
        private System.Windows.Forms.Label lblProjects;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabProjects;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTasks;
        private EPMClient.ListViewEx lvTasks;
        private System.Windows.Forms.ImageList tabImageList;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDone;
        private System.Windows.Forms.ColumnHeader colDayLeft;
        private System.Windows.Forms.ColumnHeader colTaskName;
        private System.Windows.Forms.ColumnHeader colProjectName;
        private System.Windows.Forms.ColumnHeader colTaskDayLeft;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private ListViewEx lvProjects1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private ListViewEx lvTasks1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

