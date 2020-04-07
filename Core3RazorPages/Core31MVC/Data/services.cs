using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core31MVC.Data
{
    public class MyApplicationAppService: IMyApplicationAppService

    {
        public async Task<IActionResult> ExportV2()
        {
            // query data from database  
            await Task.Yield();
            //var list = db.UploadedFileEntities.ToList();
            var stream = new MemoryStream();

            //using (var package = new ExcelPackage(stream))
            //{
            //    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
            //    workSheet.Cells.LoadFromCollection(list, true);
            //    package.Save();
            //}
            stream.Position = 0;
            string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";



            //return new FileStreamResult(stream, mimeType)
            //{
            //    FileDownloadName = fileName
            //};
            // return System.IO.File(stream, "application/octet-stream", excelName);  
            return new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = excelName
            }; //it doesn't work

        }
    }

    public interface IMyApplicationAppService
    {
        Task<IActionResult> ExportV2();
    }
}
