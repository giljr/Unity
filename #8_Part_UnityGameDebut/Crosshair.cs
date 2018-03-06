using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //hide the mouse cursor
        Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        //make the mouse convas follows its position on screen 
        this.transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.gameObject.tag);
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    //Destroy(hit.transform.gameObject);
                    hit.transform.parent.GetComponent<Soldier>().Hit();
                }
            }
        }
    }
}
