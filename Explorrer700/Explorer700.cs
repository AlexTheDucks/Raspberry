﻿// ----------------------------------------------------------------------------
// CSA - C# in Action
// (c) 2020, Christian Jost, HSLU
// ----------------------------------------------------------------------------
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

namespace SW04_Explorer700
{
    public class Explorer700
    {
        public Explorer700()
        {
            // Wiring-Pi für den Zugriff auf die Hardware initialisieren
            Pi.Init<BootstrapWiringPi>();
            Led1 = new LedGpio();
            Pcf8574 = new Pcf8574(0x20);
            Led2 = new LedI2C(Pcf8574);
            Buzzer = new Buzzer(Pcf8574);
            Joystick = new Joystick(Pcf8574);
            //Display = new Display();
        }

        public LedBase Led1 { get; }
        public Pcf8574 Pcf8574 { get; }
        public LedBase Led2 { get; }
        public Buzzer Buzzer { get; }
        public Joystick Joystick { get; }
        //public Display Display { get; }

    }
}