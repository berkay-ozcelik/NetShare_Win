using NetShare_Core.Entity;
using NetShare_Win.Communicator;
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
    public partial class ManageFiles : Form
    {
        public ManageFiles()
        {
            InitializeComponent();
            InitListBox();
        }

        private void InitListBox()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Name", (int)(listView1.Width * 0.60));
            listView1.Columns.Add("Size (MB)", (int)(listView1.Width * 0.40));
            RefreshListBox();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pick file dialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            //If not selected
            if (string.IsNullOrEmpty(ofd.FileName))
            {
                return;
            }

            //Get selected file path
            string filePath = ofd.FileName;

            //Send request to share file

            CommandRequest request = new CommandRequest()
            {
                CommandName = "ShareFile",
                Parameter = filePath
            };

            CommandResult result = Requestor.GetInstance().SendAndReceive(request);

            if (result.Type == CommandResult.ResultType.Success)
            {

                RefreshListBox();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }


        }

        private void RefreshListBox()
        {
            listView1.Items.Clear();
            //Send request to get file list
            CommandRequest request = new CommandRequest()
            {
                CommandName = "GetSharingFilesOfCurrentDevice",
                Parameter = string.Empty
            };

            CommandResult result = Requestor.GetInstance().SendAndReceive(request);

            if (result.Type == CommandResult.ResultType.Success)
            {
                SharingFile[] files = JsonSerializer.Deserialize<SharingFile[]>(result.Message);

                foreach (var file in files)
                {
                    //Convert file size to MB with 2 decimal places

                    string fileSize = (file.FileSize / 1024 / 1024).ToString("0.00");

                    string[] row = { file.FileName, fileSize };
                    listView1.Items.Add(new ListViewItem(row));
                }
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index;
            try
            {
                index = listView1.FocusedItem.Index;
            }
            catch
            {
                MessageBox.Show("Please select a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Send request to unshare file

            CommandRequest request = new CommandRequest()
            {
                CommandName = "StopShareFile",
                Parameter = index.ToString()
            };

            CommandResult result = Requestor.GetInstance().SendAndReceive(request);

            if (result.Type == CommandResult.ResultType.Success)
            {
                RefreshListBox();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
