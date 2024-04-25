using System;

class InvalidDataException : Exception
{
    public InvalidDataException(string message) : base(message)
    {
    }
}

class UserData
{
    private string lastName;
    private string firstName;
    private string middleName;
    private string birthDate;
    private long phoneNumber;
    private char gender;

    public UserData(string data)
    {
        string[] tokens = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length != 6)
        {
            throw new InvalidDataException("Неправильное количество элементов данных.");
        }

        this.lastName = tokens[0];
        this.firstName = tokens[1];
        this.middleName = tokens[2];
        this.birthDate = tokens[3];

        // Проверка номера телефона
        if (!long.TryParse(tokens[4], out long phoneNumber) || phoneNumber < 1000000000 || phoneNumber > 99999999999)
        {
            throw new InvalidDataException("Неверный формат номера телефона. Используйте целое число из 10 или 11 цифр.");
        }
        this.phoneNumber = phoneNumber;

        this.gender = tokens[5][0];

        // Проверка формата данных
        if (!DateTime.TryParseExact(birthDate, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out _))
        {
            throw new InvalidDataException("Неверный формат даты. Используйте dd.mm.yyyy");
        }
        if (gender != 'f' && gender != 'm')
        {
            throw new InvalidDataException("Неверный пол. Используйте 'f' или 'm'.");
        }
    }

    public string GetLastName()
    {
        return lastName;
    }

    public string GetFirstName()
    {
        return firstName;
    }

    public string GetMiddleName()
    {
        return middleName;
    }

    public string GetBirthDate()
    {
        return birthDate;
    }

    public long GetPhoneNumber()
    {
        return phoneNumber;
    }

    public char GetGender()
    {
        return gender;
    }
}