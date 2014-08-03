using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectedMeals : MonoBehaviour {
	public List<bool> selectedInv = new List<bool>();		//The real selected meal inventory
	public List<Meal> inventory = new List<Meal>();			//The entire meal inventory (the contents of the database)
	private MealDatabase database;							//The meal database
	private CompleteInventory completeInventory;
	public Meal[] chosenMeals = new Meal[21];

	public int slotsX, slotsY;
	public int buffer, mealBuffer, slotRectWidth; //the buffer amount between slot Rects, the rect width - based on screen size
	public int headerHeight, footerHeight, arrowWidth;
	public GUIStyle arrowStyle_back, arrowStyle_forward;
	public string arrow_back, arrow_forward;
	public int extraSpace = 0;
	public int extraSpace_v = 0;
	public int pageNum = 0;
	public string[] days = new string[7];

	public GUISkin skin;
	public bool drawMeals;
	public bool drawIngreds;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {

		//initialize database, is still empty for some reason at this point
		database = GameObject.FindGameObjectWithTag("MealDatabase").GetComponent<MealDatabase>();
		completeInventory = GameObject.FindGameObjectWithTag("CompleteInventory").GetComponent<CompleteInventory>();
		//initialize the slots and inventory with empty meal objects
		for(int i=0; i < database.meals.Count; i++){
			inventory.Add(new Meal());
			selectedInv.Add(false);
		}
		//fill the inventory with every meal in the database
		for(int i=0; i < database.meals.Count; i++){
			inventory[i] = database.meals[i];
		}

		//Get the day of the week, determine following week
		int date = (int)System.DateTime.Now.DayOfWeek;
		for(var i=0; i < 7; i++){
			var foo = (System.DayOfWeek)((i + date) % 7);
			days[i] = foo.ToString();
		}
		
		//set buffer and slot rect size - based on screen size
		buffer = 24;
		mealBuffer = 12;
		headerHeight = 32;
		arrowWidth = 16;
		//slotsX, slotsY are always 7, 3
		slotsX = 7;
		slotsY = 3;
		
		if(Mathf.FloorToInt((float)(Screen.width - (2 * buffer) - (6 * mealBuffer)) / 7f) <
		   Mathf.FloorToInt((float)(Screen.height - (2 * buffer) - headerHeight - (3 * mealBuffer)) / 3f)){
			slotRectWidth = Mathf.FloorToInt((float)(Screen.width - (2 * buffer) - (6 * mealBuffer)) / 7f);
		} else {
			slotRectWidth = Mathf.FloorToInt((float)(Screen.height - (2 * buffer) - headerHeight - (3 * mealBuffer)) / 3f);
			extraSpace = Mathf.FloorToInt((float)(Screen.width - (2 * buffer) - (6 * mealBuffer) - (7 * slotRectWidth)));
		}
		extraSpace_v = Mathf.FloorToInt((float)(Screen.height - (2 * buffer) - (4 * slotRectWidth) - (headerHeight)));
	}

	void Update () {
		//Update the selected inventory
		selectedInv = completeInventory.selectedInv;
	}

	//Get the meal database and complete inventory
	void GetMeals(){
		database = GameObject.FindGameObjectWithTag("MealDatabase").GetComponent<MealDatabase>();
		//completeInventory = GameObject.FindGameObjectWithTag("CompleteInventory").GetComponent<CompleteInventory>();
		Debug.Log("count:" + database.meals.Count);
		
		//initialize the slots and inventory with empty meal objects
		for(int i=0; i < database.meals.Count; i++){
			inventory.Add(new Meal());
			selectedInv.Add(false);
		}
		
		//fill the inventory with every meal in the database
		for(int i=0; i < database.meals.Count; i++){
			inventory[i] = database.meals[i];
		}
	}
	
	void OnLevelWasLoaded(int level) {
		if (level == 2){
			GetMeals();
			ChooseMeals();
			drawMeals = true;
		}
	}

	//Determine meals and stuff
	void ChooseMeals() {
		//Make new list to store Meal indices
		List<int> selectedInvInd = new List<int>();
		for(int i=0; i < selectedInv.Count; i++){
			if(selectedInv[i]){
				selectedInvInd.Add(i);
				Debug.Log("added something");
			}
		}

		//double content of selected inventory index list
		/*
		for(int i=0; i < selectedInvInd.Count; i++){
			Debug.Log(selectedInvInd[i]);
			selectedInvInd.Add(selectedInvInd[i]);
		}
		*/

		int index = 0;
		int rand = Random.Range(0, 12);
		for(int i=0; i < 21; i++){
			index = (i + rand * 3) % inventory.Count;
			chosenMeals[i] = inventory[index];
			/*
			if((i % 3) == (selectedInvInd[i] % 3)){
				chosenMeals[i] = inventory[index];
			}
			*/
		}
	}

	void OnGUI() {
		GUI.skin = skin;
		if(drawMeals){
			DrawPlanner();
		} else if(drawIngreds){
			DrawIngreds();
		}
	}

	void DrawPlanner(){
		//Draw Days of the week headers
		for(var j=0; j < 7; j++){
			GUI.Box(new Rect(j * (mealBuffer + slotRectWidth) + buffer + Mathf.FloorToInt(extraSpace / 2f), 
			                 buffer + Mathf.FloorToInt(extraSpace_v / 2f), slotRectWidth, headerHeight), days[j], skin.GetStyle("Header"));
		}
		
		//Draw slots with items
		int i = 0;
		for(int x=0; x < slotsX; x++){
			for(int y=0; y < slotsY; y++){
				
				Rect slotRect = new Rect(x * (slotRectWidth + mealBuffer) + buffer + Mathf.FloorToInt(extraSpace / 2f), 
				                         y * (slotRectWidth + mealBuffer) + mealBuffer + buffer + headerHeight + Mathf.FloorToInt(extraSpace_v / 2f),
				                         slotRectWidth, slotRectWidth);
				GUI.Box(slotRect, chosenMeals[i].mealName, skin.GetStyle("Slot"));

				//Draw the inventory
					GUI.Button(slotRect, new GUIContent(chosenMeals[i].mealIcon, chosenMeals[i].mealDesc), skin.GetStyle("SlotIconPlanner"));
					GUI.Label(new Rect (buffer + Mathf.FloorToInt(extraSpace / 2f),
					                    (3 * slotRectWidth) + (4 * mealBuffer) + buffer + headerHeight + Mathf.FloorToInt(extraSpace_v / 2f),
					                    (2 * slotRectWidth) + mealBuffer, footerHeight), GUI.tooltip, skin.GetStyle("Tooltip"));
				i++;
			}
		}
		
		//Draw arrow. forward
		if(pageNum == 1){
			arrowStyle_forward = skin.GetStyle("ArrowNull");
			arrow_forward = "";
		} else {
			arrowStyle_forward = skin.GetStyle("Arrow");
			arrow_forward = ">";
		}
		if(GUI.Button(new Rect(buffer + (6 * slotRectWidth) + (6 * mealBuffer) + Mathf.FloorToInt(extraSpace / 2f), 
		                       (3 * slotRectWidth) + (4 * mealBuffer) + buffer + headerHeight + Mathf.FloorToInt(extraSpace_v / 2f),
		                       Mathf.FloorToInt((float)slotRectWidth / 1.62f), Mathf.FloorToInt((float)slotRectWidth / 1.62f)), arrow_forward, arrowStyle_forward)){
			Debug.Log("go forward");
			if(pageNum < 1){
				drawIngreds = true;
				drawMeals = false;
				pageNum++;
			}
		}
	}

	void DrawIngreds(){
				
		//Draw Ingredients
		GUI.Button(new Rect(buffer, buffer, Screen.width - 2 * buffer, Screen.height - 4 * buffer), "Bread, Bacon, Broccoli, Carrot, Cereal, Crouton, CurrySauce, Dressing, Egg, Lettuce, Milk, Mushroom, Potato, RedPepper, Rice, Steak, Tomato", skin.GetStyle("Ingred"));
		
		//Draw arrow, backwards
		if(pageNum == 0){
			arrowStyle_back = skin.GetStyle("ArrowNull");
			arrow_back = "";
		} else {
			arrowStyle_back = skin.GetStyle("Arrow");
			arrow_back = "<";
		}

		if(GUI.Button(new Rect(buffer + (6 * slotRectWidth) + (6 * mealBuffer) + Mathf.FloorToInt(extraSpace / 2f), 
		                                (3 * slotRectWidth) + (4 * mealBuffer) + buffer + headerHeight + Mathf.FloorToInt(extraSpace_v / 2f),
		                                Mathf.FloorToInt((float)slotRectWidth / 1.62f), Mathf.FloorToInt((float)slotRectWidth / 1.62f)), arrow_back, arrowStyle_back)){
			if(pageNum > 0){
				drawIngreds = false;
				drawMeals = true;
				pageNum--;
			}
		}
	}

}
