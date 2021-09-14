using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 bulletMasterPos;
    int acceleration = 1;
    // Start is called before the first frame update
    void Start()
    {
        bulletMasterPos = weapon.weaponPos;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(this.gameObject);
        transform.position = bulletMasterPos;
        if(Input.GetMouseButtonDown(0))
        {
            
            bulletMasterPos.x += acceleration * Time.deltaTime;
            bulletMasterPos.y += acceleration * Time.deltaTime;
        }
    }
}
