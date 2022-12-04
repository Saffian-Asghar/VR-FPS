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

    private OVRGrabbable grabbable;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        audio = GetComponent<AudioSource>();
        barrel = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.isGrabbed && OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController()))
        {
            Shoot();
            //simpleShoot.StartShoot();
            audio.Play();
        }

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
