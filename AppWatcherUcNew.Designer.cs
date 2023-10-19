namespace WinFormsWebDav
{
    partial class AppWatcherUcNew
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
            btnWatch = new Button();
            tbWatcher = new TextBox();
            label8 = new Label();
            rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // btnWatch
            // 
            btnWatch.Location = new Point(423, 291);
            btnWatch.Name = "btnWatch";
            btnWatch.Size = new Size(137, 32);
            btnWatch.TabIndex = 30;
            btnWatch.Text = "监控";
            btnWatch.UseVisualStyleBackColor = true;
            btnWatch.Click += btnWatch_Click;
            // 
            // tbWatcher
            // 
            tbWatcher.Location = new Point(125, 24);
            tbWatcher.Name = "tbWatcher";
            tbWatcher.Size = new Size(435, 30);
            tbWatcher.TabIndex = 29;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 30);
            label8.Name = "label8";
            label8.Size = new Size(46, 24);
            label8.TabIndex = 28;
            label8.Text = "监控";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(40, 81);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(520, 174);
            rtbLog.TabIndex = 33;
            rtbLog.Text = "";
            // 
            // AppWatcherUcNew
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rtbLog);
            Controls.Add(btnWatch);
            Controls.Add(tbWatcher);
            Controls.Add(label8);
            Name = "AppWatcherUcNew";
            Size = new Size(588, 396);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnWatch;
        private TextBox tbWatcher;
        private Label label8;
        private RichTextBox rtbLog;
    }
}
