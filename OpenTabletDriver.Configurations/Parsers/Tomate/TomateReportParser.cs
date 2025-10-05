using OpenTabletDriver.Tablet;

namespace OpenTabletDriver.Configurations.Parsers.Tomate
{
    public class TomateReportParser : IReportParser<IDeviceReport>
    {
        public IDeviceReport Parse(byte[] report)
        {
            if ((report[11] << 8 | report[12]) != 0xFF33)
                return new TomateAuxReport(report);
            else if ((report[11] << 8 | report[12]) == 0xFF33)
                return new TomateReport(report);

            return new OutOfRangeReport(report);
        }
    }
}
