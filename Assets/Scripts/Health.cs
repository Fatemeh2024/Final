using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health;
    public RectTransform Healthbar;
    private float originalhealthbarsize;
   

    [Header("UI")]
    public TextMeshProUGUI healthText;


    private void Start()
    {
        originalhealthbarsize = Healthbar.sizeDelta.x;
    }

    public void Update()
    {
       // Healthbar.sizeDelta = new Vector2(originalhealthbarsize * health / 100f, Healthbar.sizeDelta.y);  
    }
    [PunRPC]
    public void TakeDamage(int _damage) {
        health -= _damage;

        Healthbar.sizeDelta = new Vector2(originalhealthbarsize * health / 100f, Healthbar.sizeDelta.y);

        healthText.text = health.ToString();

        if (health <= 0) {

             RoomManager.instance.RespawnPlayer();

                Destroy(gameObject);
          
            

        }
    }
}
