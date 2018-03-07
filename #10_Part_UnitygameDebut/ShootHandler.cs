using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour {

    private AudioSource mAudioSrc;

    public void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
    }


    public void ShootEvent()
    {

        int doShoot = Random.Range(0, 2);

        if (doShoot > 0)
        {
            mAudioSrc.Play();
            //int damage = Random.Range(0, 6);
            //increase the damage value so that the health value
            //of the player will come down to zero faster
            int damage = Random.Range(0, 30);
            //we must add a random logic to set damage
            //GameController.Instance.SetDamage(10);
            GameController.Instance.SetDamage(damage);
        }
    }

}
