using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFClassUr11
{
    internal class Consultant
    {
        public CustomerData workingRecord;
        public void DispleyClientData(SelectionChangedEventArgs e) 
        {
            foreach (CustomerData name in e.AddedItems)
            {
                MainWindow.Instance.TextClientSurname.IsReadOnly = true;
                MainWindow.Instance.TextClientSurname.Text = name.ClientSurname;
                MainWindow.Instance.TextClientName.IsReadOnly = true;
                MainWindow.Instance.TextClientName.Text = name.ClientName;
                MainWindow.Instance.TextClientPatronymic.IsReadOnly = true;
                MainWindow.Instance.TextClientPatronymic.Text = name.ClientPatronymic;
                MainWindow.Instance.TextClientPhoneNumber.Text = name.ClientPhoneNumber;
                MainWindow.Instance.TextClientPassportNumber.IsReadOnly = true;
                MainWindow.Instance.TextClientPassportNumber.Text = "*******************";
                MainWindow.Instance.TextThisDay.Text = name.ThisDay.ToString();
                MainWindow.Instance.TextChangesData.Text = name.ChangesData;
                MainWindow.Instance.TextChangesType.Text = name.ChangesType;
                MainWindow.Instance.TextChangesWho.Text = name.ChangesWho;
                MainWindow.Instance.TextId.Text = name.Id;
                workingRecord = name;
                
            }

        }

        public CustomerData WriteClientData() 
        {
            if (workingRecord.ClientPhoneNumber != MainWindow.Instance.TextClientPhoneNumber.Text)
            {
                Debug.WriteLine("Изменена строка номера телефона.");
                workingRecord.ChangesData = workingRecord.ClientPhoneNumber;
                workingRecord.ClientPhoneNumber = MainWindow.Instance.TextClientPhoneNumber.Text;
                workingRecord.ThisDay = DateTime.Now;
                workingRecord.ChangesType = "Телефон";
                workingRecord.ChangesWho = "Консультант";
            }
            return workingRecord;
        }
    }
}
