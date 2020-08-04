using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessPowerUpScript : MonoBehaviour
{
    //El rigidbody del jugador
    private Rigidbody2D player;
    public int type;
    //Las botas que se activan al recoger el power up de doble salto
    private SpriteRenderer playerBootL;
    private SpriteRenderer playerBootR;

    public bool used = false;
    //animacion que sale cuando el jugador coge el power up
    private GameObject doublejumpAnim;
    //animacion que sale cuando el jugador coge el power up
    private GameObject shieldAnim;

    void Start()
    {
        player = GameObject.Find("Character").GetComponent<Rigidbody2D>();
        playerBootL = GameObject.Find("UltraBoots_L").GetComponent<SpriteRenderer>();
        playerBootR = GameObject.Find("UltraBoots_R").GetComponent<SpriteRenderer>();
        doublejumpAnim = player.transform.Find("explosion_doublejump").gameObject;
        shieldAnim = player.transform.Find("explosion_shield").gameObject;
    }

    //Con esta funcion activamos el power up en el personaje correspondiente y si este ya dispone de un power up desactivamos la caja sin dar nada al personaje
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Escudo
        if (type == 0)
        {
            if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !used && !player.GetComponent<PlayerScript>().powered)
            {
                used = true;
                shieldAnim.SetActive(true);
                //Destroy(gameObject, 0.38f);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<AudioSource>().Play();
                player.GetComponent<PlayerScript>().shielded = true;
            }
        }
        //Salto doble
        if (type == 1)
        {
            if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !used && !player.GetComponent<PlayerScript>().powered)
            {
                used = true;
                doublejumpAnim.SetActive(true);
                //Destroy(gameObject, 0.38f);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                player.GetComponent<PlayerScript>().doubleJump = true;
                player.GetComponent<PlayerScript>().remainingJumps = 3;
                playerBootL.enabled = true;
                playerBootR.enabled = true;
                GetComponent<AudioSource>().Play();
            }
        }
        
    }
}

