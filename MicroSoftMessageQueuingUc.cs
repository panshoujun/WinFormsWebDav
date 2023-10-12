using MSMQ.Messaging;

namespace WinFormsWebDav
{
    public partial class MicroSoftMessageQueuingUc : UserControl
    {
        //FormatName:DIRECT=OS:panshoujun\private$\fff
        //string publicMQPath = "FormatName:Direct=TCP:192.168.0.110\\private$\\DESKTOP-2AEJ0GU";
        public MicroSoftMessageQueuingUc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取列队连接字符串
        /// </summary>
        /// <returns></returns>
        private string GetQueueConnection()
        {
            return $"{GetQueueServiceAddress()}\\{GetQueueName()}";
        }

        /// <summary>
        /// 获取列队名称
        /// </summary>
        /// <returns></returns>
        private string GetQueueName()
        {
            return $"{tbQueueName.Text}";
        }

        /// <summary>
        /// 获取服务器地址
        /// </summary>
        /// <returns></returns>
        private string GetQueueServiceAddress()
        {
            if (tbServiceAddress.Text.Equals("."))
            {
                return System.Net.Dns.GetHostName();
            }
            return $"{tbServiceAddress.Text}";
        }

        /// <summary>
        /// 是否是本机
        /// </summary>
        /// <returns></returns>
        private bool IsLocalhost()
        {
            return GetQueueServiceAddress().Equals(".") || GetQueueServiceAddress().Equals(System.Net.Dns.GetHostName(), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMessage(string msg)
        {
            //MessageBox.Show(msg);
            rtbLog.Text += $"{msg}\n";
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string queue = GetQueueConnection();
            try
            {
                if (!MessageQueue.Exists(queue))
                {
                    ShowMessage($"队列:{rtbMessage.Text}不存在,请先创建");
                    return;
                }

                using var mqSend = new MessageQueue(queue);
                using var msg = new MSMQ.Messaging.Message(rtbMessage.Text, new XmlMessageFormatter(new Type[] { typeof(string) }));
                if (int.TryParse(tbExpirationTime.Text, out int time) && time > 0)
                {
                    msg.TimeToBeReceived = TimeSpan.FromSeconds(time);
                }
                if (mqSend.Transactional)
                {
                    using var msgTransaction = new MessageQueueTransaction();
                    msgTransaction.Begin();
                    mqSend.Send(msg, msgTransaction);
                    msgTransaction.Commit();
                }
                else
                {
                    mqSend.Send(msg);
                }
                ShowMessage($"发送成功:{rtbMessage.Text}");
            }
            catch (Exception ex)
            {

                ShowMessage(ex.Message);
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnReceive_Click(object sender, EventArgs e)
        {
            string queue = $"{GetQueueServiceAddress()}\\{GetQueueName()}";
            using var mqReceive = new MessageQueue(queue)
            {
                Formatter = new XmlMessageFormatter(new Type[] { typeof(string) })
            };

            var msgs = mqReceive.GetAllMessages();
            if (msgs.Any())
            {
                var msg = mqReceive.Receive();
                var bodyReceive = msg.Body as string;
                ShowMessage($"接收消息:{bodyReceive}");
            }
            else
            {
                ShowMessage($"列队:{GetQueueName()}无消息");
            }
        }

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = string.Empty;
        }

        /// <summary>
        /// 获取队列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAllQueue_Click(object sender, EventArgs e)
        {
            //获取服务端计算机名称
            string machineName = GetQueueServiceAddress();

            //所有列队
            var list = MessageQueue.GetPublicQueues()?.ToList();
            if (!string.IsNullOrEmpty(machineName))
            {
                list = list?.Where(p => p.MachineName.Equals(machineName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ShowMessage($"获取以下队列:");
            if (IsLocalhost())
            {
                var listPrivate = MessageQueue.GetPrivateQueuesByMachine(machineName)?.ToList();
                listPrivate?.ForEach(x =>
                {
                    ShowMessage($"队列:{x.QueueName},路劲{x.Path}");
                });
            }
            list?.ForEach(x =>
            {
                ShowMessage($"队列:{x.QueueName},路劲{x.Path}");
            });
        }

        /// <summary>
        /// 创建列队
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateQueue_Click(object sender, EventArgs e)
        {
            string queue = GetQueueConnection();
            if (!MessageQueue.Exists(queue))
            {
                using var msmq = MessageQueue.Create(queue, true);
                ShowMessage($"队列:{GetQueueName()}创建成功");
            }
            else
            {
                ShowMessage($"队列:{GetQueueName()}已存在");
            }
        }

        /// <summary>
        /// 删除队列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string queue = GetQueueConnection();
            if (MessageQueue.Exists(queue))
            {
                MessageQueue.Delete(queue);
                ShowMessage($"队列:{GetQueueName()}删除成功");
            }
            else
            {
                ShowMessage($"队列:{GetQueueName()}不存在");
            }
        }

        /// <summary>
        /// 删除所有列队
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            string serviceAddress = GetQueueServiceAddress();

            ShowMessage($"删除以下队列:");

            //删除共有队列
            var list = MessageQueue.GetPublicQueues()?.ToList();
            if (!string.IsNullOrEmpty(serviceAddress))
            {
                list = list?.Where(p => p.MachineName.Equals(serviceAddress, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            list?.ForEach(x =>
            {
                MessageQueue.Delete($"{serviceAddress}\\{x.QueueName}");
                ShowMessage($"已删除队列:{x.QueueName}");
            });

            //如果是本地 私有也删除
            if (IsLocalhost())
            {
                var listPrivate = MessageQueue.GetPrivateQueuesByMachine(serviceAddress)?.ToList();
                listPrivate?.ForEach(x =>
                {
                    MessageQueue.Delete($"{serviceAddress}\\{x.QueueName}");
                    ShowMessage($"已删除队列:{x.QueueName}");
                });
            }
        }
    }
}
