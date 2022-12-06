using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    public GameObject barrel;
    public SimpleShoot simpleShoot;
    public int damage = 20;
    public float impactForce = 20f;
    public OVRInput.Button shootButton;
    public OVRInput.Button reloadButton;

    private OVRGrabbable grabbable;


    public AudioSource audioSource;
    public AudioClip shootingSound;
    public AudioClip noAmmoAudioSound;
    public AudioClip reloadSound;
    // for ammo count
    public int ammoCount;
    public int maxAmmo = 10;
    // Start is called before the first frame update
    void Start()
    {
        ammoCount = maxAmmo;
        grabbable = GetComponent<OVRGrabbable>();
        barrel = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.isGrabbed)
        {
            if (OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController()))
            {
                if (ammoCount > 0)
                {
                    Shoot();
                    simpleShoot.StartShoot();
                    GetComponent<AudioSource>().Play();
                    audioSource.PlayOneShot(shootingSound, 80);
                    ammoCount -= 1;
                }
                else
                {
                    audioSource.PlayOneShot(noAmmoAudioSound, 80);

                }

            }
            if (OVRInput.GetDown(reloadButton, grabbable.grabbedBy.GetController()))
            {
                reload();

            }
            
        }

    }
    void reload()
    {
        ammoCount = maxAmmo;
        audioSource.PlayOneShot(reloadSound, 80);
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            EnemyAI target = hit.transform.GetComponent<EnemyAI>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
