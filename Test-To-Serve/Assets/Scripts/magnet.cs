using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class magnet : MonoBehaviour
{

    Rigidbody2D rb;
    GameObject Player;
    Vector2 playerDirection;
    float timeStamp;
    bool flyToPlayer;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        magnetActive();

        

    }

    private void magnetActive()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            if (flyToPlayer)
            {
                playerDirection = -(transform.position - Player.transform.position).normalized;
                rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * 10f * (Time.time / timeStamp);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.name.Equals("CoinMagnet"))
            {
                timeStamp = Time.time;
                Player = GameObject.Find("Player");
                flyToPlayer = true;
            }
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("CoinMagnet"))
        {
            timeStamp = Time.time;
            Player = GameObject.Find("Player");
            flyToPlayer = false;
        }
    }
}
