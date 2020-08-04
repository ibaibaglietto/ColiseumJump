using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllerScript : MonoBehaviour
{
    //El jugador
    public Rigidbody2D player;
    //El NPC lider
    public Rigidbody2D NPC1;
    //El otro NPC
    public Rigidbody2D NPC2;
    //El array de trampas colocables
    public GameObject[] traps;
    //El array de bolas de energia simples
    public GameObject[] energySimples;
    //El array de bolas de energia oscura
    public GameObject[] darkEnergies;
    //Sonido de la bola de energia simple
    public AudioClip energySimpleSound;
    //Sonido de la bola de energia oscura
    public AudioClip darkEnergySound;
    //Funcion para hacer que el jugador se mueva por el control tactil
    public void Move(int i)
    {
        if (i == 0 && player.GetComponent<PlayerScript>().ground && !player.GetComponent<PlayerScript>().trapped) player.GetComponent<PlayerScript>().btnl = true;
        else if (i == 1 && player.GetComponent<PlayerScript>().ground && !player.GetComponent<PlayerScript>().trapped) player.GetComponent<PlayerScript>().btnc = true;
        else if (i == 2 && player.GetComponent<PlayerScript>().ground && !player.GetComponent<PlayerScript>().trapped) player.GetComponent<PlayerScript>().btnr = true;
    }
    //Funcion para colocar trampas. Se colocara la trampa en la fila de abajo de la columna especificada en i. Ademas se cambiara la disposicion del nivel en el NPC lider.
    public void Trap(int i)
    {
        if(i == 0)
        {
            traps[NPC1.GetComponent<NPCScript>().numTrap].transform.position = new Vector2(-1.85f, player.GetComponent<PlayerScript>().transform.position.y-3.75f);
            NPC1.GetComponent<NPCScript>().numTrap += 1;
            player.GetComponent<PlayerScript>().canTrap = false;
            NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 2, i] = 2;
        }
        else if (i == 1)
        {
            traps[NPC1.GetComponent<NPCScript>().numTrap].transform.position = new Vector2(0.0f, player.GetComponent<PlayerScript>().transform.position.y - 3.75f);
            NPC1.GetComponent<NPCScript>().numTrap += 1;
            player.GetComponent<PlayerScript>().canTrap = false;
            NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 2, i] = 2;
        }
        else
        {
            traps[NPC1.GetComponent<NPCScript>().numTrap].transform.position = new Vector2(1.85f, player.GetComponent<PlayerScript>().transform.position.y - 3.75f);
            NPC1.GetComponent<NPCScript>().numTrap += 1;
            player.GetComponent<PlayerScript>().canTrap = false;
            NPC1.GetComponent<NPCScript>().plat[NPC1.GetComponent<NPCScript>().playingLevel, player.GetComponent<PlayerScript>().numPlat - 2, i] = 2;
        }
        
    }
    //Funcion para generar la bola de energia simple. Se activa la bola y se genera justo encima del jugador. Ademas se activa la animacion create de la bola y se le quita el power up al jugador.
    public void CreateEnergySimple()
    {        
        energySimples[0].GetComponent<SpriteRenderer>().enabled = true;
        energySimples[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        energySimples[0].transform.position = new Vector2(player.GetComponent<PlayerScript>().transform.position.x, player.GetComponent<PlayerScript>().transform.position.y + 1.7f);
        energySimples[0].GetComponent<Animator>().SetTrigger("Create");
        energySimples[0].GetComponent<AudioSource>().loop = true;
        energySimples[0].GetComponent<AudioSource>().clip = energySimpleSound;
        energySimples[0].GetComponent<AudioSource>().Play();
        player.GetComponent<PlayerScript>().energySimple = false;
    }
    //Funcion para generar la bola de energia oscura. Se activa la bola y se genera justo encima del jugador. Ademas se activa la animacion create de la bola y se le quita el power up al jugador.
    public void CreateDarkEnergy()
    {
        darkEnergies[0].GetComponent<SpriteRenderer>().enabled = true;
        darkEnergies[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        darkEnergies[0].transform.position = new Vector2(player.GetComponent<PlayerScript>().transform.position.x, player.GetComponent<PlayerScript>().transform.position.y + 1.7f);
        darkEnergies[0].GetComponent<Animator>().SetTrigger("Create");
        darkEnergies[0].GetComponent<AudioSource>().loop = true;
        darkEnergies[0].GetComponent<AudioSource>().clip = darkEnergySound;
        darkEnergies[0].GetComponent<AudioSource>().Play();
        player.GetComponent<PlayerScript>().darkEnergy = false;
    }
    //Funcion para activar la niebla.
    public void CreateFog()
    {
        player.GetComponent<PlayerScript>().canFog = false;
        NPC1.GetComponent<NPCScript>().fogged = true;
        NPC1.GetComponent<NPCScript>().foggedTime = Time.fixedTime;
        NPC2.GetComponent<NPCScript>().fogged = true;
        NPC2.GetComponent<NPCScript>().foggedTime = Time.fixedTime;
    }

}
