using System;
using System.Collections.Generic;
using System.Security.Cryptography;

class Program
{
    static List<User> users = new List<User>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to My Console App");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create an Account");
            Console.WriteLine("3. Exit");

            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Login");
                    bool loggedIn = Login();
                    if (loggedIn)
                    {
                        Console.WriteLine("Login successful. Press any key to continue...");
                    }
                    else
                    {
                        Console.WriteLine("Login failed. Press any key to continue...");
                    }
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Create an Account");
                    Register();
                    Console.WriteLine("Account created successfully. Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Exiting the program. Press any key to exit...");
                    Console.ReadKey();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static bool Login()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        // Find a user with the given username
        User user = users.Find(u => u.Username == username);

        if (user != null && VerifyPassword(password, user.PasswordHash, user.Salt))
        {
            // Successful login
            return true;
        }

        return false;
    }

    static void Register()
    {
        Console.Write("Enter a new username: ");
        string username = Console.ReadLine();

        // Check if the username is already taken
        if (users.Exists(u => u.Username == username))
        {
            Console.WriteLine("Username is already in use. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter a password: ");
        string password = Console.ReadLine();

        // Generate a random salt
        byte[] salt = GenerateSalt();

        // Hash the password with the salt
        byte[] passwordHash = HashPassword(password, salt);

        // Create a new user and add it to the list
        User newUser = new User
        {
            Username = username,
            PasswordHash = passwordHash,
            Salt = salt
        };
        users.Add(newUser);
    }

    static byte[] GenerateSalt()
    {
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            byte[] salt = new byte[16];
            rng.GetBytes(salt);
            return salt;
        }
    }

    static byte[] HashPassword(string password, byte[] salt)
    {
        using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            return pbkdf2.GetBytes(20);
        }
    }

    static bool VerifyPassword(string enteredPassword, byte[] storedPasswordHash, byte[] salt)
    {
        byte[] enteredPasswordHash = HashPassword(enteredPassword, salt);

        for (int i = 0; i < storedPasswordHash.Length; i++)
        {
            if (enteredPasswordHash[i] != storedPasswordHash[i])
            {
                return false;
            }
        }

        return true;
    }
}

class User
{
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] Salt { get; set; }
}