using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Bürozeiterfasser.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Bürozeiterfasser.Pages
{
    public partial class Index
    {
        private TimeSpan workTime;
        private DateTime workStart, workEnd;
        private int workTimeHour, workTimeMinute;

        private Countdown coundownRef { get; set; }

        private string timeZoneSelected { get; set; }

        private async Task UpdateWorktime()
        {
            StateHasChanged();

            workTime = new TimeSpan(workTimeHour,workTimeMinute,0);

            workEnd = workStart.Add(workTime);

            coundownRef.StartCountdown();

            StateHasChanged();
        }

        private async Task TimezoneChanged()
        {
            workStart = TimeZoneInfo.ConvertTime(workStart, getSelectedTimeZone());
        }


        private TimeZoneInfo getSelectedTimeZone()
        {
            switch(timeZoneSelected)
            {
                case "cet":
                    return TimeZoneInfo.CreateCustomTimeZone("cet", new TimeSpan(1,0,0),"CET","Berlin");

                case "est":
                    return TimeZoneInfo.CreateCustomTimeZone("est", new TimeSpan(-5, 0, 0), "EST", "NewYork");

                case "jst":
                    return TimeZoneInfo.CreateCustomTimeZone("jst", new TimeSpan(9, 0, 0), "JST", "Tokyo");

                default: return TimeZoneInfo.CreateCustomTimeZone("cet", new TimeSpan(1, 0, 0), "CET", "Berlin"); ;
                    break;
                    
            }
        }
    }
}
