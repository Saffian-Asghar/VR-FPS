using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testShoot : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            simpleShoot.StartShoot();
            GetComponent<AudioSource>().Play();
        }
        
    }
}
