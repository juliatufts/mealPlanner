using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class IngredientDatabase : MonoBehaviour {
	public List<Ingredient> ingredients = new List<Ingredient>();
	
	void Start(){
		ingredients.Add(new Ingredient("Egg", 0));
		ingredients.Add(new Ingredient("Bread", 1));
		ingredients.Add(new Ingredient("Bacon", 2));
		ingredients.Add(new Ingredient("Lettuce", 3));
		ingredients.Add(new Ingredient("Tomato", 4));
		ingredients.Add(new Ingredient("Steak", 5));
		ingredients.Add(new Ingredient("Potato", 6));
	}
}
