using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    public float speed;
    public static float playerX, playerY, side;
    public static bool Islocal = true;
    //private int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(new Vector3(1, 1, -1));
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "bullet")
            this.hp -= 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            Islocal = false;
            return;
        }
        if (hp <= 0) return;
        float moveZ = Input.GetAxis("Vertical"); //조작 코드
        float moveX = Input.GetAxis("Horizontal");
        playerX = this.gameObject.transform.position.x;
        playerY = this.gameObject.transform.position.y;
        side = transform.localScale.x;
        if (0 != moveX)
        {
            this.transform.Translate(new Vector2(moveX, 0) * speed);
        }
        if (0 != moveZ)
        {
            this.transform.Translate(new Vector2(0, moveZ) * speed);
        }
        if (moveX > 0) transform.localScale = new Vector3(-1, 1, 1);
        else if (moveX < 0) transform.localScale = new Vector3(1, 1, 1);
    }
}
