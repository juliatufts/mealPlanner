using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Meal {
	public string mealName;
	public int mealID;
	public string mealDesc;
	public Texture2D mealIcon;
	public MealType mealType;
	public Ingred[] mealIngreds;

	public enum MealType {
		Breakfast,
		Lunch,
		Dinner
	}

	public enum Ingred {
		Bagel,
		Bean,
		Bread,
		Bun,
		Bacon,
		Broccoli,
		Carrot,
		Cheese,
		Cereal,
		Crouton,
		CurrySauce,
		Dressing,
		Egg,
		Flour,
		GroundBeef,
		Lettuce,
		Milk,
		Mushroom,
		Oil,
		People,
		PB,
		Potato,
		RedPepper,
		Rice,
		SoylentGreen,
		Steak,
		Tomato,
		Tortilla
	}

	//Meal constructors
	public Meal(string name, int id, string desc, MealType type, Ingred[] ingreds){
		mealName = name;
		mealID = id;
		mealDesc = desc;
		mealIcon = Resources.Load<Texture2D>("Icons/" + name);
		mealType = type;
		mealIngreds = ingreds;
	}
	public Meal(string name, int id, string desc, MealType type){
		mealName = name;
		mealID = id;
		mealDesc = desc;
		mealIcon = Resources.Load<Texture2D>("Icons/" + name);
		mealType = type;
	}

	public Meal(){

	}
}
