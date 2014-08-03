using UnityEngine;
using System.Collections;

public class StartGUI : MonoBehaviour {
	public GUISkin skin;

	void OnGUI () {
		GUI.skin = skin;

		//Calculate dimension of text
		int titleWidth = Mathf.FloorToInt((float)(Screen.width) / 1.22f);
		int titleHeight = Mathf.FloorToInt((float)(Screen.height) / 1.22f);
		int startWidth = Mathf.FloorToInt((float)(titleWidth) / 1.22f);
		int startHeight = Mathf.FloorToInt(((float)Screen.height - (float)titleHeight) / 1.22f);
		int extraSpace_h = Screen.width - titleWidth;
		int extraSpace_v = Screen.height - titleHeight - startHeight;

		//Title and start
		GUI.Box(new Rect(Mathf.FloorToInt((float)extraSpace_h / 2f), Mathf.FloorToInt((float)extraSpace_v / 3f),
		                 titleWidth, titleHeight), "MEAL PLANNER", skin.GetStyle("MenuTitle"));

		if(GUI.Button(new Rect(Mathf.FloorToInt((float)(Screen.width - startWidth) / 2f), 
		                       titleHeight, startWidth, startHeight), "START", skin.GetStyle("MenuStart"))) {
			Application.LoadLevel(1);
		}
	}
}
