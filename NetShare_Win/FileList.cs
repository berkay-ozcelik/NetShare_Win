using NetShare_Core.Entity;
using NetShare_Win.Communicator;
using NetShare_Win.Utils;
using System.Text.Json;


namespace NetShare_Win
{
    public partial class FileList : Form
    {

        private int _selectedIdx;
        private SharingFile[] files;
        public FileList(string deviceName, string deviceOS, int selectedIdx)
        {
            InitializeComponent();
            label2.Text = deviceName;
            label4.Text = deviceOS;
            _selectedIdx = selectedIdx;
            InitListBox();
        }

        private void InitListBox()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Name", (int)(listView1.Width * 0.60));
            listView1.Columns.Add("Size (MB)", (int)(listView1.Width * 0.40));
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            listView1.Items.Clear();
            //Send request to get file list
            CommandRequest request = new CommandRequest()
            {
                CommandName = "GetSharingFiles",
                Parameter = _selectedIdx.ToString()
            };

            CommandResult result = Requestor.GetInstance().SendAndReceive(request);

            if (result.Type == CommandResult.ResultType.Success)
            {
                files = JsonSerializer.Deserialize<SharingFile[]>(result.Message);

                foreach (var file in files)
                {

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

        private void FileList_Load(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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

            //Send request to select file
            CommandRequest request = new CommandRequest()
            {
                CommandName = "SelectFile",
                Parameter = index.ToString()
            };

            CommandResult result = Requestor.GetInstance().SendAndReceive(request);

            if (result.Type != CommandResult.ResultType.Success)
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void button1_Click(object sender, EventArgs e)
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

            SharingFile sharingFile = files[index];

            Download download = new Download(index, sharingFile);
        RESTART:
            try
            {
                download.Start();
            }
            catch (Exception ex)
            {
                if (ex.Message == "File already exists.")
                {
                    DialogResult dialogResult = MessageBox.Show("File already exists. Do you want to overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var filePath = Path.Combine(DownloadManager.Instance.DownloadPath, sharingFile.FileName);
                        File.Delete(filePath);
                        goto RESTART;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            Progress form = new Progress(download);
            DownloadManager.Instance.AddDownload(download, form);

            form.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
