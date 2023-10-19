namespace WinFormsWebDav
{
    partial class FormMain
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
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            tbWebdav = new TabPage();
            tabPage2 = new TabPage();
            splitContainer2 = new SplitContainer();
            btnDeleteFile = new Button();
            tbResidue = new TextBox();
            label4 = new Label();
            tbCanNotDown = new TextBox();
            label3 = new Label();
            tbCanDown = new TextBox();
            label2 = new Label();
            tbAllFileCount = new TextBox();
            label1 = new Label();
            btnCheckFile = new Button();
            btnInitTree = new Button();
            tvFiles = new TreeView();
            tbMSMQ = new TabPage();
            tbFileSetInfo = new TabPage();
            fileSetInfo = new FileSetInfoUcNew();
            tbFileLockAndUnLock = new TabPage();
            btnClear = new Button();
            rtbLog = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tbFileSetInfo.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnClear);
            splitContainer1.Panel2.Controls.Add(rtbLog);
            splitContainer1.Size = new Size(1978, 944);
            splitContainer1.SplitterDistance = 850;
            splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbWebdav);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tbMSMQ);
            tabControl1.Controls.Add(tbFileSetInfo);
            tabControl1.Controls.Add(tbFileLockAndUnLock);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(850, 944);
            tabControl1.TabIndex = 0;
            // 
            // tbWebdav
            // 
            tbWebdav.Location = new Point(4, 33);
            tbWebdav.Name = "tbWebdav";
            tbWebdav.Padding = new Padding(3);
            tbWebdav.Size = new Size(842, 907);
            tbWebdav.TabIndex = 0;
            tbWebdav.Text = "WebDav";
            tbWebdav.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainer2);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(842, 907);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "WebDavFiles";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(btnDeleteFile);
            splitContainer2.Panel1.Controls.Add(tbResidue);
            splitContainer2.Panel1.Controls.Add(label4);
            splitContainer2.Panel1.Controls.Add(tbCanNotDown);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(tbCanDown);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Controls.Add(tbAllFileCount);
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Controls.Add(btnCheckFile);
            splitContainer2.Panel1.Controls.Add(btnInitTree);
            splitContainer2.Panel1.RightToLeft = RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tvFiles);
            splitContainer2.Panel2.RightToLeft = RightToLeft.Yes;
            splitContainer2.RightToLeft = RightToLeft.Yes;
            splitContainer2.Size = new Size(836, 901);
            splitContainer2.SplitterDistance = 120;
            splitContainer2.TabIndex = 1;
            // 
            // btnDeleteFile
            // 
            btnDeleteFile.Location = new Point(368, 3);
            btnDeleteFile.Name = "btnDeleteFile";
            btnDeleteFile.Size = new Size(133, 51);
            btnDeleteFile.TabIndex = 12;
            btnDeleteFile.Text = "删除文件";
            btnDeleteFile.UseVisualStyleBackColor = true;
            btnDeleteFile.Click += btnDeleteFile_Click;
            // 
            // tbResidue
            // 
            tbResidue.Location = new Point(664, 82);
            tbResidue.Name = "tbResidue";
            tbResidue.ReadOnly = true;
            tbResidue.Size = new Size(64, 30);
            tbResidue.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(602, 83);
            label4.Name = "label4";
            label4.Size = new Size(46, 24);
            label4.TabIndex = 10;
            label4.Text = "剩余";
            // 
            // tbCanNotDown
            // 
            tbCanNotDown.Location = new Point(465, 79);
            tbCanNotDown.Name = "tbCanNotDown";
            tbCanNotDown.ReadOnly = true;
            tbCanNotDown.Size = new Size(64, 30);
            tbCanNotDown.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(377, 83);
            label3.Name = "label3";
            label3.Size = new Size(82, 24);
            label3.TabIndex = 8;
            label3.Text = "不可下载";
            // 
            // tbCanDown
            // 
            tbCanDown.Location = new Point(259, 81);
            tbCanDown.Name = "tbCanDown";
            tbCanDown.ReadOnly = true;
            tbCanDown.Size = new Size(64, 30);
            tbCanDown.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, 82);
            label2.Name = "label2";
            label2.Size = new Size(64, 24);
            label2.TabIndex = 6;
            label2.Text = "可下载";
            // 
            // tbAllFileCount
            // 
            tbAllFileCount.Location = new Point(70, 80);
            tbAllFileCount.Name = "tbAllFileCount";
            tbAllFileCount.ReadOnly = true;
            tbAllFileCount.Size = new Size(64, 30);
            tbAllFileCount.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 81);
            label1.Name = "label1";
            label1.Size = new Size(46, 24);
            label1.TabIndex = 4;
            label1.Text = "总数";
            // 
            // btnCheckFile
            // 
            btnCheckFile.Location = new Point(188, 3);
            btnCheckFile.Name = "btnCheckFile";
            btnCheckFile.Size = new Size(133, 51);
            btnCheckFile.TabIndex = 3;
            btnCheckFile.Text = "检测文件";
            btnCheckFile.UseVisualStyleBackColor = true;
            btnCheckFile.Click += btnCheckFile_Click;
            // 
            // btnInitTree
            // 
            btnInitTree.Location = new Point(19, 6);
            btnInitTree.Name = "btnInitTree";
            btnInitTree.Size = new Size(133, 51);
            btnInitTree.TabIndex = 3;
            btnInitTree.Text = "初始化树形结构";
            btnInitTree.UseVisualStyleBackColor = true;
            btnInitTree.Click += btnInitTree_ClickNew;
            // 
            // tvFiles
            // 
            tvFiles.Dock = DockStyle.Fill;
            tvFiles.Location = new Point(0, 0);
            tvFiles.Name = "tvFiles";
            tvFiles.Size = new Size(836, 777);
            tvFiles.TabIndex = 0;
            // 
            // tbMSMQ
            // 
            tbMSMQ.Location = new Point(4, 33);
            tbMSMQ.Name = "tbMSMQ";
            tbMSMQ.Padding = new Padding(3);
            tbMSMQ.Size = new Size(842, 907);
            tbMSMQ.TabIndex = 2;
            tbMSMQ.Text = "MSMQ";
            tbMSMQ.UseVisualStyleBackColor = true;
            // 
            // tbFileSetInfo
            // 
            tbFileSetInfo.Controls.Add(fileSetInfo);
            tbFileSetInfo.Location = new Point(4, 33);
            tbFileSetInfo.Name = "tbFileSetInfo";
            tbFileSetInfo.Padding = new Padding(3);
            tbFileSetInfo.Size = new Size(842, 907);
            tbFileSetInfo.TabIndex = 3;
            tbFileSetInfo.Text = "FileSetInfo";
            tbFileSetInfo.UseVisualStyleBackColor = true;
            // 
            // fileSetInfo
            // 
            fileSetInfo.Location = new Point(42, 64);
            fileSetInfo.Name = "fileSetInfo";
            fileSetInfo.Size = new Size(749, 600);
            fileSetInfo.TabIndex = 0;
            // 
            // tbFileLockAndUnLock
            // 
            tbFileLockAndUnLock.Location = new Point(4, 33);
            tbFileLockAndUnLock.Name = "tbFileLockAndUnLock";
            tbFileLockAndUnLock.Padding = new Padding(3);
            tbFileLockAndUnLock.Size = new Size(842, 907);
            tbFileLockAndUnLock.TabIndex = 4;
            tbFileLockAndUnLock.Text = "FileLockAndUnLockUc";
            tbFileLockAndUnLock.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(457, 657);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(133, 51);
            btnClear.TabIndex = 1;
            btnClear.Text = "清除";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(38, 33);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(1049, 566);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1978, 944);
            Controls.Add(splitContainer1);
            Name = "FormMain";
            Text = "FormMain";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tbFileSetInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tbWebdav;
        private TabPage tabPage2;
        private Button btnClear;
        private RichTextBox rtbLog;
        private TreeView tvFiles;
        private SplitContainer splitContainer2;
        private Button btnInitTree;
        private Button btnCheckFile;
        private TextBox tbCanNotDown;
        private Label label3;
        private TextBox tbCanDown;
        private Label label2;
        private TextBox tbAllFileCount;
        private Label label1;
        private TextBox tb;
        private Label label4;
        private TextBox tbResidue;
        private Button btnDeleteFile;
        private TabPage tbMSMQ;
        private TabPage tbFileSetInfo;
        private TabPage tbFileLockAndUnLock;
        private FileSetInfoUcNew fileSetInfo;
    }
}