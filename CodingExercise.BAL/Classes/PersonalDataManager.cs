
using CodingExercise.BAL.Models;
using CodingExercise.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.BAL.Classes
{
    public static class PersonalDataManager
    {
        public static List<PersonalDataModel> GetAll()
        {
            return DbContext.Current.All<PersonalDataModel>().OrderBy(d => d.Id).ToList();
        }

        public static List<PersonalDataModel> Find(string keyword)
        {
            List<PersonalDataModel> personalData = null;

            if (keyword.Length > 0)
            {
                personalData = DbContext.Current.All<PersonalDataModel>().Where(d => d.FullName.ToLower().Contains(keyword.ToLower())).OrderBy(d => d.Id).ToList();
            }
            else
            {
                personalData = GetAll();
            }

            return personalData;
        }

        public static void Save(PersonalDataModel dragon)
        {
            DbContext.Current.Add(dragon);
        }

        public static void Delete(string Id)
        {
            DbContext.Current.Delete<PersonalDataModel>(d => d.Id == Id);
        }
    }
}
