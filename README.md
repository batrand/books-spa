# Books SPA
Interview take home project for 1Breadcrumb

# Requirements
- [x] Implement API specified at https://libapi.1breadcrumb.com/
- [ ] Optionally implement Angular client

I have implemented the API specified at the 1breadcrumb swagger document, and an additional `delete` API.

I have started implementing the Angular client, but considering the time it will take to learn REST integration will be quite long after the interview, I'm submitting now with only the backend API.

# Run notes
The backend uses EF Core SQLite. Even though it's against best practices, for ease of access, I have included a copy of the DB in the repo; it's not too big. Therefore, you should be able to just run the backend and have a functioning API straight away.

In the event you want to generate a fresh DB, you can delete the `db.sqlite*` files and run the following commands:

- `dotnet tool install -g dotnet-ef` to install EF Core Tools
- `cd books-spa\BooksSpa\BooksSpa.Api`
- `dotnet ef database update`