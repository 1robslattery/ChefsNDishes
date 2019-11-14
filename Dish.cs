using System.ComponentModel.DataAnnotations;
using System;


    namespace ChefNDishes.Models
    {
        public class Dish
        {

            [Key]
            public int DishID {get; set;}

			// Name of Dish
			[Required(ErrorMessage="Name of dish is required")]
			[MinLength(4, ErrorMessage="No abbreviated dish names, please")]
            public string DishName {get; set;}

			// How Tasty is the Dish
			[Required(ErrorMessage="We must know how tasty this dish is!!  Pick a number between 1-5")]
			[Range(1,5)]
            public int Tastiness {get; set;}

			// How Many Calories in the Dish
			[Required(ErrorMessage="How many calories will this dish be?")]
			[Range(0,4000)]
            public int Calories {get; set;}

			// Description of Dish
			[Required(ErrorMessage="Please describe this dish - be articulate!")]
			[MinLength(25, ErrorMessage="You must enter more than 25 characters!")]
			public string Description {get; set;}

            // The MySQL DATETIME type can be represented by a DateTime
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;

			// Reference a chef (int ChefID) in another table
			// and, the name of the chef who created a dish.
			public int ChefID {get; set;}
			public Chef Cook {get; set;}
        }
    }