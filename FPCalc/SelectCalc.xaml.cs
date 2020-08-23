using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FPCalc
{
    public partial class SelectCalc : ContentPage
    {
        public SelectCalc()
        {
            InitializeComponent();
            ClosingPriceCoefficientButton.Clicked += ClosingPriceCoefficientButton_Clicked;
            PresentValueCoefficientButton.Clicked += PresentValueCoefficientButton_Clicked;
            CurrentPentionFactorButton.Clicked += CurrentPentionFactorButton_Clicked;
            EndOfLifeCoefficientButton.Clicked += EndOfLifeCoefficientButton_Clicked;
            CapitalRecoveryFactorButton.Clicked += CapitalRecoveryFactorButton_Clicked;
            DebtReductionCoefficientButton.Clicked += DebtReductionCoefficientButton_Clicked;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void DebtReductionCoefficientButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DebtReductionCoefficientCalc());
        }

        private void CapitalRecoveryFactorButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CapitalRecoveryFactorCalc());
        }

        private void EndOfLifeCoefficientButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EndOfLifeCoefficientCalc());
        }

        private void CurrentPentionFactorButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CurrentPentionFactorCalc());
        }

        private void PresentValueCoefficientButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PresentValueCoefficientCalc());
        }

        private void ClosingPriceCoefficientButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClosingPriceCoefficientCalc());
        }
    }
}
