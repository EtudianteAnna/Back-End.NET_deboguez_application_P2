using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Fourni des méthodes de services pour gérer la langue de l'application
    /// </summary>
    public class LangageService : ILangageService

    {



        /// <summary>
        /// Positionne la langue de l'interface utilisateur
        /// </summary>
        public void ChangeLangageInterfaceUtilisateur(HttpContext context, string langage)
        {
            string culture = SetCulture(langage);
            MettreAJourLeCookieDeCulture(context, culture);
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(culture);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        /// <summary>
        /// Positionne la culture
        /// </summary>
        public string SetCulture(string langage)
        {

            // méthode SetCulture qui prend en charge trois langues : l'anglais, l'espagnol et le français :

            string culture = "";


            //une instruction switch pour déterminer la langue et retourner le code de culture approprié.
            //Si la langue n'est pas reconnue, la méthode retourne la culture anglaise par défaut.

            switch (langage)
            {
                case "Anglais" or "English" or "Inglés":
                    culture = "en-US";
                    break;
                case "Espagnol" or "Spanish" or "Español":
                    culture = "es-ES";
                    break;
                case "Français" or "French" or "Francés":
                    culture = "fr-FR";
                    break;

                default:
                    culture = "en-US";
                    break;
            }

            return culture;
        }





        /// <summary>
        /// Met à jour le cookie de culture// la méthode Response.Cookies.Append pour ajouter ou mettre à jour le cookie de culture dans la réponse HTTP.
        /// Le nom du cookie est le nom par défaut de CookieRequestCultureProvider,
        /// et la valeur est créée à partir de la culture passée en paramètre à l'aide de la méthode MakeCookieValue.
        /// </summary>
        public void MettreAJourLeCookieDeCulture(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));

        }
    }
}
