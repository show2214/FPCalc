using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FPCalc
{
    public partial class DebtReductionCoefficientCalc : ContentPage
    {
        public DebtReductionCoefficientCalc()
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
            double debtReductionCoefficient = (annualInterestRate / 100) / (Math.Pow(1.0 + annualInterestRate / 100, accumulatedYears) - 1);
            decimal result = Convert.ToInt64(targetAmount * debtReductionCoefficient);
            DisplayAlert("Result", Convert.ToInt64(accumulatedYears) + "年間運用して" + Convert.ToInt64(targetAmount).ToString("C0") + "を達成するには毎年" + result.ToString("C0") + "の積立が必要です", "OK");
        }
    }
}
