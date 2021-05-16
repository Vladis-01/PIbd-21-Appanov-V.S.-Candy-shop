using CandyShopBusinessLogic.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;

namespace CandyShopBusinessLogic.BusinessLogics
{
	public static class SaveToWord
	{
		/// <summary>
		/// Создание документа
		/// </summary>
		/// <param name="info"></param>
		public static void CreateDoc(WordInfo info)
		{
			using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document))
			{
				MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
				mainPart.Document = new Document();
				Body docBody = mainPart.Document.AppendChild(new Body());
				docBody.AppendChild(CreateParagraph(new WordParagraph
				{
					Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
					TextProperties = new WordTextProperties
					{
						Size = "24",
						JustificationValues = JustificationValues.Center
					}
				}));
				foreach (var pastry in info.Pastrys)
				{
					docBody.AppendChild(CreateParagraph(new WordParagraph
					{
						Texts = new List<(string, WordTextProperties)> { ($"{pastry.PastryName}: ", new WordTextProperties { Size = "24", Bold = true }), (pastry.Price.ToString(), new WordTextProperties { Size = "24" }) },
						TextProperties = new WordTextProperties
						{
							Size = "24",
							JustificationValues = JustificationValues.Both
						}
					}));
				}
				docBody.AppendChild(CreateSectionProperties());
				wordDocument.MainDocumentPart.Document.Save();
			}
		}
		/// <summary>
		/// Настройки страницы
		/// </summary>
		/// <returns></returns>
		private static SectionProperties CreateSectionProperties()
		{
			SectionProperties properties = new SectionProperties();
			PageSize pageSize = new PageSize
			{
				Orient = PageOrientationValues.Portrait
			};
			properties.AppendChild(pageSize);
			return properties;
		}
		/// <summary>
		/// Создание абзаца с текстом
		/// </summary>
		/// <param name="paragraph"></param>
		/// <returns></returns>
		private static Paragraph CreateParagraph(WordParagraph paragraph)
		{
			if (paragraph != null)
			{
				Paragraph docParagraph = new Paragraph();
				docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
				foreach (var run in paragraph.Texts)
				{
					Run docRun = new Run();
					RunProperties properties = new RunProperties();
					properties.AppendChild(new FontSize { Val = run.Item2.Size });
					if (run.Item2.Bold)
					{
						properties.AppendChild(new Bold());
					}
					docRun.AppendChild(properties);
					docRun.AppendChild(new Text { Text = run.Item1, Space = SpaceProcessingModeValues.Preserve });
					docParagraph.AppendChild(docRun);
				}
				return docParagraph;
			}
			return null;
		}
		/// <summary>
		/// Задание форматирования для абзаца
		/// </summary>
		/// <param name="paragraphProperties"></param>
		/// <returns></returns>
		private static ParagraphProperties CreateParagraphProperties(WordTextProperties paragraphProperties)
		{
			if (paragraphProperties != null)
			{
				ParagraphProperties properties = new ParagraphProperties();
				properties.AppendChild(new Justification()
				{
					Val = paragraphProperties.JustificationValues
				});
				properties.AppendChild(new SpacingBetweenLines
				{
					LineRule = LineSpacingRuleValues.Auto
				});
				properties.AppendChild(new Indentation());
				ParagraphMarkRunProperties paragraphMarkRunProperties = new ParagraphMarkRunProperties();
				if (!string.IsNullOrEmpty(paragraphProperties.Size))
				{
					paragraphMarkRunProperties.AppendChild(new FontSize { Val = paragraphProperties.Size });
				}
				properties.AppendChild(paragraphMarkRunProperties);
				return properties;
			}
			return null;
		}

		public static void CreateDocStorages(WordInfo info)
		{
			using (WordprocessingDocument doc
			= WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document))
			{
				MainDocumentPart mainPart = doc.AddMainDocumentPart();
				mainPart.Document = new Document();
				Body docBody = mainPart.Document.AppendChild(new Body());
				Table table = new Table();
				TableProperties tblProp = new TableProperties(
					new TableBorders(
						new TopBorder()
						{
							Val =
							new EnumValue<BorderValues>(BorderValues.Single),
							Size = 12
						},
						new BottomBorder()
						{
							Val =
							new EnumValue<BorderValues>(BorderValues.Single),
							Size = 12
						},
						new LeftBorder()
						{
							Val =
							new EnumValue<BorderValues>(BorderValues.Single),
							Size = 12
						},
						new RightBorder()
						{
							Val =
							new EnumValue<BorderValues>(BorderValues.Single),
							Size = 12
						},
						new InsideHorizontalBorder()
						{
							Val =
							new EnumValue<BorderValues>(BorderValues.Single),
							Size = 12
						},
						new InsideVerticalBorder()
						{
							Val =
							new EnumValue<BorderValues>(BorderValues.Single),
							Size = 12
						}
					)
				);
				docBody.AppendChild(CreateParagraph(new WordParagraph
				{
					Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
					TextProperties = new WordTextProperties
					{
						Size = "24",
						JustificationValues = JustificationValues.Center
					}
				}));
				table.AppendChild(tblProp);
				TableRow rowHeader = new TableRow();
				TableCell cellHeaderName = new TableCell();
				cellHeaderName.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3100" }));
				cellHeaderName.Append(new Paragraph(new Run(new Text("Название склада"))));
				TableCell cellHeaderFIO = new TableCell();
				cellHeaderFIO.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3100" }));
				cellHeaderFIO.Append(new Paragraph(new Run(new Text("Имя ответственного"))));
				TableCell cellHeaderDateCreate = new TableCell();
				cellHeaderDateCreate.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3100" }));
				cellHeaderDateCreate.Append(new Paragraph(new Run(new Text("Дата создания"))));
				rowHeader.Append(cellHeaderName);
				rowHeader.Append(cellHeaderFIO);
				rowHeader.Append(cellHeaderDateCreate);
				table.Append(rowHeader);
				foreach (var storage in info.Storages)
				{
					TableRow tr = new TableRow();

					TableCell tc1 = new TableCell();
					tc1.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3100" }));
					tc1.Append(new Paragraph(new Run(new Text(storage.StorageName))));
					tr.Append(tc1);

					TableCell tc2 = new TableCell();
					tc2.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3100" }));
					tc2.Append(new Paragraph(new Run(new Text(storage.StorageManager))));
					tr.Append(tc2);

					TableCell tc3 = new TableCell();
					tc3.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "3100" }));
					tc3.Append(new Paragraph(new Run(new Text(storage.DateCreate.ToString()))));
					tr.Append(tc3);

					table.Append(tr);
				}
				docBody.AppendChild(table);
				doc.MainDocumentPart.Document.Save();
			}
		}
	}
}