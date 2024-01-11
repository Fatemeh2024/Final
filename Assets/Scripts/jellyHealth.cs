using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class jellyHealth : MonoBehaviour
{
    public int health;



    [PunRPC]
    public void TakeDamage(int _damage)
    {
        health -= _damage;

       

        if (health <= 0)
        {

            gameObject.GetComponent<Animation>().enabled = false;
            gameObject.AddComponent<Rigidbody>();


            StartCoroutine(Test());


        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(5f);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
