using OpenTabletDriver.Tablet;

namespace OpenTabletDriver.Configurations.Parsers.Tomate
{
    public struct TomateAuxReport : IAuxReport
    {
        public TomateAuxReport(byte[] report)
        {
            Raw = report;
            AuxButtons = new bool[]
            {
                !report[12].IsBitSet(1),
                !report[12].IsBitSet(4),
                !report[11].IsBitSet(7),
                !report[12].IsBitSet(0),
                !report[11].IsBitSet(6),
                !report[12].IsBitSet(5),
                !report[11].IsBitSet(5),
                !report[11].IsBitSet(0),
                !report[11].IsBitSet(4),
                !report[11].IsBitSet(1),
                !report[11].IsBitSet(3),
                !report[11].IsBitSet(2),
            };
        }

        public bool[] AuxButtons { set; get; }
        public byte[] Raw { set; get; }
    }
}
