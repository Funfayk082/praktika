using Autovokzal_v1._0.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

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
            using (ExcelPackage excelPackage = new ExcelPackage(System.IO.Path.Combine(path, "Отчёт от "+DateOnly.FromDateTime(DateTime.Today) + ".xlsx"), "password"))
            {

                string sqlQuery = "SELECT * FROM Personal";

                DataTable dataTable = loadExternalDataSet(sqlQuery);

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Personal");

                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
                excelPackage.SaveAs(System.IO.Path.Combine(path, "Отчёт от " + DateOnly.FromDateTime(DateTime.Today) + ".xlsx"), "password");
            }
        }

        public static DataTable loadExternalDataSet(string sqlQuery)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID"));
            dt.Columns.Add(new DataColumn("Имя"));
            dt.Columns.Add(new DataColumn("Фамилия"));
            dt.Columns.Add(new DataColumn("Отчество"));
            dt.Columns.Add(new DataColumn("Дата рождения"));
            dt.Columns.Add(new DataColumn("Отдел"));
            dt.Columns.Add(new DataColumn("Номер"));
            dt.Rows.Add(dt);
            using (SqlConnection connection = new SqlConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
            {
                try
                {
                    adapter.Fill(dt);
                }
                catch
                {
                }
            }
            return dt;
        }
    }
}
