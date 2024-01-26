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

namespace A2MannatVerma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataSet1TableAdapters.EmployeesTableAdapter _adapters;
        private DataSet1.EmployeesDataTable employeeDataTable;

        private DataSet1TableAdapters.OrdersTableAdapter ordersTableAdapter;
        private DataSet1.OrdersDataTable ordersDataTable;
        public MainWindow()
        {
            InitializeComponent();
            _adapters = new DataSet1TableAdapters.EmployeesTableAdapter(); 
            employeeDataTable = new DataSet1.EmployeesDataTable();

            ordersTableAdapter = new DataSet1TableAdapters.OrdersTableAdapter();
            ordersDataTable = new DataSet1.OrdersDataTable();
        }
        private void GetAllEmployee() {
            _adapters.FillEmployee(employeeDataTable);
            grdData.ItemsSource = employeeDataTable;
            
        }

        private void btnGetEmployee_Click(object sender, RoutedEventArgs e)
        {
           
            GetAllEmployee();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            employeeDataTable = _adapters.GetDataByTitleSearch(txttitle.Text);
            if (employeeDataTable.Count > 0)
            {
                var row = employeeDataTable[0];
                MessageBox.Show($"ID: {row.EmployeeID}\nFirstName: {row.FirstName}\n LastName: {row.LastName}\n Title: {row.Title}\nBirth_Date: {row.BirthDate}");
            }
            else
            {
                MessageBox.Show("No data related to this Title", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grdData.ItemsSource = null;
            txtId.Clear();
            txtFirstName.Clear();   
            txttitle.Clear();
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            employeeDataTable = _adapters.GetDataBySortAge();
            grdData.ItemsSource = employeeDataTable;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
             int id = int.Parse(txtId.Text);
            _adapters.Delete(id);
            MessageBox.Show("Employee has been deleted", "Inform",MessageBoxButton.OK, MessageBoxImage.Information);
            GetAllEmployee();
           
        }

        private void btnGetOrder_Click(object sender, RoutedEventArgs e)
        {
            ordersTableAdapter.FillOrderDate(ordersDataTable);
            grdData.ItemsSource = ordersDataTable;
        }
    }
}
