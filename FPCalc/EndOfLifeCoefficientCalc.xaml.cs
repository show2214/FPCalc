using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FPCalc
{
    public partial class EndOfLifeCoefficientCalc : ContentPage
    {
        public EndOfLifeCoefficientCalc()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            CalcButton.Clicked += CalcButton_Clicked;
        }

        private void CalcButton_Clicked(object sender, EventArgs e)
        {
            var parseResult = Int64.TryParse(Deposit.Text, out long deposit);
            if (!parseResult && deposit > long.MaxValue)
            {
                DisplayAlert("Alert", "Your inputted parameter is not number.", "OK");
                return;
            }
            parseResult = Double.TryParse(AnnualInterestRate.Text, out double annualInterestRate);
            if (!parseResult && annualInterestRate > Double.MaxValue)
            {
                DisplayAlert("Alert", "Your inputted parameter is not number.", "OK");
                return;
            }
            parseResult = Double.TryParse(AccumulatedYears.Text, out double accumulatedYears);
            if (!parseResult && accumulatedYears > Double.MaxValue)
            {
                DisplayAlert("Alert", "Your inputted parameter is not number.", "OK");
                return;
            }
            double endOfLifeCoefficient = (Math.Pow(1.0 + annualInterestRate / 100, accumulatedYears) - 1) / (annualInterestRate / 100);
            decimal result = Convert.ToInt64(deposit * endOfLifeCoefficient);
            DisplayAlert("Result", "積み立てて運用すると" + result.ToString("C0") + "になります", "OK");
        }
    }
}
