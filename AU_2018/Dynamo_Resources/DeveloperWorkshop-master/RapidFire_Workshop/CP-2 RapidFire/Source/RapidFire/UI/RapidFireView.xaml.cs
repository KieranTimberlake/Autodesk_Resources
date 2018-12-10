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

namespace RapidFire.UI
{
    /// <summary>
    /// Interaction logic for RapidFireView.xaml
    /// </summary>
    public partial class RapidFireView : Window
    {
        //TODO include the view model in the constructor
        public RapidFireView()
        {
            InitializeComponent();

            //TODO set the data context
           
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
       
    }
}
