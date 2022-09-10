using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CSharpVitamins;
using System.Windows;

namespace WPFClassUr11
{
    internal class CustomerData : IChanges
    {
        static string IdCards;
        static List<string> idCD;
        static string FileCustomerData;
        static List <CustomerData> CDdata;
        static bool AddFlag;
        static CustomerData()
        {
            AddFlag = true;
            FileCustomerData = @"resources\CustomerData.json";
            IdCards = File.ReadAllText(FileCustomerData);
            idCD = new List<string>();
            Debug.WriteLine(">Строка 29 >" + IdCards);
            if (IdCards == "")
            {
                idCD.Add(Guid.NewGuid().ToString("N").Substring(0, 6));
                List<CustomerData> CDnewList = new List<CustomerData>();
                CDnewList.Add(new CustomerData());
                IdCards = JsonConvert.SerializeObject(CDnewList);
                System.IO.File.WriteAllTextAsync(FileCustomerData, IdCards);
                IdCards = System.IO.File.ReadAllText(FileCustomerData);
            }
            CDdata = JsonConvert.DeserializeObject<List<CustomerData>>(IdCards);
            foreach (var name in CDdata)
            {
                idCD.Add(name.Id);
                Debug.WriteLine($"<>Строка 42<> {name.Id}");
            }
        }
        private string id;
        public string Id { get { return this.id; } } 
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
        public string ClientPatronymic { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientPassportNumber { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Цифровой идентификатор записи</param>
        /// <param name="clientName">Имя</param>
        /// <param name="clientPatronymic">Отчество</param>
        /// <param name="clientPhoneNumber">Номер Телефона</param>
        /// <param name="clientPassportNumber">Серия и номер паспорта</param>
        public CustomerData(string clientSurname, string clientName, string clientPatronymic, string clientPhoneNumber, string clientPassportNumber)
        {
            do
            {
                id = $@"{Guid.NewGuid().ToString("N").Substring(0,6)}";
            }
            while (CustomerData.idCD.Contains(id));
            ClientSurname = clientSurname;
            ClientName = clientName;
            ClientPatronymic = clientPatronymic;
            ClientPhoneNumber = clientPhoneNumber;
            ClientPassportNumber = clientPassportNumber;
            ThisDay = DateTime.Now;
            ChangesData = "";
            ChangesType = "";
            ChangesWho = "";
    }
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public CustomerData() : this("0", "0", "0", "0", "0")
        {
            ChangesWho = (new Consultant()).GetType().ToString();
        }
        /// <summary>
        /// Дабавление в список записей
        /// </summary>
        public void Add() 
        {
            if (AddFlag)
            {
                if (MainWindow.Instance.TextClientPhoneNumber.Text != "")
                {
                    this.ClientSurname = MainWindow.Instance.TextClientSurname.Text;
                    this.ClientName = MainWindow.Instance.TextClientName.Text;
                    this.ClientPatronymic = MainWindow.Instance.TextClientPatronymic.Text;
                    this.ClientPhoneNumber = MainWindow.Instance.TextClientPhoneNumber.Text;
                    this.ClientPassportNumber = MainWindow.Instance.TextClientPassportNumber.Text;
                    CDdata.Add(new CustomerData(this.ClientSurname, this.ClientName, this.ClientPatronymic, this.ClientPhoneNumber, this.ClientPassportNumber));
                    IdCards = JsonConvert.SerializeObject(CDdata);
                    System.IO.File.WriteAllTextAsync(FileCustomerData, IdCards);
                    MainWindow.Instance.СlientListPrint();
                    idCD.Clear();
                    foreach (var name in CDdata)
                    {
                        idCD.Add(name.Id);
                        Debug.WriteLine($"<>Строка 107<> {name.Id}");
                    }
                    AddFlag = false;
                }
                else
                {
                    string messageBoxText = "Поле с номером телефона неможет быть пустым!";
                    string caption = "Предупреждение";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }               
            }

        }

        public void Write() 
        {
            int idRecord = 0;
            if (this.ClientPhoneNumber != "")
            {
                foreach (var name in CDdata)
                {
                    if (name.Id == this.Id)
                    {
                        break;
                    }
                    idRecord++;
                }
                Debug.WriteLine(idRecord);
                CDdata[idRecord] = this;
                IdCards = JsonConvert.SerializeObject(CDdata);
                System.IO.File.WriteAllTextAsync(FileCustomerData, IdCards);
                MainWindow.Instance.СlientListPrint();
            }
            else
            {
                string messageBoxText = "Поле с номером телефона неможет быть пустым!";
                string caption = "Предупреждение";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

        public List<CustomerData> DisplayingList() 
        {
            return CDdata;
        }
        // IChanges
        public DateTime ThisDay { get; set; }
        public string ChangesData { get; set; }
        public string ChangesType { get; set; }
        public string ChangesWho { get; set; }
    }
}
