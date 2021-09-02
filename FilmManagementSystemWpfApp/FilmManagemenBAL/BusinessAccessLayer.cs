using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmManagementBEL;
using FilmManagementDAL;
using System.Data;
using System.Data.SqlClient;

namespace FilmManagemenBAL
{
    public class BusinessAccessLayer
    {
        DataAccessLayer dal_obj = new DataAccessLayer();



        public DataTable getFilms()
        {
            return dal_obj.getFilms();
        }

        public int insertFilms(BusinessEntityLayerFilm obj)
        {
            return dal_obj.InsertFilm(obj);
        }
        public int UpdateFilms(string FilmTitle, BusinessEntityLayerFilm obj)
        {
            return dal_obj.UpdateFilm(FilmTitle, obj);
        }

        public DataTable SearchTitle(string FilmTitle)
        {
            return dal_obj.SearchTitle(FilmTitle);
        }

        public DataTable SearchRating(int Rating)
        {
            return dal_obj.SearchRating(Rating);
        }

        public DataTable SearchLanguage(string Language)
        {
            return dal_obj.SearchLanguage(Language);
        }

        public DataTable SearchCategory(string CategoryId)
        {
            return dal_obj.SearchCategory(CategoryId);
        }

        public DataTable SearchActor(string ActorId)
        {
            return dal_obj.SearchActor(ActorId);
        }

        public int deleteFilm(string FilmTitle)
        {
            return dal_obj.deleteFilm(FilmTitle);
        }




    }


}

