using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FPCalc
{
    public partial class CurrentPentionFactorCalc : ContentPage
    {
        public CurrentPentionFactorCalc()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            CalcButton.Clicked += CalcButton_Clicked;
        }

        private void CalcButton_Clicked(object sender, EventArgs e)
        {
            var parseResult = Int64.TryParse(PentionAmount.Text, out long pentionAmount);
            if (!parseResult && pentionAmount > long.MaxValue)
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
            double currentPentionFactor = (1.0 - Math.Pow(1.0 + annualInterestRate / 100, -accumulatedYears)) / (annualInterestRate/100);
            decimal result = Convert.ToInt64(pentionAmount * currentPentionFactor);
            DisplayAlert("Result", result.ToString("C0") + "用意すると実現できます", "OK");
        }
    }
}
