/* Need 
 * 1. Player position
 * 2. Mouse position
 * 3. direction
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponClass : MonoBehaviour
{
    public GameObject player;
    public Transform Aim;
    public Sprite sprite;
    private float angle;

    void Start()
    {
        
    }

    void Update()
    {
        this.gameObject.transform.position = player.gameObject.transform.position;
    }
}
