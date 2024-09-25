
# LibraryManagerApp

## Description

This web application allows managing data related to authors and their books. Users can add, edit, and delete information about authors and their books. The application provides an intuitive user interface and form validation to ensure data correctness.

## Features

### Author
Each author has the following attributes:
- **Last Name** (required)
- **First Name** (required)
- **Middle Name** (optional)
- **Date of Birth** (required)
- **List of Books**

### Book
Each book has the following attributes:
- **Title** (required)
- **Number of Pages** (required)
- **Genre** (required, selectable from a predefined list)

## Key Functionality:
- Adding, editing, and deleting authors.
- Adding, editing, and deleting books linked to authors.
- Form validation on all forms.
- Intuitive and user-friendly interface.
- Adding books via a modal form without page reloading.

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core (for database interactions)
- Bootstrap (for the user interface)
- jQuery and AJAX (for modal windows without page reload)

## Expected Outcome
- The application should allow adding, deleting, and editing authors and books.
- Books should be added through a modal form without reloading the page.
- All forms should include validation.
- The user interface should be simple and easy to use.

## Example Interface

1. **Author List**:
   - Displays all authors in a table with options to edit or delete.

2. **Author Details Page**:
   - Displays detailed information about an author and a list of their books.

## License

This project is licensed under the MIT License.
