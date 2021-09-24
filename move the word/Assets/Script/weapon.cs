using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/* Need 
 * 1. Player position
 * 2. Mouse position
 * 3. direction
 */

public class weapon : MonoBehaviourPun, IPunObservable
{
    public enum State
    {
        Ready,
        Empty,
        Reloading
    }
    public State state { get; private set; } //총 상태

    public GameObject bullet;
    

    float angle;
    Vector2 target, mouse;

    public float damage = 25;

    public float timeBetweenshots; //연사 속도
    public float reloadTime = 1.8f;
    public float barrel = 0.15f; //발사 반경
    private float lastFireTime;

    public int magCapacity = 25;
    public int ammoRemain = 100;
    public int magAmmo;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(ammoRemain);
            stream.SendNext(magAmmo);
        }
        else
        {
            ammoRemain = (int)stream.ReceiveNext();
            magAmmo = (int)stream.ReceiveNext();
            state = (State)stream.ReceiveNext();
        }
    }

    [PunRPC]
    public void Addammo(int ammo)
    {
        ammoRemain += ammo;
    }

    private void OnEnable()
    {
        magAmmo = magCapacity;
        state = State.Ready;
        lastFireTime = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        mouse = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - Player.playerY, mouse.x - Player.playerX) * Mathf.Rad2Deg;
        if (Player.side > 0)
        {
            if (mouse.x < Player.playerX)
                transform.localScale = new Vector3(0.1f, 0.1f, 0);
            else
                transform.localScale = new Vector3(0.1f, -0.1f, 0);
        }
        else
        {
            if (mouse.x < Player.playerX)
                transform.localScale = new Vector3(-0.1f, 0.1f, 0);
            else
                transform.localScale = new Vector3(-0.1f, -0.1f, 0);
        }

        transform.rotation = Quaternion.AngleAxis(angle-180, Vector3.forward);
        Vector2 diretion = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            bulletFire();
        }
    }

    private void bulletFire()
    {
        magAmmo--;
        if (magAmmo <= 0) state = State.Empty;
        PhotonNetwork.Instantiate("총알_0", new Vector3(bulletHoleX(),bulletHoleY(),transform.position.z), transform.rotation);
    }

    public bool Reload()
    {
        if (state == State.Reloading || ammoRemain <= 0 || magAmmo >= magCapacity) return false;
        StartCoroutine(ReloadRoutine());
        return true;
    }
    
    private IEnumerator ReloadRoutine()
    {
        state = State.Reloading;

        yield return new WaitForSeconds(reloadTime);

        int ammoToFill = magCapacity - magAmmo;
        if (ammoRemain < ammoToFill) ammoToFill = ammoRemain;

        magAmmo += ammoToFill;
        ammoRemain -= ammoToFill;

        state = State.Ready;
    }

    private float bulletHoleX()
    {
        return Mathf.Cos(angle*Mathf.Deg2Rad) * barrel + transform.position.x;
    }

    private float bulletHoleY()
    {
        return Mathf.Sin(angle * Mathf.Deg2Rad) * barrel + transform.position.y - Mathf.Sign(transform.rotation.z) * 0.3f;
    }

    
    
}
