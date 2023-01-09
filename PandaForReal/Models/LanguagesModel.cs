namespace PandaForReal.Models
{
    
    public class LanguagesModel
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Language[] languages { get; set; }
    }

    public class Language
    {
        public string language { get; set; }
    }

}
