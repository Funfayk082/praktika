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
            //if (string.IsNullOrEmpty(Number.Text) || (string.IsNullOrEmpty(WhoIsIt.Text)) || (string.IsNullOrEmpty(Kat.Text)) ||
            //    (string.IsNullOrEmpty(FD.Text)) || (string.IsNullOrEmpty(LD.Text)))
            //{
            //    MessageBox.Show("Все поля не должны быть пустыми!", "Пустые поля", MessageBoxButton.OK, MessageBoxImage.Error);
            //    Close();
            //}
            //else
            //{
            //    DialogResult = true;
            //}
        }
    }
}
