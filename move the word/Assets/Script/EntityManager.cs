using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EntityManager : MonoBehaviourPun, Idamagable
{
    public int startingHealth = 10;
    public int health { get; protected set; }
    public bool dead { get; protected set; }
    public event Action onDeath;

    protected virtual void OnEnable()
    {
        dead = false;
        health = startingHealth;
    }

    public virtual void OnDamage(int damage)
    {
        startingHealth -= damage;
        if (startingHealth <= 0 && !dead) Die();
    }

    public virtual void RestoreHealth(int newHealth)
    {
        if (dead) return;
        health += newHealth;
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
