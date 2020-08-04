using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    //El rigidbody del jugador
    public Rigidbody2D player;
    //La camara del nivel
    public GameObject cam;
    //El NPC lider
    public Rigidbody2D NPC1;
    //El segundo NPC
    public Rigidbody2D NPC2;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Si el que choca contra la trampa es el jugador
        if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && player.GetComponent<PlayerScript>().ground)
        {
            //Si este tiene escudo se desactiva el escudo
            if (player.GetComponent<PlayerScript>().shielded)
            {
                player.GetComponent<PlayerScript>().shielded = false;
                player.GetComponent<PlayerScript>().powered = false;
            }
            //Si no dispone de escudo se queda atrapado y la camara tiembla
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                player.GetComponent<PlayerScript>().trapped = true;
                cam.GetComponent<CameraController>().TriggerShake(2.0f);
                player.GetComponent<PlayerScript>().trappedTime = Time.fixedTime;
            }
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            //Se desactiva la trampa activada
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            //Se cambia la disposicion del nivel, eliminando la trampa
            NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 1, player.GetComponent<PlayerScript>().pos] = 1;
        }
        //Cuando el que choca es un NPC
        if ((collision.attachedRigidbody == NPC1.GetComponent<Rigidbody2D>()) && NPC1.GetComponent<NPCScript>().ground && !NPC1.GetComponent<NPCScript>().jumping)
        {
            //Si este tiene escudo se desactiva el escudo
            if (NPC1.GetComponent<NPCScript>().shielded == 1)
            {
                NPC1.GetComponent<NPCScript>().shielded = 0;
                NPC1.GetComponent<NPCScript>().powered = false;
            }
            //Si no dispone de escudo se queda atrapado
            else
            {                
                NPC1.GetComponent<NPCScript>().trapped = true;
                NPC1.GetComponent<NPCScript>().trappedTime = Time.fixedTime;
            }
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            //Se desactiva la trampa activada
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            //Se cambia la disposicion del nivel, eliminando la trampa
            NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC1.GetComponent<NPCScript>().numPlat - 1, NPC1.GetComponent<NPCScript>().pos] = 1;
        }
        if ((collision.attachedRigidbody == NPC2.GetComponent<Rigidbody2D>()) && NPC2.GetComponent<NPCScript>().ground && !NPC2.GetComponent<NPCScript>().jumping)
        {
            //Si este tiene escudo se desactiva el escudo
            if (NPC2.GetComponent<NPCScript>().shielded == 1)
            {
                NPC2.GetComponent<NPCScript>().shielded = 0;
                NPC2.GetComponent<NPCScript>().powered = false;
            }
            //Si no dispone de escudo se queda atrapado
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                NPC2.GetComponent<NPCScript>().trapped = true;
                NPC2.GetComponent<NPCScript>().trappedTime = Time.fixedTime;
            }
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            //Se desactiva la trampa activada
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            //Se cambia la disposicion del nivel, eliminando la trampa
            NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, NPC2.GetComponent<NPCScript>().numPlat - 1, NPC2.GetComponent<NPCScript>().pos] = 1;
        }
    }
}
