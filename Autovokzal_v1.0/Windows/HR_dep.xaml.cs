using Autovokzal_v1._0.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Autovokzal_v1._0;
using System.Windows.Controls;
using System.ComponentModel;
using Autovokzal_v1._0.Windows;

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

        int item;

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Report report = new Report();
            if (item == 1)
            {
                report.Report_to_Excel(personalList);
            }
            else if (item == 2)
            {
                report.Report_to_Json(personalList);
            }
            else
            {
                MessageBox.Show("Выберите формат отчёта", "Не выбран формат", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void RF_choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? comboBox = (ComboBox)sender;
            ComboBoxItem? selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem == xlsx)
            {
                item = 1;
            }
            else if (selectedItem == json)
            {
                item = 2;
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            SortParams sortParams= new SortParams();
            personalList.Items.SortDescriptions.Clear();
            if (sortParams.ShowDialog() == true)
            {
                ListBoxItem lbi = (ListBoxItem)(sortParams.selectSortParams.ItemContainerGenerator.ContainerFromIndex(sortParams.selectSortParams.SelectedIndex));
                personalList.Items.SortDescriptions.Add(new SortDescription(lbi.Name, sortParams.ascending.IsChecked == true ? ListSortDirection.Ascending : ListSortDirection.Descending));
            }
        }
    }
}
