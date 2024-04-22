using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Add_data.xaml
    /// </summary>
    public partial class Add_data : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataTable AeroportTable;
        SqlConnection connection = null;


        public Add_data()
        {
            InitializeComponent();
        }

        public object Last_ts { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Airplane_name.Text != "" && DOI.Text != "" && Copacity.Text != "" && TObox.Text != "" && FHbox.Text != "")
            {
                string sql = $"insert into Airplanes values ('{Airplane_name.Text}','{DOI.Text}',{Copacity.Text},'{TObox.Text}',{FHbox.Text})";
                AeroportTable = new DataTable();
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                adapter = new SqlDataAdapter(command);
                MessageBox.Show("Данные добавлены");
             

                if (connection != null)
                    connection.Close();
               
            }
            else
            {
                MessageBox.Show("Не все поля были заполнены");
            }
        }
    }
}
