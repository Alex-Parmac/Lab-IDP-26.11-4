using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab_IDP_26._11_4
{
    public partial class Statistici : Form
    {
        public Statistici( )
        {
            InitializeComponent( );
        }

        private void Statistici_Load( object sender, EventArgs e )
        {
            List<string> producatori = new List<string>( );
            producatori.Add( "Levnovo" );
            producatori.Add( "HP" );
            producatori.Add( "ASUS" );
            producatori.Add( "Dell" );
            producatori.Add( "Acer" );
            producatori.Add( "Toshiba" );
            producatori.Add( "Huawei" );
            producatori.Add( "LG" );

            Produs p = new Produs( );
            List<Produs> listaProduse = p.preiaLista();

            int globalCnt = 0;
            foreach(string b in producatori)
            {
                int nrCnt = listaProduse.Where( c => c.numeProdus.ToUpper( ).Contains( b.ToUpper( ) ) ).Count();
                if (nrCnt > 0)
                    listBox1.Items.Add( b + ": " + nrCnt );
                globalCnt += nrCnt;
            }

            if (( listaProduse.Count( ) - globalCnt ) > 0)
                listBox1.Items.Add( "Alti producatori: " + ( listaProduse.Count( ) - globalCnt ) );

            List<string> procesor = new List<string> { "i3", "i5", "i7", "Ryzen 3", "Ryzen 5", "Ryzen 7", "Ryzen 9" };
            globalCnt = 0;
            chartProcesor.Series["procSeries"]["PieLabelStyle"] = "Disabled";
            foreach(string proc in procesor)
            {
                int nrCnt = listaProduse.Where( c => c.numeProdus.ToUpper( ).Contains( proc.ToUpper( ) ) ).Count( );

                if(nrCnt>0)
                {
                    DataPoint punct = new DataPoint( );
                    punct.SetValueXY( proc, nrCnt );
                    punct.ToolTip = nrCnt.ToString( );
                    chartProcesor.Series["procSeries"].Points.Add( punct );
                }
                globalCnt += nrCnt;
            }
            if((listaProduse.Count() - globalCnt)>0)
            {
                DataPoint punct = new DataPoint( );
                punct.SetValueXY( "Alte procesoare", ( listaProduse.Count( ) - globalCnt ) );
                punct.ToolTip = ( listaProduse.Count() - globalCnt ).ToString( );
                chartProcesor.Series["procSeries"].Points.Add( punct );
            }

            double pretMaxim = listaProduse.Select( c => c.pretProdus ).Max( );
            for(int i=0;i<=pretMaxim;i=i+1000)
            {
                int nr = listaProduse.Count( c => c.pretProdus > i && c.pretProdus <= i + 1000 );
                if (nr > 0)
                    chart1.Series["categoriePret"].Points.AddXY( i + "-" + ( i + 1000 ), nr );
            }
        }        
    }
}
