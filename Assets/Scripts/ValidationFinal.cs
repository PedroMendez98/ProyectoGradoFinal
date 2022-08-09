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
        validarTodos(cont);
    }
    /// <summary>
    /// If the number of objects is equal to the number of objects in the array, then the exit button is
    /// activated, the image is activated, the prefab is deactivated, and the counter is set to 0
    /// </summary>
    /// <param name="num">is the number of objects that have been validated</param>
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
    /// <summary>
    /// This function loads the scene called "SampleScene" when the button is clicked
    /// </summary>
    public void buttonSalir()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
