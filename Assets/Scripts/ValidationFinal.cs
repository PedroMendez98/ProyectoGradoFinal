using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ValidationFinal : MonoBehaviour
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
    public static int cont = 0;
    public GameObject button;
    public GameObject prefabGame2D;
    public Collider colliderTeacherThree;
    public GameObject imagenFin;
    private void Start()
    {
        cont = 0;
    }
    private void Update()
    {
        //if (obj1.activeInHierarchy == false && obj2.activeInHierarchy == false && obj3.activeInHierarchy == false && obj4.activeInHierarchy == false && obj5.activeInHierarchy == false && obj6.activeInHierarchy == false && obj7.activeInHierarchy == false && obj8.activeInHierarchy == false && obj9.activeInHierarchy == false)
        //{
        //    prefabGame2D.SetActive(false);
        //    Time.timeScale = 1f;
        //}                   
    
        validarTodos(cont);
    }
    void validarTodos(int num)
    {
        if (num == objetos.LongLength)
        {
            //scriptNotes.n = 1;
            //colliderTeacherThree.enabled = false;
            //prefabGame2D.SetActive(false);
            //Time.timeScale = 1f;
            //imagenFin.SetActive(true);
            SceneManager.LoadScene("SampleScene");
        }
    }
}

