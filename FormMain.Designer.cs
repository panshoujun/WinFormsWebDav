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
            btnCheckAllFile = new Button();
            btnClear = new Button();
            rtbLog = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
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
            splitContainer1.Panel2.Controls.Add(btnCheckAllFile);
            splitContainer1.Panel2.Controls.Add(btnClear);
            splitContainer1.Panel2.Controls.Add(rtbLog);
            splitContainer1.Size = new Size(1478, 744);
            splitContainer1.SplitterDistance = 858;
            splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbWebdav);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(858, 744);
            tabControl1.TabIndex = 0;
            // 
            // tbWebdav
            // 
            tbWebdav.Location = new Point(4, 33);
            tbWebdav.Name = "tbWebdav";
            tbWebdav.Padding = new Padding(3);
            tbWebdav.Size = new Size(850, 707);
            tbWebdav.TabIndex = 0;
            tbWebdav.Text = "WebDav";
            tbWebdav.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(850, 707);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCheckAllFile
            // 
            btnCheckAllFile.Location = new Point(38, 657);
            btnCheckAllFile.Name = "btnCheckAllFile";
            btnCheckAllFile.Size = new Size(133, 51);
            btnCheckAllFile.TabIndex = 2;
            btnCheckAllFile.Text = "检查文件";
            btnCheckAllFile.UseVisualStyleBackColor = true;
            btnCheckAllFile.Click += btnCheckAllFile_ClickAsync;
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
            rtbLog.Size = new Size(552, 566);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1478, 744);
            Controls.Add(splitContainer1);
            Name = "FormMain";
            Text = "FormMain";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tbWebdav;
        private TabPage tabPage2;
        private Button btnClear;
        private RichTextBox rtbLog;
        private Button btnCheckAllFile;
    }
}