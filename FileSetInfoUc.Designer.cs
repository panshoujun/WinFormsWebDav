﻿namespace WinFormsWebDav
{
    partial class FileSetInfoUc
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
            rtbLog = new RichTextBox();
            splitContainer1 = new SplitContainer();
            btClear = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelReadOnly
            // 
            btnCancelReadOnly.Location = new Point(272, 251);
            btnCancelReadOnly.Name = "btnCancelReadOnly";
            btnCancelReadOnly.Size = new Size(104, 32);
            btnCancelReadOnly.TabIndex = 27;
            btnCancelReadOnly.Text = "取消只读";
            btnCancelReadOnly.UseVisualStyleBackColor = true;
            btnCancelReadOnly.Click += btnCancelReadOnly_Click;
            // 
            // btReadOnlyFile
            // 
            btReadOnlyFile.Location = new Point(132, 37);
            btReadOnlyFile.Multiline = true;
            btReadOnlyFile.Name = "btReadOnlyFile";
            btReadOnlyFile.Size = new Size(244, 30);
            btReadOnlyFile.TabIndex = 26;
            btReadOnlyFile.Text = "Z:\\teslock\\11.dwg";
            // 
            // btnSetReadOnly
            // 
            btnSetReadOnly.Location = new Point(132, 251);
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
            label1.Location = new Point(26, 43);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 28;
            label1.Text = "文件路劲";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(24, 40);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(723, 185);
            rtbLog.TabIndex = 47;
            rtbLog.Text = "";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(18, 17);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnCancelReadOnly);
            splitContainer1.Panel1.Controls.Add(btnSetReadOnly);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(btReadOnlyFile);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btClear);
            splitContainer1.Panel2.Controls.Add(rtbLog);
            splitContainer1.Size = new Size(1200, 400);
            splitContainer1.SplitterDistance = 400;
            splitContainer1.TabIndex = 48;
            // 
            // btClear
            // 
            btClear.Location = new Point(643, 251);
            btClear.Name = "btClear";
            btClear.Size = new Size(104, 32);
            btClear.TabIndex = 48;
            btClear.Text = "清理";
            btClear.UseVisualStyleBackColor = true;
            // 
            // FileSetInfoUc
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "FileSetInfoUc";
            Size = new Size(1234, 436);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancelReadOnly;
        private TextBox btReadOnlyFile;
        private Button btnSetReadOnly;
        private Label label1;
        private RichTextBox rtbLog;
        private SplitContainer splitContainer1;
        private Button btClear;
    }
}
