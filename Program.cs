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

//Metodos

static void AddContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    try{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine() ?? "";
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine() ?? "";
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine() ?? "";
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine() ?? "";
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine() ?? "";
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
    }

    catch (Exception ex)
    {
        Console.WriteLine("Ocurrió un error al agregar el contacto: " + ex.Message);
    }

}


static void ShowContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    try
    {
        if (ids.Count == 0)
        {
            Console.WriteLine("No hay contactos para mostrar.");
            return;
        }

        foreach (var id in ids)
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nombre: {names[id]}");
            Console.WriteLine($"Apellido: {lastnames[id]}");
            Console.WriteLine($"Dirección: {addresses[id]}");
            Console.WriteLine($"Teléfono: {telephones[id]}");
            Console.WriteLine($"Email: {emails[id]}");
            Console.WriteLine($"Edad: {ages[id]}");
            Console.WriteLine($"Mejor Amigo: {(bestFriends[id] ? "Sí" : "No")}");
            Console.WriteLine("-----------------------------");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocurrió un error al mostrar los contactos: " + ex.Message);
    }
}

static void SearchContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    try
    {
        Console.WriteLine("Digite el nombre o apellido del contacto que desea buscar:");
        string searchTerm = Console.ReadLine() ?? "";

        var foundContacts = ids.Where(id => names[id].Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || lastnames[id].Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundContacts.Count == 0)
        {
            Console.WriteLine("No se encontraron contactos con ese nombre o apellido.");
            return;
        }

        foreach (var id in foundContacts)
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nombre: {names[id]}");
            Console.WriteLine($"Apellido: {lastnames[id]}");
            Console.WriteLine($"Dirección: {addresses[id]}");
            Console.WriteLine($"Teléfono: {telephones[id]}");
            Console.WriteLine($"Email: {emails[id]}");
            Console.WriteLine($"Edad: {ages[id]}");
            Console.WriteLine($"Mejor Amigo: {(bestFriends[id] ? "Sí" : "No")}");
            Console.WriteLine("-----------------------------");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocurrió un error al buscar los contactos: " + ex.Message);
    }
}

static void ModifyContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    try
    { 
        if (ids.Count == 0)
        {
            Console.WriteLine("No hay contactos registrados");
            return;
        }

ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
int id = Convert.ToInt32(Console.ReadLine());

if (!ids.Contains(id))
{
    Console.WriteLine("ID no encontrado.");
    return;
}

Console.WriteLine("(Presione Enter para mantener el valor actual)");

Console.WriteLine($"Nombre actual: {names[id]}");
string input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) names[id] = input;

Console.WriteLine($"Apellido actual: {lastnames[id]}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) lastnames[id] = input;

Console.WriteLine($"Dirección actual: {addresses[id]}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) addresses[id] = input;

Console.WriteLine($"Telefóno actual: {telephones[id]}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) telephones[id] = input;

Console.WriteLine($"Email actual: {emails[id]}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) emails[id] = input;

Console.WriteLine($"Edad actual: {ages[id]}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) ages[id] = Convert.ToInt32(input);

Console.WriteLine($"Mejor Amigo actual: {(bestFriends [id] ? "Sí" : "No")}");
input = Console.ReadLine() ?? "";
if (string.IsNullOrWhiteSpace(input)) bestFriends[id] = Convert.ToInt32(input) == 1;

Console.WriteLine("Contacto modificado exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocurrió un error al modificar el contacto: " + ex.Message);
    }
}

static void DeleteContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    try
    {
        if (ids.Count == 0)
        {
            Console.WriteLine("No hay contactos registrados");
            return;
        }

        ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
        
        Console.WriteLine("Digite el ID del contacto que desea eliminar:");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("ID no encontrado.");
            return;
        }

        Console.WriteLine($"¿Estás seguro de que desea eliminar a {names[id]} {lastnames[id]}? 1. Sí, 2. No");
        int confirmation = Convert.ToInt32(Console.ReadLine());

        if (confirmation == 1)
        {

        //elimina todos los diccionarios y la listade ids
        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contacto eliminado exitosamente.");
    }

    else
    {
        Console.WriteLine("Eliminación cancelada.");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Ocurrió un error al eliminar el contacto: " + ex.Message);
}

}

Console.ReadKey();
