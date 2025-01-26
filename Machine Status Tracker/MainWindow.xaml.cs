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

namespace Machine_Status_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Machine> Machines { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Machines = new List<Machine>();
        }


        private void BtAddMachine_Click(object sender, RoutedEventArgs e)
        {
            NewMachineCard.Visibility = Visibility.Visible;
            NewMachineTi.Content = "New Machine";
        }

        private void CloseAddMachineBt_Click(object sender, RoutedEventArgs e)
        {
            NewMachineCard.Visibility = Visibility.Collapsed;
        }
        //Save machine
        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = false;
                if (string.IsNullOrEmpty(NameTextBox.Text.Trim()))
                {
                    NameError.Visibility = Visibility.Visible;
                    flag = true;
                }
                else
                {
                    NameError.Visibility = Visibility.Collapsed;
                }

                if (string.IsNullOrEmpty(DescriptionTextBox.Text.Trim()))
                {
                    DescriptionError.Visibility = Visibility.Visible;
                    flag = true;
                }
                else
                {
                    DescriptionError.Visibility = Visibility.Collapsed;
                }

                if (flag) { return; }

                //Check if the machine already exists
                if (Machines.Count > 0 && Machines.Any(x => x.Name == NameTextBox.Text.Trim()))
                {
                    MessageBox.Show("The machine already exists");
                    return;
                }


                //add machine to the list
                Machines.Add(new Machine
                {
                    Name = NameTextBox.Text.Trim(),
                    Description = DescriptionTextBox.Text.Trim(),
                    Status = StatusCB.Text.Trim(),
                    Notes = NotestextBox.Text.Trim(),
                });

                //Create a new user control and add it to the stack panel
                MachineInformationSp.Children.Add(new MachineInformation());

                MessageBox.Show("The machine has been added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveBt_Click: " + ex.Message);
            }
        }
    }
}
