using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    private AudioSource mAudioSrc;

	// Use this for initialization
	void Start () {
        //hide the mouse cursor
        Cursor.visible = false;

        GameController.Instance.GameOverEvent += OnGameOverEvent;

        mAudioSrc = GetComponent<AudioSource>();
		
	}
	

    private void OnGameOverEvent(object sender, System.EventArgs e)
    {

    }
    // Update is called once per frame
    void Update () {
        //make crosshair follows the cursos path
        this.transform.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            mAudioSrc.Play();
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
