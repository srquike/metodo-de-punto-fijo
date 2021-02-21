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

namespace metodo_de_punto_fijo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private IList<Iteracion> iteraciones;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            Iteracion iteracionAnterior, iteracion;
            int i;

            if (double.TryParse(TxtValorX.Text, out double x) && !string.IsNullOrEmpty(TxtValorX.Text))
            {
                iteraciones = new List<Iteracion>();
                iteracionAnterior = new Iteracion();
                i = 0;

                do
                {
                    iteracion = new Iteracion();
                    iteracion.I = i;

                    if (iteracion.I == 0)
                    {
                        iteracion.Xi = x;
                    }
                    else
                    {
                        iteracion.Xi = iteracionAnterior.Gx;
                    }

                    iteracion.Gx = 490 / (9.81 * (1 - Math.Pow(Math.E, -(98 / iteracion.Xi))));
                    iteracion.Error = Math.Abs((iteracion.Xi - iteracionAnterior.Xi) / iteracion.Xi) * 100;

                    iteraciones.Add(iteracion);
                    iteracionAnterior = iteracion;
                    i++;

                } while (Math.Round(iteracion.Error, 3) != 0.001);

                DgIteraciones.ItemsSource = iteraciones;
            }
            else
            {
                MessageBox.Show("El valor de X0 es incorrecto.");
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TxtValorX.Clear();
            DgIteraciones.ItemsSource = null;
            TxtValorX.Focus();
        }
    }
}