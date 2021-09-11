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
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 160, Vector3.forward);
        Vector2 diretion = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }
}
