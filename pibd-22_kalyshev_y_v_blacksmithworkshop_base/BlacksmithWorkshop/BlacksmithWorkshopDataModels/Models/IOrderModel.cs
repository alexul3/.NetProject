using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopDataModels.Enums;

namespace BlacksmithWorkshopDataModels.Models
{
    public interface IOrderModel : IId
    {
        int ManufactureId { get; }
        int ClientId { get; }
        int Count { get; }
        double Sum { get; }
        OrderStatus Status { get; }
        DateTime DateCreate { get; }
        DateTime? DateImplement { get; }
    }
}