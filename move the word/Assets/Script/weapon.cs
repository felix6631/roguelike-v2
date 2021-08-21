using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform sPoint;//마우스 포인터
    public float timeBetweenshots;//연사 속도

    private float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 diretion = Camera.main.ScreenToWorldPoint(Input.mousePosition)
        if(Input.GetMouseButton(0))
        {

        }
    }
}
