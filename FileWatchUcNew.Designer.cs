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
            tbReadOnlyFile = new TextBox();
            btnFileWatch = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(223, 199);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 32;
            label1.Text = "监控路劲";
            // 
            // tbReadOnlyFile
            // 
            tbReadOnlyFile.Location = new Point(338, 193);
            tbReadOnlyFile.Name = "tbReadOnlyFile";
            tbReadOnlyFile.Size = new Size(235, 30);
            tbReadOnlyFile.TabIndex = 30;
            tbReadOnlyFile.Text = "C:\\bugtest";
            // 
            // btnFileWatch
            // 
            btnFileWatch.Location = new Point(338, 242);
            btnFileWatch.Name = "btnFileWatch";
            btnFileWatch.Size = new Size(104, 32);
            btnFileWatch.TabIndex = 29;
            btnFileWatch.Text = "开始监控";
            btnFileWatch.UseVisualStyleBackColor = true;
            btnFileWatch.Click += btnFileWatch_Click;
            // 
            // button1
            // 
            button1.Location = new Point(525, 266);
            button1.Name = "button1";
            button1.Size = new Size(115, 78);
            button1.TabIndex = 33;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FileWatchUcNew
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(tbReadOnlyFile);
            Controls.Add(btnFileWatch);
            Name = "FileWatchUcNew";
            Size = new Size(797, 466);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbReadOnlyFile;
        private Button btnFileWatch;
        private Button button1;
    }
}
