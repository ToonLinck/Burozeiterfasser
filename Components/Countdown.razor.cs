using System.Timers;
using Microsoft.AspNetCore.Components;

namespace Bürozeiterfasser.Components
{
    public partial class Countdown
    {
        public TimeSpan CountdownTime { get; set; }

        private System.Timers.Timer timer;
        private bool timeOver = false;

        [Parameter]
        public DateTime WorkStart { get; set; }
        [Parameter]
        public DateTime WorkEnd { get; set; }


        protected override void OnInitialized()
        {

            base.OnInitialized();
        }

        private void SetTimer()
        {
            timer = new System.Timers.Timer(100);
            timer.Elapsed += async (sender, e) => await CountdownTick();
            timer.Enabled = true;
        }

        private void StopTimer()
        {
            timer.Enabled = false;
        }


        public void StartCountdown()
        {
            timeOver = false;

            CountdownTime = WorkEnd - WorkStart;

            SetTimer();

            StateHasChanged();
        }


        private async Task CountdownTick()
        {
            if (CountdownTime.Equals(TimeSpan.Zero))
            {
                timeOver = true;
                StopTimer();

            }
            else
            {
                CountdownTime = CountdownTime.Add(-TimeSpan.FromSeconds(1));
            }

            await InvokeAsync(StateHasChanged);
        }
    }
}
