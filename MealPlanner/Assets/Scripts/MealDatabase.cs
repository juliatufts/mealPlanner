using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MealDatabase : MonoBehaviour {
	public List<Meal> meals = new List<Meal>();

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void Start(){
		meals.Add(new Meal("Eggs and toast", 0, "Eggs and toast", Meal.MealType.Breakfast,
		                    new Meal.Ingred[]{Meal.Ingred.Egg, 
											  Meal.Ingred.Bread}));
		meals.Add(new Meal("Sandwich", 1, "Sandwich with bacon, lettuce and tomato", Meal.MealType.Lunch, 
		          			new Meal.Ingred[]{Meal.Ingred.Bread,
											  Meal.Ingred.Bacon,
											  Meal.Ingred.Lettuce,
											  Meal.Ingred.Tomato}));
		meals.Add(new Meal("Steak and potatoes", 2, "Steak and potatoes", Meal.MealType.Dinner, 
		                    new Meal.Ingred[]{Meal.Ingred.Steak, 
											  Meal.Ingred.Potato}));
		meals.Add(new Meal("Cereal", 3, "Cereal and milk", Meal.MealType.Breakfast, 
		                   new Meal.Ingred[]{Meal.Ingred.Cereal, 
											 Meal.Ingred.Milk}));
		meals.Add(new Meal("Salad", 4, "Salad with Lettuce, Bacon, Croutons, Dressing", Meal.MealType.Lunch, 
		                   new Meal.Ingred[]{Meal.Ingred.Lettuce, 
											 Meal.Ingred.Bacon,
											 Meal.Ingred.Crouton,
											 Meal.Ingred.Dressing}));
		meals.Add(new Meal("Stirfry", 5, "Stirfry with Rice, Carrot, Broccoli, Red Pepper, Mushrooms, Curry Sauce", Meal.MealType.Dinner, 
		                   new Meal.Ingred[]{Meal.Ingred.Rice, 
										   	 Meal.Ingred.Carrot,
											 Meal.Ingred.Broccoli,
											 Meal.Ingred.RedPepper,
											 Meal.Ingred.Mushroom,
											 Meal.Ingred.CurrySauce}));
		meals.Add(new Meal("Toast and peanut butter", 6, "Toast and Peanut Butter", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.PB, 
											 Meal.Ingred.Bread}));
		meals.Add(new Meal("Burrito", 7, "Burrito with rice, beans, cheese and red pepper", Meal.MealType.Lunch,
		                   new Meal.Ingred[]{Meal.Ingred.Tortilla, 
											 Meal.Ingred.Rice,
											 Meal.Ingred.Bean,
											 Meal.Ingred.Cheese,
											 Meal.Ingred.RedPepper}));
		meals.Add(new Meal("Pizza", 8, "Pizza", Meal.MealType.Dinner,
		                   new Meal.Ingred[]{Meal.Ingred.Flour, 
											 Meal.Ingred.Egg,
											 Meal.Ingred.Oil,
											 Meal.Ingred.Tomato,
											 Meal.Ingred.Cheese}));


		meals.Add(new Meal("Breakfast sandwich", 9, "Breakfast sandwich with bacon and cheese", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.Bagel,
			Meal.Ingred.Egg,
			Meal.Ingred.Cheese,
			Meal.Ingred.Bacon}));
		meals.Add(new Meal("Hamburger", 10, "Hamburger and fries", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.GroundBeef,
			Meal.Ingred.Bun,
			Meal.Ingred.Cheese,
			Meal.Ingred.Tomato,
			Meal.Ingred.Lettuce,
			Meal.Ingred.Potato}));
		meals.Add(new Meal("Soylent Green", 11, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.SoylentGreen }));
		/*
		meals.Add(new Meal("Soylent Green", 12, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 13, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 14, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 15, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 16, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 17, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 18, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 19, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 20, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 21, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 22, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Soylent Green", 23, "Soylent green is made of people", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.People, }));
		meals.Add(new Meal("Eggs and toast", 10, "Eggs and toast", Meal.MealType.Lunch,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
											 Meal.Ingred.Bread}));
		meals.Add(new Meal("Eggs and toast", 11, "Eggs and toast", Meal.MealType.Dinner,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
											 Meal.Ingred.Bread}));

		meals.Add(new Meal("Eggs and toast", 12, "Eggs and toast", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
											 Meal.Ingred.Bread}));
		meals.Add(new Meal("Eggs and toast", 13, "Eggs and toast", Meal.MealType.Lunch,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
											 Meal.Ingred.Bread}));
		meals.Add(new Meal("Eggs and toast", 14, "Eggs and toast", Meal.MealType.Dinner,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
											 Meal.Ingred.Bread}));

		meals.Add(new Meal("Cereal", 15, "Cereal and milk", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.Cereal, 
											 Meal.Ingred.Milk}));
		meals.Add(new Meal("Eggs and toast", 16, "Eggs and toast", Meal.MealType.Lunch,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
			Meal.Ingred.Bread}));
		meals.Add(new Meal("Eggs and toast", 17, "Eggs and toast", Meal.MealType.Dinner,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
			Meal.Ingred.Bread}));

		meals.Add(new Meal("Eggs and toast", 18, "Eggs and toast", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
											 Meal.Ingred.Bread}));
		meals.Add(new Meal("Eggs and toast", 19, "Eggs and toast", Meal.MealType.Lunch,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
			Meal.Ingred.Bread}));
		meals.Add(new Meal("Eggs and toast", 20, "Eggs and toast", Meal.MealType.Dinner,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
			Meal.Ingred.Bread}));

		meals.Add(new Meal("Eggs and toast", 18, "Eggs and toast", Meal.MealType.Breakfast,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
			Meal.Ingred.Bread}));
		meals.Add(new Meal("Eggs and toast", 19, "Eggs and toast", Meal.MealType.Lunch,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
			Meal.Ingred.Bread}));
		meals.Add(new Meal("Eggs and toast", 20, "Eggs and toast", Meal.MealType.Dinner,
		                   new Meal.Ingred[]{Meal.Ingred.Egg, 
			Meal.Ingred.Bread}));
		*/
	}
}
