using UnityEngine;
using VR = UnityEngine.VR;

public class UpdateEyeAnchors : MonoBehaviour
{
	public GameObject[] eyes = new GameObject[2];
	string[] eyeAnchorNames = { "LeftEyeAnchor", "RightEyeAnchor" };
	//GameObject yRotation;

	void Update()
	{
		for (int i = 0; i < 2; ++i)
		{
			// if the eye anchor is nolonger a child of us, don't use it
			if (eyes[i] != null && eyes[i].transform.parent != transform)
			{
				eyes[i] = null;
			}

			// if we don't have an eye anchor, try to find one or create one
			if (eyes[i] == null)
			{
				Transform t = transform.Find(eyeAnchorNames[i]);
				if (t)
					eyes[i] = t.gameObject;

				if (eyes[i] == null)
				{
					eyes[i] = new GameObject(eyeAnchorNames[i]);
					eyes[i].transform.parent = gameObject.transform;
				}
			}

			// update the eye transform
			eyes[i].transform.localPosition = VR.InputTracking.GetLocalPosition((VR.VRNode)i);
			eyes[i].transform.localRotation = VR.InputTracking.GetLocalRotation((VR.VRNode)i);
			print ("X: " +eyes[i].transform.eulerAngles.x + "  Y: " + eyes[i].transform.eulerAngles.y + "  Z: " + eyes[i].transform.eulerAngles.z);

			//yRotation = eyes[i].transform.eulerAngles.y;

		}
	}
}