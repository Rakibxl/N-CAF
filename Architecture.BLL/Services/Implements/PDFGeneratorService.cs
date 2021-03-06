using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Architecture.Core.Common.Enums;
using Architecture.Core.Repository.Extensions;
using Architecture.BLL.Services.Exceptions;
using Architecture.Core.Common.Constants;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Query;
using Architecture.Core.Common.Helpers;
using System.IO;
using iTextSharp.text.pdf;

namespace Architecture.BLL.Services.Implements
{
    public class PDFGeneratorService : IPDFGeneratorService
    {
        public PDFGeneratorService()
        {

        }

        public string GeneratePDF()
        {
            var srcPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Input PDF", "Bonus Baby.pdf");
            var pdfName = "Bonus Baby_" + "1001" + ".pdf";
            var destPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Generated PDF", pdfName);
            using (FileStream outFile = new FileStream(destPath, FileMode.Create, FileAccess.Write))
            {
                PdfReader pdfReader = new PdfReader(srcPath);
                PdfReader.unethicalreading = true;

                PdfStamper pdfStamper = new PdfStamper(pdfReader, outFile);
                AcroFields fields = pdfStamper.AcroFields;

                var val = 1;
                foreach (string key in fields.Fields.Keys)
                {
                    String[] checkboxstates = fields.GetAppearanceStates(key);
                    var type = fields.GetFieldType(key);
                    if (type == AcroFields.FIELD_TYPE_CHECKBOX)
                    {
                        //fields.SetField(key, "true");
                        //fields.SetField(key, "Yes");
                        //fields.SetField(key, checkboxstates[0]);

                        fields.SetField(key, "1");
                        continue;
                    }
                    if (type == AcroFields.FIELD_TYPE_RADIOBUTTON)
                    {
                        //fields.SetField(key, "true");
                        //fields.SetField(key, "Yes");
                        //fields.SetField(key, checkboxstates[0]);

                        fields.SetField(key, "Yes");
                        continue;
                    }
                    fields.SetField(key, "Data" + val++);
                }

                pdfStamper.Close();
                pdfReader.Close();
            }
            return pdfName;
        }
    }
}
