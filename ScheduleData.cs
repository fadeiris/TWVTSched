using System.Text.Json.Serialization;

namespace TWVTSched.POCO;

/// <summary>
/// 時間表資料類別
/// </summary>
public partial class ScheduleData
{
	[JsonPropertyName("startTime")]
	public string? StartTime { get; set; }

	[JsonPropertyName("platformIconUrl")]
	public string? PlatformIconUrl { get; set; }

	[JsonPropertyName("channelUrl")]
	public string? ChannelUrl { get; set; }

	[JsonPropertyName("vtuberName")]
	public string? VTuberName { get; set; }

	[JsonPropertyName("strCountry")]
	public string? StrCountry { get; set; }

	[JsonPropertyName("videoUrl")]
	public string? VideoUrl { get; set; }

	[JsonPropertyName("videoThumbnailUrl")]
	public string? VideoThumbnailUrl { get; set; }

	[JsonPropertyName("videoTitle")]
	public string? VideoTitle { get; set; }
}