using Microsoft.Win32.SafeHandles;

Console.WriteLine("Bienvenido a mi lista de Contactes");

//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   6. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    try
    {
        int typeOption = Convert.ToInt32(Console.ReadLine());
    
    switch (typeOption)
    {
        case 1:
            {
                   AddContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2:
            {
                    ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 3:
            {
                    SearchContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 4:
            {
                    ModifyContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 5:
            {
                    DeleteContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 6:
            runing = false;
            break;
       } 
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocurrió un error: " + ex.Message);
    }
}

