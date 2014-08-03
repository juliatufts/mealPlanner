using UnityEngine;
using System.Collections;

public class UpLeftMovement : MonoBehaviour {

	public bool directionUp = true;
	public float movementAmount = 0.1f;
	public Vector3 startingPos;

	//All variables to calculate the elusive apple side length in world space
	AppleGenerator appleGenerator;
	public float appleLength;
	public float worldAppleLength;
	public Vector3 worldLength0;
	public Vector3 worldLength1;

	// Use this for initialization
	void Start () {
		appleGenerator = GameObject.FindWithTag("AppleGenerator").GetComponent<AppleGenerator>();
		appleLength =  appleGenerator.appleLength;
		Vector3 screenLength0 = new Vector3 (0f, 0f, Mathf.Abs(Camera.main.transform.position.z) + transform.position.z);
		Vector3 screenLength1 = new Vector3 (appleLength, 0f, Mathf.Abs(Camera.main.transform.position.z) + transform.position.z);
		worldLength0 = Camera.main.ScreenToWorldPoint(screenLength0);
		worldLength1 = Camera.main.ScreenToWorldPoint(screenLength1);
		worldAppleLength = Mathf.Abs(Mathf.Abs(worldLength1.x) - Mathf.Abs(worldLength0.x));

		startingPos = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = GetComponent<Transform>().position;
		if(directionUp){
			if(temp.y > (startingPos.y + worldAppleLength)){
				directionUp = false;
			} else {
				temp.y += movementAmount;
			}
		} else {
			if(temp.x < (startingPos.x - worldAppleLength)){
				temp.y = startingPos.y;
				temp.x = startingPos.x;
				directionUp = true;
			} else {
				temp.x -= movementAmount;
			}
		}
		GetComponent<Transform>().position = temp;
	}
}
