using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {
    private GameObject mEnemy;


    public float RightTime = 1.0f;
    public float ShootTime = 1.0f;
    public float LeftTime = 1.0f;

    // Use this for initialization
    void Start ()
    {
        //Get the enemy actual gameObject
        mEnemy = transform.GetChild(0).gameObject;
        Activate();
       
    }

    public void Activate()
    {
        MoveLeftwards();
        //return to the right position and stayd there
        Invoke("MoveRightwards", RightTime);

    }

    private void MoveLeftwards()
    {
       //Get enemy position and use trig function to move it
        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.z += Mathf.Cos(0.1f);

        iTween.MoveTo(mEnemy, enemyPos, LeftTime);
    }

    private void MoveRightwards()
    {
       //Get enemy position and use trig function to move it
        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.z -= Mathf.Cos(-0.1f);

        iTween.MoveTo(mEnemy, enemyPos, ShootTime);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
