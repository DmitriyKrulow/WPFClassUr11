using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;

namespace WPFClassUr11
{
    internal class Manager : Consultant
    {
        public new void DispleyClientData(SelectionChangedEventArgs e)
        {
            foreach (CustomerData name in e.AddedItems)
            {
                MainWindow.Instance.TextClientSurname.IsReadOnly = false;
                MainWindow.Instance.TextClientSurname.Text = name.ClientSurname;
                MainWindow.Instance.TextClientName.IsReadOnly = false;
                MainWindow.Instance.TextClientName.Text = name.ClientName;
                MainWindow.Instance.TextClientPatronymic.IsReadOnly = false;
                MainWindow.Instance.TextClientPatronymic.Text = name.ClientPatronymic;
                MainWindow.Instance.TextClientPhoneNumber.Text = name.ClientPhoneNumber;
                MainWindow.Instance.TextClientPassportNumber.IsReadOnly = false;
                MainWindow.Instance.TextClientPassportNumber.Text = name.ClientPassportNumber;
                MainWindow.Instance.TextThisDay.Text = name.ThisDay.ToString();
                MainWindow.Instance.TextChangesData.Text = name.ChangesData;
                MainWindow.Instance.TextChangesType.Text = name.ChangesType;
                MainWindow.Instance.TextChangesWho.Text = name.ChangesWho;
                MainWindow.Instance.TextId.Text = name.Id;
                base.workingRecord = name;
            }
        }

        public new CustomerData WriteClientData()
        {
            workingRecord.ChangesType = "";
            workingRecord.ChangesData = "";
            if (base.workingRecord.ClientSurname != MainWindow.Instance.TextClientSurname.Text)
            {
                Debug.WriteLine("Изменена строка фамилии.");
                workingRecord.ChangesType += "Фамилия ";
                workingRecord.ChangesData += workingRecord.ClientSurname + " ";
                base.workingRecord.ClientSurname = MainWindow.Instance.TextClientSurname.Text;
            }
            if (base.workingRecord.ClientName != MainWindow.Instance.TextClientName.Text)
            {
                Debug.WriteLine("Изменена строка имени.");
                workingRecord.ChangesType += "Имя ";
                workingRecord.ChangesData += workingRecord.ClientName + " ";
                base.workingRecord.ClientName = MainWindow.Instance.TextClientName.Text;
            }
            if (base.workingRecord.ClientPatronymic != MainWindow.Instance.TextClientPatronymic.Text)
            {
                Debug.WriteLine("Изменена строка отчества.");
                workingRecord.ChangesType += "Отчество ";
                workingRecord.ChangesData += workingRecord.ClientPatronymic + " ";
                base.workingRecord.ClientPatronymic = MainWindow.Instance.TextClientPatronymic.Text;
            }
            if (base.workingRecord.ClientPhoneNumber != MainWindow.Instance.TextClientPhoneNumber.Text)
            {
                Debug.WriteLine("Изменена строка номера телефона.");
                workingRecord.ChangesType += "Телефон ";
                workingRecord.ChangesData += workingRecord.ClientPhoneNumber + " ";
                base.workingRecord.ClientPhoneNumber = MainWindow.Instance.TextClientPhoneNumber.Text;
            }
            if (base.workingRecord.ClientPassportNumber != MainWindow.Instance.TextClientPassportNumber.Text)
            {
                Debug.WriteLine("Изменена строка номера и серии паспорта.");
                workingRecord.ChangesType += "Паспорт ";
                workingRecord.ChangesData += workingRecord.ClientPassportNumber + " ";
                base.workingRecord.ClientPassportNumber = MainWindow.Instance.TextClientPassportNumber.Text;
            }
            workingRecord.ThisDay = DateTime.Now;
            workingRecord.ChangesWho = "Менаджер";
            return base.workingRecord;
        }
    }
}
