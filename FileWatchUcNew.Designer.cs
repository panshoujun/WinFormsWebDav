namespace WinFormsWebDav
{
    partial class FileWatchUcNew
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
            label1 = new Label();
            tbFolderPath = new TextBox();
            btnFolderWatch = new Button();
            button1 = new Button();
            label2 = new Label();
            tbFilePath = new TextBox();
            btnFileWatch = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 42);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 32;
            label1.Text = "监控路劲";
            // 
            // tbFolderPath
            // 
            tbFolderPath.Location = new Point(139, 36);
            tbFolderPath.Name = "tbFolderPath";
            tbFolderPath.Size = new Size(591, 30);
            tbFolderPath.TabIndex = 30;
            tbFolderPath.Text = "C:\\bugtest";
            // 
            // btnFolderWatch
            // 
            btnFolderWatch.Location = new Point(139, 85);
            btnFolderWatch.Name = "btnFolderWatch";
            btnFolderWatch.Size = new Size(104, 32);
            btnFolderWatch.TabIndex = 29;
            btnFolderWatch.Text = "开始监控";
            btnFolderWatch.UseVisualStyleBackColor = true;
            btnFolderWatch.Click += btnFolderWatch_Click;
            // 
            // button1
            // 
            button1.Location = new Point(525, 266);
            button1.Name = "button1";
            button1.Size = new Size(106, 42);
            button1.TabIndex = 33;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 179);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 36;
            label2.Text = "监控文件";
            // 
            // tbFilePath
            // 
            tbFilePath.Location = new Point(139, 173);
            tbFilePath.Name = "tbFilePath";
            tbFilePath.Size = new Size(591, 30);
            tbFilePath.TabIndex = 35;
            tbFilePath.Text = "C:\\bugtest\\123.txt";
            // 
            // btnFileWatch
            // 
            btnFileWatch.Location = new Point(139, 222);
            btnFileWatch.Name = "btnFileWatch";
            btnFileWatch.Size = new Size(104, 32);
            btnFileWatch.TabIndex = 34;
            btnFileWatch.Text = "开始监控";
            btnFileWatch.UseVisualStyleBackColor = true;
            btnFileWatch.Click += btnFileWatch_Click;
            // 
            // FileWatchUcNew
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(tbFilePath);
            Controls.Add(btnFileWatch);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(tbFolderPath);
            Controls.Add(btnFolderWatch);
            Name = "FileWatchUcNew";
            Size = new Size(797, 466);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbFolderPath;
        private Button btnFolderWatch;
        private Button button1;
        private Label label2;
        private TextBox tbFilePath;
        private Button btnFileWatch;
    }
}
