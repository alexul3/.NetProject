using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels
{
	public class WordTable
	{
		public List<(string, int)> Columns { get; set; } = new();
		public List<List<string>> Rows { get; set; } = new();
	}
}
