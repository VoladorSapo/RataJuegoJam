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
    public AudioSource _audio;
    public AudioClip start;
    public AudioClip end;
    // Start is called before the first frame update
    void Start()
    {
        TextDisplay.text = "hello";
        intro = new string[9] { "Mas alla de los valles y de las monta�as, las leyendas hablan de una ciudad que vio a su gente consumida por el mal de la peste", "Una nube de muerte que se cernio sobre hombres y mujeres por igual","Cuentan que, ingenuo, el rey orden� a su s�quito expulsar de la ciudad a todas las ratas.", "Armados frente a la ponzo�a y la inmundicia que emanaba de aquellas bestias, completaron con honor tan ardua tarea.", "Las puertas del castillo se cerraron y el rey regocij� sentado en su trono, pues pens� que se as� esquivar�a de la muerte negra.", "Pero las plagas nunca mueren� no del todo.", " ��lzate, oh, animal de los rincones! Aquel que se llama a s� mismo rey de los hombres espera sentado a la muerte.", "Mu�strale, oh portadora de la enfermedad, lo cerca que est�n de su cuello los fr�os dedos de la peste, y entra en su alcoba para darle muerte.", "Clama tu venganza.Encuentra el camino." };
        if (FinishClass.finished)
        {
            _audio.clip = end;
            _audio.Play();
            fondo.SetInteger("Fondo",3);
            currenstring = intro;
        }
        else
        {
            _audio.clip = start;
            _audio.Play();
            fondo.SetInteger("Fondo", 1);
            currenstring = outro;
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
                    yield return new WaitForSecondsRealtime(0.0000000005f);
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
            yield return new WaitForSecondsRealtime(0.00000000000006f);
            if (!FinishClass.finished && num >= 0)
            {
                yield return new WaitForSecondsRealtime(0.000000000000005f);
                fondo.SetInteger("Fondo", 2);
            }
            StartCoroutine(Escribir(num + 1));
        }
        else
        {
            if (FinishClass.finished)
            {
                print("adios");
                SceneManager.LoadScene(0);
            }
            else
            {
                print("adios");
                SceneManager.LoadScene(1);
            }
        }

    }
}
