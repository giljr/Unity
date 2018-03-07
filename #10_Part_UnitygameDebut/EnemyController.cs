using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Soldier[] Enemies;

    // Use this for initialization
    void Start()
    {
        //foreach (Soldier enemy in Enemies)
        //{
        //    enemy.Activate();
        //}//change this to Update()
    }

        // Update is called once per frame
        void Update () {

        if (GameController.Instance.IsGameOver)
            return;

        //Check if a soldier is currentely active
        foreach (Soldier enemy in Enemies)
        {
            if (enemy.IsActive)
            {
                return;
            }
        }

        //But I wanted the soldier appered randomly
        // get index of each soldier in the list
        //TODO: checked if it active first
        int idxSoldier = Random.Range(0, Enemies.Length);
        Enemies[idxSoldier].Activate();
		
	}
}
