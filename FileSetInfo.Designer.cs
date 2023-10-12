namespace WinFormsWebDav
{
    partial class FileSetInfo
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
            btnCancelReadOnly = new Button();
            btReadOnlyFile = new TextBox();
            btnSetReadOnly = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCancelReadOnly
            // 
            btnCancelReadOnly.Location = new Point(286, 112);
            btnCancelReadOnly.Name = "btnCancelReadOnly";
            btnCancelReadOnly.Size = new Size(104, 32);
            btnCancelReadOnly.TabIndex = 27;
            btnCancelReadOnly.Text = "取消只读";
            btnCancelReadOnly.UseVisualStyleBackColor = true;
            btnCancelReadOnly.Click += btnCancelReadOnly_Click;
            // 
            // btReadOnlyFile
            // 
            btReadOnlyFile.Location = new Point(155, 63);
            btReadOnlyFile.Name = "btReadOnlyFile";
            btReadOnlyFile.Size = new Size(235, 30);
            btReadOnlyFile.TabIndex = 26;
            btReadOnlyFile.Text = "Z:\\teslock\\11.dwg";
            // 
            // btnSetReadOnly
            // 
            btnSetReadOnly.Location = new Point(155, 112);
            btnSetReadOnly.Name = "btnSetReadOnly";
            btnSetReadOnly.Size = new Size(104, 32);
            btnSetReadOnly.TabIndex = 25;
            btnSetReadOnly.Text = "设置只读";
            btnSetReadOnly.UseVisualStyleBackColor = true;
            btnSetReadOnly.Click += btnSetReadOnly_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 69);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 28;
            label1.Text = "文件路劲";
            // 
            // FileSetInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(btnCancelReadOnly);
            Controls.Add(btReadOnlyFile);
            Controls.Add(btnSetReadOnly);
            Name = "FileSetInfo";
            Size = new Size(443, 193);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelReadOnly;
        private TextBox btReadOnlyFile;
        private Button btnSetReadOnly;
        private Label label1;
    }
}
