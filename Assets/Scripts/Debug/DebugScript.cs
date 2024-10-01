using UnityEngine;
using System.Collections;

public class DebugScript : MonoBehaviour
{
	void Start()
	{
		DontDestroyOnLoad(gameObject);
	}
	void OnGUI()
	{
		Rect rect = new Rect(90, 10, 200, 30);
		GUI.Label(rect, "   Sys : " + UnityEngine.N3DS.Debug.GetSystemFree() / 1000);

		rect.y += 40;
		GUI.Label(rect, "Device : " + UnityEngine.N3DS.Debug.GetDeviceFree() / 1000);

		rect.y += 40;
		GUI.Label(rect, "VRAM A : " + UnityEngine.N3DS.Debug.GetVRAMAFree() / 1000);

		rect.y += 40;
		GUI.Label(rect, "VRAM B : " + UnityEngine.N3DS.Debug.GetVRAMBFree() / 1000);


	}
}
