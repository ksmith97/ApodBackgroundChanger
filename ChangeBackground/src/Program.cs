using ChangeBackground.Util;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeBackground
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        private static void SetupLogging()
        {
            // BasicConfigurator replaced with XmlConfigurator.
            XmlConfigurator.Configure(new System.IO.FileInfo("ChangeBackground.exe.config"));
        }

        static void Main(string[] args)
        {
            SetupLogging();

            logger.Info("Started");

            try
            {
                Util.ApodResult result = Util.Apod.GetDailyData();
                logger.Debug("Retrieved Apod data. Setting image as background.");
                Wallpaper.Set(new Uri(result.hdurl), Wallpaper.Style.Stretched);
            }
            catch (Exception e)
            {
                logger.Error("An unhandled exception occurred.", e);
            }
            finally
            {
                logger.Info("Stopped");
                logger.Info("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
