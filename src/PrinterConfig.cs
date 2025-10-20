using System;
using System.Drawing;
using System.Drawing.Printing;

namespace dyfilm_client_v2._0.src
{
    public static class PrinterConfig
    {
        public enum PrinterType
        {
            SELPHY_CP1300,
            DNP_DP_QW410
        }

        public static PrinterSettings GetDefaultPrinterSettings()
        {
            return new PrinterSettings();
        }

        public static PrinterType GetCurrentPrinterType()
        {
            string printerTypeStr = ConfigManager.GetValue("printer_type");
            if (Enum.TryParse<PrinterType>(printerTypeStr, out PrinterType printerType))
            {
                return printerType;
            }
            return PrinterType.SELPHY_CP1300;
        }

        public static void SetPrinterType(PrinterType printerType)
        {
            ConfigManager.SetValue("printer_type", printerType.ToString());
        }

        public static string GetPrinterDisplayName(PrinterType printerType)
        {
            switch (printerType)
            {
                case PrinterType.SELPHY_CP1300:
                    return "SELPHY CP1300";
                case PrinterType.DNP_DP_QW410:
                    return "DNP DP-QW410";
                default:
                    return "알 수 없는 프린터";
            }
        }

        public static PaperSize GetPaperSize(PrinterType printerType)
        {
            switch (printerType)
            {
                case PrinterType.SELPHY_CP1300:
                    return new PaperSize("SELPHY 4x6", 394, 583);
                case PrinterType.DNP_DP_QW410:
                    foreach (PaperSize paperSize in GetDefaultPrinterSettings().PaperSizes)
                    {
                        if (paperSize.PaperName == "(4x6)")
                            return paperSize;
                    }

                    // If not found
                    return new PaperSize("Default", 400, 600);
                default:
                    return new PaperSize("Default", 400, 600);
            }
        }

        public static Margins GetMargins(PrinterType printerType)
        {
            switch (printerType)
            {
                case PrinterType.SELPHY_CP1300:
                    return new Margins(0, 0, 0, 0);
                case PrinterType.DNP_DP_QW410:
                    return new Margins(0, 0, 0, 0);
                default:
                    return new Margins(0, 0, 0, 0);
            }
        }

        public static bool ShouldRotateImage(PrinterType printerType)
        {
            switch (printerType)
            {
                case PrinterType.SELPHY_CP1300:
                    return true;
                case PrinterType.DNP_DP_QW410:
                    return true;
                default:
                    return true;
            }
        }

        public static RectangleF CalculateImageBounds(PrinterType printerType, Image img, Rectangle bounds)
        {
            float printableWidth = bounds.Width;
            float printableHeight = bounds.Height;

            float imgAspect = (float)img.Width / img.Height;
            float paperAspect = printableWidth / printableHeight;

            float drawWidth, drawHeight;
            float offsetX = 0, offsetY = 0;

            if (imgAspect > paperAspect)
            {
                drawWidth = printableWidth;
                drawHeight = printableWidth / imgAspect;
                offsetY = (printableHeight - drawHeight) / 2;
            }
            else
            {
                drawHeight = printableHeight;
                drawWidth = printableHeight * imgAspect;
                offsetX = (printableWidth - drawWidth) / 2;
            }

            return new RectangleF(offsetX, offsetY, drawWidth, drawHeight);
        }
    }
}
