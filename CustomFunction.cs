using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using RandomUserAgent;
using Svg;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TWVTSched;

/// <summary>
/// 自定義函式
/// </summary>
public class CustomFunction
{
    /// <summary>
    /// 資料來源的網址
    /// </summary>
    public static readonly string DataSourceUrl = "https://space-r.tw/twvt";

    /// <summary>
    /// 快取的有效時間
    /// </summary>
    public static readonly int CacheMinutes = 10;

    /// <summary>
    /// 下載並解析 HTML
    /// </summary>
    /// <param name="httpClient">HttpClient</param>
    /// <param name="enableTimeFilter">布林值，是否啟用時間過濾，預設值為 true</param>
    /// <returns>Task&lt;List&lt;POCO.ScheduleData&gt;&gt;</returns>
    public static async Task<List<POCO.ScheduleData>> DownloadHtml(
        HttpClient httpClient,
        bool enableTimeFilter = true)
    {
        List<POCO.ScheduleData> listOutputData = new();

        string strUserAgent = RandomUa.RandomUserAgent;
        string strKeySelector = ".row.v_row";

        Debug.WriteLine($"本次的 User-Agent: {strUserAgent}");

        // TODO: 2021-12-04 待修正無法重複指定的問題。
        httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(strUserAgent);
        httpClient.DefaultRequestHeaders.Referrer = new Uri(DataSourceUrl);

        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(DataSourceUrl);

        httpResponseMessage.EnsureSuccessStatusCode();

        string strResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        HtmlParser htmlParser = new();

        IHtmlDocument htmlDocument = htmlParser.ParseDocument(strResponseBody);

        IHtmlCollection<IElement> listElements = htmlDocument.QuerySelectorAll(strKeySelector);

        int elementCount = 0;

        foreach (IElement parentElement in listElements)
        {
            foreach (IElement childElement in parentElement.Children)
            {
                bool isLastElement = false;

                if (elementCount == listElements.Length - 1)
                {
                    isLastElement = true;
                }

                string? strDivID = parentElement.Id;

                if (string.IsNullOrEmpty(strDivID))
                {
                    strDivID = string.Empty;
                }

                POCO.ScheduleData? vtpsData = ParseIElement(
                    strDivID,
                    childElement.OuterHtml,
                    enableTimeFilter,
                    isLastElement);

                if (vtpsData != null)
                {
                    listOutputData.Add(vtpsData);
                }
            }

            elementCount++;
        }

        return listOutputData;
    }

    /// <summary>
    /// 解析 IElement
    /// </summary>
    /// <param name="MainDivID">字串，Div 的 ID 值</param>
    /// <param name="HtmlContent">字串，HTML</param>
    /// <param name="EnableTimeFilter">布林值，是否啟用時間過濾，預設值為 true</param>
    /// <param name="IsLastIElement">布林值，是否為最後一個 IElement，預設值為 false</param>
    /// <returns>POCO.ScheduleData</returns>
    public static POCO.ScheduleData? ParseIElement(
        string MainDivID,
        string HtmlContent,
        bool EnableTimeFilter = true,
        bool IsLastIElement = false)
    {
        bool allowOutput = false;
        bool isCrossingDay = false;

        DateTime dtCurrentTime = DateTime.Now;
        DateTime dtStartTime = DateTime.Parse("1970/01/01");

        HtmlParser htmlParser = new();

        IHtmlDocument htmlDocument = htmlParser.ParseDocument(HtmlContent);

        IElement? elemCard = htmlDocument?.QuerySelector(".p_card");
        IElement? elemVideoThumbnail = htmlDocument?.QuerySelector(".mqdefimg");

        string strCountry = elemCard!.ClassList.Contains("TW") ? "中華民國（臺灣）"
            : elemCard.ClassList.Contains("HK") ? "中華人民共和國（香港特別行政區）"
            : elemCard.ClassList.Contains("MY") ? "馬來西亞" : "無";
        string strStartTime = htmlDocument?.QuerySelector(".time")?.Text()!;

        if (EnableTimeFilter)
        {
            // 只在有啟用時間過濾時，針對 00:00，再之後的時間就不處理。
            if (MainDivID == "pgs_0" && IsLastIElement == true)
            {
                strStartTime = $"{DateTime.Now.AddDays(1).ToShortDateString()} {strStartTime}";

                isCrossingDay = true;
            }

            if (DateTime.TryParse(strStartTime, out dtStartTime))
            {
                if (dtStartTime >= dtCurrentTime ||
                    dtStartTime.Hour >= dtCurrentTime.Hour)
                {
                    allowOutput = true;
                }
            }
            else
            {
                allowOutput = true;
            }
        }
        else
        {
            allowOutput = true;
        }

        if (allowOutput)
        {
            string strPlatformIconUrl = $"{DataSourceUrl.Replace("/twvt", string.Empty)}" +
                $"{htmlDocument?.QuerySelector("img")?.GetAttribute("src")}";
            string? strChannelUrl = htmlDocument?.QuerySelector(".channellink")?.GetAttribute("href");
            string? strVTuberName = htmlDocument?.QuerySelector(".channellink")?.Text();
            string? strVideoUrl = elemVideoThumbnail?.Parent?.ParentElement?.QuerySelector("a")?.GetAttribute("href");
            string? strVideoThumbnailUrl = elemVideoThumbnail?.GetAttribute("src");
            string? strVideoTitle = htmlDocument?.QuerySelector("h5")?.Text();

            return new POCO.ScheduleData()
            {
                // 為避免在網站資料未更新時，顯示會出現多一日的狀況，故只取 HH:mm 顯示。
                StartTime = isCrossingDay ? dtStartTime.ToString("HH:mm") : strStartTime,
                PlatformIconUrl = strPlatformIconUrl,
                ChannelUrl = strChannelUrl,
                VTuberName = strVTuberName,
                StrCountry = strCountry,
                VideoUrl = strVideoUrl,
                VideoThumbnailUrl = strVideoThumbnailUrl,
                VideoTitle = strVideoTitle
            };
        }

        return null;
    }

    /// <summary>
    /// 從網址產生 Image
    /// </summary>
    /// <param name="URL">圖片的網址</param>
    /// <returns>Image</returns>
    public static Image? GetImageFromUrl(string URL)
    {
        Image? optImage = null;

        try
        {
            // 將下載的 Image 快取 10 分鐘。
            optImage = GetCachable.BetterCacheManager.GetCachableData(URL, () =>
            {
                using HttpClient httpClient = new();

                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(URL).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    Stream stream = httpResponseMessage.Content.ReadAsStreamAsync().Result;

                    Image tempImage;

                    if (!URL.Contains(".svg"))
                    {
                        tempImage = Image.FromStream(stream);
                    }
                    else
                    {
                        SvgDocument svgDocument = SvgDocument.Open<SvgDocument>(stream);

                        tempImage = svgDocument.Draw();
                    }

                    stream.Close();
                    stream.Dispose();

                    return tempImage;
                }

                return null;
            }, CacheMinutes);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"有問題的影像檔案網址：{URL}");
            Debug.WriteLine(ex.ToString());
        }

        return optImage;
    }

    /// <summary>
    /// 開啟網頁瀏覽器
    /// <para>來源：https://brockallen.com/2016/09/24/process-start-for-urls-on-net-core/ </para>
    /// </summary>
    /// <param name="url">網址</param>
    public static void OpenBrowser(string url)
    {
        try
        {
            Process.Start(url);
        }
        catch
        {
            // Hack because of this: https://github.com/dotnet/corefx/issues/10361
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");

                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                Debug.WriteLine($"無法開啟的網址：{url}");
            }
        }
    }
}