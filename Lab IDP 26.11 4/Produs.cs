using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_IDP_26._11_4
{
    public class Produs
    {
        public string numeProdus { set; get; }

        public double pretProdus { set; get; }

        public List<Produs> preiaLista( )
        {
            string[] produse =File.ReadAllLines( @"D:\10212\IDP\Parmac Alexandru\test\nume_produs.txt" );
            string[] preturi =File.ReadAllLines( @"D:\10212\IDP\Parmac Alexandru\test\preturi.txt" );

            List<Produs> pList = new List<Produs>( );
            NumberFormatInfo nfi = new NumberFormatInfo( );


            nfi.NumberDecimalSeparator = ".";


            for (int i = 0; i < produse.Length; i++)
            {
                Produs p = new Produs( );
                p.numeProdus = produse.ElementAt( i );
                p.pretProdus = Convert.ToDouble( preturi.ElementAt( i ), nfi );
                pList.Add( p );
            }


            return pList;
        }

        public void adaugaProdus(string denumire, string pret)
        {
            File.AppendAllText( @"D:\10212\IDP\Parmac Alexandru\test\nume_produs.txt" , "\n" + denumire);
            File.AppendAllText( @"D:\10212\IDP\Parmac Alexandru\test\preturi.txt", "\n" + pret );
        }

        public void editeazaProdus(string valoare, int coloana, int rand)
        {
            if(coloana==0)
            {
                string[] produse = File.ReadAllLines( @"D:\10212\IDP\Parmac Alexandru\test\nume_produs.txt" );
                produse[rand] = valoare;
                File.WriteAllLines( @"D:\10212\IDP\Parmac Alexandru\test\nume_produs.txt", produse );
            }
            else if(coloana==1)
            {
                string[] preturi= File.ReadAllLines( @"D:\10212\IDP\Parmac Alexandru\test\preturi.txt" );
                preturi[rand] = valoare;
                File.WriteAllLines( @"D:\10212\IDP\Parmac Alexandru\test\preturi.txt", preturi );
            }
        }

        public void stergeProdus(int index)
        {
            string[] produse = File.ReadAllLines( @"D:\10212\IDP\Parmac Alexandru\test\nume_produs.txt" );
            string[] preturi = File.ReadAllLines( @"D:\10212\IDP\Parmac Alexandru\test\preturi.txt" );

            produse = produse.Where( ( val, pos ) => pos != index ).ToArray( );
            preturi = preturi.Where( ( val, pos ) => pos != index ).ToArray( );

            File.WriteAllLines( @"D:\10212\IDP\Parmac Alexandru\test\nume_produs.txt" , produse);
            File.WriteAllLines( @"D:\10212\IDP\Parmac Alexandru\test\preturi.txt", preturi );
        }
    }
}
