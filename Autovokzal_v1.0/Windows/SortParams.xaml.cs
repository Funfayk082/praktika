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
    /// Логика взаимодействия для SortParams.xaml
    /// </summary>
    public partial class SortParams : Window
    {
        public SortParams()
        {
            InitializeComponent();
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
