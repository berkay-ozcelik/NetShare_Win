using NetShare_Core.Entity;
using NetShare_Win.Communicator;
using NetShare_Win.Utils;
using System.Text.Json;

namespace NetShare_Win
{
    public partial class NetShareForm : Form
    {
        public NetShareForm()
        {
            InitializeComponent();
            InitListView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ManageFiles().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Show folder browser dialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

            //If not selected
            if (string.IsNullOrEmpty(fbd.SelectedPath))
            {
                return;
            }

            //Get selected folder path
            string folderPath = fbd.SelectedPath;

            //Send request to share folder

            CommandRequest request = new CommandRequest()
            {
                CommandName = "SetDownloadDirectory",
                Parameter = folderPath
            };

            CommandResult result = Requestor.GetInstance().SendAndReceive(request);

            if (result.Type == CommandResult.ResultType.Success)
            {
                MessageBox.Show("Download directory set successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DownloadManager.Instance.DownloadPath = folderPath;
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CommandRequest request = new CommandRequest()
            {
                CommandName = "DiscoverDevices",
                Parameter = string.Empty
            };

            listView1.Items.Clear();
            //Set mause cursor to wait cursor
            Cursor.Current = Cursors.WaitCursor;

            CommandResult result = Requestor.GetInstance().SendAndReceive(request);

            if (result.Type == CommandResult.ResultType.Success)
            {
                DeviceInfo[] devices = JsonSerializer.Deserialize<DeviceInfo[]>(result.Message);

                foreach (var device in devices)
                {
                    string[] row = { device.DeviceName, device.EndPoint, device.DeviceOS };
                    listView1.Items.Add(new ListViewItem(row));
                }

            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Normal cursor
            Cursor.Current = Cursors.Default;

        }

        private void InitListView()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Name", (int)(listView1.Width * 0.40));
            listView1.Columns.Add("Endpoint", (int)(listView1.Width * 0.60));
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected index
            int index = listView1.FocusedItem.Index;

            CommandRequest request = new CommandRequest()
            {
                CommandName = "SelectDevice",
                Parameter = index.ToString()
            };

            CommandResult result = Requestor.GetInstance().SendAndReceive(request);

            if (result.Type == CommandResult.ResultType.Error)
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NetShareForm_Load(object sender, EventArgs e)
        {
            CommandRequest commandRequest = new CommandRequest()
            {
                CommandName = "StartAcceptor",
                Parameter = string.Empty
            };

            CommandResult result = Requestor.GetInstance().SendAndReceive(commandRequest);

            if (result.Type == CommandResult.ResultType.Error)
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label3.Text = "Not Connected";
                label3.ForeColor = Color.Red;
            }
            else
            {
                label3.Text = "Connected";
                label3.ForeColor = Color.Green;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index;
            try
            {
                index = listView1.FocusedItem.Index;
            }
            catch
            {
                MessageBox.Show("Please select a device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Get device name, os values from selected item
            string deviceName = listView1.Items[index].SubItems[0].Text;
            string deviceOS = listView1.Items[index].SubItems[2].Text;


            new FileList(deviceName, deviceOS, index).ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Downloads().ShowDialog();
        }
    }
}