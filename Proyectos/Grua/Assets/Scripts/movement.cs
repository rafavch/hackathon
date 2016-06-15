using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	GameObject camara;
	float yRotate;
	//float speed = 3;

	void Start () {
		
		//UnityEngine.GameObject.Find("yRotation");
		camara = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
		print ("X: " + camara.transform.eulerAngles.x + "  Y: " + camara.transform.eulerAngles.y + "  Z: " + camara.transform.eulerAngles.z);

		if (yRotate != camara.transform.eulerAngles.y) {
			yRotate = camara.transform.eulerAngles.y;
			//transform.Rotate (new Vector3 (0, yRotate - 90, 0) * speed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, camara.transform.eulerAngles.y - 90, 0); 
		}

		//transform.Translate(Vector3.right * Time.deltaTime, Camera.main.transform);
		//transform.Translate(0, 0, 0);
		//transform.Translate(0, 0, 0, Space.World);
		//angles = InputTracking.GetLocalRotation (VRNode.CenterEye);

	}
}
