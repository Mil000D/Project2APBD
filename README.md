# Project 2: Summary

The goal of this project is to create an ASP.NET Core Web Application to support the university in managing student data. The project involves the following tasks:

1. Create a `StudentsController` to handle data management related to students.
2. The `StudentsController` should include 5 public methods for managing student data.
3. All data should be stored in a local database in CSV file format. The CSV file should contain the following fields: `Name`, `Surname`, `Direction of Study`, `Mode of Study`, `S grade`, `Date of Birth`, `Email`, `Mother's Name`, and `Father's Name`.
4. The API should return data in JSON format.
5. The first endpoint should respond to an HTTP GET request to the `/students` address. When requested without any parameters, it should retrieve the list of students from the local CSV database file. This endpoint can be seen as equivalent to a "SELECT * FROM students" query.
6. Additionally, the `GET /students` endpoint allows passing a parameter as a segment of the URL address, providing the ability to retrieve a specific student. It can also be added as a separate suffix. For example, a `GET /students/s1234` request should return a single student with the specified index number.
7. The second endpoint, responding to the `PUT /students/s1234` request, allows updating data for a specific student. The endpoint expects the updated student data to be sent in JSON format. Note that only the "index number" field should not be modified and serves as the student identifier. Upon success, the endpoint should return the updated student data.
8. The third endpoint should allow adding a new student by executing a `POST` request to the `/students` address. The endpoint accepts the data of the new student in the request body, in JSON format. Before adding a new student, validation should be performed to ensure that all required data is complete. If any data is missing, an appropriate error code should be returned. Additionally, the uniqueness and format of the selected index number should be checked. The new student should be added to the end of the CSV file, which serves as the database.
9. The fourth endpoint should respond to requests like `DELETE /students/s1234` and allow removing a specific student from the database.
10. Proper HTTP codes should be returned, and error handling should be implemented to handle possible errors.
