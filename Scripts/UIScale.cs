using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScale : MonoBehaviour {
    //Canvas HUD;

	// Use this for initialization
	void Start () {
        //Debug.Log("0" + ": " + Camera.main.pixelRect.width + ", " + Camera.main.pixelRect.height);
        //Camera.current.pixelRect.width
        if (Camera.main.pixelRect.height > Camera.main.pixelRect.width)
        {
            GetComponent<CanvasScaler>().matchWidthOrHeight = 0f;
            Debug.Log("0" + ": " + Camera.main.pixelRect.width + ", " + Camera.main.pixelRect.height);
        }
        else
        {
            GetComponent<CanvasScaler>().matchWidthOrHeight = 1f;
            Debug.Log("1" + ": " + Camera.main.pixelRect.width + ", " + Camera.main.pixelRect.height);
        }
        
        //HUD = GetComponent<CanvasScaler>().;
        //HUD.matchWidthOrHeight = 1f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
