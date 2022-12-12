using Autovokzal_v1._0.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace Autovokzal_v1._0
{
    public partial class HR_dep : Window
    {
        ApplicationContext db = new ApplicationContext();

        public HR_dep()
        {
            InitializeComponent();

            Loaded += HR_dep_Loaded;
        }

        private void HR_dep_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Personals.Load();
            DataContext = db.Personals.Local.ToObservableCollection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PersonalWindow personalWindow = new PersonalWindow(new Personal());
            if (personalWindow.ShowDialog() == true)
            {
                Personal personal = personalWindow.Personal;
                db.Personals.Add(personal);
                db.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Personal? personal = personalList.SelectedItem as Personal;
            if (personal is null) return;

            PersonalWindow personalWindow = new PersonalWindow(new Personal
            {
                Id = personal.Id,
                Short_Id = personal.Short_Id,
                Date = personal.Date,
                Name = personal.Name,
                Surname = personal.Surname,
                Patronymic = personal.Patronymic,
                Otdel = personal.Otdel,
                Phone = personal.Phone
            });

            if (personalWindow.ShowDialog() == true)
            {
                personal = db.Personals.Find(personalWindow.Personal.Id);
                if (personal != null)
                {
                    personal.Short_Id = personalWindow.Personal.Short_Id;
                    personal.Date = personalWindow.Personal.Date;
                    personal.Name = personalWindow.Personal.Name;
                    personal.Surname = personalWindow.Personal.Surname;
                    personal.Patronymic = personalWindow.Personal.Patronymic;
                    personal.Otdel = personalWindow.Personal.Otdel;
                    personal.Phone = personalWindow.Personal.Phone;
                    db.SaveChanges();
                    personalList.Items.Refresh();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Personal? personal = personalList.SelectedItem as Personal;
            if (personal is null) return;
            db.Personals.Remove(personal);
            db.SaveChanges();
        }


        private void Report_Click(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.GetFullPath(@"..\..\..");
            using (ExcelPackage excelPackage = new ExcelPackage(System.IO.Path.Combine(path, "Отчёт от " + DateOnly.FromDateTime(DateTime.Today) + ".xlsx")))
            {

                string sqlQuery = "SELECT * FROM Personal";

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Personal");

                loadExternalDataSet(sqlQuery, db, worksheet);

                excelPackage.SaveAs(System.IO.Path.Combine(path, "Отчёт от " + DateOnly.FromDateTime(DateTime.Today) + ".xlsx"));
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
                worksheet.Cells["D" + (i + 2)].Value = p.Phone;
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
    }
}
