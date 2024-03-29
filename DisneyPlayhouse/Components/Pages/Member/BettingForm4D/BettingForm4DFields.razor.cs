using Microsoft.AspNetCore.Components;

namespace DisneyPlayhouse.Components.Pages.Member.BettingForm4D
{
    public partial class BettingForm4DFields
    {
        [Parameter] public int Id { get; set; }
        [Parameter] public int Id2 { get; set; }
        [Parameter] public int Id3 { get; set; }
        [Parameter] public int SmallValue { get; set; }
        [Parameter] public int SmallValue2 { get; set; }
        [Parameter] public int SmallValue3 { get; set; }
        [Parameter] public double BigValue { get; set; }
        [Parameter] public double BigValue2 { get; set; }
        [Parameter] public double BigValue3 { get; set; }
        [Parameter] public string Number { get; set; }
        [Parameter] public string Number2 { get; set; }
        [Parameter] public string Number3 { get; set; }
        [Parameter] public string Action { get; set; }
        [Parameter] public int Day { get; set; }
        [Parameter] public int Day2 { get; set; }
        [Parameter] public int Day3 { get; set; }
        [Parameter] public string Roll { get; set; }
        [Parameter] public string Roll2 { get; set; }
        [Parameter] public string Roll3 { get; set; }
        [Parameter] public EventCallback<ValueTuple<dynamic, int, string>> ValueChangedSmall { get; set; }
        [Parameter] public EventCallback<ValueTuple<dynamic, int, string>> ValueChangedBig { get; set; }
        [Parameter] public EventCallback<ValueTuple<dynamic, int, string>> ValueChangedNumber { get; set; }
        [Parameter] public EventCallback<ValueTuple<dynamic, int, string>> ValueChangedDay { get; set; }
        [Parameter] public EventCallback<ValueTuple<dynamic, int, string>> ValueChangedRoll { get; set; }

