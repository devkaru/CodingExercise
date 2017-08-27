using Norm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.BAL.Models
{
    public class PersonalDataModel
    {
        public ObjectId Id { get; private set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string HomeAddress { get; set; }
        public long HomePhone { get; set; }
        public long Mobile { get; set; }
        public string HomeFax { get; set; }
        public string HomeEmailAddress { get; set; }
        public string DateOfBirth { get; set; }
        public string SSN { get; set; }
        public string PassportNumber { get; set; }
        public string DriverLicenseNumber { get; set; }
        public DateTime ? CreateOn { get; set; }

        public PersonalDataModel()
        {
            CreateOn = DateTime.Now;
        }
    }
}
