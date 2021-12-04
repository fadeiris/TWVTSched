using System.Diagnostics;
using System.Reflection;

namespace TWVTSched;

public partial class MainForm : Form
{
    private static HttpClient? _httpClient;

    public MainForm(IHttpClientFactory httpClientFactory)
    {
        InitializeComponent();

        _httpClient = httpClientFactory.CreateClient();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        DGVDataList.InvokeIfRequired(() =>
        {
            // 設為 false 以避免欄位的排序亂掉。
            DGVDataList.AutoGenerateColumns = false;

            // 來源：https://10tec.com/articles/why-datagridview-slow.aspx
            // Double buffering can make DGV slow in remote desktop.
            if (!SystemInformation.TerminalServerSession)
            {
                Type type = DGVDataList.GetType();

                PropertyInfo? propertyInfo = type.GetProperty(
                    "DoubleBuffered",
                    BindingFlags.Instance | BindingFlags.NonPublic);

                propertyInfo?.SetValue(DGVDataList, true, null);
            }
        });

        // 在啟動程式時，自動執行一次。
        BtnGetData_Click(this, null);
    }

    private void DGVDataList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex != -1)
        {
            string[] keySet = { "VideoThumbnailUrl", "PlatformIconUrl" };

            DataGridViewColumn currentColumn = DGVDataList.Columns[e.ColumnIndex];

            if (currentColumn != null)
            {
                if (keySet.Contains(currentColumn.Name))
                {
                    if (CBShowImage.Checked)
                    {
                        string? imageUrl = e.Value?.ToString();

                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            Image? image = CustomFunction.GetImageFromUrl(imageUrl);

                            e.Value = image;
                        }
                        else
                        {
                            e.Value = null;
                        }
                    }
                    else
                    {
                        e.Value = null;
                    }
                }
            }
        }
    }

    private void DGVDataList_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex != -1 && e.ColumnIndex != -1)
        {
            string[] keySet = { "ChannelUrl", "VideoUrl", "VideoThumbnailUrl" };

            DataGridViewColumn currentColumn = DGVDataList.Columns[e.ColumnIndex];

            if (currentColumn != null)
            {
                if (keySet.Contains(currentColumn.Name))
                {
                    DataGridViewCell currentCell = DGVDataList.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    if (currentCell != null)
                    {
                        string? strUrl = currentCell.Value?.ToString();

                        if (!string.IsNullOrEmpty(strUrl))
                        {
                            if (currentColumn.Name == "VideoThumbnailUrl")
                            {
                                using Form tempForm = new();

                                Image? tempImage = CustomFunction.GetImageFromUrl(strUrl);

                                if (tempImage != null)
                                {
                                    tempForm.Icon = Properties.Resources.app_icon;
                                    tempForm.Text = "影片封面";
                                    tempForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                                    tempForm.MaximizeBox = false;
                                    tempForm.StartPosition = FormStartPosition.CenterScreen;
                                        
                                    tempForm.ClientSize = tempImage.Size;

                                    PictureBox pictureBox = new();

                                    pictureBox.Dock = DockStyle.Fill;
                                    pictureBox.Image = tempImage;

                                    tempForm.Controls.Add(pictureBox);
                                    tempForm.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("無法載入影片封面，可能此影片已轉成私人影片或是已被刪除。", Text);
                                }
                            }
                            else if (currentColumn.Name == "ChannelUrl")
                            {
                                DialogResult dialogResult = MessageBox.Show(
                                    "您確定要開啟此 VTuber 的頻道的連接網址嗎？",
                                    Text,
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question);

                                if (dialogResult == DialogResult.OK)
                                {
                                    CustomFunction.OpenBrowser(strUrl);
                                }
                            }
                            else
                            {
                                CustomFunction.OpenBrowser(strUrl);
                            }
                        }
                    }
                }
            }
        }
    }

    private async void BtnGetData_Click(object sender, EventArgs? e)
    {
        try 
        {
            List<POCO.ScheduleData> dataSet = await CustomFunction
                .DownloadHtml(_httpClient!, CBEnableTimeFilter.Checked);

            DGVDataList.InvokeIfRequired(() =>
            {
                BindingSource bindingSource = new()
                {
                    DataSource = dataSet
                };

                DGVDataList.DataSource = bindingSource;
            });

            if (dataSet.Count <= 0)
            {
                MessageBox.Show("目前無節目資料。", Text);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());

            MessageBox.Show(ex.Message, Text);
        }
    }

    private void LLWebSiteUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (!string.IsNullOrEmpty(LLWebSiteUrl.Text))
        {
            CustomFunction.OpenBrowser(LLWebSiteUrl.Text);
        }
    }
}