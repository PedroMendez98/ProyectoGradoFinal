using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler1 : MonoBehaviour
{
    public static GameObject objBeingDraged;

    private Vector3 startPosition;
    private Transform startParent;
    private CanvasGroup canvasGroup;
    private Transform itemDraggerParent;
    public int n = 0;
    public static string cont;
    public GameObject[] objetos;
    public string sCases;
    public static int val;

    /// <summary>
    /// It's a function that is called when the game starts, and it sets all the objects in the array to
    /// inactive.
    /// </summary>
    private void Start()
    {
        cont = "";
        for (int i = 0; i < objetos.LongLength; i++)
        {
            objetos[i].SetActive(false);       
        }
    }

    private void Update()
    {
        sumarN(cont);
    }

    /// <summary>
    /// It's a function that takes a string as a parameter and depending on the value of the string, it
    /// will activate a different image
    /// </summary>
    /// <param name="name">is the name of the image that is being clicked</param>
    public void sumarN(string name)
    {
        switch (name)
        {
            case "inicioI1":
                activarImages("inicioI9");
                break;
            case "valorI4":
                activarImages("valorI41");
                break;
            case "valI2":
                if (val == 1)
                {
                    activarImages("valI21");
                }
                else if (val == 2)
                {
                    activarImages("valI22");
                }
                break;
            case "valI3":
                if (val == 1)
                {
                    activarImages("valI32");
                }
                else if (val == 2)
                {
                    activarImages("valI31");
                }
                break;
            case "impreI7":
                if (val == 1)
                {
                    activarImages("impreI71");
                }
                else if (val == 2)
                {
                    activarImages("impreI72");
                }
                break;
            case "impreI6":
                if (val == 1)
                {
                    activarImages("impreI61");
                }
                else if (val == 2)
                {
                    activarImages("impreI62");
                }
                break;
            case "impreI8":
                    activarImages("impreI82");
                break;
            case "finI5":
                activarImages("finI51");
                break;
            default:
                activarImages("");
                break;
        }
    }

    /// <summary>
    /// It takes a string as a parameter and then loops through an array of game objects and activates
    /// the one that matches the string
    /// </summary>
    /// <param name="name">The name of the object you want to activate.</param>
    void activarImages(string name)
    {
        for (int i = 0; i < objetos.LongLength; i++)
        {
            if (objetos[i].gameObject.name == name)
            {
                objetos[i].SetActive(true);
            }
        }
    }
    /// <summary>
    /// It's a function that activates images based on the value of the parameter
    /// </summary>
    /// <param name="vali">is the value of the option selected</param>
    void optionRes1(int vali)
    {
        switch (vali)
        {
            case 1:
                activarImages("impreI81");
                break;
            case 2:
                activarImages("impreI72");
                break;
            default:
                break;
        }
    }
}
