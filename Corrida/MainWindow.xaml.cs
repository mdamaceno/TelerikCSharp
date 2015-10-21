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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Corrida
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var locais = Corrida_DB.CorridaBanco.Model.Locals.OrderBy(o => o.Cidade).ToList();

            cmbLocal.ItemsSource = locais;
            cmbLocal.DisplayMemberPath = "Cidade";

            var corridas = Corrida_DB.CorridaBanco.Model.Corridas.ToList();
            grdCorrida.ItemsSource = corridas;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var corrida = new Corrida_DB.Corrida()
            {
                DataCorrida = DateTime.Now,
                Distancia = 42,
                Local = (Corrida_DB.Local)cmbLocal.SelectedItem,
                Nome = "Maratona da Bahia",
                Valor = 50
            };

            Corrida_DB.CorridaBanco.Model.Add(corrida);

            if (Corrida_DB.CorridaBanco.Model.HasChanges)
            {
                Corrida_DB.CorridaBanco.Model.SaveChanges();
            }

            var corridas = Corrida_DB.CorridaBanco.Model.Corridas.ToList();
            grdCorrida.ItemsSource = corridas;
            grdCorrida.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var corrida = (Corrida_DB.Corrida)grdCorrida.SelectedItem;

            Corrida_DB.CorridaBanco.Model.Delete(corrida);

            if (Corrida_DB.CorridaBanco.Model.HasChanges)
            {
                Corrida_DB.CorridaBanco.Model.SaveChanges();
            }

            var corridas = Corrida_DB.CorridaBanco.Model.Corridas.ToList();
            grdCorrida.ItemsSource = corridas;
            grdCorrida.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var corrida = (Corrida_DB.Corrida)grdCorrida.SelectedItem;

            corrida.Nome = "Corrida de Porto Alegre";

            if (Corrida_DB.CorridaBanco.Model.HasChanges)
            {
                Corrida_DB.CorridaBanco.Model.SaveChanges();
            }

            var corridas = Corrida_DB.CorridaBanco.Model.Corridas.ToList();
            grdCorrida.ItemsSource = corridas;
            grdCorrida.Items.Refresh();
        }
    }
}
