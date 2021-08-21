using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject Bullet;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(new Vector3(1, 1, -1));
    }

    // Update is called once per frame
    void Update()
    {

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        if (0 != moveX)
        {
            transform.Translate(new Vector2(moveX, 0) * speed);
        }
        if (0 != moveZ)
        {
            transform.Translate(new Vector2(0, moveZ) * speed);
        }
        if (moveX > 0) transform.localScale = new Vector3(-1, 1, 1);
        else if (moveX < 0) transform.localScale = new Vector3(1, 1, 1);
        if (Input.GetMouseButton(0))
        {
            Instantiate(Bullet, new Vector2(0, 0), Quaternion.identity);
        }
    }
}
