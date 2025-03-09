using System.ComponentModel;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClientHttp.Model;
using ClientHttp.ViewModel;

//Добавление пользователя
Person person = new Person()
{
    Personname = "Ivan",
    Passwordhash = "qwerty",
    Salt = "salted159",
    //Createdat = DateTime.Now
};
PersonViewModel.SendClient(person).GetAwaiter().GetResult();

//Получение списка пользователей
Task<List<Person>> task = PersonViewModel.getPerson();
List<Person> clients = task.Result;
foreach (Person c in clients)
{
    Console.WriteLine(c.Personid + " " + c.Personname + " " + c.Passwordhash + " " + c.Salt + " " + c.Createdat);
}
Console.WriteLine();

////Удаление пользователя по Id
await PersonViewModel.DelClient(10);

//Изменение пользователя
Person person2 = new Person()
{
    Personid = 11,
    Personname = "Semen",
    Passwordhash = "ytrewq",
    Salt = "salted159",
};
await PersonViewModel.PutClient(person2);




