# PropertyRentalServices - Windows Forms (.NET Framework 4.7.2)

## ============================================================
## STEP-BY-STEP SETUP GUIDE
## ============================================================

---

## PART 1: DATABASE SETUP (SSMS)

### Step 1 — Open SQL Server Management Studio (SSMS)
1. Launch **SSMS** from Start Menu
2. Connect to your SQL Server instance
   - Server name examples: `localhost`, `.\SQLEXPRESS`, `(local)`, `DESKTOP-XXXXX\SQLEXPRESS`
   - Authentication: Windows Authentication (recommended) or SQL Server Authentication

### Step 2 — Run the SQL Script
1. In SSMS, click **File → Open → File**
2. Browse and open `PropertyRentalDB.sql` (included in this zip)
3. Click **Execute** (or press **F5**)
4. You should see: `PropertyRentalDB created successfully!`
5. In Object Explorer, refresh and confirm **PropertyRentalDB** appears

### Step 3 — Note Your Server Name
- In SSMS Object Explorer, the top node shows your server name
- Examples: `DESKTOP-ABC123\SQLEXPRESS` or `localhost`
- **Copy this — you will need it in Step 4**

---

## PART 2: VISUAL STUDIO SETUP

### Step 4 — Update Connection String
1. Open the project folder
2. Open **App.config** in any text editor (Notepad, VS Code, etc.)
3. Find this line:
   ```
   Data Source=YOUR_SERVER_NAME
   ```
4. Replace `YOUR_SERVER_NAME` with your actual server name from Step 3
   
   **Examples:**
   ```xml
   <!-- For SQL Express -->
   Data Source=.\SQLEXPRESS;Initial Catalog=PropertyRentalDB;Integrated Security=True
   
   <!-- For default SQL Server instance -->
   Data Source=localhost;Initial Catalog=PropertyRentalDB;Integrated Security=True
   
   <!-- For named instance -->
   Data Source=DESKTOP-ABC123\SQLEXPRESS;Initial Catalog=PropertyRentalDB;Integrated Security=True
   ```
5. Save App.config

### Step 5 — Open in Visual Studio
1. Open **Visual Studio 2019 or 2022**
2. Click **File → Open → Project/Solution**
3. Navigate to the unzipped folder
4. Select `PropertyRentalServices.csproj`
5. Click **Open**

### Step 6 — Restore / Check References
Visual Studio may prompt to restore references. If you see errors:
1. Right-click the project in Solution Explorer → **Properties**
2. Confirm Target Framework is **.NET Framework 4.7.2**
3. Check that `System.Data.SqlClient` reference exists:
   - Right-click **References** → **Add Reference**
   - Check: `System.Data`, `System.Data.SqlClient`, `System.Configuration`

### Step 7 — Build & Run
1. Press **Ctrl+Shift+B** to Build
2. Press **F5** to Run (or Ctrl+F5 without debugger)
3. The Login screen will appear

---

## PART 3: LOGIN CREDENTIALS

| Role       | Email                  | Password  |
|------------|------------------------|-----------|
| SuperAdmin | admin@rental.com       | admin123  |
| Owner      | john@owner.com         | owner123  |
| Customer   | alice@customer.com     | cust123   |

---

## PART 4: USING THE APPLICATION

### As SuperAdmin:
- View all users, properties, bookings, reviews
- Delete low-rated owners (avg rating < 2.0)

### As Owner:
- Add/Edit/Delete your properties
- View earnings from confirmed bookings
- Add discount offers to properties

### As Customer:
- Browse & filter properties (price, location, bedrooms, status)
- Add properties to cart with check-in/check-out dates
- Confirm booking → Payment form
- Review properties after confirmed booking

---

## TROUBLESHOOTING

| Problem | Solution |
|---------|----------|
| "Cannot connect to database" | Check server name in App.config |
| "Database not found" | Re-run PropertyRentalDB.sql in SSMS |
| Build errors on SqlClient | Add reference to System.Data.SqlClient |
| Login fails | Make sure seed data was inserted (check Users table in SSMS) |
| .NET version error | Install .NET Framework 4.7.2 Developer Pack |

---

## PROJECT STRUCTURE

```
PropertyRentalServices/
├── App.config                    ← Connection string HERE
├── Program.cs                    ← Entry point
├── PropertyRentalServices.csproj ← Project file
├── PropertyRentalDB.sql          ← Run in SSMS first
├── Database/
│   └── DBConnection.cs           ← DB helper class
├── Models/
│   └── SessionManager.cs         ← Logged-in user session
└── Forms/
    ├── LoginForm.cs
    ├── RegisterForm.cs
    ├── AdminDashboard.cs
    ├── OwnerDashboard.cs
    ├── CustomerDashboard.cs
    ├── PaymentForm.cs
    └── ReviewForm.cs             ← Includes ReviewViewForm
```

---

## DATABASE TABLES

- **Users** — UserId, Name, Email, Password, Role
- **Property** — PropertyId, OwnerId, Title, Location, Price, Bedrooms, Status, Description
- **Booking** — BookingId, PropertyId, CustomerId, StartDate, EndDate, TotalPrice, Status
- **Payment** — PaymentId, BookingId, Amount, PaymentDate, Method
- **Review** — ReviewId, PropertyId, UserId, Rating, Comment, ReviewDate
- **Offer** — OfferId, PropertyId, DiscountPercent, StartDate, EndDate, Description
