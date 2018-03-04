using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Rotator : MonoBehaviour {

	public void CameraRotatePi()
    {
        Camera.main.transform.Rotate(new Vector3(0, 0, 180));
    }
}
