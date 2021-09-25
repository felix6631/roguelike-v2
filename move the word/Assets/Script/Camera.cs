using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;


public class Camera : MonoBehaviourPun
{

    public GameObject target; // 카메라가 따라갈 대상
    public float moveSpeed; // 카메라가 따라갈 속도
    private Vector3 targetPosition; // 대상의 현재 위치

    void UpdatePlayer()
    {
        target = GameManager.instance.playerInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayer();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // 대상이 있는지 체크
        if (target.gameObject != null)
        {
            if (photonView.IsMine)
            {
                Debug.Log(target.gameObject.transform.position);
                // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
                targetPosition.Set(target.gameObject.transform.position.x, target.gameObject.transform.position.y, this.transform.position.z);

                // vectorA -> B까지 T의 속도로 이동
                this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }
    }
}