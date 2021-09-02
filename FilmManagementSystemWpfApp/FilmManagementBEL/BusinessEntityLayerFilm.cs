using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FilmManagementBEL
{
    public partial class BusinessEntityLayerFilm
    {
        public int FilmID { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int RentalDuration { get; set; }
        public double RentalRate { get; set; }
        public double Length { get; set; }
        public double ReplacementCost { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int LanguageID { get; set; }
        public int ActorID { get; set; }
        
    }

    public class BusinessEntityLayerActor
    {
        public int ActorID { get; set; }
        public string ActorName { get; set; }
    }

    public class BusinessEntityLayerCategory
    {
        public int CategoryID { get; set; }
        public string Category { get; set; }
    }


    public class BusinessEntityLayerLanguage
    {
        public int LanguageID { get; set; }
        public string Language { get; set; }
    }


}
