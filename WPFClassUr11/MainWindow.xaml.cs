using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFClassUr11
{
    public partial class MainWindow : Window
    {
        List<CustomerData> ClientListDispley = new List<CustomerData>();
        private bool SelectionChanged = true;
        public static MainWindow Instance { get; private set; }
        Consultant ConsultantNew = new Consultant();
        Manager MenagerNew = new Manager();
        CustomerData CusDat = new CustomerData("", "", "", "", "");
        public MainWindow()
        {
            InitializeComponent();
            СlientListPrint();
            ClientReadDispley();
            Instance = this;
        }

        private void ClientReadDispley()
        {
            TextClientSurname.Text = CusDat.ClientSurname;
            TextClientName.Text = CusDat.ClientName;
            TextClientPatronymic.Text = CusDat.ClientPatronymic;
            TextClientPhoneNumber.Text = CusDat.ClientPhoneNumber;
            TextClientPassportNumber.Text = CusDat.ClientPassportNumber;
        }

        public void СlientListPrint()
        {
            ClientListDispley = CusDat.DisplayingList();
            СlientList.ItemsSource = ClientListDispley;
            СlientList.Items.Refresh();
        }

        private void СlientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChanged = false;
            if (ManagerRadioButton.IsChecked.Value == true)
            {
                MenagerNew.DispleyClientData(e);
            }
            else
            {
                ConsultantNew.DispleyClientData(e);

            }
        }
        /// <summary>
        /// Фильтр ввода только цифр для телефона и номера пасорта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextClientPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(((int)e.Key >= 34) && ((int)e.Key <= 43)) && !(((int)e.Key >= 74) && ((int)e.Key <= 83)))
            {
                e.Handled = true;
            }
        }

        private void TextClientPassportNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(((int)e.Key >= 34) && ((int)e.Key <= 43)) && !(((int)e.Key >= 74) && ((int)e.Key <= 83)))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Сохранение нового изменение старого по нажатию кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectionChanged)
            {
                CusDat.Add();
            }
            else
            {
                if (ManagerRadioButton.IsChecked.Value == true)
                {
                    CusDat = MenagerNew.WriteClientData();
                }
                else
                {
                    CusDat = ConsultantNew.WriteClientData();
                }
                CusDat.Write();
            }
        }
    }
}
