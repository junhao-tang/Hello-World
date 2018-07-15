using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Camera cam;

    private float maxWidth;

	// Use this for initialization
	void Start () {
        if (cam == null) {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - hatWidth;
	}
	
	// Update is called once per physic frame
	void FixedUpdate () {
        Vector3 cursorLoc = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(cursorLoc.x, 0, 0);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidth, 0, 0);
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);
	}
}
