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
    // Start is called before the first frame update
    void Start()
    {
        TextDisplay.text = "hello";
        intro = new string[2] { "Why Mundo do this?", "For the community" };
        if (finished)
        {
            currenstring = intro;
        }
        else
        {
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
        if (num != currenstring.Length)
        {
            yield return new WaitForSecondsRealtime(1f);
            StartCoroutine(Escribir(num + 1));
        }
        else
        {
            if (finished)
            {
                print("adios");
                //SceneManager.LoadScene(2);
            }
            else
            {
                print("adios");
                //SceneManager.LoadScene(0);
            }
        }

    }
}
