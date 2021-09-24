using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/* Need 
 * 1. Player position
 * 2. Mouse position
 * 3. direction
 */

public class weapon : MonoBehaviourPun
{
    public GameObject bullet;
    public float timeBetweenshots; //연사 속도
    float angle;
    Vector2 target, mouse;
    public float barrel = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        mouse = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - Player.playerY, mouse.x - Player.playerX) * Mathf.Rad2Deg;
        if (Player.side > 0)
        {
            if (mouse.x < Player.playerX)
                transform.localScale = new Vector3(0.1f, 0.1f, 0);
            else
                transform.localScale = new Vector3(0.1f, -0.1f, 0);
        }
        else
        {
            if (mouse.x < Player.playerX)
                transform.localScale = new Vector3(-0.1f, 0.1f, 0);
            else
                transform.localScale = new Vector3(-0.1f, -0.1f, 0);
        }

        transform.rotation = Quaternion.AngleAxis(angle-180, Vector3.forward);
        Vector2 diretion = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            bulletFire();
        }
    }

    private void bulletFire()
    {
        Instantiate(bullet, new Vector3(bulletHoleX(),bulletHoleY(),transform.position.z), transform.rotation);
    }

    private float bulletHoleX()
    {
        return Mathf.Cos(angle*Mathf.Deg2Rad) * barrel + transform.position.x;
    }

    private float bulletHoleY()
    {
        return Mathf.Sin(angle * Mathf.Deg2Rad) * barrel + transform.position.y - Mathf.Sign(transform.rotation.z) * 0.3f;
    }

    
    
}
