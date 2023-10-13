namespace WinFormsWebDav
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            msWebDav = new ToolStripMenuItem();
            msLockAndUnLock = new ToolStripMenuItem();
            msFileReadOnly = new ToolStripMenuItem();
            msMSMQ = new ToolStripMenuItem();
            tcWebDav = new TabControl();
            Webdav = new TabPage();
            webDav1 = new WebDav();
            tabPage2 = new TabPage();
            tabPage1 = new TabPage();
            fileSetInfo1 = new FileSetInfo();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            fileWatchUc1 = new FileWatchUc();
            fileLockOrUnLock1 = new FileLockOrUnLock();
            cbIsShowMessageBox = new CheckBox();
            cbIsWriteLog = new CheckBox();
            menuStrip1.SuspendLayout();
            tcWebDav.SuspendLayout();
            Webdav.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { msWebDav, msLockAndUnLock, msFileReadOnly, msMSMQ });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10, 2, 0, 2);
            menuStrip1.Size = new Size(1479, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // msWebDav
            // 
            msWebDav.Name = "msWebDav";
            msWebDav.Size = new Size(99, 28);
            msWebDav.Text = "WebDav";
            msWebDav.Click += webDavToolStripMenuItem_Click;
            // 
            // msLockAndUnLock
            // 
            msLockAndUnLock.Name = "msLockAndUnLock";
            msLockAndUnLock.Size = new Size(152, 28);
            msLockAndUnLock.Text = "文件锁定和解锁";
            msLockAndUnLock.Click += msLockAndUnLock_Click;
            // 
            // msFileReadOnly
            // 
            msFileReadOnly.Name = "msFileReadOnly";
            msFileReadOnly.Size = new Size(98, 28);
            msFileReadOnly.Text = "文件只读";
            msFileReadOnly.Click += msFileReadOnly_Click;
            // 
            // msMSMQ
            // 
            msMSMQ.Name = "msMSMQ";
            msMSMQ.Size = new Size(87, 28);
            msMSMQ.Text = "MSMQ";
            msMSMQ.Click += msMSMQ_Click;
            // 
            // tcWebDav
            // 
            tcWebDav.Controls.Add(Webdav);
            tcWebDav.Controls.Add(tabPage2);
            tcWebDav.Controls.Add(tabPage1);
            tcWebDav.Controls.Add(tabPage3);
            tcWebDav.Controls.Add(tabPage4);
            tcWebDav.Controls.Add(tabPage5);
            tcWebDav.Location = new Point(26, 83);
            tcWebDav.Name = "tcWebDav";
            tcWebDav.SelectedIndex = 0;
            tcWebDav.Size = new Size(1390, 690);
            tcWebDav.TabIndex = 1;
            // 
            // Webdav
            // 
            Webdav.Controls.Add(webDav1);
            Webdav.Location = new Point(4, 33);
            Webdav.Name = "Webdav";
            Webdav.Padding = new Padding(3);
            Webdav.Size = new Size(1382, 653);
            Webdav.TabIndex = 0;
            Webdav.Text = "WebDav";
            Webdav.UseVisualStyleBackColor = true;
            // 
            // webDav1
            // 
            webDav1.Location = new Point(42, 15);
            webDav1.Name = "webDav1";
            webDav1.Size = new Size(1291, 599);
            webDav1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(_fileLockAndUnLock);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1382, 653);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "文件锁定和解锁";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(fileSetInfo1);
            tabPage1.Location = new Point(4, 33);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1382, 653);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "设置文件只读";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // fileSetInfo1
            // 
            fileSetInfo1.Location = new Point(19, 61);
            fileSetInfo1.Name = "fileSetInfo1";
            fileSetInfo1.Size = new Size(664, 290);
            fileSetInfo1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(_appWatcherUc1);
            tabPage3.Location = new Point(4, 33);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1382, 653);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "监控应用程序";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(_microSoftMessageQueuingUc1);
            tabPage4.Location = new Point(4, 33);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1382, 653);
            tabPage4.TabIndex = 4;
            tabPage4.Text = "MSMQ";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(fileWatchUc1);
            tabPage5.Location = new Point(4, 33);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1382, 653);
            tabPage5.TabIndex = 5;
            tabPage5.Text = "监控文件变化";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // fileWatchUc1
            // 
            fileWatchUc1.Location = new Point(0, 0);
            fileWatchUc1.Name = "fileWatchUc1";
            fileWatchUc1.Size = new Size(1187, 594);
            fileWatchUc1.TabIndex = 0;
            // 
            // fileLockOrUnLock1
            // 
            fileLockOrUnLock1.Location = new Point(0, 0);
            fileLockOrUnLock1.Name = "fileLockOrUnLock1";
            fileLockOrUnLock1.Size = new Size(811, 331);
            fileLockOrUnLock1.TabIndex = 0;
            // 
            // cbIsShowMessageBox
            // 
            cbIsShowMessageBox.AutoSize = true;
            cbIsShowMessageBox.Location = new Point(26, 49);
            cbIsShowMessageBox.Name = "cbIsShowMessageBox";
            cbIsShowMessageBox.Size = new Size(234, 28);
            cbIsShowMessageBox.TabIndex = 2;
            cbIsShowMessageBox.Text = "提示信息是否弹出对话框";
            cbIsShowMessageBox.UseVisualStyleBackColor = true;
            cbIsShowMessageBox.CheckedChanged += cbIsShowMessageBox_CheckedChanged;
            // 
            // cbIsWriteLog
            // 
            cbIsWriteLog.AutoSize = true;
            cbIsWriteLog.Location = new Point(361, 49);
            cbIsWriteLog.Name = "cbIsWriteLog";
            cbIsWriteLog.Size = new Size(216, 28);
            cbIsWriteLog.TabIndex = 3;
            cbIsWriteLog.Text = "提示信息是否写入日志";
            cbIsWriteLog.UseVisualStyleBackColor = true;
            cbIsWriteLog.CheckedChanged += cbIsWriteLog_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1479, 795);
            Controls.Add(cbIsWriteLog);
            Controls.Add(cbIsShowMessageBox);
            Controls.Add(tcWebDav);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tcWebDav.ResumeLayout(false);
            Webdav.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem msWebDav;
        private ToolStripMenuItem msLockAndUnLock;
        private ToolStripMenuItem msFileReadOnly;
        private ToolStripMenuItem msMSMQ;
        private TabControl tcWebDav;
        private TabPage Webdav;
        private TabPage tabPage2;
        private WebDav webDav1;
        private FileLockOrUnLock fileLockOrUnLock1;
        private TabPage tabPage1;
        private TabPage tabPage3;
        private FileSetInfo fileSetInfo1;
        private TabPage tabPage4;
        //private AppWatcherUc appWatcherUc1;
        //private MicroSoftMessageQueuingUc microSoftMessageQueuingUc1;
        private TabPage tabPage5;
        private FileWatchUc fileWatchUc1;
        private CheckBox cbIsShowMessageBox;
        private CheckBox cbIsWriteLog;
    }
}