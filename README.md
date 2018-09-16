# DRV8825-Stepper-Motor-Driver-on-RPi-3-Win10-IoT

Connect two DRV8825 to RPi,
No.1:  GPIO26 to  DIR, GPIO19 to  STEP, 5V to RESET and SALEEP, GND to GND.
No.2: GPIO 13 to DIR, GPIO6 to STEP, GPIO5 to ENABLE, 5V to RESET and SALEEP, GND to GND.

Provide at least 10V to VMOT and connect GND to Power Source.


Connect stepper motors to A1, A2, B1, B2 pins. On each stepper coil I used resistor to limit the current not to burn DRV or stepper motor. 
Since the No.2 DRV is enabled only when the step is needed the motor and the DRV stays cool. Similar you can use SLEEP pin.

On RPi UI first you need to enter a number of steps and then you click on FWD or BACK Button. I called two motors Vertical and Horizontal.  
