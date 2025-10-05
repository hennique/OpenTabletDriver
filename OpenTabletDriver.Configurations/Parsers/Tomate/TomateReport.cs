using System.Numerics;
using System;
using System.Runtime.CompilerServices;
using OpenTabletDriver.Tablet;

namespace OpenTabletDriver.Configurations.Parsers.Tomate
{
    public struct TomateReport : ITabletReport
    {
        public TomateReport(byte[] report)
        {
            Raw = report;

            Position = new Vector2
            {
                X = report[1] << 8 | report[2],
                Y = Math.Max((short)(report[3] << 8 | report[4]), (short)0)
            };

            ushort prePressure = (ushort)(report[5] << 8 | report[6]);
            ushort calibratedMax = (ushort)(report[7] << 8 | report[8]);

            ushort pressure = (ushort)(calibratedMax - prePressure);
            if (pressure < 200)
                pressure = 0;

            Pressure = pressure;

            PenButtons = new bool[]
            {
                (report[9] & 6) == 6,
                (report[9] & 6) == 4
            };
        }

        public byte[] Raw { set; get; }
        public Vector2 Position { set; get; }
        public uint Pressure { set; get; }
        public bool[] PenButtons { set; get; }
    }
}
