using System;
using System.ComponentModel.DataAnnotations;

namespace Resturanter.Models{

    public class Review{
        [Key]
        public int id  {get; set;}
        public string ReviewerName {get; set;}
        public string ResturantName {get; set;}

        public string ReviewText {get; set;}

        public DateTime DateOfVisit {get; set;}

        public int Stars {get; set;}


    }


}