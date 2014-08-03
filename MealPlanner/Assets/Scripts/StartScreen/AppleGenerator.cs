using UnityEngine;
using System.Collections;

public class AppleGenerator : MonoBehaviour {

	public GameObject testApple;
	public GameObject apple;
	GetWidth getWidth;
	public float appleLength;
	public float space = 0.2f;
	public float extraYSpace = 2.0f;
	public float planeScale = 10.0f;
	
	void Start () {
		getWidth = testApple.GetComponent<GetWidth>();
		appleLength =  getWidth.appleWidth;

		for(int y = -Mathf.CeilToInt(appleLength + space); y < Screen.height; y += Mathf.CeilToInt(appleLength + space)){
			for(int x = 0; x < Screen.width + Mathf.CeilToInt(appleLength + space); x += Mathf.CeilToInt(appleLength + space)){
				Vector3 pos = new Vector3 (x + (Mathf.CeilToInt(appleLength/2f) + space), 
				                           y + (Mathf.CeilToInt(appleLength/2f) + space + extraYSpace),
				                           apple.transform.position.z);
				pos.z = Mathf.Abs(Camera.main.transform.position.z) + apple.transform.position.z;
				var newApple = GameObject.Instantiate(apple, Camera.main.ScreenToWorldPoint(pos), apple.transform.rotation) as GameObject;
				newApple.transform.parent = transform;
			}
		}
	}
}
