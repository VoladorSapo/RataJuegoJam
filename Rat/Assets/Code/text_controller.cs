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
        intro = new string[2] { "Era se una vez un reino una vez prospero azotado por la peste, es rey karjon son mando a sus temibles medicos de la peste asesinar a todas las ratas de su pais", "For the community" };
        if (finished)
        {
            fondo.SetInteger("Fondo",3);
            currenstring = intro;
        }
        else
        {
            fondo.SetInteger("Fondo", 1);
            currenstring = intro;
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
                    yield return new WaitForSecondsRealtime(0.1f);
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
            StartCoroutine(Escribir(num + 1));
            if(!finished && num >= 0)
            {
                fondo.SetInteger("Fondo", 2);
            }
        }
        else
        {
            if (finished)
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
