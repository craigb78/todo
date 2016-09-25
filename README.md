# ToDoList in Dot Net 4.5.2 using NancyFX

- Built using http://nancyfx.org/ 
- "Nancy is a lightweight, low-ceremony, framework for building HTTP based services on .NET"


# API

GET /todolists 
- Returns a JSON response containing all existing todo lists
- Http status code should be 200 OK

GET /todolist/{id}
- Get a todolist by id
- Http status code is 200 OK or 404 NOT FOUND
- 
POST /todolist
- POST a JSON document containing a todo list and zero or more items
- Http status code is 202 ACCEPTED

PUT /todolist/{listId}/item
- PUT an item into an existing to do list
- HTTP status code is 202 ACCEPTED or 404 NOT FOUND (if list could not be found).