        private async Task UpdateValueSmall(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int inputValue))
            {
                Action = "UpdateSmall";
                SmallValue = inputValue;
                await ValueChangedSmall.InvokeAsync((SmallValue, Id, Action));
            }
        }

        private async Task UpdateValueSmall2(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int inputValue))
            {
                Action = "UpdateSmall";
                SmallValue2 = inputValue;
                await ValueChangedSmall.InvokeAsync((SmallValue2, Id2, Action));
            }
        }

        private async Task UpdateValueSmall3(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int inputValue))
            {
                Action = "UpdateSmall";
                SmallValue3 = inputValue;
                await ValueChangedSmall.InvokeAsync((SmallValue3, Id3, Action));
            }
        }

        private async Task UpdateValueBig(ChangeEventArgs e)
        {
            if (double.TryParse(e.Value.ToString(), out double inputValue))
            {
                if (IsValidInput(inputValue))
                {
                    Action = "UpdateBig";
                    BigValue = inputValue;
                    await ValueChangedBig.InvokeAsync((BigValue, Id, Action));
                }
                else
                {
                    BigValue = 0; // Set to default value when input is not valid
                }
            }
        }

        private async Task UpdateValueBig2(ChangeEventArgs e)
        {
            if (double.TryParse(e.Value.ToString(), out double inputValue))
            {
                if (IsValidInput(inputValue))
                {
                    Action = "UpdateBig";
                    BigValue2 = inputValue;
                    await ValueChangedBig.InvokeAsync((BigValue2, Id2, Action));
                }
                else
                {
                    BigValue = 0; // Set to default value when input is not valid
                }
            }
        }

        private async Task UpdateValueBig3(ChangeEventArgs e)
        {
            if (double.TryParse(e.Value.ToString(), out double inputValue))
            {
                if (IsValidInput(inputValue))
                {
                    Action = "UpdateBig";
                    BigValue3 = inputValue;
                    await ValueChangedBig.InvokeAsync((BigValue3, Id3, Action));
                }
                else
                {
                    BigValue = 0; // Set to default value when input is not valid
                }
            }
        }

        private async Task UpdateNumber(ChangeEventArgs e)
        {
            if (e.Value?.ToString().Length == 4)
            {
                Number = e.Value?.ToString();
            }
            else
            {
                Number = " ";
            }
            Action = "UpdateNumber";
            await ValueChangedNumber.InvokeAsync((Number, Id, Action));
        }

        private async Task UpdateNumber2(ChangeEventArgs e)
        {
            if (e.Value?.ToString().Length == 4)
            {
                Number2 = e.Value?.ToString();
            }
            else
            {
                Number2 = " ";
            }
            Action = "UpdateNumber";
            await ValueChangedNumber.InvokeAsync((Number2, Id2, Action));
        }

        private async Task UpdateNumber3(ChangeEventArgs e)
        {
            if (e.Value?.ToString().Length == 4)
            {
                Number3 = e.Value?.ToString();
            }
            else
            {
                Number3 = " ";
            }
            Action = "UpdateNumber";
            await ValueChangedNumber.InvokeAsync((Number3, Id3, Action));
        }

        private async Task UpdateDay(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int inputValue))
            {
                Action = "UpdateDay";
                Day = inputValue;
                await ValueChangedDay.InvokeAsync((Day, Id, Action));
            }
        }

        private async Task UpdateDay2(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int inputValue))
            {
                Action = "UpdateDay";
                Day2 = inputValue;
                await ValueChangedDay.InvokeAsync((Day2, Id2, Action));
            }
        }

        private async Task UpdateDay3(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int inputValue))
            {
                Action = "UpdateDay";
                Day3 = inputValue;
                await ValueChangedDay.InvokeAsync((Day3, Id3, Action));
            }
        }

        private async Task UpdateRoll(ChangeEventArgs e)
        {
            Action = "UpdateRoll";
            Roll = e.Value.ToString();
            await ValueChangedRoll.InvokeAsync((Roll, Id, Action));
        }

        private async Task UpdateRoll2(ChangeEventArgs e)
        {
            Action = "UpdateRoll";
            Roll2 = e.Value.ToString();
            await ValueChangedRoll.InvokeAsync((Roll2, Id2, Action));
        }

        private async Task UpdateRoll3(ChangeEventArgs e)
        {
            Action = "UpdateRoll";
            Roll3 = e.Value.ToString();
            await ValueChangedRoll.InvokeAsync((Roll3, Id3, Action));
        }

        private List<int> GetAvailableDays()
        {
            DateTime currentDate = DateTime.Now;
            // Check if today is Monday
            if (currentDate.DayOfWeek == DayOfWeek.Monday)
            {
                return new List<int> { 1, 2, 3, 6, 7 };
            }
            // Check if today is Tuesday
            if (currentDate.DayOfWeek == DayOfWeek.Tuesday)
            {
                return new List<int> { 1, 2, 3, 6, 7 };
            }
            // Check if today is Wednesday before 4pm
            if (currentDate.DayOfWeek == DayOfWeek.Wednesday && currentDate.Hour < 16)
            {
                return new List<int> { 1, 2, 3, 6, 7 };
            }
            if (currentDate.DayOfWeek == DayOfWeek.Wednesday && currentDate.Hour > 16)
            {
                return new List<int> { 2, 6, 7 };
            }
            if (currentDate.DayOfWeek == DayOfWeek.Thursday)
            {
                return new List<int> { 2, 6, 7 };
            }
            if (currentDate.DayOfWeek == DayOfWeek.Friday)
            {
                return new List<int> { 2, 6, 7 };
            }
            // Check if today is Saturday before 4pm
            if (currentDate.DayOfWeek == DayOfWeek.Saturday && currentDate.Hour < 16)
            {
                return new List<int> { 2, 6, 7 };
            }
            // Check if today is Saturday after 4pm
            if (currentDate.DayOfWeek == DayOfWeek.Saturday && currentDate.Hour >= 16)
            {
                return new List<int> { 3, 7 };
            }
            // Check if today is Sunday before 4pm
            if (currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Hour < 16)
            {
                return new List<int> { 3, 7 };
            }
            // Check if today is Sunday after 4pm
            if (currentDate.DayOfWeek == DayOfWeek.Sunday && currentDate.Hour >= 16)
            {
                return new List<int> { 1, 2, 3, 6, 7 };
            }
            // For all other cases, show all options
            return new List<int> { 1, 2, 3, 6, 7 };
        }

        // Manage for Big input only to accept whole numbers or numbers with .5
        private bool IsValidInput(double value)
        {
            return Math.Floor(value) == value || Math.Floor(value * 2) == value * 2;
        }
    }
}