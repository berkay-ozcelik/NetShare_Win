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
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetShare_Win
{
    public partial class Downloads : Form
    {
        public Downloads()
        {
            InitializeComponent();
            InitListBox();

        }

        private void InitListBox()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Name", (int)(listView1.Width * 0.50));
            listView1.Columns.Add("Size (MB)", (int)(listView1.Width * 0.25));
            listView1.Columns.Add("Status", (int)(listView1.Width * 0.25));
            UpdateListBox();

        }

        private void UpdateListBox()
        {
            listView1.Items.Clear();

            Download[] downloads = DownloadManager.Instance.GetAllDownloads();

            foreach (var download in downloads)
            {

                var file = download.File;

                string fileSize = (file.FileSize / 1024 / 1024).ToString("0.00");

                string status = "Active";

                if (download.IsCompleted)
                {
                    status = "Completed";
                }

                if (download.IsCanceled)
                {
                    status = "Canceled";
                }

                if (download.IsFailed)
                {
                    status = "Failed";
                }


                string[] row = { file.FileName, fileSize, status };

                listView1.Items.Add(new ListViewItem(row));
            }


        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get selected item index from listview
            int selectedIdx = listView1.FocusedItem.Index;

            //Get selected download
            Tuple<Download, Progress> tuple = DownloadManager.Instance.GetDownload(selectedIdx);

            //Get download
            Download download = tuple.Item1;

            //Get download form
            Progress downloadForm = tuple.Item2;

            if (download.IsActive)
            {
                downloadForm.IsHide = false;
                downloadForm.Show();
            }
            else
                MessageBox.Show("Download is not active", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void Downloads_Load(object sender, EventArgs e)
        {

        }
    }
}
