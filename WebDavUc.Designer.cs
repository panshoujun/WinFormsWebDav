namespace WinFormsWebDav
{
    partial class WebDavUc
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
            btGetWebDavList = new Button();
            label5 = new Label();
            cbDriveLetter = new ComboBox();
            btUnMountWebDav = new Button();
            cbIsAutoClose = new ComboBox();
            label4 = new Label();
            rtbPath = new RichTextBox();
            label3 = new Label();
            tbPassword = new TextBox();
            label2 = new Label();
            tbUserName = new TextBox();
            label1 = new Label();
            btMountWebdav = new Button();
            SuspendLayout();
            // 
            // btGetWebDavList
            // 
            btGetWebDavList.Location = new Point(434, 492);
            btGetWebDavList.Name = "btGetWebDavList";
            btGetWebDavList.Size = new Size(137, 32);
            btGetWebDavList.TabIndex = 30;
            btGetWebDavList.Text = "获取挂载列表";
            btGetWebDavList.UseVisualStyleBackColor = true;
            btGetWebDavList.Click += btGetWebDavList_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(74, 224);
            label5.Name = "label5";
            label5.Size = new Size(46, 24);
            label5.TabIndex = 28;
            label5.Text = "盘符";
            // 
            // cbDriveLetter
            // 
            cbDriveLetter.FormattingEnabled = true;
            cbDriveLetter.Location = new Point(169, 221);
            cbDriveLetter.Name = "cbDriveLetter";
            cbDriveLetter.Size = new Size(400, 32);
            cbDriveLetter.TabIndex = 27;
            // 
            // btUnMountWebDav
            // 
            btUnMountWebDav.Location = new Point(169, 492);
            btUnMountWebDav.Name = "btUnMountWebDav";
            btUnMountWebDav.Size = new Size(104, 32);
            btUnMountWebDav.TabIndex = 26;
            btUnMountWebDav.Text = "解挂";
            btUnMountWebDav.UseVisualStyleBackColor = true;
            btUnMountWebDav.Click += btUnMountWebDav_Click;
            // 
            // cbIsAutoClose
            // 
            cbIsAutoClose.FormattingEnabled = true;
            cbIsAutoClose.Items.AddRange(new object[] { "否", "是" });
            cbIsAutoClose.Location = new Point(171, 34);
            cbIsAutoClose.Name = "cbIsAutoClose";
            cbIsAutoClose.Size = new Size(400, 32);
            cbIsAutoClose.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 36);
            label4.Name = "label4";
            label4.Size = new Size(118, 24);
            label4.TabIndex = 24;
            label4.Text = "是否自动关闭";
            // 
            // rtbPath
            // 
            rtbPath.Location = new Point(169, 307);
            rtbPath.Name = "rtbPath";
            rtbPath.Size = new Size(400, 150);
            rtbPath.TabIndex = 22;
            rtbPath.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 307);
            label3.Name = "label3";
            label3.Size = new Size(46, 24);
            label3.TabIndex = 21;
            label3.Text = "路径";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(169, 149);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(400, 30);
            tbPassword.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 155);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 19;
            label2.Text = "密码";
            // 
            // tbUserName
            // 
            tbUserName.Location = new Point(169, 81);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(400, 30);
            tbUserName.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 87);
            label1.Name = "label1";
            label1.Size = new Size(46, 24);
            label1.TabIndex = 17;
            label1.Text = "账号";
            // 
            // btMountWebdav
            // 
            btMountWebdav.Location = new Point(300, 492);
            btMountWebdav.Name = "btMountWebdav";
            btMountWebdav.Size = new Size(104, 32);
            btMountWebdav.TabIndex = 16;
            btMountWebdav.Text = "挂载";
            btMountWebdav.UseVisualStyleBackColor = true;
            btMountWebdav.Click += btMountWebdav_Click;
            // 
            // WebDavUc
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btGetWebDavList);
            Controls.Add(label5);
            Controls.Add(cbDriveLetter);
            Controls.Add(btUnMountWebDav);
            Controls.Add(cbIsAutoClose);
            Controls.Add(label4);
            Controls.Add(rtbPath);
            Controls.Add(label3);
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(tbUserName);
            Controls.Add(label1);
            Controls.Add(btMountWebdav);
            Name = "WebDavUc";
            Size = new Size(650, 550);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btGetWebDavList;
        private Label label5;
        private ComboBox cbDriveLetter;
        private Button btUnMountWebDav;
        private ComboBox cbIsAutoClose;
        private Label label4;
        private RichTextBox rtbPath;
        private Label label3;
        private TextBox tbPassword;
        private Label label2;
        private TextBox tbUserName;
        private Label label1;
        private Button btMountWebdav;
    }
}
