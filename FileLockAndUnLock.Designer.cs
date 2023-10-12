namespace WinFormsWebDav
{
    partial class FileLockAndUnLock
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
            tbFile = new TextBox();
            label7 = new Label();
            tbProject = new TextBox();
            label6 = new Label();
            btnFileUnLock = new Button();
            btnFileLock = new Button();
            tbPassword = new TextBox();
            label2 = new Label();
            rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // tbFile
            // 
            tbFile.Location = new Point(132, 92);
            tbFile.Name = "tbFile";
            tbFile.Size = new Size(235, 30);
            tbFile.TabIndex = 27;
            tbFile.Text = "1.dwg";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(37, 98);
            label7.Name = "label7";
            label7.Size = new Size(46, 24);
            label7.TabIndex = 26;
            label7.Text = "文件";
            // 
            // tbProject
            // 
            tbProject.Location = new Point(132, 20);
            tbProject.Name = "tbProject";
            tbProject.Size = new Size(235, 30);
            tbProject.TabIndex = 25;
            tbProject.Text = "08db9faa-e5ce-4a96-8f83-040321727070";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 26);
            label6.Name = "label6";
            label6.Size = new Size(46, 24);
            label6.TabIndex = 24;
            label6.Text = "项目";
            // 
            // btnFileUnLock
            // 
            btnFileUnLock.Location = new Point(230, 235);
            btnFileUnLock.Name = "btnFileUnLock";
            btnFileUnLock.Size = new Size(137, 32);
            btnFileUnLock.TabIndex = 23;
            btnFileUnLock.Text = "解锁";
            btnFileUnLock.UseVisualStyleBackColor = true;
            btnFileUnLock.Click += btnFileUnLock_Click;
            // 
            // btnFileLock
            // 
            btnFileLock.Location = new Point(41, 235);
            btnFileLock.Name = "btnFileLock";
            btnFileLock.Size = new Size(137, 32);
            btnFileLock.TabIndex = 22;
            btnFileLock.Text = "锁定";
            btnFileLock.UseVisualStyleBackColor = true;
            btnFileLock.Click += btnFileLock_Click;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(132, 162);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(235, 30);
            tbPassword.TabIndex = 29;
            tbPassword.Text = "cst_Ju490XH68A5dOXRFY71JiJHzQmZyHzAWwk7aaEmzESbdu5vNDYGE8KnuUrkB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 168);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 28;
            label2.Text = "密码";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(397, 26);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(405, 241);
            rtbLog.TabIndex = 30;
            rtbLog.Text = "";
            // 
            // FileLockAndUnLock
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rtbLog);
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(tbFile);
            Controls.Add(label7);
            Controls.Add(tbProject);
            Controls.Add(label6);
            Controls.Add(btnFileUnLock);
            Controls.Add(btnFileLock);
            Name = "FileLockAndUnLock";
            Size = new Size(828, 311);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbFile;
        private Label label7;
        private TextBox tbProject;
        private Label label6;
        private Button btnFileUnLock;
        private Button btnFileLock;
        private TextBox tbPassword;
        private Label label2;
        private RichTextBox rtbLog;
    }
}
