using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        
        Debug.Log("foo");
       
        //충돌시 데미지 깎이는거 입력
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-0.15f,0f,0));
        if( Time.deltaTime >= 0.02)
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
