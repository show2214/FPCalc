using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FPCalc
{
    public partial class PresentValueCoefficientCalc : ContentPage
    {
        public PresentValueCoefficientCalc()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            CalcButton.Clicked += CalcButton_Clicked;
        }

        private void CalcButton_Clicked(object sender, EventArgs e)
        {
            var parseResult = Int64.TryParse(TargetAmount.Text, out long targetAmount);
            if (!parseResult && targetAmount > long.MaxValue)
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
            double presentValueCoefficient = 1.0 / Math.Pow(1.0 + annualInterestRate / 100, accumulatedYears);
            decimal result = Convert.ToInt64(targetAmount * presentValueCoefficient);
            DisplayAlert("Result", result.ToString("C0") + "用意すると達成できます", "OK");
        }
    }
}