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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using Autovokzal_v1._0.Models;

namespace Autovokzal_v1._0
{
    /// <summary>
    /// Логика взаимодействия для PersonalWindow.xaml
    /// </summary>
    public partial class PersonalWindow : Window
    {
        
        public Personal Personal { get; private set; }
        public PersonalWindow(Personal personal)
        {
            InitializeComponent();
            Personal = personal;
            DataContext = Personal;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SI.Text) || (string.IsNullOrEmpty(Name.Text)) || (string.IsNullOrEmpty(SName.Text)) ||
                (string.IsNullOrEmpty(Patr.Text)) || (string.IsNullOrEmpty(Date.Text)) || (string.IsNullOrEmpty(Otdel.Text)))
            {
                MessageBox.Show("Все поля, кроме номера телефона, не должны быть пустыми!", "Пустые поля", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
