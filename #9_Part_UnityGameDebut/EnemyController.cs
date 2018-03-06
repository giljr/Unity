using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public Soldier[] Enemies;   

    // Use this for initialization
    void Start () {

       /* transfered to the Update()
        * foreach (Soldier Enemy in Enemies)
        {
            Enemy.Activate();
        }*/

    }
	
	// Update is called once per frame
	void Update () {

        foreach (Soldier enemy in Enemies)
        {
            //Enemy.Activate();
            //If not active, return, so I do not activate another one
            if(enemy.IsActive)
            {
                return;
            }
                
        }

        //TODO: Check if the soldier are active
        int idxSoldier = Random.Range(0, Enemies.Length);
        Enemies[idxSoldier].Activate();
    }
}
