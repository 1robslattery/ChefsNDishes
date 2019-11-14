using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using formsubmit.Models.Validators;
using System;

    namespace ChefNDishes.Models
    {
        public class Chef
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int ChefID {get; set;}
            // MySQL VARCHAR and TEXT types can be represeted by a string

			// First Name
			[Required(ErrorMessage="Our Chef must have a first name.")]
			[MinLength(3, ErrorMessage="No abbreviated names, please.")]
            public string FirstName {get; set;}

			// Last Name
			[Required(ErrorMessage="Our Chef must have a last name.")]
			[MinLength(3, ErrorMessage="No abbreviated names, please.")]
            public string LastName {get; set;}

			// Date of Birth
			[Required(ErrorMessage = "Date must be in the past.")]
			[PastDate]
			[DataType(DataType.Date)]
			public DateTime BirthDate {get; set;}

			// Chef's Age
			// [Required(ErrorMessage="We must know how old the Chef is, pick a number between 18-99")]
			// [Range(18,99)]
            public int Age {get; set;}

            // The MySQL DATETIME type can be represented by a DateTime
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;

			// Reference a list of dishes (<Dish>) in another table
			// This is known as a Navigation Property.
			public List<Dish> nameofdish {get;set;}
        }
    }