using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 1. player pos
 * 2. mouse pos
 * 3. if click, move straight to cursor
 *  -1. copy bullet
 *  -2. get angle and whatever
 *  -3. add velocity to gameobject
 * 4. until it break into something
 * 5. if collider crashes, destroy and discound it's health
 */

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
        transform.Translate(new Vector3(-0.15f,0f,0f));
        if( Time.deltaTime >= 0.1)
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
