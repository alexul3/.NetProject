using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.DI
{
    public interface IBusinessLogicImplementationExtension
    {
        /// <summary>
        /// Регистрация сервисов бизнес-логики
        /// </summary>
        public void RegisterServices();
    }
}
