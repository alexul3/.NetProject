using BlacksmithWorkshopBusinessLogic.BusinessLogics;
using BlacksmithWorkshopBusinessLogic.OfficePackage;
using BlacksmithWorkshopBusinessLogic.OfficePackage.Implements;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using ManufactureCompanyBusinessLogic.BusinessLogics;
using BlacksmithWorkshopBusinessLogic.MailWorker;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.DI;

namespace BlacksmithWorkshopView
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InitDependency();
            try
			{
				var mailSender = DependencyManager.Instance.Resolve<AbstractMailWorker>();
                mailSender?.MailConfig(new MailConfigBindingModel
				{
					MailLogin = System.Configuration.ConfigurationManager.AppSettings["MailLogin"] ?? string.Empty,
					MailPassword = System.Configuration.ConfigurationManager.AppSettings["MailPassword"] ?? string.Empty,
					SmtpClientHost = System.Configuration.ConfigurationManager.AppSettings["SmtpClientHost"] ?? string.Empty,
					SmtpClientPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"]),
					PopHost = System.Configuration.ConfigurationManager.AppSettings["PopHost"] ?? string.Empty,
					PopPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PopPort"])
				});
                // Создаем таймер
				var timer = new System.Threading.Timer(new TimerCallback(MailCheck!), null, 0, 100000);
			}
			catch (Exception ex)
			{
				var logger = DependencyManager.Instance.Resolve<ILogger>();
                logger?.LogError(ex, "Ошибка работы с почтой");
			}

			Application.Run(DependencyManager.Instance.Resolve<FormMain>());
        }
        private static void InitDependency()
        {
            DependencyManager.InitDependency();

            DependencyManager.Instance.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });

            DependencyManager.Instance.RegisterType<AbstractSaveToExcel, SaveToExcel>();
            DependencyManager.Instance.RegisterType<AbstractSaveToWord, SaveToWord>();
            DependencyManager.Instance.RegisterType<AbstractSaveToPdf, SaveToPdf>();
            DependencyManager.Instance.RegisterType<IWorkProcess, WorkModeling>();
            DependencyManager.Instance.RegisterType<AbstractMailWorker, MailKitWorker>(true);
            DependencyManager.Instance.RegisterType<IBackUpLogic, BackUpLogic>();

            DependencyManager.Instance.RegisterType<FormMain>();
            DependencyManager.Instance.RegisterType<FormComponent>();
            DependencyManager.Instance.RegisterType<FormComponents>();
            DependencyManager.Instance.RegisterType<FormCreateOrder>();
            DependencyManager.Instance.RegisterType<FormManufacture>();
            DependencyManager.Instance.RegisterType<FormManufacturies>();
            DependencyManager.Instance.RegisterType<FormManufactureComponent>();
            DependencyManager.Instance.RegisterType<FormReportManufactureComponents>();
            DependencyManager.Instance.RegisterType<FormReportOrders>();
            DependencyManager.Instance.RegisterType<FormClients>();
            DependencyManager.Instance.RegisterType<FormImplementers>();
            DependencyManager.Instance.RegisterType<FormImplementer>();
            DependencyManager.Instance.RegisterType<FormMessages>();
            DependencyManager.Instance.RegisterType<FormMessage>();
        }
        private static void MailCheck(object obj) => DependencyManager.Instance.Resolve<AbstractMailWorker>()?.MailCheck();
    }
}
