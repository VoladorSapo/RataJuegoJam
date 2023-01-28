using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class text_controller : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public bool escribiendo;
    public bool terminado;
    string[] intro;
    string[] outro;
    public bool finished;
    string[] currenstring;
    public Animator fondo;
    // Start is called before the first frame update
    void Start()
    {
        TextDisplay.text = "hello";
<<<<<<< HEAD
        intro = new string[9] { "Mas alla de los valles y de los montes, las leyendas hablan de una ciudad que vio a su gente consumida por el mal de la peste.", "Una nube de muerte que se cernio sobre hombres y mujeres por igual.", "Cuentan que, ingenuo, el rey ordeno a su sequito expulsar de la ciudad a todas las ratas.", "Armados a la barbara inmundicia que emanaba de aquellas bestias, completaron con honor tan ardua tarea.", "Las puertas del castillo se cerraron, y el rey regocijo sentado en su trono, pues penso que se así evitaba la muerte negra.", "Pero las plagas nunca mueren… no del todo.", "¡Alzate, oh, animal de los rincones! Aquel que se llama a sí mismo rey de los hombres espera sentado a la muerte. ", "Muestrale, oh portadora de la enfermedad, lo cerca que están de su cuello los frios dedos de la peste, y entra en su alcoba para darle muerte.", "Clama tu venganza. Encuentra el camino." };
        outro = new string[3] { "Las campanas de la iglesia resuenan en todo el pueblo.", "Los campesinos salen de sus casas y las tabernas y tiendas adelantan el cierre. El rey ha muerto.", "Su cadaver, como tantos otros, hallara descanso en las fosas que ya rebosan a las afueras de la ciudad, donde, con suerte, sera pasto de las ratas." };
        if (!FinishClass.finished)
        {
            _audio.clip = start;
            _audio.Play();
            fondo.SetInteger("Fondo",1);
=======
        intro = new string[2] { "Era se una vez un reino una vez prospero azotado por la peste, es rey karjon son mando a sus temibles medicos de la peste asesinar a todas las ratas de su pais", "For the community" };
        if (finished)
        {
            fondo.SetInteger("Fondo",3);
>>>>>>> parent of 2cffbe2 (Merge branch 'main' of https://github.com/VoladorSapo/RataJuegoJam)
            currenstring = intro;
        }
        else
        {
<<<<<<< HEAD
            _audio.clip = end;
            _audio.Play();
            fondo.SetInteger("Fondo", 3);
            currenstring = outro;
=======
            fondo.SetInteger("Fondo", 1);
            currenstring = intro;
>>>>>>> parent of 2cffbe2 (Merge branch 'main' of https://github.com/VoladorSapo/RataJuegoJam)
        }
        StartCoroutine(Escribir(0));
    }
    public IEnumerator Escribir(int num)
    {
            print("hey");
            string txt = currenstring[num];
            TextDisplay.enabled = true;
            TextDisplay.text = txt;
            TextDisplay.color = Color.white;
            escribiendo = true;
            terminado = false;
            for (int i = 0; i < txt.ToCharArray().Length; i++)
            {
            print("uy");
                if (!terminado)
                {
                print("chas");
                    TextDisplay.maxVisibleCharacters = i + 1;
                    if (TextDisplay.maxVisibleCharacters >= txt.ToCharArray().Length)
                    {
                        terminado = true;
                    }
<<<<<<< HEAD
                    yield return new WaitForSecondsRealtime(0.06f);
=======
                    yield return new WaitForSecondsRealtime(0.1f);
>>>>>>> parent of 2cffbe2 (Merge branch 'main' of https://github.com/VoladorSapo/RataJuegoJam)
                }
                else
                {
                    TextDisplay.maxVisibleCharacters = txt.ToCharArray().Length;
                    terminado = true;
                    break;
                }
            }
            terminado = true;
        if (num != currenstring.Length - 1)
        {
            yield return new WaitForSecondsRealtime(1f);
<<<<<<< HEAD
            if (!FinishClass.finished && num == 5)
            {
                yield return new WaitForSecondsRealtime(1.5f);
=======
            StartCoroutine(Escribir(num + 1));
            if(!finished && num >= 0)
            {
>>>>>>> parent of 2cffbe2 (Merge branch 'main' of https://github.com/VoladorSapo/RataJuegoJam)
                fondo.SetInteger("Fondo", 2);
            }
        }
        else
        {
<<<<<<< HEAD

            yield return new WaitForSecondsRealtime(1.5f);
            if (FinishClass.finished)
=======
            if (finished)
>>>>>>> parent of 2cffbe2 (Merge branch 'main' of https://github.com/VoladorSapo/RataJuegoJam)
            {
                yield return new WaitForSecondsRealtime(3f);
                print("adios");
                SceneManager.LoadScene(0);
            }
            else
            {
                yield return new WaitForSecondsRealtime(3f);
                print("adios");
                SceneManager.LoadScene(1);
            }
        }

    }
}
