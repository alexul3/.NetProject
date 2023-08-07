﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BusinessLogicsContracts
{
	public interface IWorkProcess
	{
		/// <summary>
		/// Запуск работ
		/// </summary>
		void DoWork(IImplementerLogic implementerLogic, IOrderLogic orderLogic);
	}
}
