using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //El jugador
    public GameObject player;    
    //El offset a aplicar
    private Vector3 offset;
    //Duracion deseada del efecto de vibracion 
    private float shakeDuration = 0f;

    //Magnitud de la vibracion
    private float shakeMagnitude = 0.025f;

    //Rapidez en la que el efecto desaparece
    private float dampingSpeed = 1.0f;

    //Posicion inicial del gameobject
    Vector3 initialPosition;




   //Inicializamos el offset
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    
    void Update()
    {
        //Mientras el tiempo de duracion sea mayor que 0 hacemos que la camara tiemble segun los parametros que le hemos especificado antes
        if (shakeDuration > 0)
        {
            transform.localPosition = new Vector3(transform.position.x, player.transform.position.y + offset.y, transform.position.z) + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        //Cuando el tiempo llega a cero volvemos a poner la camara en la posicion original
        else
        {
            shakeDuration = 0f;
            transform.position = new Vector3(0.0f, player.transform.position.y + offset.y, transform.position.z);
        }       


    }

    public void TriggerShake(float d)
    {
        shakeDuration = d;
    }

}
