
namespace Lahor.Shared.Constants
{
    public class EmailMessages
    {
        public const string ResetPasswordSubject = "Lahor Team | Resetovanje lozinke";
        public const string ConfirmationEmailSubject = "Lahor Team | Dodjela korisničkog naloga";
        public const string ClientEmailSubject = "Lahor Team | Dodjela uloge klijenta";

        public static string ResetPasswordEmail(string password)
        {
            return $"Poštovani/a," +
                $"<br/><br/>Uspješno Vam je resetovana lozinka na aplikaciji <b>lahor.ba</b>" +
                $"<br/>Vaša privremena lozinka je: <b>{password}</b>." +
                $"<br/>Nakon što se prijavite na aplikaciju, potrebno je da postavite <b>novu lozinku</b> za Vaš korisnički nalog." +
                $"<br/><br/>Lijep pozdrav" +
                $"<br/>Appointify Team";
        }
        public static string GeneratePasswordEmail(string name, string password)
        {
            string message = $"Poštovani {name}, </br> Uspješno je kreiran račun na aplikaciji <span style='font-style:italic'>Lahor</span>. </br> Vaš privremeni password je:<h4 style='color:blue'> {password} </h4></br> Uživajte u korištenju naše aplikacije. </br> Lijep pozdrav,</br> <span style='font-style: italic'>Lahor Team</span>";
            return message;
        }

        public static string ConfirmationEmail(string username, string password)
        {
            return $"Poštovani/a," +
                $"<br/><br/>Uspješno Vam je dodijeljen korisničko nalog na aplikaciji <b>lahor.ba</b>" +
                $"<br/>Vaše korisničko ime je: <b>{username}</b>, a lozinka je: <b>{password}</b>." +
                $"<br/>Nakon što se prijavite na aplikaciju, potrebno je da postavite <b>novu lozinku</b> za Vaš korisnički nalog." +
                $"<br/><br/>Lijep pozdrav" +
                $"<br/>Lahor Team";
        }

        public static string ClientEmail(string firma)
        {
            return $"Poštovani/a," +
                $"<br/>Firma {firma} Vas je dodala među svoje klijente. Sada možete prijaviti, rezervisati resurse ili usluge." +
                $"<br/><br/>Lijep pozdrav" +
                $"<br/>Lahor Team";
        }

    }
}
