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


    }
}
