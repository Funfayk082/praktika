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
using Autovokzal_v1._0.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Autovokzal_v1._0.Windows
{
    /// <summary>
    /// Логика взаимодействия для TechniqueEdit.xaml
    /// </summary>
    public partial class TechniqueEdit : Window
    {
        public Technique Technique { get; set; }
        public TechniqueEdit(Technique technique)
        {
            InitializeComponent();
            Technique = technique;
            DataContext = Technique;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Mark.Text) || (string.IsNullOrEmpty(Model.Text)) || (string.IsNullOrEmpty(Color.Text)) ||
                (string.IsNullOrEmpty(GovNumber.Text)) || (string.IsNullOrEmpty(Type.Text)) || (string.IsNullOrEmpty(Volume.Text)) ||
                (string.IsNullOrEmpty(FuelCons.Text)) || (string.IsNullOrEmpty(LC.Text)) || (string.IsNullOrEmpty(VIN.Text)))
            {
                MessageBox.Show("Все поля не должны быть пустыми!", "Пустые поля", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
