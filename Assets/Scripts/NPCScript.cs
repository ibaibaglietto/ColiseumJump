using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class NPCScript : MonoBehaviour
{
    //Animator del NPC
    Animator anim;
    //porcentaje de salto bueno
    private int goodJump;
    //porcentaje de salto malo
    private int badJump;
    //Boolean para ver si el personaje esta en el suelo
    public bool ground = false;
    //Boolean para ver si el personaje esta atrapado
    public bool trapped = false;
    //Float para ver desde cuando lleva atrapado el personaje
    public float trappedTime = 0.0f;
    //El objeto que nos permite saber si el personaje esta en el suelo
    public Transform groundCheck;
    //Float que marca el radio que vamos a usar desde la posición del groundCheck para ver el suelo
    float gRad = 0.2f;
    //La fuerza de salto
    float jumpStrength;
    //La layer que se detectara como suelo por el groundCheck
    public LayerMask Platforms;
    //Variable para ver en cual de las tres posiciones posibles esta el personaje (0 = izquierda, 1 = centro, 2 = derecha)
    public int pos;
    //Booleans para controlar el salto, saber hacia donde se esta saltando y saber hacia donde se va a saltar
    bool left, right, center, jumpingLeft, jumpingCenterRight, jumpingCenterLeft, jumpingRight, goRight, goLeft, goCenter;
    //Variable para saber en que fila se encuentra el personaje
    public int numPlat = 0;
    //Variable que guarda todas las plataformas de todos los niveles
    public int[,,] plat;
    //Numero generado de forma aleatoria para decidir el salto del personaje
    int r;
    //Variable para controlar el tiempo en tierra del personaje
    float groundTime = 0;
    //Variable para saber si el personaje ha terminado el nivel
    public bool ended = false;
    //Variable para saber si el personaje ha empezado a saltar
    public bool jumping = false;
    //Variable que dice si el personaje tiene un power up activo
    public bool powered = false;
    //Variable del power up escudo
    public int shielded;
    //Variable del power up de salto doble
    public int doubleJump;
    //Botas que se activan al tener el salto doble
    public SpriteRenderer bootL;
    public SpriteRenderer bootR;
    //Numero restante de saltos dobles
    public int remainingJumps;
    //Variable del power up de trampa
    public bool canTrap;
    //El numero de trampa a colocar
    public int numTrap;
    //Posicion en X de la trampa a colocar
    float trapPos;
    //Columna de la trampa a colocar
    int trapPosI;    
    //Variable del power up de bola de energia simple
    public bool energySimple;
    //Los gameobject de la bola de energia simple del boss
    public GameObject[] energyBallBoss;
    //El numero de la ultima bola de energia usada
    private int ballNumb = 0;
    //El gameobject de la bola de energia simple
    public GameObject energyBall;
    //Los gameobject de la bola de energia oscura del boss
    public GameObject[] darkEnergyBallBoss;
    //El numero de la ultima bola de energia oscura usada
    private int darkBallNumb = 0;
    //Variable del power up de bola de energia oscura
    public bool darkEnergy;
    //El gameobject de la bola de energia oscura
    public GameObject darkEnergyBall;
    //Variable del power up de activar la niebla
    public bool canFog;
    //Variable que dice si el personaje esta afectado por la niebla  
    public bool fogged;
    //Variable para controlar el tiempo que lleva la niebla activa
    public float foggedTime = 0.0f;
    //El spriteRenderer del NPC
    public SpriteRenderer self;
    //Array de trampas que pueden ser puestas en el mapa
    public GameObject[] traps;
    //El sprite renderer del power up del escudo
    public SpriteRenderer shield;
    //El numero de nivel que se esta jugando
    public int playingLevel;
    //El NPC lider, en el que se guardarán todos los cambios del nivel
    public Rigidbody2D NPCLeader;
    //El otro NPC del nivel
    public Rigidbody2D NPCOther;
    //El canvas del nivel
    public GameObject canvas;
    //Sonido de la bola de energia simple
    public AudioClip energySimpleSound;
    //Sonido de la bola de energia oscura
    public AudioClip darkEnergySound;
    //Numero que determina que boss es, si no es ninguno sera 0
    public int bossNumb;
    //Al empezar en nivel inicializaremos las variables necesarias, entre ellas el animator, los power ups y la disposicion del nivel
    void Start()
    {
        anim = GetComponent<Animator>();
        NPCLeader.GetComponent<NPCScript>().plat = new int[31, 56, 3] { 
                //1-1
                { { 1, 0, 1 }, { 0, 2, 1 }, { 1, 0, 2 }, { 0, 2, 1 }, { 1, 0, 0 }, { 1, 0, 1 }, { 2, 1, 0 }, { 0, 1, 0 }, { 1, 0, 2 }, { 4, 1, 0 }, { 1, 0, 1 }, { 0, 2, 1 }, { 0, 0, 1 }, { 2, 0, 1 }, { 1, 2, 0 }, { 1, 0, 1 }, { 0, 1, 2 }, { 2, 0, 1 }, { 1, 1, 0 }, { 0, 1, 4 }, { 0, 0, 1 }, { 1, 0, 0 }, { 2, 0, 1 }, { 0, 1, 0 }, { 1, 0, 2 }, { 1, 1, 0 }, { 1, 0, 0 }, { 2, 0, 1 }, { 2, 1, 2 }, { 1, 2, 0 }, { 0, 0, 1 }, { 4, 0, 1 }, { 0, 1, 0 }, { 1, 2, 2 }, { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 }, { 0, 0, 1 }, { 2, 1, 0 }, { 0, 1, 2 }, { 0, 1, 0 }, { 4, 0, 1 }, { 0, 0, 1 }, { 1, 2, 0 }, { 1, 0, 1 }, { 0, 1, 0 }, { 2, 1, 2 }, { 1, 2, 0 }, { 2, 0, 1 }, { 1, 1, 2 }, { 1, 1, 0 }, { 0, 2, 1 }, { 2, 0, 1 }, { 1, 2, 2 }, { 2, 1, 2 }, { 1, 1, 1 } },
                //1-2
                { {1,1,0}, {0,1,0}, {0,0,1}, {2,1,0}, {1,0,1}, {0,1,2}, {1,2,0}, {2,0,1}, {1,1,2}, {4,0,1}, {2,1,0}, {0,1,1}, {1,2,0}, {2,0,1}, {1,0,1}, {0,1,2}, {1,2,0}, {2,0,1}, {0,2,1}, {0,0,1}, {2,1,0}, {1,0,4}, {1,0,2}, {2,1,2}, {1,2,2}, {1,1,0}, {1,2,1}, {2,0,1}, {0,1,1}, {1,1,2}, {2,0,1}, {0,2,1}, {2,1,2}, {4,0,1}, {0,1,1}, {1,1,2}, {2,1,0}, {1,2,2}, {2,0,1}, {1,1,2}, {1,2,0}, {2,0,1}, {0,4,2}, {1,0,0}, {1,2,1}, {1,0,2}, {2,1,0}, {0,2,1}, {2,1,2}, {1,2,0}, {0,1,2}, {1,2,1}, {1,0,2}, {2,1,2}, {2,2,1}, {1,1,1} },
                //1-3
                { {0,1,1}, {1,0,2}, {2,1,1}, {0,1,1}, {1,2,0}, {0,1,2}, {2,0,1}, {0,2,1}, {0,1,4}, {1,0,2}, {2,1,1}, {1,2,0}, {2,0,1}, {0,1,2}, {2,1,0}, {0,2,1}, {1,0,1}, {0,1,0}, {1,0,2}, {4,2,0}, {2,1,2}, {0,2,1}, {2,0,1}, {0,0,1}, {0,1,2}, {2,1,1}, {0,1,2}, {1,2,0}, {2,0,1}, {0,2,1}, {2,1,0}, {0,1,0}, {4,2,1}, {1,0,2}, {2,1,1}, {0,1,2}, {1,2,0}, {1,0,2}, {2,1,0}, {0,2,1}, {1,0,2}, {4,2,1}, {2,1,2}, {1,2,2}, {2,2,1}, {0,1,2}, {1,2,0}, {2,0,1}, {0,1,2}, {1,2,0}, {1,0,2}, {0,1,1}, {2,1,2}, {1,2,2}, {2,2,1}, {1,1,1} },
                //1-4
                { {1,1,2}, {2,1,0}, {0,1,1}, {1,0,0}, {2,1,2}, {0,0,1}, {1,0,0}, {2,1,4}, {1,2,1}, {1,0,2}, {2,1,1}, {0,1,2}, {1,0,0}, {2,1,1}, {0,1,2}, {1,1,2}, {2,1,0}, {0,2,1}, {4,0,1}, {2,2,1}, {2,1,2}, {1,2,0}, {2,0,1}, {0,1,0}, {1,0,1}, {1,1,0}, {0,2,1}, {1,0,1}, {1,2,2}, {2,1,0}, {0,1,2}, {1,2,0}, {1,0,4}, {2,1,2}, {1,2,1}, {1,0,2}, {2,1,0}, {0,2,1}, {1,0,1}, {2,1,4}, {0,0,1}, {1,1,0}, {2,1,2}, {1,2,1}, {2,1,1}, {0,1,2}, {1,2,0}, {2,0,1}, {4,2,1}, {2,0,1}, {1,1,2}, {1,2,0}, {2,0,1}, {0,1,2}, {2,2,1}, {1,1,1} },
                //1-5
                { {0,1,1}, {1,0,1}, {1,2,0}, {2,0,1}, {1,1,0}, {0,1,1}, {1,0,2}, {4,1,0}, {0,1,2}, {0,2,1}, {1,2,0}, {2,0,1}, {1,0,2}, {2,1,0}, {1,1,2}, {4,1,0}, {0,2,1}, {1,0,2}, {2,0,1}, {2,1,1}, {1,0,0}, {2,1,1}, {1,1,2}, {1,0,1}, {0,1,0}, {0,0,4}, {1,2,0}, {1,1,2}, {2,1,0}, {1,2,1}, {1,0,1}, {0,1,2}, {2,0,4}, {0,2,1}, {1,2,0}, {2,1,1}, {1,1,2}, {2,0,1}, {1,0,2}, {2,1,0}, {1,4,0}, {0,2,1}, {2,0,1}, {0,1,2}, {1,2,0}, {0,1,1}, {1,0,0}, {0,1,0}, {1,4,2}, {2,1,2}, {1,2,2}, {2,2,1}, {2,1,2}, {1,2,2}, {2,2,1}, {1,1,1} }, 
                //2-1
                { { 0, 1, 4 }, { 0, 1, 0 }, { 0, 2, 1 }, { 1, 0, 2 }, { 2, 1, 1 }, { 0, 2, 1 }, { 0, 1, 1 }, { 1, 2, 0 }, { 2, 0, 1 }, { 4, 2, 2 }, { 2, 0, 1 }, { 2, 1, 2 }, { 2, 2, 1 }, { 1, 0, 0 }, { 0, 0, 1 }, { 0, 1, 0 }, { 1, 1, 2 }, { 2, 0, 4 }, { 0, 1, 2 }, { 1, 0, 2 }, { 2, 1, 2 }, { 0, 1, 0 }, { 1, 0, 1 }, { 0, 0, 1 }, { 1, 4, 0 }, { 2, 0, 1 }, { 0, 1, 2 }, { 1, 2, 0 }, { 2, 1, 1 }, { 0, 2, 1 }, { 1, 0, 2 }, { 0, 1, 0 }, { 1, 2, 1 }, { 1, 0, 2 }, { 1, 1, 0 }, { 2, 1, 1 }, { 0, 2, 4 }, { 1, 0, 1 }, { 0, 1, 0 }, { 1, 0, 2 }, { 2, 1, 1 }, { 0, 2, 1 }, { 1, 0, 2 }, { 1, 2, 0 }, { 2, 0, 1 }, { 0, 4, 0 }, { 2, 1, 2 }, { 0, 0, 1 }, { 0, 1, 0 }, { 4, 0, 0 }, { 1, 2, 1 }, { 2, 0, 1 }, { 1, 2, 2 }, { 2, 2, 1 }, { 2, 1, 2 }, { 1, 1, 1 }  },
                //2-2
                { {4,2,1}, {1,0,2}, {2,1,1}, {0,1,2}, {1,2,0}, {1,0,2}, {1,2,1}, {2,0,1}, {0,1,2}, {4,1,0}, {1,0,2}, {2,1,0}, {2,2,1}, {2,1,2}, {1,2,1}, {2,0,1}, {0,4,1}, {1,1,2}, {1,2,0}, {1,0,1}, {2,1,2}, {1,2,2}, {0,1,0}, {1,4,0}, {2,2,1}, {0,1,2}, {1,0,0}, {2,2,1}, {1,0,2}, {2,1,0}, {0,2,1}, {1,0,2}, {1,2,1}, {0,0,1}, {1,1,0}, {1,0,4}, {0,1,2}, {1,2,2}, {1,0,1}, {2,1,2}, {1,2,0}, {2,0,1}, {0,1,0}, {1,0,1}, {1,0,2}, {2,1,4}, {0,1,2}, {2,1,0}, {0,2,1}, {4,1,2}, {1,0,2}, {2,1,2}, {1,2,1}, {1,2,2}, {2,1,1}, {1,1,1} },
                //2-3
                { {0,4,1}, {1,2,0}, {2,0,1}, {0,1,2}, {2,1,0}, {1,2,1}, {2,1,1}, {0,2,1}, {2,0,1}, {1,4,2}, {1,2,0}, {2,0,1}, {0,1,2}, {1,1,0}, {1,0,2}, {2,1,0}, {0,1,0}, {4,0,1}, {2,1,0}, {0,2,1}, {1,0,2}, {0,1,1}, {1,0,0}, {0,1,0}, {0,0,1}, {4,1,2}, {2,0,1}, {0,1,2}, {1,2,0}, {1,0,1}, {1,1,2}, {2,1,0}, {1,2,1}, {2,1,2}, {2,2,1}, {1,0,2}, {2,4,1}, {0,2,1}, {1,2,2}, {2,1,1}, {2,1,2}, {1,1,2}, {1,2,0}, {4,0,1}, {0,1,0}, {1,0,2}, {2,1,0}, {0,2,1}, {2,0,1}, {4,1,2}, {2,2,1}, {2,1,2}, {1,2,2}, {2,2,1}, {0,1,2}, {1,1,1} },
                //2-4
                { {1,1,0}, {4,1,2}, {1,2,0}, {2,0,1}, {0,1,2}, {1,1,0}, {1,0,2}, {2,1,0}, {4,2,1}, {1,0,1}, {2,1,2}, {2,2,1}, {0,1,2}, {1,2,0}, {0,1,1}, {2,0,1}, {0,1,0}, {2,4,0}, {0,1,2}, {1,0,2}, {1,2,0}, {1,0,1}, {2,1,2}, {0,0,1}, {0,1,0}, {4,1,2}, {1,2,0}, {2,0,1}, {1,0,2}, {2,1,2}, {0,1,1}, {2,1,0}, {0,2,1}, {1,0,0}, {2,1,1}, {0,1,2}, {4,2,2}, {2,1,1}, {2,1,2}, {1,1,2}, {2,2,1}, {2,1,2}, {0,2,1}, {2,1,0}, {0,0,1}, {1,4,0}, {0,2,1}, {1,0,0}, {0,1,2}, {1,2,4}, {1,1,2}, {2,1,2}, {1,2,1}, {2,2,1}, {0,1,2}, {1,1,1} },
                //2-5
                { {0,1,1}, {2,1,0}, {0,1,2}, {2,0,4}, {1,1,0}, {1,2,1}, {1,0,2}, {1,0,0}, {0,1,1}, {2,0,1}, {0,2,4}, {1,0,2}, {1,2,0}, {2,0,1}, {0,1,0}, {0,0,1}, {0,4,2}, {0,2,1}, {1,0,2}, {2,0,1}, {0,2,1}, {0,0,1}, {4,0,2}, {0,1,2}, {2,2,1}, {2,1,2}, {0,1,0}, {2,0,4}, {0,2,1}, {0,1,2}, {2,0,1}, {0,1,0}, {4,0,2}, {0,1,0}, {2,2,1}, {0,1,2}, {1,2,0}, {2,0,4}, {1,2,1}, {1,0,2}, {2,0,1}, {0,1,1}, {4,1,2}, {1,2,0}, {1,0,1}, {2,1,0}, {0,2,1}, {1,0,2}, {0,1,0}, {2,2,4}, {2,1,2}, {1,2,1}, {2,1,2}, {1,2,2}, {1,2,1}, {1,1,1} }, 
                //3-1
                { {0,1,1}, {4,1,0}, {0,1,0}, {2,0,1}, {0,1,2}, {0,0,1}, {2,0,1}, {0,2,1}, {1,0,2}, {1,2,4}, {1,0,2}, {2,1,0}, {0,2,1}, {1,0,0}, {0,0,1}, {0,1,0}, {1,4,2}, {2,1,0}, {1,2,0}, {1,0,2}, {2,0,1}, {0,1,2}, {2,4,1}, {0,2,1}, {0,1,2}, {1,0,0}, {0,0,1}, {4,0,0}, {2,1,2}, {1,2,2}, {2,2,1}, {0,1,0}, {4,2,2}, {2,0,1}, {0,0,1}, {1,2,0}, {2,0,1}, {0,2,1}, {2,0,1}, {4,0,2}, {0,1,2}, {1,2,0}, {2,0,1}, {0,1,2}, {2,1,0}, {0,1,0}, {2,0,1}, {1,0,2}, {4,0,1}, {0,2,1}, {2,0,1}, {1,2,2}, {2,2,1}, {2,1,2}, {2,2,1}, {1,1,1} },
                //3-2
                { {1,0,1}, {1,1,0}, {0,1,0}, {0,1,2}, {1,2,0}, {2,1,1}, {0,1,2}, {2,1,0}, {0,2,4}, {1,0,1}, {0,1,2}, {1,2,0}, {1,0,2}, {0,1,0}, {2,0,1}, {4,1,2}, {2,1,0}, {1,0,1}, {2,1,2}, {0,2,1}, {1,1,2}, {1,2,0}, {2,1,4}, {0,1,2}, {2,0,1}, {4,2,1}, {1,0,2}, {1,1,0}, {1,0,1}, {2,1,2}, {2,2,1}, {0,0,1}, {1,4,2}, {2,1,0}, {0,2,1}, {1,0,2}, {1,1,0}, {2,2,1}, {4,2,1}, {2,0,1}, {1,2,2}, {2,1,2}, {0,1,0}, {0,0,1}, {1,0,0}, {0,1,0}, {1,0,1}, {2,1,2}, {1,1,2}, {2,1,4}, {2,1,2}, {1,2,2}, {2,2,1}, {2,1,2}, {1,2,2}, {1,1,1} },
                //3-3
                { {1,4,2}, {1,2,0}, {0,0,1}, {1,0,1}, {2,1,2}, {0,2,1}, {1,0,2}, {2,1,0}, {4,1,2}, {1,2,1}, {2,1,2}, {1,2,1}, {1,0,0}, {0,1,0}, {2,0,1}, {1,2,2}, {2,1,4}, {1,1,2}, {2,1,0}, {0,2,1}, {1,0,2}, {1,4,0}, {1,2,0}, {2,0,1}, {1,2,1}, {4,0,1}, {0,1,2}, {2,1,0}, {1,2,1}, {1,0,2}, {2,1,0}, {4,1,2}, {0,2,1}, {2,0,1}, {1,2,2}, {2,1,2}, {0,0,1}, {1,0,0}, {2,4,1}, {1,1,2}, {1,2,0}, {1,0,2}, {1,1,0}, {0,1,2}, {1,2,2}, {2,1,0}, {0,1,1}, {2,1,1}, {1,2,4}, {1,0,2}, {1,2,1}, {1,2,2}, {2,1,2}, {2,2,1}, {1,1,2}, {1,1,1} },
                //3-4
                { {0,1,0}, {1,2,4}, {2,0,1}, {0,2,1}, {1,0,2}, {2,1,0}, {0,1,2}, {1,2,0}, {2,1,2}, {4,2,1}, {2,0,1}, {1,1,2}, {2,1,1}, {0,1,0}, {4,0,1}, {2,1,0}, {0,2,1}, {1,1,0}, {2,2,1}, {2,1,2}, {1,2,0}, {4,0,2}, {2,1,0}, {1,2,1}, {0,1,1}, {1,2,2}, {2,2,1}, {2,1,2}, {4,0,1}, {0,1,0}, {2,0,1}, {1,2,1}, {1,0,2}, {0,2,1}, {2,0,4}, {1,1,2}, {0,1,1}, {1,0,0}, {0,1,0}, {1,2,1}, {2,0,1}, {0,4,2}, {1,2,2}, {2,1,2}, {1,2,2}, {2,2,1}, {1,0,2}, {2,1,0}, {1,1,2}, {2,4,2}, {2,2,1}, {0,2,1}, {1,2,2}, {2,1,2}, {2,2,1}, {1,1,1} },
                //3-5
                { {1,0,4}, {1,2,1}, {0,0,1}, {1,4,0}, {0,2,1}, {1,0,1}, {1,1,2}, {0,1,1}, {1,2,1}, {2,0,1}, {4,0,2}, {1,2,0}, {2,0,1}, {0,2,1}, {1,1,2}, {2,1,0}, {0,2,1}, {4,0,1}, {1,1,2}, {2,1,1}, {1,2,1}, {4,0,2}, {2,1,0}, {0,1,2}, {1,1,0}, {0,2,1}, {4,0,2}, {1,2,0}, {0,0,1}, {1,0,0}, {0,0,1}, {0,1,0}, {4,0,1}, {2,1,2}, {0,1,2}, {1,2,0}, {1,1,2}, {1,0,4}, {0,2,1}, {2,1,0}, {0,0,1}, {0,1,2}, {2,1,1}, {0,2,1}, {1,0,2}, {1,2,1}, {2,1,1}, {0,1,2}, {1,0,1}, {1,4,1}, {2,2,1}, {1,2,2}, {2,1,2}, {1,2,2}, {2,2,1}, {1,1,1} },
                //4-1
                { {1,0,0}, {0,0,1}, {1,2,4}, {2,0,1}, {0,2,1}, {1,0,2}, {2,1,1}, {0,4,2}, {1,2,0}, {0,0,1}, {1,0,1}, {0,1,0}, {1,2,2}, {2,2,1}, {2,1,2}, {0,1,0}, {1,2,4}, {0,2,1}, {2,0,1}, {0,1,2}, {1,2,0}, {2,1,4}, {1,1,0}, {0,1,1}, {0,1,0}, {1,2,2}, {2,0,4}, {0,0,1}, {0,1,2}, {4,2,0}, {1,1,2}, {2,1,0}, {0,2,1}, {1,0,4}, {0,0,1}, {1,0,0}, {0,1,0}, {4,2,2}, {2,2,1}, {2,1,1}, {0,2,1}, {2,0,1}, {0,1,2}, {2,1,0}, {0,1,0}, {1,0,4}, {2,0,1}, {0,0,1}, {0,1,4}, {2,4,2}, {1,2,1}, {1,2,2}, {2,1,1}, {2,2,1}, {1,1,2}, {1,1,1} },
                //4-2
                { {1,2,1}, {2,0,4}, {0,1,2}, {1,1,2}, {1,2,0}, {2,1,2}, {2,1,4}, {1,0,2}, {2,1,0}, {0,2,1}, {1,1,2}, {2,0,1}, {0,1,1}, {2,0,1}, {0,1,0}, {1,2,1}, {1,2,0}, {4,0,1}, {0,1,2}, {1,0,0}, {2,1,4}, {0,2,1}, {0,1,0}, {1,0,0}, {0,1,1}, {2,1,2}, {1,2,2}, {2,2,1}, {4,0,1}, {0,1,2}, {1,2,0}, {2,1,1}, {1,0,0}, {0,4,2}, {1,0,1}, {1,1,2}, {2,1,0}, {0,2,4}, {1,2,2}, {2,1,2}, {1,2,1}, {2,2,1}, {1,4,2}, {1,2,0}, {0,0,1}, {1,4,0}, {2,0,1}, {1,1,2}, {0,1,0}, {1,2,4}, {1,1,0}, {2,1,2}, {0,1,0}, {2,2,1}, {1,1,2}, {1,1,1} },
                //4-3
                { {1,0,4}, {0,1,2}, {1,2,0}, {0,0,1}, {1,0,2}, {0,4,0}, {1,1,0}, {1,0,1}, {0,1,1}, {1,2,4}, {2,0,1}, {1,2,0}, {2,1,2}, {1,2,1}, {2,0,1}, {1,2,0}, {0,1,4}, {1,0,0}, {0,2,1}, {1,1,0}, {2,1,1}, {0,1,0}, {1,0,4}, {1,0,0}, {2,1,2}, {1,2,2}, {2,2,1}, {2,1,0}, {1,2,4}, {1,0,2}, {2,1,2}, {0,4,1}, {1,1,2}, {1,2,0}, {2,1,4}, {0,0,1}, {1,0,2}, {2,1,0}, {1,2,2}, {2,2,4}, {0,0,1}, {1,2,0}, {2,1,2}, {0,2,1}, {1,1,2}, {2,1,0}, {1,2,4}, {1,0,1}, {1,1,2}, {2,1,4}, {1,2,2}, {2,1,2}, {2,2,1}, {1,2,2}, {2,1,2}, {1,1,1} },
                //4-4
                { {1,0,1}, {2,1,4}, {0,1,2}, {1,2,1}, {1,0,2}, {0,1,4}, {1,0,0}, {0,2,1}, {2,0,4}, {0,1,0}, {4,2,2}, {2,0,1}, {2,1,2}, {1,2,0}, {2,1,1}, {4,1,2}, {2,1,0}, {0,1,2}, {1,2,1}, {2,0,1}, {1,2,0}, {2,1,4}, {0,1,2}, {1,0,2}, {2,0,1}, {0,1,2}, {1,2,2}, {0,1,0}, {1,2,4}, {0,2,1}, {2,1,0}, {2,4,1}, {0,0,1}, {0,1,0}, {1,0,1}, {0,1,2}, {1,2,0}, {2,1,4}, {1,2,2}, {2,1,0}, {1,1,2}, {1,2,0}, {0,1,2}, {4,2,1}, {2,1,2}, {0,0,1}, {2,1,2}, {1,2,1}, {2,1,2}, {0,2,4}, {1,1,2}, {2,2,1}, {1,2,2}, {2,1,2}, {2,2,1}, {1,1,1} },
                //4-5
                { {1,1,0}, {0,1,2}, {4,2,0}, {2,0,1}, {0,2,1}, {1,0,0}, {2,0,4}, {0,1,2}, {1,0,0}, {1,0,1}, {1,2,1}, {1,0,2}, {2,4,0}, {2,0,1}, {0,2,1}, {4,0,2}, {1,0,0}, {0,1,0}, {0,0,1}, {4,2,0}, {2,1,1}, {0,2,4}, {1,0,2}, {2,1,0}, {1,4,0}, {2,0,1}, {0,2,1}, {4,0,1}, {1,1,2}, {4,2,0}, {2,0,1}, {1,0,2}, {2,1,0}, {1,2,4}, {0,1,0}, {0,0,1}, {4,0,0}, {2,2,1}, {1,0,2}, {1,2,0}, {2,0,1}, {0,1,2}, {1,0,0}, {4,2,1}, {1,0,2}, {2,1,0}, {1,1,2}, {4,0,0}, {0,0,1}, {4,2,2}, {2,1,2}, {1,2,2}, {2,2,1}, {2,1,2}, {1,2,2}, {1,1,1} },
                //5-1
                { {0,1,1}, {1,1,0}, {1,0,4}, {2,1,4}, {0,1,2}, {1,2,0}, {0,0,1}, {2,1,1}, {0,1,2}, {0,1,0}, {2,0,4}, {0,0,1}, {1,0,2}, {0,1,0}, {1,2,4}, {2,0,1}, {0,0,1}, {1,0,0}, {2,1,0}, {0,2,1}, {4,0,1}, {1,2,2}, {2,2,1}, {2,1,2}, {4,0,1}, {2,1,1}, {0,1,2}, {1,2,0}, {2,0,4}, {0,1,0}, {0,0,1}, {4,0,0}, {1,2,1}, {1,0,2}, {2,1,0}, {1,2,0}, {0,2,1}, {0,1,2}, {1,2,2}, {2,4,2}, {1,1,0}, {1,2,1}, {2,0,1}, {4,0,2}, {0,1,0}, {2,1,1}, {0,1,2}, {1,2,0}, {2,0,1}, {1,4,2}, {1,0,0}, {2,1,2}, {2,2,1}, {2,1,2}, {1,2,2}, {1,1,1} },
                //5-2
                { {1,2,4}, {2,1,2}, {0,2,4}, {1,1,0}, {0,0,1}, {2,4,0}, {0,1,2}, {1,2,0}, {2,1,1}, {0,2,1}, {1,0,0}, {4,2,1}, {1,0,2}, {2,1,1}, {4,0,1}, {1,2,2}, {4,2,1}, {2,1,1}, {0,1,2}, {1,2,0}, {2,0,1}, {1,0,2}, {2,1,0}, {0,2,1}, {1,2,1}, {0,1,2}, {2,1,4}, {0,2,1}, {1,1,2}, {0,1,0}, {2,0,1}, {1,2,0}, {0,2,1}, {2,1,2}, {1,2,1}, {2,0,4}, {1,1,0}, {2,1,1}, {1,0,1}, {2,1,2}, {4,2,2}, {2,0,1}, {1,1,2}, {2,2,1}, {1,2,2}, {2,1,2}, {4,2,1}, {2,0,1}, {0,2,1}, {4,2,2}, {2,2,1}, {2,1,2}, {1,2,1}, {1,0,2}, {2,2,1}, {1,1,1} },
                //5-3
                { {1,1,2}, {1,2,4}, {2,1,1}, {0,1,2}, {4,2,0}, {0,0,1}, {1,0,0}, {2,1,1}, {0,4,2}, {1,2,1}, {2,1,2}, {2,2,1}, {1,1,2}, {2,1,0}, {1,0,2}, {4,2,0}, {2,1,2}, {0,1,1}, {1,0,2}, {2,4,0}, {1,2,1}, {2,1,1}, {0,2,1}, {1,0,2}, {2,4,0}, {1,2,2}, {2,2,1}, {4,2,2}, {0,1,0}, {0,0,1}, {4,2,2}, {2,1,1}, {0,1,2}, {1,1,0}, {2,2,1}, {0,4,2}, {2,2,1}, {1,2,2}, {2,1,0}, {2,1,1}, {0,1,2}, {1,2,1}, {4,0,1}, {1,1,2}, {0,1,0}, {0,0,1}, {4,2,0}, {2,0,1}, {0,1,2}, {4,2,2}, {2,2,1}, {2,1,2}, {1,2,2}, {2,1,2}, {2,2,1}, {1,1,1} },
                //5-4
                { {0,1,1}, {4,0,2}, {2,1,0}, {2,0,1}, {1,2,1}, {2,1,4}, {0,1,2}, {2,1,0}, {0,1,4}, {2,0,1}, {0,1,0}, {0,2,1}, {1,0,2}, {2,4,1}, {0,1,2}, {1,2,0}, {1,1,2}, {2,4,0}, {0,2,1}, {1,0,1}, {2,1,2}, {4,2,0}, {0,0,1}, {0,1,0}, {1,0,0}, {2,2,4}, {1,2,2}, {2,1,2}, {1,1,0}, {2,1,1}, {1,2,0}, {0,1,2}, {2,0,1}, {1,4,0}, {1,2,1}, {1,0,2}, {0,2,1}, {1,2,1}, {2,1,2}, {2,1,1}, {4,1,2}, {2,1,0}, {0,1,1}, {1,2,0}, {2,1,1}, {0,2,4}, {1,0,2}, {2,1,0}, {0,1,1}, {1,4,2}, {2,2,1}, {1,2,2}, {2,1,2}, {2,2,1}, {1,2,2}, {1,1,1} }, 
                //5-5
                { {0,1,2}, {2,4,0}, {0,0,1}, {1,1,0}, {0,2,1}, {4,1,2}, {2,1,0}, {0,2,1}, {1,0,2}, {2,0,1}, {0,1,2}, {4,0,0}, {0,1,0}, {2,2,1}, {0,4,2}, {1,1,0}, {1,0,2}, {0,4,0}, {2,0,1}, {0,1,1}, {1,0,1}, {2,1,0}, {0,2,4}, {2,1,0}, {0,0,1}, {2,4,2}, {0,1,0}, {1,1,0}, {0,2,1}, {2,4,0}, {1,1,2}, {0,4,0}, {1,0,0}, {0,0,1}, {1,1,2}, {2,0,4}, {0,1,1}, {1,1,2}, {4,2,0}, {0,1,1}, {2,1,2}, {1,2,2}, {2,2,1}, {0,0,4}, {0,1,0}, {2,1,0}, {0,2,1}, {1,0,2}, {2,1,1}, {4,2,2}, {2,2,1}, {2,1,2}, {2,2,1}, {1,2,2}, {2,1,2}, {1,1,1} },
                //6-1
                { {1,1,0}, {2,1,4}, {0,1,2}, {0,1,0}, {4,2,1}, {1,0,2}, {2,1,0}, {0,2,1}, {2,0,4}, {0,1,1}, {0,1,2}, {1,2,0}, {2,2,1}, {2,1,2}, {1,2,2}, {0,1,0}, {1,2,1}, {1,0,2}, {4,1,0}, {2,1,2}, {0,1,0}, {4,0,1}, {1,0,0}, {0,0,1}, {4,1,2}, {1,2,0}, {1,0,1}, {2,0,4}, {1,0,2}, {0,1,0}, {4,2,0}, {2,0,1}, {0,1,2}, {2,2,4}, {1,2,2}, {2,2,1}, {0,0,1}, {1,0,1}, {2,1,4}, {0,2,1}, {2,1,2}, {4,2,0}, {2,1,0}, {0,1,1}, {1,0,2}, {2,0,4}, {1,1,2}, {2,1,0}, {0,0,1}, {0,4,2}, {1,2,0}, {2,1,2}, {2,2,1}, {1,2,2}, {2,1,2}, {1,1,1} },
                //6-2
                { {1,0,1}, {2,4,1}, {1,0,2}, {2,1,0}, {0,2,1}, {4,2,2}, {1,2,0}, {1,0,2}, {2,1,0}, {0,4,2}, {4,2,1}, {2,1,2}, {2,2,1}, {1,0,0}, {0,0,4}, {1,2,2}, {2,0,1}, {1,1,0}, {0,2,1}, {1,1,2}, {2,1,0}, {4,0,2}, {0,2,1}, {1,0,0}, {0,0,1}, {0,1,0}, {4,0,1}, {2,1,2}, {1,2,2}, {2,2,4}, {1,0,2}, {2,2,1}, {4,2,2}, {2,0,1}, {1,2,0}, {2,2,1}, {1,2,2}, {2,1,4}, {1,2,0}, {1,0,1}, {2,4,0}, {0,2,1}, {1,0,2}, {4,1,0}, {0,0,1}, {1,2,0}, {2,0,1}, {1,1,2}, {2,2,1}, {4,2,2}, {2,1,2}, {2,2,1}, {1,2,2}, {2,2,1}, {2,1,2}, {1,1,1} },
                //6-3
                { {1,1,0}, {2,1,2}, {4,0,1}, {1,1,2}, {2,4,0}, {0,2,1}, {1,0,2}, {2,1,4}, {1,1,2}, {1,2,0}, {2,0,1}, {0,1,2}, {4,2,0}, {0,0,1}, {0,1,0}, {1,0,0}, {2,2,4}, {1,2,2}, {2,1,2}, {0,4,1}, {1,2,1}, {2,1,2}, {0,1,1}, {1,0,0}, {2,1,1}, {0,1,2}, {2,1,0}, {0,2,1}, {1,0,4}, {1,1,0}, {2,0,1}, {0,4,2}, {1,2,0}, {2,0,1}, {2,1,2}, {1,2,2}, {2,2,4}, {0,1,0}, {1,0,0}, {0,1,4}, {1,2,0}, {0,1,2}, {2,0,1}, {0,4,0}, {1,0,1}, {1,2,0}, {1,0,2}, {2,1,0}, {0,2,1}, {2,1,4}, {1,2,2}, {2,2,4}, {2,1,2}, {1,2,2}, {2,2,1}, {1,1,1} },
                //6-4
                { {0,1,1}, {4,2,1}, {1,0,2}, {2,1,0}, {0,2,4}, {1,1,2}, {1,2,0}, {2,0,4}, {0,1,0}, {1,0,1}, {0,1,2}, {4,1,0}, {2,2,1}, {1,2,2}, {2,1,2}, {4,0,0}, {0,0,1}, {0,1,0}, {1,0,2}, {2,1,0}, {0,2,1}, {1,0,4}, {0,1,0}, {1,0,2}, {2,1,0}, {0,2,1}, {2,0,1}, {0,4,2}, {1,2,0}, {1,0,2}, {0,4,0}, {0,0,1}, {1,1,2}, {2,2,1}, {4,2,1}, {2,0,1}, {0,4,2}, {1,2,0}, {2,1,1}, {0,2,1}, {1,0,2}, {2,1,0}, {0,1,1}, {1,2,2}, {2,0,4}, {1,0,0}, {2,1,2}, {2,2,4}, {1,2,2}, {2,1,4}, {0,1,2}, {1,2,2}, {2,2,1}, {2,1,2}, {0,1,0}, {1,1,1} },
                //6-5
                { {1,0,4}, {1,2,2}, {2,0,1}, {0,2,4}, {1,0,2}, {2,1,0}, {0,0,1}, {0,1,0}, {4,0,0}, {2,2,1}, {2,0,1}, {0,1,2}, {1,2,1}, {1,0,2}, {2,1,0}, {2,1,1}, {0,1,2}, {4,2,0}, {2,0,1}, {1,2,1}, {4,0,2}, {1,1,0}, {0,0,1}, {0,4,2}, {1,0,1}, {0,2,1}, {4,0,0}, {2,0,1}, {0,1,2}, {4,1,0}, {1,0,2}, {1,2,2}, {2,1,2}, {2,2,1}, {0,4,0}, {1,2,0}, {1,0,2}, {2,4,0}, {0,2,1}, {1,0,1}, {4,1,2}, {2,1,0}, {0,1,2}, {0,2,1}, {1,0,2}, {1,2,0}, {2,4,0}, {0,0,1}, {1,0,0}, {2,2,4}, {1,2,2}, {2,1,2}, {1,2,2}, {2,2,1}, {2,1,2}, {1,1,1} },
                //Tutorial
                { {1,1,1}, {1,1,1}, {1,1,1}, {1,2,1}, {1,1,2}, {2,1,1}, {1,1,0}, {1,0,1}, {0,1,1}, {4,1,1}, {1,2,1}, {2,1,1}, {0,2,1}, {1,0,2}, {2,1,1}, {0,1,2}, {1,1,2}, {1,1,0}, {0,0,1}, {4,2,1}, {2,1,0}, {1,2,1}, {1,0,0}, {0,1,1}, {1,2,2}, {2,1,1}, {0,2,1}, {1,0,1}, {0,1,0}, {1,2,1}, {2,4,2}, {1,2,2}, {2,1,1}, {1,0,0}, {2,2,1}, {1,1,2}, {2,1,0}, {0,1,1}, {1,0,1}, {2,1,1}, {1,0,2}, {2,4,1}, {1,2,0}, {0,1,1}, {1,0,0}, {0,1,2}, {0,1,1}, {1,1,2}, {2,1,1}, {1,2,1}, {2,1,0}, {0,1,2}, {1,0,1}, {1,2,2}, {2,1,2}, {1,1,1} } };
        shielded = 0;
        doubleJump = 0;
        remainingJumps = 0;
        numTrap = 0;
        canTrap = false;
        energySimple = false;
        darkEnergy = false;
        fogged = false;
        if(NPCLeader.GetComponent<NPCScript>().playingLevel < 5)
        {
            goodJump = 80;
            badJump = 90;
        }
        else if (NPCLeader.GetComponent<NPCScript>().playingLevel < 10)
        {
            goodJump = 82;
            badJump = 91;
        }
        else if (NPCLeader.GetComponent<NPCScript>().playingLevel < 15)
        {
            goodJump = 84;
            badJump = 92;
        }
        else if (NPCLeader.GetComponent<NPCScript>().playingLevel < 20)
        {
            goodJump = 86;
            badJump = 93;
        }
        else if (NPCLeader.GetComponent<NPCScript>().playingLevel < 25)
        {
            goodJump = 88;
            badJump = 94;
        }
        else if (NPCLeader.GetComponent<NPCScript>().playingLevel < 30)
        {
            goodJump = 90;
            badJump = 95;
        }
        else if (NPCLeader.GetComponent<NPCScript>().playingLevel == 30)
        {
            goodJump = 78;
            badJump = 89;
        }
    }


    void FixedUpdate()
    {
        if (!canvas.GetComponent<UIScript>().Paused)
        {
            //Gestion del escudo
            if (shielded == 1) shield.enabled = true;
            else shield.enabled = false;
            //Gestion del doble salto
            if (remainingJumps == 0)
            {
                doubleJump = 0;
                bootL.enabled = false;
                bootR.enabled = false;
            }
            //Gestion de la niebla
            if (fogged)
                self.color = new Color(0.27f, 0.27f, 0.27f, 1.0f);
            else
                self.color = new Color(255.0f, 255.0f, 255.0f, 1.0f);
            //Miramos si el personaje tiene un power up activo
            powered = (doubleJump == 1) || (shielded == 1) || canTrap || energySimple || darkEnergy || canFog;
            //Posicion en x e y del personaje
            float x = GetComponent<Rigidbody2D>().position.x;
            float y = GetComponent<Rigidbody2D>().position.y;

            //Miramos hacia donde esta saltando el personaje y nos aseguramos de que no se pase de su objetivo en X
            if (jumpingCenterLeft && x >= 0.0f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(0.0f, GetComponent<Rigidbody2D>().position.y));
                jumpingCenterLeft = false;

            }
            else if (jumpingCenterRight && x <= 0.0f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(0.0f, GetComponent<Rigidbody2D>().position.y));
                jumpingCenterRight = false;

            }
            else if (jumpingLeft && x <= -1.85f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(-1.85f, GetComponent<Rigidbody2D>().position.y));
                jumpingLeft = false;
            }
            else if (jumpingRight && x >= 1.85f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(1.85f, GetComponent<Rigidbody2D>().position.y));
                jumpingRight = false;
            }
            //Guardamos la columna en la que esta el NPC
            if (x <= 0.1f && x >= -0.1f)
            {
                left = false;
                center = true;
                right = false;
                pos = 1;
            }
            else if (x == -1.85f)
            {
                left = true;
                center = false;
                right = false;
                pos = 0;
            }
            else if (x == 1.85f)
            {
                left = false;
                center = false;
                right = true;
                pos = 2;
            }
            //Gestion del tiempo en la que el personaje ha estado afectado por la niebla
            if (fogged && ((Time.fixedTime - foggedTime) >= 3.0f))
            {
                fogged = false;
            }
            //Gestion del tiempo en la que el personaje ha estado atrapado atrapado
            if (trapped && ((Time.fixedTime - trappedTime) >= 2.0f))
            {
                trapped = false;
            }
            //Miramos en que fila esta el personaje
            if (y > -4.5 && y < -1.23) numPlat = 0;
            else if (y > -1.23 && y < 1.84) numPlat = 1;
            else if (y > 1.84 && y < 4.91) numPlat = 2;
            else if (y > 4.91 && y < 7.98) numPlat = 3;
            else if (y > 7.98 && y < 11.05) numPlat = 4;
            else if (y > 11.05 && y < 14.12) numPlat = 5;
            else if (y > 14.12 && y < 17.19) numPlat = 6;
            else if (y > 17.19 && y < 20.26) numPlat = 7;
            else if (y > 20.26 && y < 23.33) numPlat = 8;
            else if (y > 23.33 && y < 26.4) numPlat = 9;
            else if (y > 26.4 && y < 29.47) numPlat = 10;
            else if (y > 29.47 && y < 32.54) numPlat = 11;
            else if (y > 32.54 && y < 35.61) numPlat = 12;
            else if (y > 35.61 && y < 38.68) numPlat = 13;
            else if (y > 38.68 && y < 41.75) numPlat = 14;
            else if (y > 41.75 && y < 44.82) numPlat = 15;
            else if (y > 44.82 && y < 47.89) numPlat = 16;
            else if (y > 47.89 && y < 50.96) numPlat = 17;
            else if (y > 50.96 && y < 54.03) numPlat = 18;
            else if (y > 54.03 && y < 57.1) numPlat = 19;
            else if (y > 57.1 && y < 60.17) numPlat = 20;
            else if (y > 60.17 && y < 63.24) numPlat = 21;
            else if (y > 63.24 && y < 66.31) numPlat = 22;
            else if (y > 66.31 && y < 69.38) numPlat = 23;
            else if (y > 69.38 && y < 72.45) numPlat = 24;
            else if (y > 72.45 && y < 75.52) numPlat = 25;
            else if (y > 75.52 && y < 78.59) numPlat = 26;
            else if (y > 78.59 && y < 81.66) numPlat = 27;
            else if (y > 81.66 && y < 84.73) numPlat = 28;
            else if (y > 84.73 && y < 87.8) numPlat = 29;
            else if (y > 87.8 && y < 90.87) numPlat = 30;
            else if (y > 90.87 && y < 93.94) numPlat = 31;
            else if (y > 93.94 && y < 97.01) numPlat = 32;
            else if (y > 97.01 && y < 100.08) numPlat = 33;
            else if (y > 100.08 && y < 103.15) numPlat = 34;
            else if (y > 103.15 && y < 106.22) numPlat = 35;
            else if (y > 106.22 && y < 109.29) numPlat = 36;
            else if (y > 109.29 && y < 112.36) numPlat = 37;
            else if (y > 112.36 && y < 115.43) numPlat = 38;
            else if (y > 115.43 && y < 118.5) numPlat = 39;
            else if (y > 118.5 && y < 121.57) numPlat = 40;
            else if (y > 121.57 && y < 124.64) numPlat = 41;
            else if (y > 124.64 && y < 127.71) numPlat = 42;
            else if (y > 127.71 && y < 130.78) numPlat = 43;
            else if (y > 130.78 && y < 133.85) numPlat = 44;
            else if (y > 133.85 && y < 136.92) numPlat = 45;
            else if (y > 136.92 && y < 139.99) numPlat = 46;
            else if (y > 139.99 && y < 143.06) numPlat = 47;
            else if (y > 143.06 && y < 146.13) numPlat = 48;
            else if (y > 146.13 && y < 149.2) numPlat = 49;
            else if (y > 149.2 && y < 152.27) numPlat = 50;
            else if (y > 152.27 && y < 155.34) numPlat = 51;
            else if (y > 155.34 && y < 158.41) numPlat = 52;
            else if (y > 158.41 && y < 161.48) numPlat = 53;
            else if (y > 161.48 && y < 164.55) numPlat = 54;
            else if (y > 164.55 && y < 167.62) numPlat = 55;
            //Miramos si el personaje esta en el suelo
            if (Physics2D.OverlapCircle(groundCheck.position, gRad, Platforms) && (GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0)) && !ground)
            {
                ground = true;
                groundTime = Time.fixedTime;
                anim.SetBool("Landed", true);
            }
            else if (0.3f < (Time.fixedTime - groundTime))
            {
                ground = false;
                jumping = false;

            }

            if (jumping)
            {
                anim.SetBool("Landed", false);
            }


            //Miramos que el personaje no este atrapado, no este saltando y no haya terminado el nivel
            if ((0.2f < (Time.fixedTime - groundTime)) && !trapped && !jumping && ground && !ended)
            {

                //Asignamos la fuerza de salto dependiendo del power up de salto doble
                if (doubleJump == 1 && numPlat < 54)
                {
                    jumpStrength = 1400.0f;
                }
                else
                {
                    jumpStrength = 1000.0f;
                }
                //Calculamos un numero aleatorio que usaremos para decidir como saltara el NPC
                r = Random.Range(0, 100);
                if (!fogged)
                {
                    //Con un 80% de probabilidad el personaje saltara a la plataforma libre que se encuentre mas a la izquierda o a la plataforma que tenga un power up
                    if (r <= goodJump)
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().Play();
                        if((r <=40) && bossNumb == 1 && numPlat < 54)
                        {
                            jumpStrength = 1400.0f;
                            if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 0] == 4) goLeft = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 1] == 4) goCenter = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 2] == 4) goRight = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 0] == 1) goLeft = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 1] == 1) goCenter = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 2] == 1) goRight = true;
                        }
                        else
                        {
                            if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 0] == 4) goLeft = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 1] == 4) goCenter = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 2] == 4) goRight = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 0] == 1) goLeft = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 1] == 1) goCenter = true;
                            else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 2] == 1) goRight = true;
                        }
                        if((r <= 12) && bossNumb == 2)
                        {
                            energyBallBoss[ballNumb].GetComponent<BoxCollider2D>().enabled = true;
                            energyBallBoss[ballNumb].GetComponent<SpriteRenderer>().enabled = true;
                            energyBallBoss[ballNumb].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                            energyBallBoss[ballNumb].transform.position = new Vector2(GetComponent<NPCScript>().transform.position.x, GetComponent<NPCScript>().transform.position.y + 1.7f);
                            energyBallBoss[ballNumb].GetComponent<Animator>().SetTrigger("Create");
                            energyBallBoss[ballNumb].GetComponent<AudioSource>().loop = true;
                            energyBallBoss[ballNumb].GetComponent<AudioSource>().clip = energySimpleSound;
                            energyBallBoss[ballNumb].GetComponent<AudioSource>().Play();
                            if (ballNumb == 8) ballNumb = 0;
                            else ballNumb += 1;
                        }
                        if ((r <= 25) && bossNumb == 3)
                        {
                            if (GetComponent<NPCScript>().numPlat >= 2)
                            {
                                if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, 0] == 1)
                                {
                                    trapPos = -1.85f;
                                    trapPosI = 0;
                                }
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, 1] == 1)
                                {
                                    trapPos = 0.0f;
                                    trapPosI = 1;
                                }
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, 2] == 1)
                                {
                                    trapPos = 1.85f;
                                    trapPosI = 2;
                                }

                                traps[NPCLeader.GetComponent<NPCScript>().numTrap].transform.position = new Vector2(trapPos, GetComponent<NPCScript>().transform.position.y - 3.75f);                                
                                NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, trapPosI] = 2;
                                if (numTrap == 8) numTrap = 0;
                                else numTrap += 1;
                            }
                        }
                        if(r<=25 && bossNumb == 4 && canvas.GetComponent<UIScript>().fogLevel <= 0.0f)
                        {
                            canvas.GetComponent<UIScript>().fogLevel = 2.0f;
                            NPCOther.GetComponent<NPCScript>().fogged = true;
                            NPCOther.GetComponent<NPCScript>().foggedTime = Time.fixedTime;
                        }
                        if ((r <= 12) && bossNumb == 5)
                        {
                            darkEnergyBallBoss[darkBallNumb].GetComponent<BoxCollider2D>().enabled = true;
                            darkEnergyBallBoss[darkBallNumb].GetComponent<SpriteRenderer>().enabled = true;
                            darkEnergyBallBoss[darkBallNumb].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                            darkEnergyBallBoss[darkBallNumb].transform.position = new Vector2(GetComponent<NPCScript>().transform.position.x, GetComponent<NPCScript>().transform.position.y + 1.7f);
                            darkEnergyBallBoss[darkBallNumb].GetComponent<Animator>().SetTrigger("Create");
                            darkEnergyBallBoss[darkBallNumb].GetComponent<AudioSource>().loop = true;
                            darkEnergyBallBoss[darkBallNumb].GetComponent<AudioSource>().clip = darkEnergySound;
                            darkEnergyBallBoss[darkBallNumb].GetComponent<AudioSource>().Play();
                            if (darkBallNumb == 8) darkBallNumb = 0;
                            else darkBallNumb += 1;
                        }
                        if((r<=50) && bossNumb == 6)
                        {
                            if (r <= 20 && numPlat<54)
                            {
                                jumpStrength = 1400.0f;
                                if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 0] == 4) goLeft = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 1] == 4) goCenter = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 2] == 4) goRight = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 0] == 1) goLeft = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 1] == 1) goCenter = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + 1, 2] == 1) goRight = true;
                            }
                            else
                            {
                                if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 0] == 4) goLeft = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 1] == 4) goCenter = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 2] == 4) goRight = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 0] == 1) goLeft = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 1] == 1) goCenter = true;
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 2] == 1) goRight = true;
                            }
                            if (r>20 && r <= 25)
                            {
                                energyBallBoss[ballNumb].GetComponent<BoxCollider2D>().enabled = true;
                                energyBallBoss[ballNumb].GetComponent<SpriteRenderer>().enabled = true;
                                energyBallBoss[ballNumb].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                                energyBallBoss[ballNumb].transform.position = new Vector2(GetComponent<NPCScript>().transform.position.x, GetComponent<NPCScript>().transform.position.y + 1.7f);
                                energyBallBoss[ballNumb].GetComponent<Animator>().SetTrigger("Create");
                                energyBallBoss[ballNumb].GetComponent<AudioSource>().loop = true;
                                energyBallBoss[ballNumb].GetComponent<AudioSource>().clip = energySimpleSound;
                                energyBallBoss[ballNumb].GetComponent<AudioSource>().Play();
                                if (ballNumb == 8) ballNumb = 0;
                                else ballNumb += 1;
                            }
                            if (r>25 && r <= 35)
                            {
                                if (GetComponent<NPCScript>().numPlat >= 2)
                                {
                                    if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, 0] == 1)
                                    {
                                        trapPos = -1.85f;
                                        trapPosI = 0;
                                    }
                                    else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, 1] == 1)
                                    {
                                        trapPos = 0.0f;
                                        trapPosI = 1;
                                    }
                                    else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, 2] == 1)
                                    {
                                        trapPos = 1.85f;
                                        trapPosI = 2;
                                    }

                                    traps[NPCLeader.GetComponent<NPCScript>().numTrap].transform.position = new Vector2(trapPos, GetComponent<NPCScript>().transform.position.y - 3.75f);
                                    NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, trapPosI] = 2;
                                    if (numTrap == 8) numTrap = 0;
                                    else numTrap += 1;
                                }
                            }
                            if (r>35 && r <= 45 && canvas.GetComponent<UIScript>().fogLevel <= 0.0f)
                            {
                                canvas.GetComponent<UIScript>().fogLevel = 2.0f;
                                NPCOther.GetComponent<NPCScript>().fogged = true;
                                NPCOther.GetComponent<NPCScript>().foggedTime = Time.fixedTime;
                            }
                            if (r>45 && r <= 50)
                            {
                                darkEnergyBallBoss[darkBallNumb].GetComponent<BoxCollider2D>().enabled = true;
                                darkEnergyBallBoss[darkBallNumb].GetComponent<SpriteRenderer>().enabled = true;
                                darkEnergyBallBoss[darkBallNumb].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                                darkEnergyBallBoss[darkBallNumb].transform.position = new Vector2(GetComponent<NPCScript>().transform.position.x, GetComponent<NPCScript>().transform.position.y + 1.7f);
                                darkEnergyBallBoss[darkBallNumb].GetComponent<Animator>().SetTrigger("Create");
                                darkEnergyBallBoss[darkBallNumb].GetComponent<AudioSource>().loop = true;
                                darkEnergyBallBoss[darkBallNumb].GetComponent<AudioSource>().clip = darkEnergySound;
                                darkEnergyBallBoss[darkBallNumb].GetComponent<AudioSource>().Play();
                                if (darkBallNumb == 8) darkBallNumb = 0;
                                else darkBallNumb += 1;
                            }
                        }
                        //Ademas, si el numero es menor que 40 el NPC usara el power up que tenga activo siempre que disponga de uno
                        if (r <= 40)
                        {
                            if (GetComponent<NPCScript>().canTrap && GetComponent<NPCScript>().numPlat >= 2)
                            {
                                if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, 0] == 1)
                                {
                                    trapPos = -1.85f;
                                    trapPosI = 0;
                                }
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, 1] == 1)
                                {
                                    trapPos = 0.0f;
                                    trapPosI = 1;
                                }
                                else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, 2] == 1)
                                {
                                    trapPos = 1.85f;
                                    trapPosI = 2;
                                }

                                traps[NPCLeader.GetComponent<NPCScript>().numTrap].transform.position = new Vector2(trapPos, GetComponent<NPCScript>().transform.position.y - 3.75f);
                                NPCLeader.GetComponent<NPCScript>().numTrap += 1;
                                GetComponent<NPCScript>().canTrap = false;
                                NPCLeader.GetComponent<NPCScript>().plat[playingLevel, GetComponent<NPCScript>().numPlat - 2, trapPosI] = 2;
                            }
                            if (GetComponent<NPCScript>().energySimple)
                            {
                                energyBall.GetComponent<BoxCollider2D>().enabled = true;
                                energyBall.GetComponent<SpriteRenderer>().enabled = true;
                                energyBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                                energyBall.transform.position = new Vector2(GetComponent<NPCScript>().transform.position.x, GetComponent<NPCScript>().transform.position.y + 1.7f);
                                energyBall.GetComponent<Animator>().SetTrigger("Create");
                                energyBall.GetComponent<AudioSource>().loop = true;
                                energyBall.GetComponent<AudioSource>().clip = energySimpleSound;
                                energyBall.GetComponent<AudioSource>().Play();
                                GetComponent<NPCScript>().energySimple = false;
                            }
                            if (GetComponent<NPCScript>().darkEnergy)
                            {
                                darkEnergyBall.GetComponent<BoxCollider2D>().enabled = true;
                                darkEnergyBall.GetComponent<SpriteRenderer>().enabled = true;
                                darkEnergyBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                                darkEnergyBall.transform.position = new Vector2(GetComponent<NPCScript>().transform.position.x, GetComponent<NPCScript>().transform.position.y + 1.7f);
                                darkEnergyBall.GetComponent<Animator>().SetTrigger("Create");
                                energyBall.GetComponent<AudioSource>().loop = true;
                                energyBall.GetComponent<AudioSource>().clip = darkEnergySound;
                                energyBall.GetComponent<AudioSource>().Play();
                                GetComponent<NPCScript>().darkEnergy = false;
                            }
                            if (GetComponent<NPCScript>().canFog && canvas.GetComponent<UIScript>().fogLevel <= 0.0f)
                            {
                                canvas.GetComponent<UIScript>().fogLevel = 2.0f;
                                NPCOther.GetComponent<NPCScript>().fogged = true;
                                NPCOther.GetComponent<NPCScript>().foggedTime = Time.fixedTime;
                                GetComponent<NPCScript>().canFog = false;
                            }
                        }
                    }
                    //si el numero esta entre 80 y 90 el NPC saltará a donde no haya plataforma
                    else if (r > goodJump && r <= badJump)
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().Play();
                        if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 0] == 0) goLeft = true;
                        else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 1] == 0) goCenter = true;
                        else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 2] == 0) goRight = true;
                    }
                    //Si ninguna de las anteriores se cumple saltara a una plataforma con trampa
                    else
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().Play();
                        if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 0] == 2) goLeft = true;
                        else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 1] == 2) goCenter = true;
                        else if (NPCLeader.GetComponent<NPCScript>().plat[playingLevel, numPlat + doubleJump, 2] == 2) goRight = true;
                    }
                }
                //Si el personaje esta afectado por la niebla saltara de forma totalmente aleatoria
                else
                {
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    if (r <= 33) goLeft = true;
                    else if (r <= 66) goCenter = true;
                    else goRight = true;
                }
                //Straight Jump
                if (goCenter && center)
                {
                    anim.SetTrigger("JumpStraight");
                    anim.SetBool("Landed", false);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpStrength));
                    jumping = true;
                    goCenter = false;
                    if (doubleJump == 1) remainingJumps -= 1;
                }
                else if (goLeft && left)
                {
                    anim.SetTrigger("JumpStraight");
                    anim.SetBool("Landed", false);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpStrength));
                    jumping = true;
                    goLeft = false;
                    if (doubleJump == 1) remainingJumps -= 1;
                }
                else if (goRight && right)
                {
                    anim.SetTrigger("JumpStraight");
                    anim.SetBool("Landed", false);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpStrength));
                    jumping = true;
                    goRight = false;
                    if (doubleJump == 1) remainingJumps -= 1;
                }
                //Level 1 Left
                else if (goCenter && right)
                {
                    anim.SetTrigger("JumpLeft");
                    anim.SetBool("Landed", false);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-300.0f, jumpStrength));
                    jumpingCenterRight = true;
                    jumping = true;
                    goCenter = false;
                    if (doubleJump == 1) remainingJumps -= 1;
                }
                else if (goLeft && center)
                {
                    anim.SetTrigger("JumpLeft");
                    anim.SetBool("Landed", false);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-300.0f, jumpStrength));
                    jumpingLeft = true;
                    jumping = true;
                    goLeft = false;
                    if (doubleJump == 1) remainingJumps -= 1;
                }
                //Level 1 Right
                else if (goCenter && left)
                {
                    anim.SetTrigger("JumpRight");
                    anim.SetBool("Landed", false);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(300.0f, jumpStrength));
                    jumpingCenterLeft = true;
                    jumping = true;
                    goCenter = false;
                    if (doubleJump == 1) remainingJumps -= 1;
                }
                else if (goRight && center)
                {
                    anim.SetTrigger("JumpRight");
                    anim.SetBool("Landed", false);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(300.0f, jumpStrength));
                    jumpingRight = true;
                    jumping = true;
                    goRight = false;
                    if (doubleJump == 1) remainingJumps -= 1;
                }
                //Level 2 Left
                else if (goLeft && right)
                {
                    anim.SetTrigger("JumpLeft");
                    anim.SetBool("Landed", false);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-600.0f, jumpStrength));
                    jumpingLeft = true;
                    jumping = true;
                    goLeft = false;
                    if (doubleJump == 1) remainingJumps -= 1;
                }
                //Level 2 Right
                else if (goRight && left)
                {
                    anim.SetTrigger("JumpRight");
                    anim.SetBool("Landed", false);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(600.0f, jumpStrength));
                    jumpingRight = true;
                    jumping = true;
                    goRight = false;
                    if (doubleJump == 1) remainingJumps -= 1;
                }
            }
        }
    }
}