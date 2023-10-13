namespace WinFormsWebDav.Modes.Options
{
    /// <summary>
    /// 默认值
    /// </summary>
    public class DefaultInfoOptions
    {
        /// <summary>
        /// 监控进程
        /// </summary>
        public string WatcherProcess { get; set; }
    }

    /// <summary>
    /// 队列默认值
    /// </summary>
    public class DefaultQueueOptions
    {
        /// <summary>
        /// 队列服务器地址  (.本机)
        /// </summary>
        public string ServiceAddress { get; set; }

        /// <summary>
        /// 列队名称
        /// </summary>
        public string QueueName { get; set; }

        /// <summary>
        /// 过期时间 单位秒
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        public string MsgBody { get; set; }
    }
}
