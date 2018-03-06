using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Soldier : MonoBehaviour {
    private GameObject mEnemy;


    public float RightTime = 3.0f;
    public float ShootTime = 1.0f;
    public float LeftTime = 2.0f;
    private Animator mAnimator = null;

    //control if the soldier are active or not
    public bool mIsActive = false;

    // Use this for initialization
    //void Start ()
   void Awake()
    {
        //Get the enemy actual gameObject
        mEnemy = transform.GetChild(0).gameObject;

        mAnimator = mEnemy.GetComponent<Animator>();
        //Activate it once
        //TODO: Transfer thismethod to Update() below 
        //Activate();


    }

    public void Activate()
    {
        mAnimator.SetBool("shoot", true);
        mIsActive = true;
        MoveLeftwards();
        
        //TODO: Shooting logic

        //return to the right position after shooting and stayed there
        Invoke("MoveRightwards", ShootTime);

    }

    internal void Hit()
    {
        mAnimator.SetTrigger("fall");

        Invoke("MoveRightwards", 1.5f);
    }


    public bool IsActive
    {
        get { return mIsActive; }
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
        mAnimator.SetBool("shoot", false);
        //Move to the left
        mEnemy = transform.GetChild(0).gameObject;

        //Get enemy position and use trig function to move it
        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.z -= Mathf.Cos(-0.1f);

        iTween.MoveTo(mEnemy, enemyPos, RightTime);
        //mIsActive = false;

        iTween.MoveTo(mEnemy, iTween.Hash("z", enemyPos.z, "time", LeftTime, "onComplete", "OnLeftComplete", "onCompleteTarget", gameObject));

        //the enemies are not shooting
        //mIsActive = false;
    }

    void OnLeftComplete()
    {
        mIsActive = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
