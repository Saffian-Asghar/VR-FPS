using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testShoot : MonoBehaviour
{
    public GameObject barrel;
    public SimpleShoot simpleShoot;
    public float damage = 20f;
    public float impactForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Shoot();
            simpleShoot.StartShoot();
            GetComponent<AudioSource>().Play();
        }
        
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            itakedamage target = hit.transform.GetComponent<itakedamage>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
