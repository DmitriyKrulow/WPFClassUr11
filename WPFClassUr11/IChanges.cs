using System;

namespace WPFClassUr11
{
    internal interface IChanges
    {
        //Дата и время изменения записи.
        DateTime ThisDay { get; set; }
        //какие данные изменены.
        string ChangesData { get; set; }
        //тип изменений;
        string ChangesType { get; set; }
        //кто изменил данные(консультант или менеджер).
        string ChangesWho { get; set; }
    }
}
