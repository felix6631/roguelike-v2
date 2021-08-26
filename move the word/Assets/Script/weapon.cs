using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform sPoint;//마우스 포인터
    public float timeBetweenshots;//연사 속도
    float angle;
    Vector2 target, mouse;

    private float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        //Vector2 diretion = Camera.main.ScreenToWorldPoint(Input.mousePosition)
        if (Input.GetMouseButton(0))
        {

        }
    }
}
