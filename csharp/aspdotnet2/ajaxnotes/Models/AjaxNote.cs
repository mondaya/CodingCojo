using System;
using System.ComponentModel.DataAnnotations;
namespace Models.Note{

    public class AjaxNote: BaseEntity {
        [Key]
        public int id {get; set;}
        [Required]
        public string title {get; set;}        
        public string description {get; set;}

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public AjaxNote(){
            CreatedAt =  DateTime.Now;
            UpdatedAt =  DateTime.Now;
            
        }
    }
}