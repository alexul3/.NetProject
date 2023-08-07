using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopListImplement.Models;

namespace BlacksmithWorkshopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton? _instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Manufacture> Manufactures { get; set; }
        public List<Client> Clients { get; set; }
		public List<Implementer> Implementers { get; set; }
        public List<Shop> Shops { get; set; }
		public List<MessageInfo> MessageInfos { get; set; }
		private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Manufactures = new List<Manufacture>();
            Shops = new List<Shop>();
            Clients = new List<Client>();
			Implementers = new List<Implementer>();
			MessageInfos = new List<MessageInfo>();
		}
        public static DataListSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataListSingleton();
            }
            return _instance;
        }
    }
}
