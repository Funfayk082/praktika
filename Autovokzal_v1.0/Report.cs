using Autovokzal_v1._0.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autovokzal_v1._0.Windows;
using System.Windows.Controls;
using System.IO;

namespace Autovokzal_v1._0
{
    public class Report
    {
        ApplicationContext db = new ApplicationContext();
        string pathToRep = System.IO.Path.GetFullPath(@"..\..\..\Reports\");

        public void Report_to_Excel(ListBox personalList)
        {
            using (ExcelPackage excelPackage = new ExcelPackage(System.IO.Path.Combine(pathToRep, "Отчёт от " + DateOnly.FromDateTime(DateTime.Today) + ".xlsx")))
            {

                string sqlQuery = "SELECT * FROM Personal";

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Personal");

                loadExternalDataSet(sqlQuery, db, worksheet);

                excelPackage.SaveAs(System.IO.Path.Combine(pathToRep, "Отчёт от " + DateOnly.FromDateTime(DateTime.Today) + ".xlsx"));
            }

            for (int i = 0; i < personalList.Items.Count; i++)
            {
                Personal personal = personalList.Items[i] as Personal;
                File.AppendAllText(System.IO.Path.Combine(pathToRep, "Отчёт от " + DateOnly.FromDateTime(DateTime.Today) + ".json"), JsonConvert.SerializeObject(personal));

            }
        }

        private static void loadExternalDataSet(string sqlQuery, ApplicationContext db, ExcelWorksheet worksheet)
        {
            worksheet.Row(1).Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["A1:G1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
            worksheet.Cells["A1"].Value = "Короткий ID";
            worksheet.Cells["B1"].Value = "Имя";
            worksheet.Cells["C1"].Value = "Фамилия";
            worksheet.Cells["D1"].Value = "Отчество";
            worksheet.Cells["E1"].Value = "Дата рождения";
            worksheet.Cells["F1"].Value = "Отдел";
            worksheet.Cells["G1"].Value = "Номер";
            int i = 0;
            while (i < db.Personals.Count())
            {
                var p = db.Personals.Find(i + 1);
                worksheet.Cells["A" + (i + 2)].Value = p.Short_Id;
                worksheet.Cells["B" + (i + 2)].Value = p.Name;
                worksheet.Cells["C" + (i + 2)].Value = p.Surname;
                worksheet.Cells["D" + (i + 2)].Value = p.Patronymic;
                worksheet.Cells["E" + (i + 2)].Value = p.Date;
                worksheet.Cells["F" + (i + 2)].Value = p.Otdel;
                worksheet.Cells["G" + (i + 2)].Value = p.Phone;
                i++;
            }
            using (SqlConnection connection = new SqlConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
            {
                return;
            }
        }

        public void Report_to_Json(ListBox personalList)
        {
            for (int i = 0; i < personalList.Items.Count; i++)
            {
                Personal personal = personalList.Items[i] as Personal;
                File.AppendAllText(System.IO.Path.Combine(pathToRep, "Отчёт от " + DateOnly.FromDateTime(DateTime.Today) + ".json"), JsonConvert.SerializeObject(personal));
            }
        }
    }
}
