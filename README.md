# Basic User Authentication System (C#)

## Description

This is a C# console application that serves as a foundational example of user authentication with advanced security measures such as password hashing and salted passwords. It allows users to create accounts with secure credentials and log in securely.

The application provides insights into essential security practices and can serve as a starting point for more robust authentication systems in real-world applications.

## Features

- User registration with strong password security (hashing and salting).
- User login with secure password verification.
- Implementation of the PBKDF2 (Password-Based Key Derivation Function 2) hashing algorithm.
- Random salt generation for each user to prevent common password attacks.
- Error handling for various stages of user interaction.

## Getting Started

### Prerequisites

Before running this application, ensure that you have the following prerequisites installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet)
- A C# development environment (e.g., Visual Studio, Visual Studio Code)

### Installation

1. Clone this repository to your local machine or download the source code.

   ```bash
   git clone https://github.com/cpu9995/Basic-User-Authentication.git
   ```

2. Open the project in your preferred C# development environment.

3. Build and run the project.

   ```bash
   dotnet run
   ```

## Usage

Upon launching the application, you will encounter a menu with three primary options:

1. **Login**: Existing users can log in with their username and password.
2. **Create an Account**: New users can register by choosing a username and password.
3. **Exit**: This option terminates the program.

### Registration (Create an Account)

- When creating an account, the application performs the following steps for enhanced security:
  - Generates a unique random salt for the user.
  - Hashes the user's password using the PBKDF2 algorithm and the salt.
  - Securely stores the salt and password hash.

### Login

- During the login process, the application verifies user credentials by:
  - Retrieving the stored salt and password hash.
  - Repeating the PBKDF2 hashing process with the entered password and stored salt.
  - Comparing the computed hash with the stored hash to grant or deny access.

## Security Considerations

- While this application demonstrates fundamental security practices for password management, it is essential to use specialized authentication libraries and methods for real-world applications.
- Console-based interfaces are not suitable for most production systems; typical applications use web-based or desktop user interfaces.

## Contributing

If you wish to contribute to this project or have suggestions for improvements, please follow these steps:

1. Fork the repository.
2. Create a new branch to work on your feature or bug fix.
3. Make your code changes.
4. Create a pull request with a description of your changes for review and integration.

## License

This project is open-source and licensed under the MIT License. For detailed licensing information, refer to the [LICENSE](LICENSE) file.

## Acknowledgments

- This project is intended for educational purposes and emphasizes the importance of secure password management.
- Proper password handling and user data security are essential in safeguarding user privacy and data integrity.
