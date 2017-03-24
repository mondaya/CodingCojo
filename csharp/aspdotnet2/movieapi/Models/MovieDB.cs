using System;
using System.ComponentModel.DataAnnotations;
namespace Models.Movie{

    public class MovieDB: BaseEntity {

        [Key]
        public int id {get; set;}

        [Required]
        public string title {get; set;}

        [Required]
        public float rating {get; set;}

        [Required]
        public DateTime releasedAt {get; set;}

        public DateTime createdAt {get; set;}

        public MovieDB(){
            createdAt = DateTime.Now;
        }
 

    }
}

