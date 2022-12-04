using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testShoot : MonoBehaviour
{
    public GameObject barrel;
    public SimpleShoot simpleShoot;
    public float damage = 20f;
    public float impactForce = 20f;
public AudioSource shootingSound;
    public AudioSource noAmmoAudioSound;
    public AudioSource reloadSound;
    // for ammo count
    public int ammoCount;
    public int maxAmmo = 10;
    // Start is called before the first frame update
    void Start()
    {
        shootingSound= GetComponent<AudioSource>();
        noAmmoAudioSound = GetComponent<AudioSource>();
        reloadSound= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("r"))
        {
reload();
        }
        if (Input.GetKeyDown("f"))
        {
            if (ammoCount > 0 )
            {
            Shoot();
            simpleShoot.StartShoot();
            GetComponent<AudioSource>().Play();
            shootingSound.Play();
            ammoCount-=1;
        }
        else 
        {
noAmmoAudioSound.Play();

        }
        }
    }

void reload()
{
ammoCount = maxAmmo;
reloadSound.play();
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
