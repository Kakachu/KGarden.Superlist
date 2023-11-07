namespace KGarden.Superlist.Utils.Common.Date
{
	public static class DateCommon
    {
        public static DateTime DateNowBR()
        {
            return ConvertDateToBR(DateTime.Now);
        }

        public static DateTime ConvertDateToBR(this DateTime date)
        {
            var dateNowBR = DateTime.Now;

            try
            {
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                if (timeZone != null)
                {
                    var timeZoneSource = TimeZoneInfo.Utc;
                    if(date.Kind != DateTimeKind.Local)
                    {
                        timeZoneSource = TimeZoneInfo.Local;
                    }

                    var dateConvert = TimeZoneInfo.ConvertTime(date, timeZoneSource, timeZone);
                    dateNowBR = dateConvert;
                }
            }
            catch (Exception)
            {
                return DateTime.Now;
            }

            return dateNowBR;
        }
    }
}
