using UnityEngine;
using System.Collections;

public class Planner : MonoBehaviour {
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

	void Start () {
		//Get the day of the week, determine following week
		int date = (int)System.DateTime.Now.DayOfWeek;
		Debug.Log(date);
		date = 2;
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

		/*
		//initialize the slots and inventory with empty meal objects
		for(int i=0; i < (slotsX * slotsY); i++){
			slots.Add(new Meal());
			inventory.Add(new Meal());
			selectedInv.Add(false);
		}
		//database = GameObject.FindGameObjectWithTag("MealDatabase").GetComponent<MealDatabase>();
		
		//number of slots is always 6
		slotsX = 3;
		slotsY = 2;
		
		//fill the inventory with every meal in the database
		for(int i=0; i < database.meals.Count; i++){
			inventory[i] = database.meals[i];
		}
		*/
	}
	
	void OnGUI() {
		GUI.skin = skin;
		DrawPlanner();
	}
	
	void DrawPlanner(){
		//Draw Days of the week headers
		for(var j=0; j < 7; j++){
			GUI.Box(new Rect(j * (mealBuffer + slotRectWidth) + buffer + Mathf.FloorToInt(extraSpace / 2f), 
			                 buffer + Mathf.FloorToInt(extraSpace_v / 2f), slotRectWidth, headerHeight), days[j], skin.GetStyle("Header"));
		}

		//Draw slots with items
		int i = 0;
		for(int y=0; y < slotsY; y++){
			for(int x=0; x < slotsX; x++){
				/*
				if(0 == (database.meals.Count % 3)){
					//do nothing
				} else if(y == (slotsY - 1) && x == (database.meals.Count % 3)){
					break;
				}
				*/
				
				Rect slotRect = new Rect(x * (slotRectWidth + mealBuffer) + buffer + Mathf.FloorToInt(extraSpace / 2f), 
				                         y * (slotRectWidth + mealBuffer) + mealBuffer + buffer + headerHeight + Mathf.FloorToInt(extraSpace_v / 2f),
				                         slotRectWidth, slotRectWidth);
				GUI.Box(slotRect, "Test Name", skin.GetStyle("Slot"));
				//slots[i] = inventory[(pageNum * 6) + i];
				
				//update the bools for selected inventory
				//slotsSelectedInv[i] = selectedInv[(pageNum * 6) + i];

				/*
				//Draw the inventory
				if(slots[i].mealName != null){
					slotsSelectedInv[i] = GUI.Toggle(slotRect, 
					                                 slotsSelectedInv[i], 
					                                 new GUIContent(slots[i].mealIcon, 
					               slots[i].mealDesc), 
					                                 slotsSelectedInv[i] ? skin.GetStyle("SlotIconHighlight") : skin.GetStyle("SlotIcon"));
					selectedInv[(pageNum * 6) + i] = slotsSelectedInv[i];
					GUI.Label(new Rect (buffer + Mathf.FloorToInt(extraSpace / 2f),
					                    buffer + headerHeight + (3 * mealBuffer) + (2 * slotRectWidth),
					                    (2 * slotRectWidth) + mealBuffer, footerHeight), GUI.tooltip, skin.GetStyle("Tooltip"));
				}
				
				i++;
				*/
			}
		}
		
		//Draw arrows
		//backwards
		if(pageNum == 0){
			arrowStyle_back = skin.GetStyle("ArrowNull");
			arrow_back = "";
		} else {
			arrowStyle_back = skin.GetStyle("Arrow");
			arrow_back = "<";
		}
		if(GUI.Button(new Rect(Screen.width - buffer - slotRectWidth - Mathf.FloorToInt(extraSpace / 2f),
		                       (3 * slotRectWidth) + (4 * mealBuffer) + buffer + headerHeight + Mathf.FloorToInt(extraSpace_v / 2f),
		                       Mathf.FloorToInt((float)slotRectWidth / 1.62f), Mathf.FloorToInt((float)slotRectWidth / 1.62f)), arrow_back, arrowStyle_back)){
			Debug.Log("go back");
			if(pageNum > 0){
				pageNum--;
			}
		}
		//forwards
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
				pageNum++;
			}
		}
	}
}
