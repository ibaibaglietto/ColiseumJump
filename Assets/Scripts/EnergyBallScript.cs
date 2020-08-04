using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBallScript : MonoBehaviour
{
    //El jugador
    public Rigidbody2D player;
    //El NPC lider
    public Rigidbody2D NPC1;
    //El otro NPC
    public Rigidbody2D NPC2;
    //La camara
    public GameObject cam;
    //El usuario de la bola
    public int user;
    //Sonido de explosion
    public AudioClip explode;

    //Funcion que hace que la bola se mueva hacia arriba sin parar
    public void MoveEnergySimple()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 450.0f));
        
    }
    //Funcion para controlar el choque de la bola
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si la bola choca contra el jugador y la ha lanzado un NPC
        if ((collision.attachedRigidbody == player.GetComponent<Rigidbody2D>()) && (user == 1 || user == 2))
        {
            //Si no dispone del escudo se quedara atrapado mientras la camara tiembla
            if (!player.GetComponent<PlayerScript>().shielded)
            {
                player.GetComponent<PlayerScript>().trapped = true;
                cam.GetComponent<CameraController>().TriggerShake(2.0f);
                player.GetComponent<PlayerScript>().trappedTime = Time.fixedTime;
            }
            //Si dispone de escudo este se desactivara
            else  player.GetComponent<PlayerScript>().shielded = false;
            //Desactivamos el box collider, hacemos que la bola deje de moverse y activamos la animacion de explotar
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            GetComponent<Animator>().SetTrigger("Explode");
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = explode;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();
        }
        //Si la bola choca contra el NPC1 y la ha lanzado el jugador o el NPC2
        else if ((collision.attachedRigidbody == NPC1.GetComponent<Rigidbody2D>()) && (user == 0 || user == 2))
        {
            //Si no dispone del escudo se quedara atrapado
            if (NPC1.GetComponent<NPCScript>().shielded == 0)
            {
                NPC1.GetComponent<NPCScript>().trapped = true;
                NPC1.GetComponent<NPCScript>().trappedTime = Time.fixedTime;
            }
            //Si dispone de escudo este se desactivara
            else NPC1.GetComponent<NPCScript>().shielded = 0;
            //Desactivamos el box collider, hacemos que la bola deje de moverse y activamos la animacion de explotar
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            GetComponent<Animator>().SetTrigger("Explode");
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = explode;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();
        }
        //Si la bola choca contra el NPC2 y la ha lanzado el jugador o el NPC1
        else if ((collision.attachedRigidbody == NPC2.GetComponent<Rigidbody2D>()) && (user == 0 || user == 1))
        {
            //Si no dispone del escudo se quedara atrapado
            if (NPC2.GetComponent<NPCScript>().shielded == 0)
            {
                NPC2.GetComponent<NPCScript>().trapped = true;
                NPC2.GetComponent<NPCScript>().trappedTime = Time.fixedTime;
            }
            //Si dispone de escudo este se desactivara
            else NPC2.GetComponent<NPCScript>().shielded = 0;
            //Desactivamos el box collider, hacemos que la bola deje de moverse y activamos la animacion de explotar
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            GetComponent<Animator>().SetTrigger("Explode");
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = explode;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();
        }
    }
    //Funcion para hacer desaparecer la bola, que se activara al terminar la animacion de explotar
    public void dissapear()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<AudioSource>().Stop();
    }
}
