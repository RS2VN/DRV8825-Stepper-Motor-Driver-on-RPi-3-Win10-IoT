using System;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace StepperTest.Helpers
{
    class StepperStep
    {
        public int STEP_PIN { get; set; }
        public int DIR_PIN { get; set; }
        public int ENABLE_PIN { get; set; }
        private GpioPin stepPin;
        private GpioPin directionPin;
        private GpioPin enablePin;
        private GpioPinValue stepPinValue;
        private GpioPinValue directionPinValue;
        private GpioPinValue enablePinValue;


        public StepperStep(int sTEP_PIN, int dIR_PIN)
        {
            STEP_PIN = sTEP_PIN;
            DIR_PIN = dIR_PIN;
        }

        public StepperStep(int sTEP_PIN, int dIR_PIN, int eNABLE_PIN = 0)
        {
            STEP_PIN = sTEP_PIN;
            DIR_PIN = dIR_PIN;
            ENABLE_PIN = eNABLE_PIN;
        }

        public void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            stepPin = gpio.OpenPin(STEP_PIN);
            stepPin.SetDriveMode(GpioPinDriveMode.Output);
            stepPinValue = GpioPinValue.Low;
            stepPin.Write(stepPinValue);

            directionPin = gpio.OpenPin(DIR_PIN);
            directionPin.SetDriveMode(GpioPinDriveMode.Output);
            directionPinValue = GpioPinValue.Low;
            directionPin.Write(directionPinValue);

            if (ENABLE_PIN != 0)
            {
                enablePin = gpio.OpenPin(ENABLE_PIN);
                enablePin.SetDriveMode(GpioPinDriveMode.Output);
                enablePinValue = GpioPinValue.High;
                enablePin.Write(enablePinValue);
            }
        }

        private void OneStep()
        {
            var signal = Task.Run(async delegate { await Task.Delay(TimeSpan.FromMilliseconds(1)); });
            var pavza = Task.Run(async delegate { await Task.Delay(TimeSpan.FromMilliseconds(1)); });

            stepPinValue = GpioPinValue.High;
            stepPin.Write(stepPinValue);
            signal.Wait();
            stepPinValue = GpioPinValue.Low;
            stepPin.Write(stepPinValue);
            pavza.Wait();
        }

        public void Step(int steps)
        {
            if (ENABLE_PIN != 0)
            {
                enablePinValue = GpioPinValue.Low;
                enablePin.Write(enablePinValue);
            }

            if (steps <= 0) { directionPinValue = GpioPinValue.Low; }
            else { directionPinValue = GpioPinValue.High; }
            directionPin.Write(directionPinValue);

            for (int i = 0; i < Math.Abs(steps); i++)
            {
                OneStep();
            }

            if (ENABLE_PIN != 0)
            {
                enablePinValue = GpioPinValue.High;
                enablePin.Write(enablePinValue);
            }
        }
    }
}
