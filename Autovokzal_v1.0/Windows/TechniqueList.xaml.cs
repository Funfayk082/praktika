using Autovokzal_v1._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Autovokzal_v1._0.Windows
{
    /// <summary>
    /// Логика взаимодействия для TechniqueList.xaml
    /// </summary>
    public partial class TechniqueList : Window
    {
        ApplicationContext db = new ApplicationContext();
        public TechniqueList()
        {
            InitializeComponent();
        }

        private void TechniqueList_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Techniques.Load();
            DataContext = db.Techniques.Local.ToObservableCollection();
        }

        private void Add_Click_1(object sender, RoutedEventArgs e)
        {
            TechniqueEdit techniqueEdit = new TechniqueEdit(new Technique());
            if (techniqueEdit.ShowDialog() == true)
            {
                Technique technique = techniqueEdit.Technique;
                db.Techniques.Add(technique);
                db.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Technique? technique = techniqueList.SelectedItem as Technique;
            if (technique is null) return;

            //TechniqueEdit techniqueEdit = new TechniqueEdit(new Technique
            //{
            //    Id = technique.Id,
            //    DriveLicense = technique.DriveLicense,
            //    DriverLicGetter = technique.DriverLicGetter,
            //    KatTS = technique.KatTS,
            //    GetDate = technique.GetDate,
            //    LastDate = technique.LastDate,
            //});
            //
            //if (techniqueEdit.ShowDialog() == true)
            //{
            //    technique = db.Techniques.Find(techniqueEdit.Technique.Id);
            //    if (technique != null)
            //    {
            //        technique.DriveLicense = techniqueEdit.Driver.DriveLicense;
            //        technique.DriverLicGetter = techniqueEdit.Driver.DriverLicGetter;
            //        technique.KatTS = techniqueEdit.Driver.KatTS;
            //        technique.GetDate = techniqueEdit.Driver.GetDate;
            //        technique.LastDate = techniqueEdit.Driver.LastDate;
            //        db.SaveChanges();
            //        techniqueList.Items.Refresh();
            //    }
            //}
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Technique? technique = techniqueList.SelectedItem as Technique;
            if (technique is null) return;
            db.Techniques.Remove(technique);
            db.SaveChanges();
        }
    }
}

