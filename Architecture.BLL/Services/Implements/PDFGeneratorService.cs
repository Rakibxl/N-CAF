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

        public async Task<string> GetAllAsync()
        {
            using (FileStream outFile = new FileStream("result.pdf", FileMode.Create))
            {
                PdfReader pdfReader = new PdfReader(@"E:\Projects\Angular Projects\N-CAF\Sample PDF\file.pdf", null);
                //PdfReader.unethicalreading = true;

                PdfStamper pdfStamper = new PdfStamper(pdfReader, outFile);
                AcroFields fields = pdfStamper.AcroFields;

                var val = 1;
                foreach (string key in fields.Fields.Keys)
                {
                    fields.SetField(key, "Test" + val++);
                }

                pdfStamper.Close();
                pdfReader.Close();
            }
            return "Ok";
        }
    }
}
