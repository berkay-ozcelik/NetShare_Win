using NetShare_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShare_Win.Utils
{
    public class DownloadManager
    {
        private static DownloadManager _instance;

        private string _downloadPath;

        public string DownloadPath { get => _downloadPath; set => _downloadPath = value; }

        public static DownloadManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DownloadManager();
                }

                return _instance;
            }
        }

        private List<Download> _downloads;
        private List<Progress> _downloadUI;
        public DownloadManager()
        {   
            _downloadUI = new List<Progress>();
            _downloads = new List<Download>();
            _downloadPath = "./Downloads";
        }

        public void AddDownload(Download download,Progress UI)
        {
            _downloads.Add(download);
            _downloadUI.Add(UI);
        }

        public Tuple<Download,Progress> GetDownload(int idx)
        {
            return new Tuple<Download, Progress>(_downloads[idx], _downloadUI[idx]);
        }

        public Download[] GetAllDownloads()
        {
            return _downloads.ToArray();
        }



    }
}
