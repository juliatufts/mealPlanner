using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Ingredient {
	public string ingredName;
	public int ingredID;
	public Texture2D ingredIcon;
	
	//Ingredient constructor
	public Ingredient(string name, int id){
		ingredName = name;
		ingredID = id;
		ingredIcon = Resources.Load<Texture2D>("IngredIcons/" + name);
	}
	
	public Ingredient(){
		
	}
}
