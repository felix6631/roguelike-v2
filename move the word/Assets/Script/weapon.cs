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
        int sum=0;
        mouse = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition); //화면상 마우스 커서 위치 땡겨오기
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg; //Atan2(y,x); return y/x * 180/PI_math
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-0.1f, 0.1f);
            sum = 160;
            //X값 스케일을 -1로 주어 좌우반전
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector2(+0.1f, 0.1f);
            sum = -160;
            //X값 스케일을 1로 주어 다시 원위치 
        }
        this.transform.rotation = Quaternion.AngleAxis(angle + sum, Vector3.forward);

        mouse = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 위치 구하는 코드
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-0.1f, 0.1f);
            sum = 160;
            //X값 스케일을 -1로 주어 좌우반전
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector2(+0.1f, 0.1f);
            sum = -160;
            //X값 스케일을 1로 주어 다시 원위치 
        }
        this.transform.rotation = Quaternion.AngleAxis(angle + sum, Vector3.forward);
        


        Vector2 diretion = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            Instantiate(bullet);
            bullet.transform.position = 
        }
        
    }
}
