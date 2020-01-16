using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5;
    public int damage = 1;
    Rigidbody2D rb;
    
    void Awake(){//This needs to happen in awake because Start happens AFTER OnEnable, and we need the rb in OnEnable.

        rb = GetComponent<Rigidbody2D>();//This start function will only happen once, even with pooling. 
        //Thats sort of the whole point? Getting references and doing various expensive calculations can happen here.
    }
    void OnEnable()//OnEnable is replacing our start function, because of pooling.
    {
        rb.velocity = transform.up*bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision){//EASY MISTAKE ALERT: note the "2d" in this function. It's different then OnCollisionEnter.
        if(!collision.gameObject.CompareTag("Player")){//We would want to use layers to handle this collision what-with-what stuff in a larger project.
            if(collision.gameObject.GetComponent<Enemy>() != null){//Does the thing we hit have an "enemy" component?
                collision.gameObject.GetComponent<Enemy>().OnHit(damage);//Tell that thing that we hit it. Let it sort itself out.
            }
            //
            gameObject.SetActive(false);
        }//end if not player
    }//end onCollisionEnter
}
