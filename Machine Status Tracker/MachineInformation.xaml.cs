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
    /// Interaction logic for MachineInformation.xaml
    /// </summary>
    public partial class MachineInformation : UserControl
    {
        private MainWindow main = (MainWindow)Application.Current.MainWindow;
        public MachineInformation()
        {
            InitializeComponent();
            try
            {
                //Add information to the card
                if (main.Machines != null && main.Machines.Count > 0)
                {
                    Machine machine = main.Machines[main.Machines.Count - 1];

                    NameLabel.Content += machine.Name;
                    DescriptionLabel.Content += machine.Description;
                    NotesLabel.Content += machine.Notes;
                    StatusLabel.Content += machine.Status;

                    if (machine.Status == "Running")
                    {
                        Card.Background = Brushes.Green;
                    }
                    else if (machine.Status == "Idle")
                    {
                        Card.Background = Brushes.Orange;

                    }
                    else
                    {
                        Card.Background = Brushes.Red;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MachineInformation(): " + ex.Message);
            }


        }

        //Not active at the moment
        //Edit machine
        //private void EditBt_Click(object sender, RoutedEventArgs e)
        //{
        //    main.NewMachineCard.Visibility = Visibility.Visible;
        //    main.NewMachinTi.Content = "Edit Machin";
        //    main.NameTextBox.Text = NameLabel.Content.ToString();
        //    main.DescriptionTextBox.Text = DescriptionLabel.Content.ToString();
        //    main.NotestextBox.Text = NotesLabel.Content.ToString();

        //    foreach (var item in main.StatusCB.Items)
        //    {
        //        if (item is ComboBoxItem comboBoxItem && comboBoxItem.Content.ToString() == StatusLabel.Content.ToString())
        //        {
        //            main.StatusCB.SelectedItem = comboBoxItem;
        //            return;
        //        }
        //    }
        //}
        //Not active at the moment
        //public void UpdateInfo()
        //    {
        //        NameLabel.Content = main.NameTextBox.Text.Trim();
        //        DescriptionLabel.Content = main.DescriptionTextBox.Text.Trim();
        //        NotesLabel.Content = main.NotestextBox.Text.Trim();
        //        StatusLabel.Content = main.StatusCB.Text.Trim();
        //    }

        //Delete machine
        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Parent is StackPanel parentPanel)
                {
                    main.Machines.RemoveAll(x => x.Name.Trim() == NameLabel.Content.ToString().Trim().Substring(6));

                    parentPanel.Children.Remove(this);
                    MessageBox.Show("The machine has been deleted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DeleteBt_Click: " + ex.Message);
            }
        }
    }
}

