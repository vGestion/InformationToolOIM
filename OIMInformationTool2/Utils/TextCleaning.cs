namespace OIMInformationTool2.Utils
{
    public class TextCleaning
    {

        public String ReplaceAccents(String palabra)
        {
            palabra = palabra.ToUpper();
            palabra = palabra.Replace('Á', 'A').Replace('É', 'E').Replace('Í', 'I')
                .Replace('Ó', 'O').Replace('Ú', 'U').Replace('Ä', 'A').Replace('Ë', 'E')
                .Replace('Ï', 'I').Replace('Ö', 'O').Replace('Ü', 'U').Replace('Â', 'A')
                .Replace('Ê', 'E').Replace('Î', 'I').Replace('Ô', 'O').Replace('Û', 'U')
                .Replace('À', 'A').Replace('È', 'E').Replace('Ì', 'I').Replace('Ò', 'O')
                .Replace('Ù', 'U').Replace(" ","");
            return palabra;
        }
    }
}

