namespace Working_with_Exceptions
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите данные пользователя (Фамилия Имя Отчество Дата_рождения Номер_телефона Пол):");
                string line = Console.ReadLine();
                UserData userData = new UserData(line);
                WriteFile(userData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }

        private static void WriteFile(UserData userData)
        {
            string fileName = userData.GetLastName() + ".txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine($"{userData.GetLastName()} {userData.GetFirstName()} " +
                        $"{userData.GetMiddleName()} {userData.GetBirthDate()} " +
                        $"{userData.GetPhoneNumber()} {userData.GetGender()}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }   
}