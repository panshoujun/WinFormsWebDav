using WinFormsWebDav.Enums;

namespace WinFormsWebDav.Modes
{
    public class MessageEventArgs : EventArgs
    {
        public string Msg { get; set; }

        public ShowMessageTypeEnums MessageType { get; set; } = ShowMessageTypeEnums.LogTxt;
    }
}
