using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StepperTest.Helpers;
using System;

namespace StepperTest
{

    public sealed partial class MainPage : Page
    {

        public int stepsVertical { get; set; }
        public int stepsHorizontal { get; set; }

        StepperStep stepperVertical = new StepperStep(19, 26);
        StepperStep stepperHorizontal = new StepperStep(6, 13, 5);

        public MainPage()
        {
            this.InitializeComponent();
            stepperVertical.InitGPIO();
            stepperHorizontal.InitGPIO();
        }

        private void VertikalStepFWD_Click(object sender, RoutedEventArgs e) => stepperVertical.Step(stepsVertical);

        private void VerticalStepBACK_Click(object sender, RoutedEventArgs e) => stepperVertical.Step(-stepsVertical);

        private void HorizontalFWD_Click(object sender, RoutedEventArgs e) => stepperHorizontal.Step(stepsHorizontal);

        private void HorizontalBACK_Click(object sender, RoutedEventArgs e) => stepperHorizontal.Step(-stepsHorizontal);

        private void StepsVerticalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int val = Convert.ToInt32(StepsVerticalTextBox.Text);
                stepsVertical = val;
            }
            catch (FormatException ex)
            {

                StepsVerticalTextBox.Text = "Not an Int!";
            }
            catch (OverflowException ex)
            {
                StepsVerticalTextBox.Text = "Not an Int!";
            }

        }

        private void StepsHorizontalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int val = Convert.ToInt32(StepsHorizontalTextBox.Text);
                stepsHorizontal = val;
            }
            catch (FormatException ex)
            {

                StepsHorizontalTextBox.Text = "Not an Int!";
            }
            catch (OverflowException ex)
            {
                StepsHorizontalTextBox.Text = "Not an Int!";
            }
        }
    }
}
