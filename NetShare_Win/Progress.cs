using NetShare_Core.Entity;
using NetShare_Win.Communicator;
using NetShare_Win.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetShare_Win
{
    public partial class Progress : Form
    {
        private Download download;
        private bool isCanceled = false;
        private bool isFailed = false;
        private bool isCompleted = false;
        private bool isHide = false;



        public Progress(Download d)
        {
            InitializeComponent();
            download = d;
            label2.Text = "0%";
            label1.Text = d.File.FileName;
        }

        private void Progress_Load(object sender, EventArgs e)
        {

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(DoWork);

            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);
            worker.RunWorkerAsync();

        }

        private static void WatchDownload(Download d)
        {
            while (true)
            {
                Tuple<int, SharingFile, int, bool, bool, bool> observeResult = d.Observe();

                int progress = observeResult.Item3;
                bool isCompleted = observeResult.Item6;
                bool isCanceled = observeResult.Item4;
                bool isFailed = observeResult.Item5;

                if (isCanceled)
                {
                    MessageBox.Show("Download canceled: " + d.File.FileName, "Download canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (isFailed)
                {
                    MessageBox.Show("Download failed: " + d.File.FileName, "Download failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isCompleted)
                {
                    MessageBox.Show("Download completed: " + d.File.FileName, "Download completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Thread.Sleep(300);

            }
        }

        private void CompletedWork(object? sender, RunWorkerCompletedEventArgs e)
        {

            if (isCanceled)
            {
                MessageBox.Show("Download canceled: " + download.File.FileName, "Download canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (isFailed)
            {
                MessageBox.Show("Download failed: " + download.File.FileName, "Download failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Download completed: " + download.File.FileName, "Download completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Tuple<int, SharingFile, int, bool, bool, bool> observeResult = download.Observe();

                int progress = observeResult.Item3;
                isCompleted = observeResult.Item6;
                isCanceled = observeResult.Item4;
                isFailed = observeResult.Item5;

                if (isCanceled)
                {
                    return;
                }

                if (isFailed)
                {
                    return;
                }

                if (isCompleted && isHide)
                {
                    return;
                }


                Thread.Sleep(300);

                if (isHide)
                    continue;

                progressBar1.Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Value = progress;
                    label2.Text = progress + "%";
                }));

                if (isCompleted)
                {
                    return;
                }




            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            download.IsCanceled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            isHide = true;
            Hide();
        }

        public bool IsHide
        {
            get { return isHide; }

            set { isHide = value; }


        }
    }
}
