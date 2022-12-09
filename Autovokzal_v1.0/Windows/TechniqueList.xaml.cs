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

            TechniqueEdit techniqueEdit = new TechniqueEdit(new Technique
            {
                Id = technique.Id,
                Mark = technique.Mark,
                Model = technique.Model,
                Color = technique.Color,
                GovNumber = technique.GovNumber,
                Type = technique.Type,
                Volume = technique.Volume,
                FuelCons = technique.FuelCons,
                LC = technique.LC,
                VIN = technique.VIN
            });
            
            if (techniqueEdit.ShowDialog() == true)
            {
                technique = db.Techniques.Find(techniqueEdit.Technique.Id);
                if (technique != null)
                {
                    technique.Mark = techniqueEdit.Technique.Mark;
                    technique.Model = techniqueEdit.Technique.Model;
                    technique.Color = techniqueEdit.Technique.Color;
                    technique.GovNumber = techniqueEdit.Technique.GovNumber;
                    technique.Type = techniqueEdit.Technique.Type;
                    technique.Volume = techniqueEdit.Technique.Volume;
                    technique.FuelCons = techniqueEdit.Technique.FuelCons;
                    technique.LC = techniqueEdit.Technique.LC;
                    technique.VIN = techniqueEdit.Technique.VIN;
                    db.SaveChanges();
                    techniqueList.Items.Refresh();
                }
            }
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

