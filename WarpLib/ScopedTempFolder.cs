using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpLib
{
    public class ScopedTempFolder : IDisposable
    {
        private string _DirectoryPath;

        public string DirectoryPath
        {
            get { return _DirectoryPath; }
        }
        
        public ScopedTempFolder(string namePrefix = "")
        {
            _DirectoryPath = Path.Combine(TempsHelper.AppTempFolder(false), namePrefix + TempsHelper.GetTemporalFilename(""));
            if (!Directory.Exists(_DirectoryPath)) { Directory.CreateDirectory(_DirectoryPath); }
        }

        /// <summary>
        /// A temporal filename within the temporal folder. The file will be deleted with the temporal folder on dispose
        /// </summary>
        /// <param name="extensionWithDot"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string GetTempFile(string extensionWithDot, string prefix = "")
        {
            return Path.Combine(_DirectoryPath, prefix + TempsHelper.GetTemporalFilename(extensionWithDot));
        }

        bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                }
            }
            try
            {
                if (Directory.Exists(_DirectoryPath))
                {
                    Directory.Delete(_DirectoryPath, true);
                }
            }
            catch { }
            //dispose unmanaged resources
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
