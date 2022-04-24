using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ValidationFinal : MonoBehaviour
{
    public GameObject[] objetos;
    public static int cont = 0;
    public GameObject button;
    public GameObject prefabGame2D;
    public Collider colliderTeacherThree;
    public GameObject imagenFin;
    public GameObject salir;
    private void Start()
    {
        cont = 0;
        salir.SetActive(false);
        imagenFin.SetActive(false);
        prefabGame2D.SetActive(true);
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
            salir.SetActive(true);
            imagenFin.SetActive(true);
            prefabGame2D.SetActive(false);
            cont = 0;
        }
    }
    public void buttonSalir()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
