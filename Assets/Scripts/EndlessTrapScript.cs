using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTrapScript : MonoBehaviour
{
    //El rigidbody del jugador
    private Rigidbody2D player;
    //La camara del nivel
    private GameObject cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Character").GetComponent<Rigidbody2D>();
    }

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
                cam.GetComponent<CameraController>().TriggerShake(1.0f);
                player.GetComponent<PlayerScript>().trappedTime = Time.fixedTime - 1.0f;
            }
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            //Se desactiva la trampa activada
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
