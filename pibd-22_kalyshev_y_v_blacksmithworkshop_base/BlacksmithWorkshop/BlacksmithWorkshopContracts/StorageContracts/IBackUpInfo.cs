using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.StorageContracts
{
    public interface IBackUpInfo
    {
        List<T>? GetList<T>() where T : class, new();
        Type? GetTypeByModelInterface(string modelInterfaceName);
    }
}
