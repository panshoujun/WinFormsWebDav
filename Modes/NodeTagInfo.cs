using WinFormsWebDav.Enums;

namespace WinFormsWebDav.Modes
{
    public class NodeTagInfo
    {
        public NodeTypeEnums NodeType { get; set; }

        public string ProjectName { get; set; }

        public string ProjectId { get; set; }

        public string FullPath { get; set; }

        public string GetFilePath { get { return $"{ProjectId}/{FullPath}"; } }
    }
}
