using UnityEngine;
using System.Collections;

public class GetWidth : MonoBehaviour {

	public float appleWidth;
	private float planeScale = 10.0f;
	
	void Start () {
		//Calculate the width of the apple based on screen size, camera position
		Vector3 v3 = new Vector3(planeScale * transform.localScale.x, planeScale * transform.localScale.y, transform.position.z);
		v3 = Camera.main.WorldToScreenPoint(v3);
		Vector3 v3Zero = Camera.main.WorldToScreenPoint(Vector3.zero);
		v3 = v3 - v3Zero;
		appleWidth = v3.x;
	}
}
