using Autovokzal_v1._0.Models;
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
    /// Логика взаимодействия для PersSelected.xaml
    /// </summary>
    public partial class PersSelected : Window
    {
        public PersSelected(Personal personal)
        {
            this.Title = ("Сотрудник " + personal.Id).ToString();
            InitializeComponent();
            PersView(personal);
        }

        public void PersView(Personal personal)
        {
            Short_Id.Text = personal.Short_Id.ToString();
            Surname.Text = personal.Surname;
            Name.Text = personal.Name;
            Patronymic.Text = personal.Patronymic;
            Date.Text = personal.Date.ToString();
            Otdel.Text = personal.Otdel;
            Phone.Text = personal.Phone.ToString();
        }
    }
}
