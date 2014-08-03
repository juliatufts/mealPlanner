using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompleteInventory : MonoBehaviour {
	public int slotsX, slotsY;
	public int buffer, mealBuffer, slotRectWidth; //the buffer amount between slot Rects, the rect width - based on screen size
	public int headerHeight, footerHeight, arrowWidth;
	public GUIStyle arrowStyle_back, arrowStyle_forward;
	public string arrow_back, arrow_forward;
	public int extraSpace = 0;
	public int pageNum = 0;
	public GUISkin skin;

	public List<bool> selectedInv = new List<bool>();			//The real selected inventory
	public bool[] slotsSelectedInv = 
		new bool[]{false, false, false, false, false, false};	//The temp selected inventory displayed for each page		
	public List<Meal> inventory = new List<Meal>();
	public List<Meal> slots = new List<Meal>();
	public Vector2 scrollPosition = Vector2.zero;
	private MealDatabase database;

	void Start () {
		//set buffer and slot rect size - based on screen size
		buffer = 24;
		mealBuffer = 12;
		headerHeight = 32;
		footerHeight = 24;
		arrowWidth = 16;

		//Determine slot width, calculate leftover space
		if(Mathf.FloorToInt((float)(Screen.width - 2 * buffer - 2 * mealBuffer) / 3f) <
		   Mathf.FloorToInt((float)(Screen.height - buffer - headerHeight - 4 * mealBuffer - footerHeight) / 2f)){
			slotRectWidth = Mathf.FloorToInt((float)(Screen.width - 2 * buffer - 2 * mealBuffer) / 3f);
		} else {
			slotRectWidth = Mathf.FloorToInt((float)(Screen.height - buffer - headerHeight - 4 * mealBuffer - footerHeight) / 2f);
			extraSpace = Mathf.FloorToInt((float)(Screen.width - 2 * buffer - 2 * mealBuffer - 3 * slotRectWidth));
		}

		//initialize the slots and inventory with empty meal objects
		for(int i=0; i < (slotsX * slotsY); i++){
			slots.Add(new Meal());
			inventory.Add(new Meal());
			selectedInv.Add(false);
		}
		database = GameObject.FindGameObjectWithTag("MealDatabase").GetComponent<MealDatabase>();

		//number of slots is always 6
		slotsX = 3;
		slotsY = 2;

		//fill the inventory with every meal in the database
		for(int i=0; i < database.meals.Count; i++){
			inventory[i] = database.meals[i];
		}
	}

	void OnGUI() {
		GUI.skin = skin;
		DrawInventory();
	}

	void DrawInventory(){
		//Draw headers
		GUI.Box(new Rect(buffer + Mathf.FloorToInt(extraSpace / 2f), buffer, slotRectWidth, headerHeight), "Breakfast", skin.GetStyle("Header"));
		GUI.Box(new Rect(slotRectWidth + buffer + mealBuffer + Mathf.FloorToInt(extraSpace / 2f), buffer, slotRectWidth, headerHeight), "Lunch", skin.GetStyle("Header"));
		GUI.Box(new Rect(2 * slotRectWidth + buffer + (2 * mealBuffer) + Mathf.FloorToInt(extraSpace / 2f), buffer, slotRectWidth, headerHeight), "Dinner", skin.GetStyle("Header"));

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
				                         y * (slotRectWidth + mealBuffer) + mealBuffer + buffer + headerHeight, 
				                         slotRectWidth, slotRectWidth);
				GUI.Box(slotRect, slots[i].mealName, skin.GetStyle("Slot"));
				slots[i] = inventory[(pageNum * 6) + i];

				//update the bools for selected inventory
				slotsSelectedInv[i] = selectedInv[(pageNum * 6) + i];

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
			}
		}

		//Draw arrows
		//forward
		if(pageNum == 0){
			arrowStyle_back = skin.GetStyle("ArrowNull");
			arrow_back = "";
		} else {
			arrowStyle_back = skin.GetStyle("Arrow");
			arrow_back = "<";
		}
		if(GUI.Button(new Rect(Mathf.FloorToInt(buffer / 2f) - Mathf.FloorToInt(arrowWidth / 2f) + Mathf.FloorToInt(extraSpace / 4f),
		                 buffer + headerHeight + mealBuffer + Mathf.FloorToInt(slotRectWidth / 2) + Mathf.FloorToInt(mealBuffer / 2),
		                 arrowWidth, slotRectWidth + mealBuffer), arrow_back, arrowStyle_back)){
			Debug.Log("go back");
			if(pageNum > 0){
				pageNum--;
			}
		}
		//back
		if(pageNum == Mathf.CeilToInt((float)database.meals.Count / 6f) - 1){
			arrowStyle_forward = skin.GetStyle("ArrowNull");
			arrow_forward = "";
		} else {
			arrowStyle_forward = skin.GetStyle("Arrow");
			arrow_forward = ">";
		}
		if(GUI.Button(new Rect(Screen.width - Mathf.FloorToInt(buffer / 2f) - Mathf.FloorToInt(arrowWidth / 2f) - Mathf.FloorToInt(extraSpace / 4f),
		                 buffer + headerHeight + mealBuffer + Mathf.FloorToInt(slotRectWidth / 2) + Mathf.FloorToInt(mealBuffer / 2),
		                 arrowWidth, slotRectWidth + mealBuffer), arrow_forward, arrowStyle_forward)){
			Debug.Log("go forward");
			if(pageNum < Mathf.CeilToInt((float)database.meals.Count / 6f) - 1){
				pageNum++;
			}
		}

		//Draw START footer
		if(GUI.Button(new Rect(buffer + Mathf.FloorToInt(extraSpace / 2f) + (2 * slotRectWidth) + (2 * mealBuffer),
		                 buffer + headerHeight + (3 * mealBuffer) + (2 * slotRectWidth),
		                 slotRectWidth, footerHeight), "DONE", skin.GetStyle("Done"))){
			Application.LoadLevel(2);
		}
	}

}
