using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class EntityManager : MonoBehaviourPun, IDamageable
{
    public int startingHealth = 10;
    public int health { get; protected set; }
    public bool dead { get; protected set; }
    public event Action onDeath;

    [PunRPC]
    public void ApplyUpdatedHealth(int newHealth, bool newDead)
    {
        health = newHealth;
        dead = newDead;
    }
    
    protected virtual void OnEnable()
    {
        dead = false;
        health = startingHealth;
    }

    
    [PunRPC]
    public virtual void OnDamage(int damage, Vector2 hitPoint, Vector2 hitNormal)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            health -= damage;
            photonView.RPC("ApplyUpdatedHealth", RpcTarget.Others, health, dead);
            photonView.RPC("OnDamage", RpcTarget.Others, damage, hitPoint, hitNormal);
        }

        if (health <= 0 && !dead) Die();
    }

    public virtual void RestoreHealth(int newHealth)
    {
        if (dead) return;
        health += newHealth;

        if(PhotonNetwork.IsMasterClient)
        {
            health += newHealth;
            photonView.RPC("ApplyUpdatedHealth", RpcTarget.Others, health, dead);
            photonView.RPC("RestoreHealth", RpcTarget.Others, newHealth);
        }
    }
    
    public virtual void Die()
    {
        this?.onDeath(); //== if (onDeath != null) onDeath();
        dead = true;
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
