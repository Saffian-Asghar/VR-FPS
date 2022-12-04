using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    public GameObject barrel;
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
        }
    }
}
