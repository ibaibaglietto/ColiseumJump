using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translateTutorialScript : MonoBehaviour
{
    public Text tutorial1;
    public Text contiune1;
    public Text tutorial2;
    public Text contiune2;
    public Text tutorial3;
    public Text contiune3;
    public Text tutorial4;
    public Text contiune4;
    public Text tutorial5;
    public Text contiune5;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Language") == 0)
        {
            tutorial1.text = "Bienvenido al tutorial.\nPara empezar, elije a que lado de la pantalla quieres saltar tocando en ese lado: izquierda, centro o derecha.";
            contiune1.text = "Continuar";
            tutorial2.text = "Como podrás ver en la siguiente fila, no todas las plataformas a las que puedas saltar seran seguras. Si saltas a una plataforma con trampa no podras moverte por un breve periodo de tiempo.";
            contiune2.text = "Continuar";
            tutorial3.text = "Además de las trampas tambien podras encontrar filas con menos de 3 plataformas. si saltas a un lado sin plataforma caeras a la de abajo, asi que mira bien a donde saltas.";
            contiune3.text = "Continuar";
            tutorial4.text = "Por último hablemos de los power ups. Por ahora solo tienes desbloqueado el escudo, que te permitirá recibir daño sin tener que quedarte parado. Para ver el funcionamiento de los demás poderes entra en la pestaña tutorial del menú. Para continuar salta al escudo y luego a la trampa.";
            contiune4.text = "Continuar";
            tutorial5.text = "¡Ya sabes todo lo que tienes que saber para poder ser el mejor corredor del coliseo! intenta ganar esta carrera de calentamiento para ver si de verdad controlas todos los fundamentos.";
            contiune5.text = "Continuar";
        }
        else if (PlayerPrefs.GetInt("Language") == 1)
        {
            tutorial1.text = "Wellcome to the tutorial.\nTo start playing, select which side of the screen you want to jump to: left, center or right.";
            contiune1.text = "Continue";
            tutorial2.text = "As you can see on the next row, not all the platforms are safe to jump to. If you jump to a platform with a trap you'll get stunned for a little while.";
            contiune2.text = "Continue";
            tutorial3.text = "In addition to the traps, you can also find rows with less than three platforms. If you jump to a side without platform you'll fall to the one below, so look two times before jumping.";
            contiune3.text = "Continue";
            tutorial4.text = "Finally, let's talk about power ups. Now you only have access to the shield, that lends you receive damage without being stunned. To see how the other powers work go to the tutorial menu on the main menu. Jump to the shield and then to the trap to continue.";
            contiune4.text = "Continue";
            tutorial5.text = "Now you know all that you need to become the best runner of the coliseum! Try to win this warmup run to see if you really know all the basis.";
            contiune5.text = "Continue";
        }
        else if (PlayerPrefs.GetInt("Language") == 2)
        {
            tutorial1.text = "Ongietorria izan Coliseum Jumpeko tutorialera.\nHasteko, pantailako zer aldetara salto egitea nahi duzun erabaki: ezkerrera, erdira edo eskuinera.";
            contiune1.text = "Jarraitu";
            tutorial2.text = "Hurrengo filan ikusi ahal duzun bezala plataforma guztiak ez dira seguruak izango. Tranpadun plataforma batera salto egiten baduzu ezin izango zara mugitu denboratxo baten.";
            contiune2.text = "Jarraitu";
            tutorial3.text = "Tranpez gain 3 plataforma baino gutxiagoko filak aurki ditzakezu. Plataformarik gabeko alde batetara salto egiten baduzu behekora eroriko zara, ondo begira ezazu nora salto egiten duzun.";
            contiune3.text = "Jarraitu";
            tutorial4.text = "Azkenik, hitzegin dezagun boterei buruz. Oraingoz ezkutua bakarrik duzu erabilgarri, geldi utzi gabe golpe bat hartzen ahalbidetzen dizuna. Beste botereak nola funtzinatzen duten ikusteko joan tutorial menura menu nagusitik. Salto egin ezkutura eta gero tranpara jarraitzeko.";
            contiune4.text = "Jarraitu";
            tutorial5.text = "Orain badakizu Koliseoko korrikalari onena izateko jakin behar duzun guztia! Beroketa karrera hau irabazten sailatu benetan oinarri guztiak ondo dakizkizula ikusteko.";
            contiune5.text = "Jarraitu";
        }

    }


}
