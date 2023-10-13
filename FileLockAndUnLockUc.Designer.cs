namespace WinFormsWebDav
{
    partial class FileLockAndUnLockUc
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            rtbLog = new RichTextBox();
            btnClear = new Button();
            splitContainer1 = new SplitContainer();
            tbPassword = new TextBox();
            label2 = new Label();
            tbFile = new TextBox();
            label7 = new Label();
            tbProject = new TextBox();
            label6 = new Label();
            btnFileUnLock = new Button();
            btnFileLock = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(32, 15);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(780, 172);
            rtbLog.TabIndex = 30;
            rtbLog.Text = "";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(675, 230);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(137, 32);
            btnClear.TabIndex = 31;
            btnClear.Text = "清理";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(14, 16);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tbPassword);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(tbFile);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(tbProject);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(btnFileUnLock);
            splitContainer1.Panel1.Controls.Add(btnFileLock);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(rtbLog);
            splitContainer1.Panel2.Controls.Add(btnClear);
            splitContainer1.Size = new Size(1200, 400);
            splitContainer1.SplitterDistance = 370;
            splitContainer1.TabIndex = 32;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(116, 157);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(235, 30);
            tbPassword.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 163);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 36;
            label2.Text = "密码";
            // 
            // tbFile
            // 
            tbFile.Location = new Point(116, 87);
            tbFile.Name = "tbFile";
            tbFile.Size = new Size(235, 30);
            tbFile.TabIndex = 35;
            tbFile.Text = "1.dwg";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 93);
            label7.Name = "label7";
            label7.Size = new Size(46, 24);
            label7.TabIndex = 34;
            label7.Text = "文件";
            // 
            // tbProject
            // 
            tbProject.Location = new Point(116, 15);
            tbProject.Name = "tbProject";
            tbProject.Size = new Size(235, 30);
            tbProject.TabIndex = 33;
            tbProject.Text = "08db9faa-e5ce-4a96-8f83-040321727070";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 21);
            label6.Name = "label6";
            label6.Size = new Size(46, 24);
            label6.TabIndex = 32;
            label6.Text = "项目";
            // 
            // btnFileUnLock
            // 
            btnFileUnLock.Location = new Point(214, 230);
            btnFileUnLock.Name = "btnFileUnLock";
            btnFileUnLock.Size = new Size(137, 32);
            btnFileUnLock.TabIndex = 31;
            btnFileUnLock.Text = "解锁";
            btnFileUnLock.UseVisualStyleBackColor = true;
            btnFileUnLock.Click += btnFileUnLock_Click;
            // 
            // btnFileLock
            // 
            btnFileLock.Location = new Point(25, 230);
            btnFileLock.Name = "btnFileLock";
            btnFileLock.Size = new Size(137, 32);
            btnFileLock.TabIndex = 30;
            btnFileLock.Text = "锁定";
            btnFileLock.UseVisualStyleBackColor = true;
            btnFileLock.Click += btnFileLock_Click;
            // 
            // FileLockAndUnLock
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "FileLockAndUnLock";
            Size = new Size(1232, 437);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox rtbLog;
        private Button btnClear;
        private SplitContainer splitContainer1;
        private TextBox tbPassword;
        private Label label2;
        private TextBox tbFile;
        private Label label7;
        private TextBox tbProject;
        private Label label6;
        private Button btnFileUnLock;
        private Button btnFileLock;
    }
}
