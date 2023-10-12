namespace WinFormsWebDav
{
    partial class WebDavForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btMountWebdav = new Button();
            label1 = new Label();
            tbUserName = new TextBox();
            tbPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            rtbPath = new RichTextBox();
            rtbLog = new RichTextBox();
            label4 = new Label();
            cbIsAutoClose = new ComboBox();
            btUnMountWebDav = new Button();
            cbDriveLetter = new ComboBox();
            label5 = new Label();
            btClear = new Button();
            btGetWebDavList = new Button();
            btnSend = new Button();
            btnUnLock = new Button();
            tbProject = new TextBox();
            label6 = new Label();
            tbFile = new TextBox();
            label7 = new Label();
            btnSetReadOnly = new Button();
            btReadOnlyFile = new TextBox();
            btnCancelReadOnly = new Button();
            tbWatcher = new TextBox();
            label8 = new Label();
            btnWatch = new Button();
            tbServiceAddress = new TextBox();
            label9 = new Label();
            tbQueueName = new TextBox();
            label10 = new Label();
            rtbMessage = new RichTextBox();
            btnSendMessage = new Button();
            tbnReceive = new Button();
            tbExpirationTime = new TextBox();
            label11 = new Label();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            菜单1ToolStripMenuItem = new ToolStripMenuItem();
            菜单2ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btMountWebdav
            // 
            btMountWebdav.Location = new Point(277, 571);
            btMountWebdav.Name = "btMountWebdav";
            btMountWebdav.Size = new Size(104, 32);
            btMountWebdav.TabIndex = 0;
            btMountWebdav.Text = "挂载";
            btMountWebdav.UseVisualStyleBackColor = true;
            btMountWebdav.Click += btMountWebdav_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 166);
            label1.Name = "label1";
            label1.Size = new Size(46, 24);
            label1.TabIndex = 1;
            label1.Text = "账号";
            // 
            // tbUserName
            // 
            tbUserName.Location = new Point(146, 160);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(235, 30);
            tbUserName.TabIndex = 2;
            tbUserName.Text = "admin";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(146, 228);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(235, 30);
            tbPassword.TabIndex = 4;
            tbPassword.Text = "cst_Ju490XH68A5dOXRFY71JiJHzQmZyHzAWwk7aaEmzESbdu5vNDYGE8KnuUrkB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 234);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 3;
            label2.Text = "密码";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 405);
            label3.Name = "label3";
            label3.Size = new Size(46, 24);
            label3.TabIndex = 5;
            label3.Text = "路径";
            // 
            // rtbPath
            // 
            rtbPath.Location = new Point(146, 405);
            rtbPath.Name = "rtbPath";
            rtbPath.Size = new Size(238, 132);
            rtbPath.TabIndex = 7;
            rtbPath.Text = "http://qatest007.cscloud.cscad.net:6003/api/document/webdav";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(544, 115);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(683, 422);
            rtbLog.TabIndex = 8;
            rtbLog.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 115);
            label4.Name = "label4";
            label4.Size = new Size(118, 24);
            label4.TabIndex = 9;
            label4.Text = "是否自动关闭";
            // 
            // cbIsAutoClose
            // 
            cbIsAutoClose.FormattingEnabled = true;
            cbIsAutoClose.Items.AddRange(new object[] { "否", "是" });
            cbIsAutoClose.Location = new Point(148, 113);
            cbIsAutoClose.Name = "cbIsAutoClose";
            cbIsAutoClose.Size = new Size(236, 32);
            cbIsAutoClose.TabIndex = 10;
            // 
            // btUnMountWebDav
            // 
            btUnMountWebDav.Location = new Point(146, 571);
            btUnMountWebDav.Name = "btUnMountWebDav";
            btUnMountWebDav.Size = new Size(104, 32);
            btUnMountWebDav.TabIndex = 11;
            btUnMountWebDav.Text = "解挂";
            btUnMountWebDav.UseVisualStyleBackColor = true;
            btUnMountWebDav.Click += btUnMountWebDav_Click;
            // 
            // cbDriveLetter
            // 
            cbDriveLetter.FormattingEnabled = true;
            cbDriveLetter.Location = new Point(146, 300);
            cbDriveLetter.Name = "cbDriveLetter";
            cbDriveLetter.Size = new Size(236, 32);
            cbDriveLetter.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 303);
            label5.Name = "label5";
            label5.Size = new Size(46, 24);
            label5.TabIndex = 13;
            label5.Text = "盘符";
            // 
            // btClear
            // 
            btClear.Location = new Point(1123, 571);
            btClear.Name = "btClear";
            btClear.Size = new Size(104, 32);
            btClear.TabIndex = 14;
            btClear.Text = "清理";
            btClear.UseVisualStyleBackColor = true;
            btClear.Click += btClear_Click;
            // 
            // btGetWebDavList
            // 
            btGetWebDavList.Location = new Point(544, 571);
            btGetWebDavList.Name = "btGetWebDavList";
            btGetWebDavList.Size = new Size(137, 32);
            btGetWebDavList.TabIndex = 15;
            btGetWebDavList.Text = "获取挂载列表";
            btGetWebDavList.UseVisualStyleBackColor = true;
            btGetWebDavList.Click += btGetWebDavList_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(609, 767);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(137, 32);
            btnSend.TabIndex = 16;
            btnSend.Text = "锁定";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnUnLock
            // 
            btnUnLock.Location = new Point(798, 767);
            btnUnLock.Name = "btnUnLock";
            btnUnLock.Size = new Size(137, 32);
            btnUnLock.TabIndex = 17;
            btnUnLock.Text = "解锁";
            btnUnLock.UseVisualStyleBackColor = true;
            btnUnLock.Click += btnUnLock_Click;
            // 
            // tbProject
            // 
            tbProject.Location = new Point(700, 643);
            tbProject.Name = "tbProject";
            tbProject.Size = new Size(235, 30);
            tbProject.TabIndex = 19;
            tbProject.Text = "08db9faa-e5ce-4a96-8f83-040321727070";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(605, 649);
            label6.Name = "label6";
            label6.Size = new Size(46, 24);
            label6.TabIndex = 18;
            label6.Text = "项目";
            // 
            // tbFile
            // 
            tbFile.Location = new Point(700, 715);
            tbFile.Name = "tbFile";
            tbFile.Size = new Size(235, 30);
            tbFile.TabIndex = 21;
            tbFile.Text = "1.dwg";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(605, 721);
            label7.Name = "label7";
            label7.Size = new Size(46, 24);
            label7.TabIndex = 20;
            label7.Text = "文件";
            // 
            // btnSetReadOnly
            // 
            btnSetReadOnly.Location = new Point(146, 749);
            btnSetReadOnly.Name = "btnSetReadOnly";
            btnSetReadOnly.Size = new Size(104, 32);
            btnSetReadOnly.TabIndex = 22;
            btnSetReadOnly.Text = "设置只读";
            btnSetReadOnly.UseVisualStyleBackColor = true;
            btnSetReadOnly.Click += btnSetReadOnly_Click;
            // 
            // btReadOnlyFile
            // 
            btReadOnlyFile.Location = new Point(146, 700);
            btReadOnlyFile.Name = "btReadOnlyFile";
            btReadOnlyFile.Size = new Size(235, 30);
            btReadOnlyFile.TabIndex = 23;
            btReadOnlyFile.Text = "Z:\\teslock\\11.dwg";
            // 
            // btnCancelReadOnly
            // 
            btnCancelReadOnly.Location = new Point(277, 749);
            btnCancelReadOnly.Name = "btnCancelReadOnly";
            btnCancelReadOnly.Size = new Size(104, 32);
            btnCancelReadOnly.TabIndex = 24;
            btnCancelReadOnly.Text = "取消只读";
            btnCancelReadOnly.UseVisualStyleBackColor = true;
            btnCancelReadOnly.Click += btnCancelReadOnly_Click;
            // 
            // tbWatcher
            // 
            tbWatcher.Location = new Point(1049, 643);
            tbWatcher.Name = "tbWatcher";
            tbWatcher.Size = new Size(235, 30);
            tbWatcher.TabIndex = 26;
            tbWatcher.Text = "notepad";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(954, 649);
            label8.Name = "label8";
            label8.Size = new Size(46, 24);
            label8.TabIndex = 25;
            label8.Text = "监控";
            // 
            // btnWatch
            // 
            btnWatch.Location = new Point(1147, 713);
            btnWatch.Name = "btnWatch";
            btnWatch.Size = new Size(137, 32);
            btnWatch.TabIndex = 27;
            btnWatch.Text = "监控";
            btnWatch.UseVisualStyleBackColor = true;
            btnWatch.Click += btnWatch_Click;
            // 
            // tbServiceAddress
            // 
            tbServiceAddress.Location = new Point(1477, 115);
            tbServiceAddress.Name = "tbServiceAddress";
            tbServiceAddress.Size = new Size(235, 30);
            tbServiceAddress.TabIndex = 29;
            tbServiceAddress.Text = "qatest007";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1382, 121);
            label9.Name = "label9";
            label9.Size = new Size(64, 24);
            label9.TabIndex = 28;
            label9.Text = "服务器";
            // 
            // tbQueueName
            // 
            tbQueueName.Location = new Point(1477, 166);
            tbQueueName.Name = "tbQueueName";
            tbQueueName.Size = new Size(235, 30);
            tbQueueName.TabIndex = 31;
            tbQueueName.Text = "pantestqueue";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1382, 172);
            label10.Name = "label10";
            label10.Size = new Size(64, 24);
            label10.TabIndex = 30;
            label10.Text = "列队名";
            // 
            // rtbMessage
            // 
            rtbMessage.Location = new Point(1393, 272);
            rtbMessage.Name = "rtbMessage";
            rtbMessage.Size = new Size(333, 215);
            rtbMessage.TabIndex = 32;
            rtbMessage.Text = "";
            // 
            // btnSendMessage
            // 
            btnSendMessage.Location = new Point(1393, 533);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(137, 32);
            btnSendMessage.TabIndex = 33;
            btnSendMessage.Text = "发送";
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // tbnReceive
            // 
            tbnReceive.Location = new Point(1589, 533);
            tbnReceive.Name = "tbnReceive";
            tbnReceive.Size = new Size(137, 32);
            tbnReceive.TabIndex = 34;
            tbnReceive.Text = "接收";
            tbnReceive.UseVisualStyleBackColor = true;
            tbnReceive.Click += tbnReceive_Click;
            // 
            // tbExpirationTime
            // 
            tbExpirationTime.Location = new Point(1479, 228);
            tbExpirationTime.Name = "tbExpirationTime";
            tbExpirationTime.Size = new Size(235, 30);
            tbExpirationTime.TabIndex = 36;
            tbExpirationTime.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1384, 234);
            label11.Name = "label11";
            label11.Size = new Size(82, 24);
            label11.TabIndex = 35;
            label11.Text = "过期时间";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem3 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1865, 32);
            menuStrip1.TabIndex = 37;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(201, 28);
            toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(285, 34);
            toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { 菜单1ToolStripMenuItem, 菜单2ToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(80, 28);
            toolStripMenuItem3.Text = "主菜单";
            // 
            // 菜单1ToolStripMenuItem
            // 
            菜单1ToolStripMenuItem.Name = "菜单1ToolStripMenuItem";
            菜单1ToolStripMenuItem.Size = new Size(270, 34);
            菜单1ToolStripMenuItem.Text = "菜单1";
            菜单1ToolStripMenuItem.Click += 菜单1ToolStripMenuItem_Click;
            // 
            // 菜单2ToolStripMenuItem
            // 
            菜单2ToolStripMenuItem.Name = "菜单2ToolStripMenuItem";
            菜单2ToolStripMenuItem.Size = new Size(270, 34);
            菜单2ToolStripMenuItem.Text = "菜单2";
            // 
            // WebDavForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1865, 803);
            Controls.Add(tbExpirationTime);
            Controls.Add(label11);
            Controls.Add(tbnReceive);
            Controls.Add(btnSendMessage);
            Controls.Add(rtbMessage);
            Controls.Add(tbQueueName);
            Controls.Add(label10);
            Controls.Add(tbServiceAddress);
            Controls.Add(label9);
            Controls.Add(btnWatch);
            Controls.Add(tbWatcher);
            Controls.Add(label8);
            Controls.Add(btnCancelReadOnly);
            Controls.Add(btReadOnlyFile);
            Controls.Add(btnSetReadOnly);
            Controls.Add(tbFile);
            Controls.Add(label7);
            Controls.Add(tbProject);
            Controls.Add(label6);
            Controls.Add(btnUnLock);
            Controls.Add(btnSend);
            Controls.Add(btGetWebDavList);
            Controls.Add(btClear);
            Controls.Add(label5);
            Controls.Add(cbDriveLetter);
            Controls.Add(btUnMountWebDav);
            Controls.Add(cbIsAutoClose);
            Controls.Add(label4);
            Controls.Add(rtbLog);
            Controls.Add(rtbPath);
            Controls.Add(label3);
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(tbUserName);
            Controls.Add(label1);
            Controls.Add(btMountWebdav);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "WebDavForm";
            Text = "WinFormsWebDav";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox tbUserName;
        private TextBox tbPassword;
        private Label label2;
        private Label label3;
        private RichTextBox rtbPath;
        private RichTextBox rtbLog;
        private Label label4;
        private ComboBox cbIsAutoClose;
        private Button btUnMountWebDav;
        private ComboBox cbDriveLetter;
        private Label label5;
        private Button btClear;
        private Button btMountWebdav;
        private Button btGetWebDavList;
        private Button btnSend;
        private Button btnUnLock;
        private TextBox tbProject;
        private Label label6;
        private TextBox tbFile;
        private Label label7;
        private Button btnSetReadOnly;
        private TextBox btReadOnlyFile;
        private Button btnCancelReadOnly;
        private TextBox tbWatcher;
        private Label label8;
        private Button btnWatch;
        private TextBox tbServiceAddress;
        private Label label9;
        private TextBox tbQueueName;
        private Label label10;
        private RichTextBox rtbMessage;
        private Button btnSendMessage;
        private Button tbnReceive;
        private TextBox tbExpirationTime;
        private Label label11;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem 菜单1ToolStripMenuItem;
        private ToolStripMenuItem 菜单2ToolStripMenuItem;
    }
}