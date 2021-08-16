using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Core.Adstract
{
    public interface IFileInfoModel
    {
        string FileName { get; }
        string ContentType { get; }
    }

    public class FileInfoModel : IFileInfoModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }

    public interface IFileOperationResult<T>
    {
        bool Success { get; }
        T Entity { get; }
        string Message { get; }
        string Path { get; }
        string FileName { get; }
    }

    public class FileOperationResult<T> : IFileOperationResult<T>
    {
        public bool Success { get; set; }
        public T Entity { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
    }
}
