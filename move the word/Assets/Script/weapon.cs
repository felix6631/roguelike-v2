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
        mouse = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition); //화면상 마우스 커서 위치 땡겨오기
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg; //Atan2(y,x); return y/x * 180/PI_math
        this.transform.rotation = Quaternion.AngleAxis(angle - 160, Vector3.forward);

        mouse = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 위치 구하는 코드
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 160, Vector3.forward);
        
        Vector2 diretion = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

