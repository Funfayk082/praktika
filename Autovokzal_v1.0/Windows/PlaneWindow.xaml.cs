using Autovokzal_v1._0.Models;
using Autovokzal_v1._0.Windows;
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

namespace Autovokzal_v1._0
{
    /// <summary>
    /// Логика взаимодействия для PlaneWindow.xaml
    /// </summary>
    public partial class PlaneWindow : Window
    {
        public PlaneWindow()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DriversList driversList = new DriversList();
            driversList.Show();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            TechniqueList techniqueList = new TechniqueList();
            techniqueList.Show();
        }
    }
}
