namespace WinFormsWebDav
{
    partial class FileLockAndUnLockUcNew
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
            tbPassword = new TextBox();
            label2 = new Label();
            tbFile = new TextBox();
            label7 = new Label();
            tbProject = new TextBox();
            label6 = new Label();
            btnFileUnLock = new Button();
            btnFileLock = new Button();
            SuspendLayout();
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(154, 184);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(546, 30);
            tbPassword.TabIndex = 45;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 190);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 44;
            label2.Text = "密码";
            // 
            // tbFile
            // 
            tbFile.Location = new Point(154, 114);
            tbFile.Name = "tbFile";
            tbFile.Size = new Size(546, 30);
            tbFile.TabIndex = 43;
            tbFile.Text = "1.dwg";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(59, 120);
            label7.Name = "label7";
            label7.Size = new Size(46, 24);
            label7.TabIndex = 42;
            label7.Text = "文件";
            // 
            // tbProject
            // 
            tbProject.Location = new Point(154, 42);
            tbProject.Name = "tbProject";
            tbProject.Size = new Size(546, 30);
            tbProject.TabIndex = 41;
            tbProject.Text = "08db9faa-e5ce-4a96-8f83-040321727070";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(59, 48);
            label6.Name = "label6";
            label6.Size = new Size(46, 24);
            label6.TabIndex = 40;
            label6.Text = "项目";
            // 
            // btnFileUnLock
            // 
            btnFileUnLock.Location = new Point(413, 272);
            btnFileUnLock.Name = "btnFileUnLock";
            btnFileUnLock.Size = new Size(137, 32);
            btnFileUnLock.TabIndex = 39;
            btnFileUnLock.Text = "解锁";
            btnFileUnLock.UseVisualStyleBackColor = true;
            btnFileUnLock.Click += btnFileUnLock_Click;
            // 
            // btnFileLock
            // 
            btnFileLock.Location = new Point(224, 272);
            btnFileLock.Name = "btnFileLock";
            btnFileLock.Size = new Size(137, 32);
            btnFileLock.TabIndex = 38;
            btnFileLock.Text = "锁定";
            btnFileLock.UseVisualStyleBackColor = true;
            btnFileLock.Click += btnFileLock_Click;
            // 
            // FileLockAndUnLockUcNew
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(tbFile);
            Controls.Add(label7);
            Controls.Add(tbProject);
            Controls.Add(label6);
            Controls.Add(btnFileUnLock);
            Controls.Add(btnFileLock);
            Name = "FileLockAndUnLockUcNew";
            Size = new Size(783, 437);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
