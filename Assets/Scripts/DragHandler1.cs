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

    private void Start()
    {

    }

    private void Update()
    {
        sumarN(cont);
    }
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
                if (val == 1)
                {
                    activarImages("impreI81");
                }
                else if (val == 2)
                {
                    activarImages("impreI82");
                }
                break;
            case "finI5":
                activarImages("finI51");
                break;
            default:
                break;
        }

    }
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
