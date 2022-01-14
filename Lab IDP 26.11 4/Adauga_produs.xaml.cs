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

namespace Lab_IDP_26._11_4
{
    /// <summary>
    /// Interaction logic for Adauga_produs.xaml
    /// </summary>
    public partial class Adauga_produs : Window
    {
        public Adauga_produs( )
        {
            InitializeComponent( );
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            Produs p = new Produs( );
            p.adaugaProdus( numeProdus_Txt.Text, pretProdus_Txt.Text );
            MessageBox.Show( "Produs adaugat cu succes!" );
            this.Close( );
        }
    }
}
