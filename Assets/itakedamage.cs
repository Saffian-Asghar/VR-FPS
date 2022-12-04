using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itakedamage : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {

            Die();
        }
    }
    void Die()
    {
        Destroy(this.gameObject);
    }


    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "bullet" && this.gameObject.tag == "Player")
        {
            health = health - 20;
            if (health <= 0)
            {
                //Destroy(this.gameObject);
                Debug.Log(this.gameObject.tag + "Dead");

            }

            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Hit");
        }
    }
}
