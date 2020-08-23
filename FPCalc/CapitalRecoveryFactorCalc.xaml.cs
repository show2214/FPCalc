using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FPCalc
{
    public partial class CapitalRecoveryFactorCalc : ContentPage
    {
        public CapitalRecoveryFactorCalc()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            CalcButton.Clicked += CalcButton_Clicked;
        }

        private void CalcButton_Clicked(object sender, EventArgs e)
        {
            var parseResult = Int64.TryParse(PensionFund.Text, out long pensionFund);
            if (!parseResult && pensionFund > long.MaxValue)
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
            parseResult = Double.TryParse(ReceivedYears.Text, out double receivedYears);
            if (!parseResult && receivedYears > Double.MaxValue)
            {
                DisplayAlert("Alert", "Your inputted parameter is not number.", "OK");
                return;
            }
            double capitalRecoveryFactor = (annualInterestRate / 100) / (1 - Math.Pow(1.0 + annualInterestRate / 100, -receivedYears));
            decimal result = Convert.ToInt64(pensionFund * capitalRecoveryFactor);
            DisplayAlert("Result", Convert.ToInt64(receivedYears) + "年間運用しながら取り崩すと毎年" + result.ToString("C0") + "受け取れます", "OK");
        }
    }
}
