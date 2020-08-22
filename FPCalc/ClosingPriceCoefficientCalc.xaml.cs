using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FPCalc
{
    public partial class ClosingPriceCoefficientCalc : ContentPage
    {
        public ClosingPriceCoefficientCalc()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            CalcButton.Clicked += CalcButton_Clicked;
        }

        private void CalcButton_Clicked(object sender, EventArgs e)
        {
            var parseResult = Int64.TryParse(Principal.Text, out long principal);
            if (!parseResult && principal > long.MaxValue)
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
            parseResult = Double.TryParse(YearsOfOperation.Text, out double yearOfOperation);
            if (!parseResult && yearOfOperation > Double.MaxValue)
            {
                DisplayAlert("Alert", "Your inputted parameter is not number.", "OK");
                return;
            }
            double closingPriceCoefficient = Math.Pow(1.0 + annualInterestRate / 100, yearOfOperation);
            decimal result = Convert.ToInt64(principal * closingPriceCoefficient);
            DisplayAlert("Result", "Result is " + result.ToString("C0"), "OK");
        }
    }
}
