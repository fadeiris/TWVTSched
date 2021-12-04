
namespace TWVTSched
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BtnGetData = new System.Windows.Forms.Button();
            this.CBEnableTimeFilter = new System.Windows.Forms.CheckBox();
            this.CBShowImage = new System.Windows.Forms.CheckBox();
            this.DGVDataList = new System.Windows.Forms.DataGridView();
            this.GBOperationSet = new System.Windows.Forms.GroupBox();
            this.LSourceFrom = new System.Windows.Forms.Label();
            this.LLWebSiteUrl = new System.Windows.Forms.LinkLabel();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VTuberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoThumbnailUrl = new System.Windows.Forms.DataGridViewImageColumn();
            this.VideoUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PlatformIconUrl = new System.Windows.Forms.DataGridViewImageColumn();
            this.ChannelUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.StrCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDataList)).BeginInit();
            this.GBOperationSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGetData
            // 
            this.BtnGetData.Location = new System.Drawing.Point(8, 25);
            this.BtnGetData.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGetData.Name = "BtnGetData";
            this.BtnGetData.Size = new System.Drawing.Size(96, 29);
            this.BtnGetData.TabIndex = 1;
            this.BtnGetData.Text = "取得節目表";
            this.BtnGetData.UseVisualStyleBackColor = true;
            this.BtnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // CBEnableTimeFilter
            // 
            this.CBEnableTimeFilter.AutoSize = true;
            this.CBEnableTimeFilter.Checked = true;
            this.CBEnableTimeFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBEnableTimeFilter.Location = new System.Drawing.Point(8, 62);
            this.CBEnableTimeFilter.Margin = new System.Windows.Forms.Padding(4);
            this.CBEnableTimeFilter.Name = "CBEnableTimeFilter";
            this.CBEnableTimeFilter.Size = new System.Drawing.Size(91, 23);
            this.CBEnableTimeFilter.TabIndex = 2;
            this.CBEnableTimeFilter.Text = "時間過濾";
            this.CBEnableTimeFilter.UseVisualStyleBackColor = true;
            // 
            // CBShowImage
            // 
            this.CBShowImage.AutoSize = true;
            this.CBShowImage.Checked = true;
            this.CBShowImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBShowImage.Location = new System.Drawing.Point(8, 95);
            this.CBShowImage.Margin = new System.Windows.Forms.Padding(4);
            this.CBShowImage.Name = "CBShowImage";
            this.CBShowImage.Size = new System.Drawing.Size(91, 23);
            this.CBShowImage.TabIndex = 3;
            this.CBShowImage.Text = "顯示圖片";
            this.CBShowImage.UseVisualStyleBackColor = true;
            // 
            // DGVDataList
            // 
            this.DGVDataList.AllowUserToAddRows = false;
            this.DGVDataList.AllowUserToDeleteRows = false;
            this.DGVDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartTime,
            this.VTuberName,
            this.VideoTitle,
            this.VideoThumbnailUrl,
            this.VideoUrl,
            this.PlatformIconUrl,
            this.ChannelUrl,
            this.StrCountry});
            this.DGVDataList.Location = new System.Drawing.Point(15, 15);
            this.DGVDataList.Margin = new System.Windows.Forms.Padding(4);
            this.DGVDataList.Name = "DGVDataList";
            this.DGVDataList.ReadOnly = true;
            this.DGVDataList.RowHeadersWidth = 51;
            this.DGVDataList.RowTemplate.Height = 25;
            this.DGVDataList.Size = new System.Drawing.Size(1201, 709);
            this.DGVDataList.TabIndex = 3;
            this.DGVDataList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDataList_CellClick);
            this.DGVDataList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVDataList_CellFormatting);
            // 
            // GBOperationSet
            // 
            this.GBOperationSet.Controls.Add(this.CBShowImage);
            this.GBOperationSet.Controls.Add(this.BtnGetData);
            this.GBOperationSet.Controls.Add(this.CBEnableTimeFilter);
            this.GBOperationSet.Location = new System.Drawing.Point(1224, 15);
            this.GBOperationSet.Margin = new System.Windows.Forms.Padding(4);
            this.GBOperationSet.Name = "GBOperationSet";
            this.GBOperationSet.Padding = new System.Windows.Forms.Padding(4);
            this.GBOperationSet.Size = new System.Drawing.Size(114, 128);
            this.GBOperationSet.TabIndex = 4;
            this.GBOperationSet.TabStop = false;
            this.GBOperationSet.Text = "操作";
            // 
            // LSourceFrom
            // 
            this.LSourceFrom.AutoSize = true;
            this.LSourceFrom.Location = new System.Drawing.Point(15, 728);
            this.LSourceFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LSourceFrom.Name = "LSourceFrom";
            this.LSourceFrom.Size = new System.Drawing.Size(84, 19);
            this.LSourceFrom.TabIndex = 5;
            this.LSourceFrom.Text = "資料來源：";
            // 
            // LLWebSiteUrl
            // 
            this.LLWebSiteUrl.AutoSize = true;
            this.LLWebSiteUrl.Location = new System.Drawing.Point(109, 728);
            this.LLWebSiteUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LLWebSiteUrl.Name = "LLWebSiteUrl";
            this.LLWebSiteUrl.Size = new System.Drawing.Size(166, 19);
            this.LLWebSiteUrl.TabIndex = 4;
            this.LLWebSiteUrl.TabStop = true;
            this.LLWebSiteUrl.Text = "https://space-r.tw/twvt";
            this.LLWebSiteUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLWebSiteUrl_LinkClicked);
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "開始時間";
            this.StartTime.MinimumWidth = 6;
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartTime.ToolTipText = "開始時間";
            this.StartTime.Width = 110;
            // 
            // VTuberName
            // 
            this.VTuberName.DataPropertyName = "VTuberName";
            this.VTuberName.HeaderText = "VTuber 名稱";
            this.VTuberName.MinimumWidth = 6;
            this.VTuberName.Name = "VTuberName";
            this.VTuberName.ReadOnly = true;
            this.VTuberName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VTuberName.ToolTipText = "VTuber 名稱";
            this.VTuberName.Width = 160;
            // 
            // VideoTitle
            // 
            this.VideoTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VideoTitle.DataPropertyName = "VideoTitle";
            this.VideoTitle.HeaderText = "影片標題";
            this.VideoTitle.MinimumWidth = 6;
            this.VideoTitle.Name = "VideoTitle";
            this.VideoTitle.ReadOnly = true;
            this.VideoTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VideoTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VideoTitle.ToolTipText = "影片標題";
            // 
            // VideoThumbnailUrl
            // 
            this.VideoThumbnailUrl.DataPropertyName = "VideoThumbnailUrl";
            this.VideoThumbnailUrl.HeaderText = "影片封面";
            this.VideoThumbnailUrl.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.VideoThumbnailUrl.MinimumWidth = 6;
            this.VideoThumbnailUrl.Name = "VideoThumbnailUrl";
            this.VideoThumbnailUrl.ReadOnly = true;
            this.VideoThumbnailUrl.ToolTipText = "影片封面";
            this.VideoThumbnailUrl.Width = 80;
            // 
            // VideoUrl
            // 
            this.VideoUrl.DataPropertyName = "VideoUrl";
            this.VideoUrl.HeaderText = "影片網址";
            this.VideoUrl.MinimumWidth = 6;
            this.VideoUrl.Name = "VideoUrl";
            this.VideoUrl.ReadOnly = true;
            this.VideoUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VideoUrl.ToolTipText = "影片網址";
            this.VideoUrl.Width = 125;
            // 
            // PlatformIconUrl
            // 
            this.PlatformIconUrl.DataPropertyName = "PlatformIconUrl";
            this.PlatformIconUrl.HeaderText = "平臺";
            this.PlatformIconUrl.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.PlatformIconUrl.MinimumWidth = 6;
            this.PlatformIconUrl.Name = "PlatformIconUrl";
            this.PlatformIconUrl.ReadOnly = true;
            this.PlatformIconUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PlatformIconUrl.ToolTipText = "平臺";
            this.PlatformIconUrl.Width = 50;
            // 
            // ChannelUrl
            // 
            this.ChannelUrl.DataPropertyName = "ChannelUrl";
            this.ChannelUrl.HeaderText = "頻道網址";
            this.ChannelUrl.MinimumWidth = 6;
            this.ChannelUrl.Name = "ChannelUrl";
            this.ChannelUrl.ReadOnly = true;
            this.ChannelUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChannelUrl.ToolTipText = "頻道網址";
            this.ChannelUrl.Width = 125;
            // 
            // StrCountry
            // 
            this.StrCountry.DataPropertyName = "StrCountry";
            this.StrCountry.HeaderText = "國家";
            this.StrCountry.MinimumWidth = 6;
            this.StrCountry.Name = "StrCountry";
            this.StrCountry.ReadOnly = true;
            this.StrCountry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StrCountry.ToolTipText = "國家";
            this.StrCountry.Width = 260;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 759);
            this.Controls.Add(this.LLWebSiteUrl);
            this.Controls.Add(this.LSourceFrom);
            this.Controls.Add(this.GBOperationSet);
            this.Controls.Add(this.DGVDataList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "台V節目表";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDataList)).EndInit();
            this.GBOperationSet.ResumeLayout(false);
            this.GBOperationSet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGetData;
        private System.Windows.Forms.CheckBox CBEnableTimeFilter;
        private System.Windows.Forms.CheckBox CBShowImage;
        private System.Windows.Forms.DataGridView DGVDataList;
        private System.Windows.Forms.GroupBox GBOperationSet;
        private System.Windows.Forms.Label LSourceFrom;
        private System.Windows.Forms.LinkLabel LLWebSiteUrl;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn VTuberName;
        private DataGridViewTextBoxColumn VideoTitle;
        private DataGridViewImageColumn VideoThumbnailUrl;
        private DataGridViewLinkColumn VideoUrl;
        private DataGridViewImageColumn PlatformIconUrl;
        private DataGridViewLinkColumn ChannelUrl;
        private DataGridViewTextBoxColumn StrCountry;
    }
}

