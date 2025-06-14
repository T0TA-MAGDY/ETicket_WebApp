# 🎟️ Ticketer - E-Tickets Booking Web App

**Ticketer** is a full-stack ASP.NET Core MVC application designed to streamline cinema ticket booking with a modern user experience for both customers and administrators.

## 🌟 Features

### 🎬 User Side
- Browse movies with details like cast, producer, trailer, and showtimes
- Add movies to favorites
- Submit reviews and ratings
- View actors, producers, and cinema information
- Download purchased tickets
- Receive email notifications when new movies are added
- Reset password via email

### 🛠️ Admin Side
- Manage movies, cinemas, actors, and producers
- Add and update showtimes
- View all registered users
- View all orders

> ✅ **Note:** Admin accounts are *seeded* and not created manually.

## 🔐 Seeded Accounts

### Admins
- **Email:** `admin@etickets.com`  
  **Password:** `Coding@1234?`


### Test User
- **Email:** `user@etickets.com`  
  **Password:** `Coding@1234?`

> ⚠️ It's **recommended** to create a user account using your real email to test:
> - Password reset functionality  
> - New movie email notifications

## ⚙️ Configuration Required

Before running the application, make sure to update the following in your `appsettings.json`:

### 🗃️ SQL Server Connection

Replace with your actual SQL Server connection string:
```json
 "ConnectionStrings": {
   "DefaultConnectionString": "Data Source=Your_Server;Initial Catalog=ticketer10;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"

 }
```
## 📧 Email Service Setup (SMTP)

To enable and test email-based features like password resets and movie alerts:

1. Create an account with an SMTP provider (e.g., Gmail, Outlook, etc.).
2. Generate an **App Password** or use your SMTP credentials.
3. Update your `appsettings.json` with your SMTP settings:
   ```json
   "EmailSettings": {
     "Host": "smtp.yourprovider.com",
     "Port": 587,
     "EnableSSL": true,
     "UserName": "your_email@example.com",
     "Password": "your_app_password"
   }
