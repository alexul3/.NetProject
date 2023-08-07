﻿using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperEnums;
using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Document = DocumentFormat.OpenXml.Wordprocessing.Document;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage.Implements
{
    public class SaveToWord : AbstractSaveToWord
    {
        private WordprocessingDocument? _wordDocument;
        private Body? _docBody;
        /// <summary>
        /// Получение типа выравнивания
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static JustificationValues GetJustificationValues(WordJustificationType type)
        {
            return type switch
            {
                WordJustificationType.Both => JustificationValues.Both,
                WordJustificationType.Center => JustificationValues.Center,
                _ => JustificationValues.Left,
            };
        }
        /// <summary>
        /// Настройки страницы
        /// </summary>
        /// <returns></returns>
        private static SectionProperties CreateSectionProperties()
        {
            var properties = new SectionProperties();
            var pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };
            properties.AppendChild(pageSize);
            return properties;
        }
        /// <summary>
        /// Задание форматирования для абзаца
        /// </summary>
        /// <param name="paragraphProperties"></param>
        /// <returns></returns>
        private static ParagraphProperties? CreateParagraphProperties(WordTextProperties? paragraphProperties)
        {
            if (paragraphProperties == null)
            {
                return null;
            }
            var properties = new ParagraphProperties();
            properties.AppendChild(new Justification()
            {
                Val = GetJustificationValues(paragraphProperties.JustificationType)
            });
            properties.AppendChild(new SpacingBetweenLines
            {
                LineRule = LineSpacingRuleValues.Auto
            });
            properties.AppendChild(new Indentation());
            var paragraphMarkRunProperties = new ParagraphMarkRunProperties();
            if (!string.IsNullOrEmpty(paragraphProperties.Size))
            {
                paragraphMarkRunProperties.AppendChild(new FontSize
                {
                    Val = paragraphProperties.Size
                });
            }
            properties.AppendChild(paragraphMarkRunProperties);
            return properties;
        }
        protected override void CreateWord(WordInfo info)
        {
            _wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document);
            MainDocumentPart mainPart = _wordDocument.AddMainDocumentPart();
            mainPart.Document = new Document();
            _docBody = mainPart.Document.AppendChild(new Body());
        }
        protected override void CreateParagraph(WordParagraph paragraph)
        {
            if (_docBody == null || paragraph == null)
            {
                return;
            }
            var docParagraph = new Paragraph();
            docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
            foreach (var run in paragraph.Texts)
            {
                var docRun = new Run();
                var properties = new RunProperties();
                properties.AppendChild(new FontSize { Val = run.Item2.Size });
                if (run.Item2.Bold)
                {
                    properties.AppendChild(new Bold());
                }
                docRun.AppendChild(properties);
                docRun.AppendChild(new Text
                {
                    Text = run.Item1,
                    Space = SpaceProcessingModeValues.Preserve
                });
                docParagraph.AppendChild(docRun);
            }
            _docBody.AppendChild(docParagraph);
        }
		private static TableCell CreateTableCell(string text, int? cellWidth = null)
		{
			TableCell tableCell = new(new Paragraph(new Run(new Text(text))));
			tableCell.Append(new TableCellProperties()
			{
				TableCellWidth = new() { Width = cellWidth.ToString() }
			});
			return tableCell;
		}
		protected override void CreateTable(WordTable table)
		{
			if (_docBody == null || table == null)
			{
				return;
			}
			var docTable = new Table();

			TableProperties tableProperties = new(
				new TableBorders(
					new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicBlackDashes), Size = 3 },
					new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicBlackDashes), Size = 3 },
					new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicBlackDashes), Size = 3 },
					new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicBlackDashes), Size = 3 },
					new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicBlackDashes), Size = 3 },
					new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.BasicBlackDashes), Size = 3 }
				)
			);
			docTable.AppendChild(tableProperties);

			docTable.Append(new TableRow(table.Columns.Select(x => CreateTableCell(x.Item1, x.Item2))));
			docTable.Append(table.Rows.Select(x => new TableRow(x.Select(y => CreateTableCell(y)))));

			_docBody.AppendChild(docTable);
		}
        protected override void SaveWord(WordInfo info)
        {
            if (_docBody == null || _wordDocument == null)
            {
                return;
            }
            _docBody.AppendChild(CreateSectionProperties());
            _wordDocument.MainDocumentPart!.Document.Save();
            _wordDocument.Close();
        }
    }
}
