using NetShare_Core.Entity;
using NetShare_Win.Communicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShare_Win.Utils
{

    public class Download
    {
        private int _fileIdx;
        private SharingFile _file;
        private int _progress;
        private bool _isCanceled;
        private int _downloadID;
        private bool _isFailed;



        public Download(int idx, SharingFile file)
        {

            _fileIdx = idx;
            _file = file;
            _progress = 0;
            _isCanceled = false;
            _isFailed = false;
            _downloadID = -1;

        }

        public void Start()
        {

            CommandRequest request = new CommandRequest()
            {
                CommandName = "StartDownload",
                Parameter = _fileIdx.ToString()
            };

            CommandResult result = Requestor.GetInstance().SendAndReceive(request);

            if (result.Type == CommandResult.ResultType.Success)
            {
                _downloadID = int.Parse(result.Message);
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public bool IsActive
        {
            get
            {
                if (IsCanceled)
                    return false;

                if (IsFailed)
                    return false;

                if (IsCompleted)
                    return false;

                return true;

            }
        }

        public int Id { get => _downloadID; }

        public bool IsFailed { get => _isFailed; }
        public SharingFile File { get => _file; }

        public int Progress
        {
            get
            {

                if (IsCanceled)
                    return _progress;

                if (IsFailed)
                    return _progress;

                CommandRequest request = new CommandRequest()
                {
                    CommandName = "GetDownloadProgress",
                    Parameter = _downloadID.ToString()
                };

                CommandResult result = Requestor.GetInstance().SendAndReceive(request);

                if (result.Type == CommandResult.ResultType.Success)
                {
                    _progress = int.Parse(result.Message);
                    return _progress;
                }
                else
                {
                    _isFailed = true;
                    return _progress;
                }
            }
        }

        public bool IsCanceled
        {
            get => _isCanceled;

            set
            {
                if (value)
                {
                    CommandRequest request = new CommandRequest()
                    {
                        CommandName = "StopDownload",
                        Parameter = _downloadID.ToString()
                    };

                    CommandResult result = Requestor.GetInstance().SendAndReceive(request);

                    if (result.Type == CommandResult.ResultType.Success)
                    {
                        _isCanceled = true;
                    }
                    else
                    {
                        throw new Exception(result.Message);
                    }
                }

            }
        }

        public bool IsCompleted { get => Progress == 100 & !_isCanceled; }

        // Returns ID, File, Progress,Canceled,Failed,Completed
        public Tuple<int, SharingFile, int, bool, bool, bool> Observe()
        {
            int id = _fileIdx;
            SharingFile file = _file;
            int progress = Progress;
            bool canceled = _isCanceled;
            bool completed = IsCompleted;
            bool failed = IsFailed;
            return new Tuple<int, SharingFile, int, bool, bool, bool>(id, file, progress, canceled, failed, completed);
        }

    }
}
