using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Validation : MonoBehaviour
{
    public GameObject[] objetos;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    public GameObject obj7;
    public GameObject obj8;
    public GameObject obj9;
    int cont;
    public GameObject button;
    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        if (obj1.activeInHierarchy == false && obj2.activeInHierarchy == false && obj3.activeInHierarchy == false && obj4.activeInHierarchy == false && obj5.activeInHierarchy == false && obj6.activeInHierarchy == false && obj7.activeInHierarchy == false && obj8.activeInHierarchy == false && obj9.activeInHierarchy == false)
        {
            button.SetActive(true);
            Debug.Log("si");
        }
    }
    public void activar()
    {
        for (int i = 0; i < objetos.LongLength; i++)
        {
            
            if ((objetos[i].gameObject.name == "SlotA1" || objetos[i].gameObject.name == "SlotA2" || objetos[i].gameObject.name == "SlotA3") && objetos[i].activeInHierarchy == false)
            {
                
                cont = cont + 1;
                Debug.Log("gano: " + cont);
            }
            if (cont == 3)
            {
                Debug.Log("gano: " + cont);
            }
        }
    }
}


