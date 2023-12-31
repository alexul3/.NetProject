﻿using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperEnums;
using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdf
    {
        public void CreateDoc(PdfInfo info)
        {
            CreatePdf(info);
            CreateParagraph(new PdfParagraph
            {
                Text = info.Title,
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            CreateParagraph(new PdfParagraph
            {
                Text = $"с { info.DateFrom.ToShortDateString() } по { info.DateTo.ToShortDateString() }", Style = "Normal",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            CreateTable(new List<string> { "2cm", "3cm", "6cm", "3cm", "3cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Номер", "Дата заказа", "Изделие", "Статус", "Сумма" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            foreach (var order in info.Orders)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { order.Id.ToString(), order.DateCreate.ToShortDateString(), order.ManufactureName, order.Status, order.Sum.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            CreateParagraph(new PdfParagraph
            {
                Text = $"Итого: {info.Orders.Sum(x  => x.Sum)}\t",
                Style = "Normal",
                ParagraphAlignment = PdfParagraphAlignmentType.Right
            });
            SavePdf(info);
        }
		public void CreateDocOrdersByDate(PdfInfoOrdersByDate info)
		{
			CreatePdf(new PdfInfo() { FileName = info.FileName });
			CreateParagraph(new PdfParagraph { Text = info.Title, Style = "NormalTitle", ParagraphAlignment = PdfParagraphAlignmentType.Center });

			CreateTable(new List<string> { "5cm", "4cm", "4cm" });

			CreateRow(new PdfRowParameters
			{
				Texts = new List<string> { "Дата", "Количество", "Сумма" },
				Style = "NormalTitle",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});
			foreach (var order in info.Orders)
			{
				CreateRow(new PdfRowParameters
				{
					Texts = new List<string> { order.DateCreate.ToShortDateString(), order.Count.ToString(), order.Sum.ToString() },
					Style = "Normal",
					ParagraphAlignment = PdfParagraphAlignmentType.Left
				});
			}
			CreateParagraph(new PdfParagraph
			{
				Text = $"Итого: {info.Orders.Sum(x => x.Sum)}\t",
				Style = "Normal",
				ParagraphAlignment = PdfParagraphAlignmentType.Right
			});
			SavePdf(new PdfInfo() { FileName = info.FileName });
		}
        /// <summary>
        /// Создание doc-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreatePdf(PdfInfo info);
        /// <summary>
        /// Создание параграфа с текстом
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateParagraph(PdfParagraph paragraph);
        /// <summary>
        /// Создание таблицы
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateTable(List<string> columns);
        /// <summary>
        /// Создание и заполнение строки
        /// </summary>
        /// <param name="rowParameters"></param>
        protected abstract void CreateRow(PdfRowParameters rowParameters);
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void SavePdf(PdfInfo info);
    }
}
