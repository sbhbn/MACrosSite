namespace MACrosSite.Pages;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public partial class LoginPage : ContentPage
{
    private readonly string storedUsername;
    private readonly string storedPasswordHash;
    public LoginPage()
    {
        InitializeComponent();

        // Åª¨ú appsettings.json
        var configText = File.ReadAllText("appsettings.json");
        var config = JsonDocument.Parse(configText);
        var loginSection = config.RootElement.GetProperty("Login");
        storedUsername = loginSection.GetProperty("Username").GetString();
        storedPasswordHash = loginSection.GetProperty("PasswordHash").GetString();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        string hashedPassword = ComputeSha256Hash(password);

        if (username == storedUsername && hashedPassword == storedPasswordHash)
        {
            ErrorLabel.IsVisible = false;
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            ErrorLabel.Text = "±b¸¹©Î±K½X¿ù»~";
            ErrorLabel.IsVisible = true;
        }
    }

    private string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            foreach (var b in bytes)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
    }
}