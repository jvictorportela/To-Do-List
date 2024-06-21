# To-Do List Application

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Framework](https://img.shields.io/badge/ASP.NET_Core-5.0-blue)
![Database](https://img.shields.io/badge/Entity_Framework-SQL_Server-blue)

## Overview

This is a complete To-Do List application built with **ASP.NET Core**, **Entity Framework**, **SQL Server**, **Bootstrap**, and **C#**. The application allows users to create, read, update, and delete tasks (CRUD operations). Additionally, it provides filtering and sorting functionalities for tasks based on categories and dates.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete tasks.
- **Filtering**: Filter tasks by category and due dates (past, present, future).
- **Sorting**: Sort tasks by expiration dates.
- **Responsive Design**: Built with Bootstrap for a mobile-first responsive design.

## Technologies Used

- **ASP.NET Core**: For building the web application.
- **Entity Framework Core**: For interacting with the SQL Server database.
- **SQL Server**: As the database for storing tasks and related data.
- **Bootstrap**: For styling and responsive design.
- **C#**: The programming language used for backend development.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/your-repo-name.git
    cd your-repo-name
    ```

2. Set up the database:

    - Ensure SQL Server is running.
    - Update the connection string in `appsettings.json` to point to your SQL Server instance.

3. Apply migrations to create the database schema:

    ```bash
    dotnet ef database update
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

5. Open your browser and navigate to `https://localhost:5001` to see the application.

### Usage

- **Add Task**: Use the form to add a new task.
- **Edit Task**: Click on a task to edit its details.
- **Delete Task**: Click the delete button next to a task to remove it.
- **Filter Tasks**: Use the filter options to view tasks by category or due date.

## Screenshots

![Screenshot1](screenshots/screenshot1.png)
![Screenshot2](screenshots/screenshot2.png)

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


Thank you for using the To-Do List application! We hope it helps you stay organized and productive.
