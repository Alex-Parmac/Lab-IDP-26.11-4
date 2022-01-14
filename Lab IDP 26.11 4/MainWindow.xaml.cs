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

namespace Lab_IDP_26._11_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( )
        {
            InitializeComponent( );
            criteriuFiltrare.Items.Add( "Selecteaza valoare" );
            criteriuFiltrare.SelectedIndex = 0;
            criteriuFiltrare.Items.Add( "Incepe cu" );
            criteriuFiltrare.Items.Add( "Contine" );
        }

        public void populeazaGrid( string expresie = "", string criteriu = "" )
        {
            // Sterg intregul continut al obiectului dataGrid
            dataGridFilter.ClearValue( ItemsControl.ItemsSourceProperty );
            // Se instantiaza obiectul si se preia lista produselor
            Produs pObject = new Produs( );
            List<Produs> produse = pObject.preiaLista( ).ToList( );

            // Daca exista expresie de filtrare
            if (expresie != "")
            {
                // Se verifica daca este criteriul de incepere cu expresia
                // in caz contrar, criteriul este de existenta a expresiei in numele produsului
                if (criteriu.Equals( "Contine" ))
                    produse = produse.Where( x => x.numeProdus.ToLower( ).Contains( expresie.ToLower( ) ) ).ToList( );
                else
                    produse = produse.Where( x => x.numeProdus.ToLower( ).StartsWith( expresie.ToLower( ) ) ).ToList( );
            }


            dataGridFilter.ItemsSource = produse;
        }

         private void DataGridFilter_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {

        }

        private void dataGridFilter_Loaded( object sender, RoutedEventArgs e )
        {
            populeazaGrid( );
        }

        private void DataGridFilter_Loaded_1( object sender, RoutedEventArgs e )
        {
            populeazaGrid( );
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            if (( criteriuFiltrare.SelectedIndex > 0 ) && ( expresieFiltrare.Text != "" ))
            {
                populeazaGrid( expresieFiltrare.Text, criteriuFiltrare.SelectedValue.ToString( ) );
            }
        }

        private void Button_Click_1( object sender, RoutedEventArgs e )
        {
            Adauga_produs ap = new Adauga_produs( );
            ap.Closed += actualizareDate;
            ap.Show( );
        }

        public void actualizareDate(object sender, EventArgs e)
        {
            populeazaGrid( );
        }

        private void DataGridFilter_CellEditEnding( object sender, DataGridCellEditEndingEventArgs e )
        {
            int coloana = e.Column.DisplayIndex;
            int rand = e.Row.GetIndex( );
            TextBox t = e.EditingElement as TextBox;
            Produs p = new Produs( );
            p.editeazaProdus( t.Text, coloana, rand );
        }

        private void Button1_Click( object sender, RoutedEventArgs e )
        {
            int index = dataGridFilter.SelectedIndex;
            if (index >= 0)
            {
                Produs p = new Produs( );
                p.stergeProdus( index );
                populeazaGrid( );
            }
            else
            {
                MessageBox.Show( "Nu a fost selectat niciun rand!" );
            }
        }

        private void Button2_Click( object sender, RoutedEventArgs e )
        {
            Statistici s = new Statistici( );
            s.Show( );
        }
    }
}
