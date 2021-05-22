# rotfaipoonpoon
Database project (KMUTT CPE332) using ASP.NET and Microsoft SQL Server
- PB 4012
- SP 4016
- PSP 4030
<br />
Project Tour Video on YouTube: https://youtu.be/XQAIsSpFb1o
<br />
How to run the project (code)
1.	Download the Train_project.rar and extract the file at your desired path (e.g., Desktop)
2.	Open Train_project.sln with Visual Studio
3.	Delete the Migration folder
4.	Go to Tools  NuGet Package Manager  Package manager console.
5.	Run: add-migration InitialCreate (or any desired name)
6.	After that, run: update-database
7.	Go to SQL server and check if the database has been built (The name is Train_database)
8.	Go to Databases  Train_database  Tables  dbo.AdminLogins. Then, query the username and password for admin as you desired (for example, username = admin, password = admin)
9.	Run the project, it will be run on set browser.
10.	Scroll down to the bottom of the first page, you will see the “Developer” and “Admin” hyperlinks, click “Admin” first.
11.	Login with the username and password you set.
12.	Set Routes, Train Classes, Promotions, Staffs, Train, and Schedule
13.	Next, click the Passengers tab, it will take you to the passenger details page. Then, click Sign Up, enter the passenger details, and click Create. The customer’s detail will be show in the index of the Passenger page and save in the database, you can inspect this by select (view) the top rows of the table you want.
14.	After that, click the “Book a Ticket” tab to book a ticket (this can be done after inputting every other tables already). Customer can take a look at promotion percent, routes, class prices, and train info. Click the “Book a ticket now” to book a train ticket, select Date Issued (click the “Today” button), Passenger ID, Train ID, Train Class ID, Route ID, Schedule ID, Promotion ID. Then, click “Buy a Ticket”, the page will ask you for a confirmation, click confirm to book a ticket.
15.	After booking a ticket, the ticket that customer will use to travel is available if click the “Detail” tab, it will automatically generate the ticket for each customer including the information they selected.
16.	We can do the CRUD operation on every data rows, both customer (their own information) and administrator (the information that required an admin login)

