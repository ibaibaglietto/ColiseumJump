using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    //El jugador
    public Rigidbody2D player;
    //El NPC lider
    public Rigidbody2D NPC1;
    //El otro NPC
    public Rigidbody2D NPC2;
    //El tipo de power up
    public int type;
    //animacion que sale cuando el jugador coge el power up
    public GameObject playerAnim;
    //animacion que sale cuando el NPC1 coge el power up
    public GameObject NPC1Anim;
    //animacion que sale cuando el NPC2 coge el power up
    public GameObject NPC2Anim;
    //Las botas que se activan al recoger el power up de doble salto
    public SpriteRenderer playerBootL;
    public SpriteRenderer playerBootR;
    public SpriteRenderer NPCBootL;
    public SpriteRenderer NPCBootR;
    public SpriteRenderer NPC2BootL;
    public SpriteRenderer NPC2BootR;

    public bool used = false;

    //Con esta funcion activamos el power up en el personaje correspondiente y si este ya dispone de un power up desactivamos la caja sin dar nada al personaje
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Escudo
        if (type == 0)
        {
            if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !used && !player.GetComponent<PlayerScript>().powered)
            {
                used = true;
                playerAnim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<AudioSource>().Play();
                player.GetComponent<PlayerScript>().shielded = true;
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 1, player.GetComponent<PlayerScript>().pos] = 1;
            }
            
            else if ((collision.attachedRigidbody == NPC1.GetComponent<Rigidbody2D>()) && NPC1.GetComponent<NPCScript>().ground && !NPC1.GetComponent<NPCScript>().jumping && !used && !NPC1.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC1Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC1.GetComponent<NPCScript>().shielded = 1;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC1.GetComponent<NPCScript>().numPlat - 1, NPC1.GetComponent<NPCScript>().pos] = 1;
            }
            else if ((collision.attachedRigidbody == NPC2.GetComponent<Rigidbody2D>()) && NPC2.GetComponent<NPCScript>().ground && !NPC2.GetComponent<NPCScript>().jumping && !used && !NPC2.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC2Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC2.GetComponent<NPCScript>().shielded = 1;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC2.GetComponent<NPCScript>().numPlat - 1, NPC2.GetComponent<NPCScript>().pos] = 1;
            }
            
        }
        //Salto doble
        if (type == 1)
        {
            if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !used && !player.GetComponent<PlayerScript>().powered)
            {
                used = true;
                playerAnim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                player.GetComponent<PlayerScript>().doubleJump = true;
                player.GetComponent<PlayerScript>().remainingJumps = 3;
                playerBootL.enabled = true;
                playerBootR.enabled = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 1, player.GetComponent<PlayerScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC1.GetComponent<Rigidbody2D>()) && NPC1.GetComponent<NPCScript>().ground && !NPC1.GetComponent<NPCScript>().jumping && !used && !NPC1.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC1Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC1.GetComponent<NPCScript>().doubleJump = 1;
                NPC1.GetComponent<NPCScript>().remainingJumps = 3;
                NPCBootL.enabled = true;
                NPCBootR.enabled = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC1.GetComponent<NPCScript>().numPlat - 1, NPC1.GetComponent<NPCScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC2.GetComponent<Rigidbody2D>()) && NPC2.GetComponent<NPCScript>().ground && !NPC2.GetComponent<NPCScript>().jumping && !used && !NPC2.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC2Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC2.GetComponent<NPCScript>().doubleJump = 1;
                NPC2.GetComponent<NPCScript>().remainingJumps = 3;
                NPC2BootL.enabled = true;
                NPC2BootR.enabled = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC2.GetComponent<NPCScript>().numPlat - 1, NPC2.GetComponent<NPCScript>().pos] = 1;
            }
        }
        //Trampa
        if (type == 2)
        {
            if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !used && !player.GetComponent<PlayerScript>().powered)
            {
                used = true;
                playerAnim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                player.GetComponent<PlayerScript>().canTrap = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 1, player.GetComponent<PlayerScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC1.GetComponent<Rigidbody2D>()) && NPC1.GetComponent<NPCScript>().ground && !NPC1.GetComponent<NPCScript>().jumping && !used && !NPC1.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC1Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC1.GetComponent<NPCScript>().canTrap = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC1.GetComponent<NPCScript>().numPlat - 1, NPC1.GetComponent<NPCScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC2.GetComponent<Rigidbody2D>()) && NPC2.GetComponent<NPCScript>().ground && !NPC2.GetComponent<NPCScript>().jumping && !used && !NPC2.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC2Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC2.GetComponent<NPCScript>().canTrap = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC2.GetComponent<NPCScript>().numPlat - 1, NPC2.GetComponent<NPCScript>().pos] = 1;
            }
        }
        //Bola de energia simple
        if (type == 3)
        {
            if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !used && !player.GetComponent<PlayerScript>().powered)
            {
                used = true;
                playerAnim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                player.GetComponent<PlayerScript>().energySimple = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 1, player.GetComponent<PlayerScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC1.GetComponent<Rigidbody2D>()) && NPC1.GetComponent<NPCScript>().ground && !NPC1.GetComponent<NPCScript>().jumping && !used && !NPC1.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC1Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC1.GetComponent<NPCScript>().energySimple = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC1.GetComponent<NPCScript>().numPlat - 1, NPC1.GetComponent<NPCScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC2.GetComponent<Rigidbody2D>()) && NPC2.GetComponent<NPCScript>().ground && !NPC2.GetComponent<NPCScript>().jumping && !used && !NPC2.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC2Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC2.GetComponent<NPCScript>().energySimple = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC2.GetComponent<NPCScript>().numPlat - 1, NPC2.GetComponent<NPCScript>().pos] = 1;
            }
        }
        //Bola de energia oscura
        if (type == 4)
        {
            if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !used && !player.GetComponent<PlayerScript>().powered)
            {
                used = true;
                playerAnim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                player.GetComponent<PlayerScript>().darkEnergy = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 1, player.GetComponent<PlayerScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC1.GetComponent<Rigidbody2D>()) && NPC1.GetComponent<NPCScript>().ground && !NPC1.GetComponent<NPCScript>().jumping && !used && !NPC1.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC1Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC1.GetComponent<NPCScript>().darkEnergy = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC1.GetComponent<NPCScript>().numPlat - 1, NPC1.GetComponent<NPCScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC2.GetComponent<Rigidbody2D>()) && NPC2.GetComponent<NPCScript>().ground && !NPC2.GetComponent<NPCScript>().jumping && !used && !NPC2.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC2Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC2.GetComponent<NPCScript>().darkEnergy = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC2.GetComponent<NPCScript>().numPlat - 1, NPC2.GetComponent<NPCScript>().pos] = 1;
            }
        }
        //Niebla
        if (type == 5)
        {
            if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground && !used && !player.GetComponent<PlayerScript>().powered)
            {
                used = true;
                playerAnim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                player.GetComponent<PlayerScript>().canFog = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 1, player.GetComponent<PlayerScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC1.GetComponent<Rigidbody2D>()) && NPC1.GetComponent<NPCScript>().ground && !NPC1.GetComponent<NPCScript>().jumping && !used && !NPC1.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC1Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC1.GetComponent<NPCScript>().canFog = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC1.GetComponent<NPCScript>().numPlat - 1, NPC1.GetComponent<NPCScript>().pos] = 1;
            }
            else if((collision.attachedRigidbody == NPC2.GetComponent<Rigidbody2D>()) && NPC2.GetComponent<NPCScript>().ground && !NPC2.GetComponent<NPCScript>().jumping && !used && !NPC2.GetComponent<NPCScript>().powered)
            {
                used = true;
                NPC2Anim.gameObject.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                NPC2.GetComponent<NPCScript>().canFog = true;
                GetComponent<AudioSource>().Play();
                NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC2.GetComponent<NPCScript>().numPlat - 1, NPC2.GetComponent<NPCScript>().pos] = 1;
            }
        }
    }
}
