using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;


public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag == "p1ayer")
        {
            if (Player.Islocal)
                return;
        }
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-0.15f,0f,0));
        
    }
}
