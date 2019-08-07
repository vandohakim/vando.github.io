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
using MySql.Data.MySqlClient;
using System.Data;

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for Windowkedua.xaml
    /// </summary>
    public partial class Windowkedua : Window
    {
        public Windowkedua()
        {
            InitializeComponent();
            lihatData();
        }
        MySqlConnection koneksi = new MySqlConnection("server=localhost;port=3306;database=kalkulatorcsharp;uid=root;password=;SslMode=none");

        public void lihatData()
        {
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = "select * from csharphw2";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataGridAja.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(Label.Content);
            if (id != null)
            {
                if (MessageBox.Show("Delete this data?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //do no stuff
                    lihatData();
                }
                else
                {
                    //do yes stuff
                    koneksi.Open();
                    MySqlCommand cmd;
                    cmd = koneksi.CreateCommand();
                    cmd.CommandText = "delete FROM csharphw2 WHERE id='" + id + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success delete data");
                    lihatData();
                    koneksi.Close();
                }                              
            }
        }
        private void DataGridAja_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                Label.Content = row_selected["id"].ToString();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow W1 = new MainWindow();
            W1.Show();
            this.Hide();
        }
    }
}
