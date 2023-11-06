internal class Program
{

    static (string Name, string LastName, byte Age, bool HasPet,
            string[] arrPet, string[] arrColor) User;
    static void Data(ref byte NumPets, ref byte NumColors)
    {
       
        Console.WriteLine("Введите имя: ");
        User.Name = Console.ReadLine();

        Console.WriteLine("Введите фамилию: ");
        User.LastName = Console.ReadLine();

        User.Age = InputByteCheck("Введите возрас цифрами:", 100);
        
        Console.WriteLine("Есть ли у вас питомцы? Да или Нет");

        var result = Console.ReadLine();

        while (result != "Да" && result != "Нет")
        {
            Console.WriteLine("Некорректный ответ, пожалуйста, ответьте Да или Нет");
            result = Console.ReadLine();
        }
        if (result == "Да")
        {
            User.HasPet = true;
            NumPets = InputByteCheck("Укажите количество питомцев", 10);
            while (NumPets == 0)
            {
                Console.WriteLine("Количество питомцев не может быть равно 0");
                NumPets = InputByteCheck("Укажите количество питомцев", 10);
            }
            User.arrPet = PetsNameNum(ref NumPets);
        }
        else
        {
            User.HasPet = false;
        }

        NumColors = InputByteCheck("Сколько у Вас любимых цветов?", 10);
        User.arrColor = ColorNumb(ref NumColors);

        static string[] PetsNameNum(ref byte NumPets)
        {
            string[] petName = new string[NumPets];
            Console.WriteLine("Напишите кличку(ки) Вашего(их) питомца(ев)");
            for (int i = 0; i < NumPets; i++)
            {
                petName[i] = Console.ReadLine();
            }
            return petName;
        }

        static string[] ColorNumb(ref byte colorNumb)
        {
            string[] color = new string[colorNumb];
            Console.WriteLine("Напишите ваши любимые цвета");
            for (int j = 0; j < colorNumb; j++)
            {
                color[j] = Console.ReadLine();
            }
            return color;
        }

        static byte InputByteCheck(string error, byte allowedValue)
        {
            byte result; bool validInput;
            do
            {
                Console.WriteLine(error);
                validInput = byte.TryParse(Console.ReadLine(), out result) && result <= allowedValue;
                if (!validInput)
                {
                    Console.WriteLine($"Некорректное значение. Введите число от 0 до {allowedValue}.");
                }
            } while (!validInput);
            return result;
        }
    }
    static void ShowData((string Name, string LastName, byte Age, bool HasPet, string[] arrPet, string[] arrColor) anketa)
    {
        Console.WriteLine("///////////////////////////////");
        Console.WriteLine($"Имя: {User.Name}");
        Console.WriteLine($"Фамилия: {User.LastName}");
        Console.WriteLine($"Возраст: {User.Age}"); if (User.HasPet)
        {
            Console.WriteLine($"Количество питомцев: {User.arrPet.Length}");
            Console.WriteLine("Клички Вашкго(их) питомца(ев):"); foreach (string pet in User.arrPet)
            {
                Console.WriteLine(pet);
            }
        }
        else
        {
            Console.WriteLine("У пользователя нет питомцев");
        }
        Console.WriteLine($"Количество любимых цветов: {User.arrColor.Length}");
        Console.WriteLine("Любимый(е) цвет(а):");
        foreach (string message in User.arrColor)
        {
            Console.WriteLine(message);
        }
    }
    private static void Main()
    {
        byte NumPets = 0, NumColors = 0;
        Data(ref NumPets, ref NumColors);
        ShowData(User);
    }
}