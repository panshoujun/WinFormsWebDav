namespace WinFormsWebDav
{
    partial class FileSetInfoUcNew
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
            btnSetReadOnly = new Button();
            label1 = new Label();
            btReadOnlyFile = new TextBox();
            SuspendLayout();
            // 
            // btnCancelReadOnly
            // 
            btnCancelReadOnly.Location = new Point(470, 270);
            btnCancelReadOnly.Name = "btnCancelReadOnly";
            btnCancelReadOnly.Size = new Size(104, 32);
            btnCancelReadOnly.TabIndex = 31;
            btnCancelReadOnly.Text = "取消只读";
            btnCancelReadOnly.UseVisualStyleBackColor = true;
            btnCancelReadOnly.Click += btnCancelReadOnly_Click;
            // 
            // btnSetReadOnly
            // 
            btnSetReadOnly.Location = new Point(330, 270);
            btnSetReadOnly.Name = "btnSetReadOnly";
            btnSetReadOnly.Size = new Size(104, 32);
            btnSetReadOnly.TabIndex = 29;
            btnSetReadOnly.Text = "设置只读";
            btnSetReadOnly.UseVisualStyleBackColor = true;
            btnSetReadOnly.Click += btnSetReadOnly_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 65);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 32;
            label1.Text = "文件路劲";
            // 
            // btReadOnlyFile
            // 
            btReadOnlyFile.Location = new Point(194, 59);
            btReadOnlyFile.Multiline = true;
            btReadOnlyFile.Name = "btReadOnlyFile";
            btReadOnlyFile.Size = new Size(380, 30);
            btReadOnlyFile.TabIndex = 30;
            btReadOnlyFile.Text = "Z:\\teslock\\11.dwg";
            // 
            // FileSetInfoUcNew
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCancelReadOnly);
            Controls.Add(btnSetReadOnly);
            Controls.Add(label1);
            Controls.Add(btReadOnlyFile);
            Name = "FileSetInfoUcNew";
            Size = new Size(700, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelReadOnly;
        private Button btnSetReadOnly;
        private Label label1;
        private TextBox btReadOnlyFile;
    }
}
