namespace WinFormsWebDav
{
    partial class MicroSoftMessageQueuingUcNew
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
            tbExpirationTime = new TextBox();
            label11 = new Label();
            tbnReceive = new Button();
            btnSendMessage = new Button();
            rtbMessage = new RichTextBox();
            tbQueueName = new TextBox();
            label10 = new Label();
            tbServiceAddress = new TextBox();
            label9 = new Label();
            btClear = new Button();
            btnGetAllQueue = new Button();
            btnCreateQueue = new Button();
            btnDelete = new Button();
            btnDeleteAll = new Button();
            SuspendLayout();
            // 
            // tbExpirationTime
            // 
            tbExpirationTime.Location = new Point(128, 143);
            tbExpirationTime.Name = "tbExpirationTime";
            tbExpirationTime.Size = new Size(664, 30);
            tbExpirationTime.TabIndex = 45;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(33, 149);
            label11.Name = "label11";
            label11.Size = new Size(82, 24);
            label11.TabIndex = 44;
            label11.Text = "过期时间";
            // 
            // tbnReceive
            // 
            tbnReceive.Location = new Point(158, 448);
            tbnReceive.Name = "tbnReceive";
            tbnReceive.Size = new Size(100, 30);
            tbnReceive.TabIndex = 43;
            tbnReceive.Text = "接收";
            tbnReceive.UseVisualStyleBackColor = true;
            tbnReceive.Click += tbnReceive_Click;
            // 
            // btnSendMessage
            // 
            btnSendMessage.Location = new Point(42, 448);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(100, 30);
            btnSendMessage.TabIndex = 42;
            btnSendMessage.Text = "发送";
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // rtbMessage
            // 
            rtbMessage.Location = new Point(42, 187);
            rtbMessage.Name = "rtbMessage";
            rtbMessage.Size = new Size(750, 215);
            rtbMessage.TabIndex = 41;
            rtbMessage.Text = "";
            // 
            // tbQueueName
            // 
            tbQueueName.Location = new Point(126, 81);
            tbQueueName.Name = "tbQueueName";
            tbQueueName.Size = new Size(666, 30);
            tbQueueName.TabIndex = 40;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(31, 87);
            label10.Name = "label10";
            label10.Size = new Size(64, 24);
            label10.TabIndex = 39;
            label10.Text = "列队名";
            // 
            // tbServiceAddress
            // 
            tbServiceAddress.Location = new Point(126, 30);
            tbServiceAddress.Name = "tbServiceAddress";
            tbServiceAddress.Size = new Size(666, 30);
            tbServiceAddress.TabIndex = 38;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(31, 36);
            label9.Name = "label9";
            label9.Size = new Size(64, 24);
            label9.TabIndex = 37;
            label9.Text = "服务器";
            // 
            // btClear
            // 
            btClear.Location = new Point(688, 448);
            btClear.Name = "btClear";
            btClear.Size = new Size(104, 32);
            btClear.TabIndex = 47;
            btClear.Text = "清理";
            btClear.UseVisualStyleBackColor = true;
            btClear.Click += btClear_Click;
            // 
            // btnGetAllQueue
            // 
            btnGetAllQueue.Location = new Point(370, 448);
            btnGetAllQueue.Name = "btnGetAllQueue";
            btnGetAllQueue.Size = new Size(100, 30);
            btnGetAllQueue.TabIndex = 48;
            btnGetAllQueue.Text = "获取MQ";
            btnGetAllQueue.UseVisualStyleBackColor = true;
            btnGetAllQueue.Click += btnGetAllQueue_Click;
            // 
            // btnCreateQueue
            // 
            btnCreateQueue.Location = new Point(264, 448);
            btnCreateQueue.Name = "btnCreateQueue";
            btnCreateQueue.Size = new Size(100, 30);
            btnCreateQueue.TabIndex = 49;
            btnCreateQueue.Text = "创建MQ";
            btnCreateQueue.UseVisualStyleBackColor = true;
            btnCreateQueue.Click += btnCreateQueue_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(476, 448);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 50;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Location = new Point(582, 448);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(100, 30);
            btnDeleteAll.TabIndex = 51;
            btnDeleteAll.Text = "删除所有";
            btnDeleteAll.UseVisualStyleBackColor = true;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // MicroSoftMessageQueuingUcNew
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDeleteAll);
            Controls.Add(btnDelete);
            Controls.Add(btnCreateQueue);
            Controls.Add(btnGetAllQueue);
            Controls.Add(btClear);
            Controls.Add(tbExpirationTime);
            Controls.Add(label11);
            Controls.Add(tbnReceive);
            Controls.Add(btnSendMessage);
            Controls.Add(rtbMessage);
            Controls.Add(tbQueueName);
            Controls.Add(label10);
            Controls.Add(tbServiceAddress);
            Controls.Add(label9);
            Name = "MicroSoftMessageQueuingUcNew";
            Size = new Size(800, 500);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbExpirationTime;
        private Label label11;
        private Button tbnReceive;
        private Button btnSendMessage;
        private RichTextBox rtbMessage;
        private TextBox tbQueueName;
        private Label label10;
        private TextBox tbServiceAddress;
        private Label label9;
        private Button btClear;
        private Button btnGetAllQueue;
        private Button btnCreateQueue;
        private Button btnDelete;
        private Button btnDeleteAll;
    }
}
