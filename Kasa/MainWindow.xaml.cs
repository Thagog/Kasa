using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Kasa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int Index = 1;
       
        
            
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private List<Item> items = new List<Item>();
        

        public void ShopItem_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            LogNewItem(jmenoItemu: thisButton.Content.ToString());
            ViewItemByName(itemName: thisButton.Content.ToString());
            
            KontentKosiku.Text = KontentKosiku.Text + Index + ". " + KonkretniPredmet.Content.ToString() + " " + Cena.Content.ToString()+ "\n";
            Index++;
        }
        public void LogNewItem(string jmenoItemu)
        {
            switch (jmenoItemu)
            {
                case "Jablko":
                    items.Add(new Item("Jablko", 5, "Ovoce"));
                    break;
                case "Čokoláda":
                    items.Add(new Item("Čokoláda", 40, "Sladkosti"));
                    break; 
                case "Hovězí":
                    items.Add(new Item("Hovězí", 100, "Maso"));
                    break;
                case "Německý slovník":
                    items.Add(new Item("Německý slovník", 100, "Knihy"));
                    break;
                case "Notebook":
                    items.Add(new Item("Notebook", 15000, "Elektronika"));
                    break;
                case "Eso Piků":
                    items.Add(new Item("Eso Piků", 14, "loltyler1.com"));
                    break;
                case "Boty":
                    items.Add(new Item("Boty", 700, "Boty"));
                    break;
                case "Káva":
                    items.Add(new Item("Káva", 50, "Nápoj"));
                    break;
                case "Kolo":
                    items.Add(new Item("Kolo", 10000, "Turistika"));
                    break;
                case "Rubínový prsten":
                    items.Add(new Item("Rubínový prsten", 50000, "Šperky"));
                    break;

            }
        }
        public void ViewItemByName(string itemName)
        {


            foreach (var i in items)
            {
              
                if (i.Jmeno == itemName)
                {

                    // Ukázat položku podle jména         
                    KonkretniPredmet.Content = i.Jmeno;
                    Regal.Content = i.Regal;
                    Cena.Content = i.Cena;
                }

            }


        }
        public string CenaCelek()
        {
            decimal Returnvalue = 0;
            foreach(var item in items)
            {
                Returnvalue += item.Cena;
                
            }             
            return string.Format(Returnvalue.ToString() + " ,-");
        }
        public class Item
        {
            public string Regal { get; set; }
            public decimal Cena { get; set; }
            public string Jmeno { get; set; }


            public Item(string jmeno,decimal cena,string regal)
            {
                Regal = regal;
                Cena = cena;
                Jmeno = jmeno;
            }
        }

        private void Kašír_Click(object sender, RoutedEventArgs e)
        {

            Total.Text = CenaCelek();
        }
    }
}
