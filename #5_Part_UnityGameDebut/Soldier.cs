using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {
    private GameObject mEnemy;

    // Use this for initialization
    void Start () {
        //Move to the left
        mEnemy = transform.GetChild(0).gameObject;

        //Get enemy position and use trig function to move it
        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.z += Mathf.Cos(0.1f);

        iTween.MoveTo(mEnemy, enemyPos, 2.0f);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
