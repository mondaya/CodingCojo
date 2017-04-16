using System;
using System.ComponentModel.DataAnnotations;


namespace NetworkProfessional.Models
{

    public class RsvpView : BaseEntity
    {


        [RequiredAttribute()]
        public string RsvpName { get; set; }

        public char RsvpSide { get; set; }

    }
}