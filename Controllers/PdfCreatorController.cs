﻿using DinkToPdf;
using Microsoft.AspNetCore.Mvc;
using DinkToPdf.Contracts;
using System.IO;

namespace Software04._12._2020.Controllers
{
    [Route("api/pdfcreator")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private IConverter _converter;
        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }
        [HttpGet]
        public IActionResult CreatePDF()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"D:\PDFCreator\Employee_Report.pdf"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
               /* HtmlContent = Utility.TemplateGenerator.GetHTMLString(),*/
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            return Ok("Successfully created PDF document.");
        }
    }
}
