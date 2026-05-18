using System;
using System.Windows.Forms;
using PropertyRentalServices.Database;
using PropertyRentalServices.Forms;

namespace PropertyRentalServices
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test DB connection before launching
            if (!DBConnection.TestConnection())
            {
                MessageBox.Show(
                    "Cannot connect to the database.\n\n" +
                    "Please check:\n" +
                    "1. SQL Server is running\n" +
                    "2. The connection string in App.config is correct\n" +
                    "3. The database 'PropertyRentalDB' exists\n\n" +
                    "Update App.config → connectionStrings → 'Data Source=YOUR_SERVER_NAME'",
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new LoginForm());
        }
    }
}
