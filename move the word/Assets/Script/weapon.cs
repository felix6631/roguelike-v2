using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Need 
 * 1. Player position
 * 2. Mouse position
 * 3. direction
 */

public class weapon : MonoBehaviour
{
    public GameObject bullet;
    public float timeBetweenshots; //연사 속도
    float angle;
    Vector2 target, mouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - Player.playerY, mouse.x - Player.playerX) * Mathf.Rad2Deg;
        if (Player.side > 0)
        {
            if (mouse.x < Player.playerX)
                this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            else
                this.transform.localScale = new Vector3(0.1f, -0.1f, 0.1f);
        }
        else
        {
            if (mouse.x < Player.playerX)
                this.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
            else
                this.transform.localScale = new Vector3(-0.1f, -0.1f, 0.1f);
        }

        this.transform.rotation = Quaternion.AngleAxis(angle-180, Vector3.forward);
        Vector2 diretion = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }
}
