using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWebDav.Modes.Temp
{

    public class Rootobject
    {
        public int code { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
        public long timestamp { get; set; }
    }

    public class Data
    {
        public List<Folder> folders { get; set; }
        public List<File> files { get; set; }
    }

    public class Folder
    {
        public string id { get; set; }
        public string projectId { get; set; }
        public string name { get; set; }
        public string fullPath { get; set; }
        public string parentId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public object projectResponse { get; set; }
    }

    public class File
    {
        public int contentLength { get; set; }
        public int latestVersion { get; set; }
        public bool isLocked { get; set; }
        public string id { get; set; }
        public string projectId { get; set; }
        public string projectName { get; set; }
        public string name { get; set; }
        public string fullPath { get; set; }
        public string parentId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public object projectResponse { get; set; }
    }

}

