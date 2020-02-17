using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientInformationManager.Models
{

    [MetadataType(typeof(Person_Validation))]
    public partial class Person
    {
        //empty class here, we just wanted to add the annotation above
    }

    [MetadataType(typeof(Contact_Validation))]
    public partial class Contact
    {
        //empty class here, we just wanted to add the annotation above
    }

    [MetadataType(typeof(Address_Validation))]
    public partial class Address
    {
        //empty class here, we just wanted to add the annotation above
    }

    [MetadataType(typeof(Picture_Validation))]
    public partial class Picture
    {
        //empty class here, we just wanted to add the annotation above
    }


    //    [Bind(Exclude = "ID")]
    public class Person_Validation
    {
        [Display(Name = "First name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a valid first name")]
        [Required(ErrorMessage = "Please enter a valid first name")]
        public string first_name;

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please enter a valid last name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a valid last name")]
        public string last_name;

        [Display(Name = "Notes")]
        [Required(ErrorMessage = "Please enter some notes")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter some notes")]
        public string notes;

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please enter a valid gender")]
        [RegularExpression("^(?:m|M|male|Male|f|F|female|Female)$", ErrorMessage = "Please enter M, F, Male, Female")]
        public string gender;
    }

    public class Contact_Validation
    {
        [Display(Name = "Type of information")]
        [Required(ErrorMessage = "Please enter the type of information")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter the type of information")]
        public string type;

        [Display(Name = "Information")]
        [Required(ErrorMessage = "Please enter the information")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter the information")]
        public string info;
    }

    public class Address_Validation
    {

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter a City name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a City name")]
        public string city;

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter a decription")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a decription")]
        public string description;

        [Display(Name = "Province/State")]
        [Required(ErrorMessage = "Please enter a Province/State")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a Province/State")]
        public string prov_state;

        [Display(Name = "Street Name")]
        [Required(ErrorMessage = "Please enter a Street Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a Street Name")]
        public string street;

        [Display(Name = "Zip/Postal Code")]
        [Required(ErrorMessage = "Please enter a Zip/Postal Code")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a Zip/Postal Code")]
        public string zip_postal;
    }

    public class Picture_Validation
    {
        [Display(Name = "Caption")]
        [Required(ErrorMessage = "Please enter a Caption")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a Caption")]
        public string caption;

        [Display(Name = "Time Information")]
        [Required(ErrorMessage = "Please enter a Time")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a Time Information")]
        public string time_info;

        [Display(Name = "Location Information")]
        [Required(ErrorMessage = "Please enter a Location")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a Location")]
        public string loc_info;

        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Please enter a Location")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a Location")]
        public string relative_path;

    }
}
