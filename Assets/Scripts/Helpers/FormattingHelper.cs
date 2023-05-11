using System;

namespace Helpers
{
	public static class FormattingHelper
	{
		public static string FormatFloatToTime(float time)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(time);
			string formattedTime = "";
			
			if (timeSpan.Hours > 0)
			{
				formattedTime = TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss\:fff");
			}
			else
			{
				formattedTime = TimeSpan.FromSeconds(time).ToString(@"mm\:ss\:fff");
			}

			return formattedTime;
		}
	}
}