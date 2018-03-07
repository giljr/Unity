using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {
    private GameObject mEnemy;

    float timeCounter;

    public float RightTime = 3.0f;
    public float ShootTime = 1.0f;
    public float LeftTime = 2.0f;

    //control if the soldir are active or not
    public bool mIsActive = false; //set in Activate 

    private Animator mAnimator = null;
    Vector3 mStartPos = Vector3.zero;

    // Use this for initialization
    //void Start() change for initialize enemies before Enemycontroller
    void Awake  ()
    {
        mEnemy = transform.GetChild(0).gameObject;

        mStartPos = mEnemy.transform.position;

        mAnimator = mEnemy.GetComponent<Animator>();
        //code transfered to Activate:
        //MoveRightwards();

        //Shooting logics

        //Invoke("MoveLeftwards", ShootTime);

   
    }

    public void Activate()
    {
        mIsActive = true;
        mEnemy.transform.position = mStartPos;
        MoveLeftwards();

        //Shooting logics
        mAnimator.SetBool("shoot", true);

        //TODO: Call this via event of shoot animation
        //ShootEvent();

        Invoke("MoveRightwards", ShootTime);
    }

    // transfer it to ShootHandler() 
    //public void ShootEvent()
    //{
    //    GameController.Instance.SetDamage(10);
    //}

    internal void Hit()
    {
        mAnimator.SetTrigger("fall");

        Invoke("MoveRightwards", 1.5f);
    }

    private void MoveLeftwards()
    {

        //Shooting logics
        mAnimator.SetBool("shoot", false);

        //Move upwards
        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.z += Mathf.Cos(0.1f);

        iTween.MoveTo(mEnemy, enemyPos, LeftTime);
    }
    private void MoveRightwards()
    {
        //stop Shootting at us method goes here!
        mAnimator.SetBool("shoot", false);

        //Move upwards
        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.z -= Mathf.Cos(-0.1f);


        iTween.MoveTo(mEnemy, enemyPos, LeftTime);

        //mIsActive = false;

        iTween.MoveTo(mEnemy, iTween.Hash("z", enemyPos.z, "time", LeftTime, "onComplete", "onLeftComplete", "onCompleteTarget", gameObject));
    }

    void onLeftComplete()
    {
        mIsActive = false;
    }

    public bool IsActive
    {
        get { return mIsActive; }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
