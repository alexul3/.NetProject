using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperEnums;
using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            foreach (var manufacture in info.Manufactures)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)>
                    {
                        (manufacture.ManufactureName, new WordTextProperties { Bold = true, Size = "24", }),
                        (", price: " + manufacture.Price.ToString(), new WordTextProperties { Size = "24", })
                    },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord(info);
        }
		public void CreateDocShopTable(WordInfoShopTable info)
		{
			CreateWord(new() { FileName = info.FileName });
			CreateParagraph(new WordParagraph
			{
				Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
				TextProperties = new WordTextProperties
				{
					Size = "24",
					JustificationType = WordJustificationType.Center
				}
			});
			CreateTable(new()
			{
				Columns = new() { ("Название", 3000), ("Дата открытия", 3000), ("Адрес", 3000) },
				Rows = info.Shops.Select(x => new List<string>
					{
						x.ShopName,
						Convert.ToString(x.DateOpening),
						x.Address,
					})
					.ToList()
			});

			SaveWord(new() { FileName = info.FileName });
		}
        /// <summary>
        /// Создание doc-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreateWord(WordInfo info);
        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateParagraph(WordParagraph paragraph);
        /// <summary>
		/// Создание таблицы
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		protected abstract void CreateTable(WordTable table);
		/// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void SaveWord(WordInfo info);
    }
}
