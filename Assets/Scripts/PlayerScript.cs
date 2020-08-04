using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Animator del jugador
    Animator anim;
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
    public int pos = 1;
    //Booleans para controlar el salto y saber hacia donde se esta saltando
    bool left, right, center, jumpingLeft, jumpingCenterRight, jumpingCenterLeft, jumpingRight;
    //Variable para saber en que fila se encuentra el personaje
    public int numPlat = 0;
    //Boolean para saber cual de los tres botones de salto se ha pulsado
    public bool btnl, btnc, btnr;
    //Boolean para saber si el jugador ha terminado el nivel
    public bool ended = false;
    //Variable del power up escudo
    public bool shielded;
    //Variable del power up de salto doble
    public bool doubleJump;
    //Botas que se activan al tener el salto doble
    public SpriteRenderer bootL;
    public SpriteRenderer bootR;
    //Numero restante de saltos dobles
    public int remainingJumps;
    //Variable del power up de trampa
    public bool canTrap;
    //Variable del power up de bola de energia simple
    public bool energySimple;
    //Variable del power up de bola de energia oscura
    public bool darkEnergy;
    //Variable del power up de activar la niebla
    public bool canFog;
    //Variable que dice si el personaje tiene un power up activo
    public bool powered = false;
    //El sprite renderer del power up del escudo
    public SpriteRenderer shield;



    //Al empezar en nivel inicializaremos las variables necesarias, entre ellas el animator y los power ups.
    void Start()
    {
        anim = GetComponent<Animator>();
        shielded = false;
        doubleJump = false;
        remainingJumps = 0;
        canTrap = false;
        energySimple = false;
        darkEnergy = false;
        canFog = false;
    }

    
    void FixedUpdate()
    {
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
        //Guardamos la columna en la que esta el jugador
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
        //Gestion del tiempo en la que el personaje ha estado atrapado atrapado
        if (trapped && ((Time.fixedTime - trappedTime) >= 2.0f))
        {
            trapped = false;
        }
        //Miramos en que fila esta el personaje
        if (y > -4.5 && y <= -1.23) numPlat = 0;
        else if (y > -1.23 && y <= 1.84) numPlat = 1;
        else if (y > 1.84 && y <= 4.91) numPlat = 2;
        else if (y > 4.91 && y <= 7.98) numPlat = 3;
        else if (y > 7.98 && y <= 11.05) numPlat = 4;
        else if (y > 11.05 && y <= 14.12) numPlat = 5;
        else if (y > 14.12 && y <= 17.19) numPlat = 6;
        else if (y > 17.19 && y <= 20.26) numPlat = 7;
        else if (y > 20.26 && y <= 23.33) numPlat = 8;
        else if (y > 23.33 && y <= 26.4) numPlat = 9;
        else if (y > 26.4 && y <= 29.47) numPlat = 10;
        else if (y > 29.47 && y <= 32.54) numPlat = 11;
        else if (y > 32.54 && y <= 35.61) numPlat = 12;
        else if (y > 35.61 && y <= 38.68) numPlat = 13;
        else if (y > 38.68 && y <= 41.75) numPlat = 14;
        else if (y > 41.75 && y <= 44.82) numPlat = 15;
        else if (y > 44.82 && y <= 47.89) numPlat = 16;
        else if (y > 47.89 && y <= 50.96) numPlat = 17;
        else if (y > 50.96 && y <= 54.03) numPlat = 18;
        else if (y > 54.03 && y <= 57.1) numPlat = 19;
        else if (y > 57.1 && y <= 60.17) numPlat = 20;
        else if (y > 60.17 && y <= 63.24) numPlat = 21;
        else if (y > 63.24 && y <= 66.31) numPlat = 22;
        else if (y > 66.31 && y <= 69.38) numPlat = 23;
        else if (y > 69.38 && y <= 72.45) numPlat = 24;
        else if (y > 72.45 && y <= 75.52) numPlat = 25;
        else if (y > 75.52 && y <= 78.59) numPlat = 26;
        else if (y > 78.59 && y <= 81.66) numPlat = 27;
        else if (y > 81.66 && y <= 84.73) numPlat = 28;
        else if (y > 84.73 && y <= 87.8) numPlat = 29;
        else if (y > 87.8 && y <= 90.87) numPlat = 30;
        else if (y > 90.87 && y <= 93.94) numPlat = 31;
        else if (y > 93.94 && y <= 97.01) numPlat = 32;
        else if (y > 97.01 && y <= 100.08) numPlat = 33;
        else if (y > 100.08 && y <= 103.15) numPlat = 34;
        else if (y > 103.15 && y <= 106.22) numPlat = 35;
        else if (y > 106.22 && y <= 109.29) numPlat = 36;
        else if (y > 109.29 && y <= 112.36) numPlat = 37;
        else if (y > 112.36 && y <= 115.43) numPlat = 38;
        else if (y > 115.43 && y <= 118.5) numPlat = 39;
        else if (y > 118.5 && y <= 121.57) numPlat = 40;
        else if (y > 121.57 && y <= 124.64) numPlat = 41;
        else if (y > 124.64 && y <= 127.71) numPlat = 42;
        else if (y > 127.71 && y <= 130.78) numPlat = 43;
        else if (y > 130.78 && y <= 133.85) numPlat = 44;
        else if (y > 133.85 && y <= 136.92) numPlat = 45;
        else if (y > 136.92 && y <= 139.99) numPlat = 46;
        else if (y > 139.99 && y <= 143.06) numPlat = 47;
        else if (y > 143.06 && y <= 146.13) numPlat = 48;
        else if (y > 146.13 && y <= 149.2) numPlat = 49;
        else if (y > 149.2 && y <= 152.27) numPlat = 50;
        else if (y > 152.27 && y <= 155.34) numPlat = 51;
        else if (y > 155.34 && y <= 158.41) numPlat = 52;
        else if (y > 158.41 && y <= 161.48) numPlat = 53;
        else if (y > 161.48 && y <= 164.55) numPlat = 54;
        else if (y > 164.55 && y <= 167.62) numPlat = 55;
        else numPlat = 56;
        //Miramos si el personaje esta en el suelo
        if (Physics2D.OverlapCircle(groundCheck.position, gRad, Platforms) && (GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0)))
        {
            ground = true;
        }else ground = false;
        //Gestion del escudo
        if (shielded) shield.enabled = true;
        else shield.enabled = false;


        anim.SetBool("Landed", ground);

     
        
    }

    private void Update()
    {
        //Gestion del doble salto
        if (remainingJumps == 0)
        {
            doubleJump = false;
            bootL.enabled = false;
            bootR.enabled = false;
        }
        //Miramos si el personaje tiene un power up activo
        powered = shielded || doubleJump || canTrap || energySimple || darkEnergy || canFog;
        //Asignamos la fuerza de salto dependiendo del power up de salto doble
        if (doubleJump) jumpStrength = 1400.0f;
        else jumpStrength = 1000.0f;
        //Miramos que el personaje no este atrapado, este en el suelo y no haya terminado el nivel
        if (ground && !trapped && !ended)
        {
            //Straight Jump
            if ((Input.GetKeyDown(KeyCode.DownArrow)|| btnc) && center)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                btnc = false;
                anim.SetTrigger("JumpStraight");
                anim.SetBool("Landed", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpStrength));
                if (doubleJump) remainingJumps -= 1;
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || btnl) && left)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                btnl = false;
                anim.SetTrigger("JumpStraight");
                anim.SetBool("Landed", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpStrength));
                if (doubleJump) remainingJumps -= 1;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || btnr) && right)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                btnr = false;
                anim.SetTrigger("JumpStraight");
                anim.SetBool("Landed", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpStrength));
                if (doubleJump) remainingJumps -= 1;
            }
            //Level 1 Left
            else if ((Input.GetKeyDown(KeyCode.DownArrow) || btnc) && right)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                btnc = false;
                anim.SetTrigger("JumpLeft");
                anim.SetBool("Landed", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-300.0f, jumpStrength));
                jumpingCenterRight = true;
                if (doubleJump) remainingJumps -= 1;
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || btnl) && center)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                btnl = false;
                anim.SetTrigger("JumpLeft");
                anim.SetBool("Landed", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-300.0f, jumpStrength));
                jumpingLeft = true;
                if (doubleJump) remainingJumps -= 1;
            }
            //Level 1 Right
            else if ((Input.GetKeyDown(KeyCode.DownArrow) || btnc) && left)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                btnc = false;
                anim.SetTrigger("JumpRight");
                anim.SetBool("Landed", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(300.0f, jumpStrength));
                jumpingCenterLeft = true;
                if (doubleJump) remainingJumps -= 1;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || btnr) && center)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                btnr = false;
                anim.SetTrigger("JumpRight");
                anim.SetBool("Landed", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(300.0f, jumpStrength));
                jumpingRight = true;
                if (doubleJump) remainingJumps -= 1;
            }
            //Level 2 Left
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || btnl) && right)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                btnl = false;
                anim.SetTrigger("JumpLeft");
                anim.SetBool("Landed", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-600.0f, jumpStrength));
                jumpingLeft = true;
                if (doubleJump) remainingJumps -= 1;
            }
            //Level 2 Right
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || btnr) && left)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().Play();
                btnr = false;
                anim.SetTrigger("JumpRight");
                anim.SetBool("Landed", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(600.0f, jumpStrength));
                jumpingRight = true;
                if (doubleJump) remainingJumps -= 1;
            }
        }
    }



}
