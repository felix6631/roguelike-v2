using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerHealth : EntityManager
{
    public Slider healthSlider;

    public AudioClip deathClip;
    public AudioClip hitClip;
    public AudioClip itemPickupClip;

    private AudioSource playerAudioplayer;

    private Player playerMovement;
    private weapon playerShooter;

    private void Awake()
    {
        playerAudioplayer = GetComponent<AudioSource>();

        playerMovement = GetComponent<Player>();
        playerShooter = GetComponent<weapon>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        healthSlider.gameObject.SetActive(true);
        healthSlider.maxValue = startingHealth;
        healthSlider.value = health;

        playerMovement.enabled = true;
        playerShooter.enabled = true;
    }

    [PunRPC]
    public override void RestoreHealth(int newHealth)
    {
        base.RestoreHealth(newHealth);
        healthSlider.value = health;
    }

    [PunRPC]
    public override void OnDamage(int damage, Vector2 hitPoint, Vector2 hitDirection)
    {
        if (!dead) playerAudioplayer.PlayOneShot(hitClip);
        base.OnDamage(damage, hitPoint, hitDirection);
        healthSlider.value = health;
    }

    public override void Die()
    {
        base.Die();

        healthSlider.gameObject.SetActive(false);
        playerAudioplayer.PlayOneShot(deathClip);
        

        playerMovement.enabled = false;
        playerShooter.enabled = false;

        Invoke("Respawn", 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!dead)
        {
            IItem item = other.GetComponent<IItem>();

            if(item != null)
            {
                if (PhotonNetwork.IsMasterClient) item.Use(gameObject);
                playerAudioplayer.PlayOneShot(itemPickupClip);
            }
        }
    }

    public void Respawn()
    {
        if(photonView.IsMine)
        {
            Vector2 randomSpawnPos = Random.insideUnitSphere * 5f;

            transform.position = randomSpawnPos;
        }

        gameObject.SetActive(false);
        gameObject.SetActive(true);
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
