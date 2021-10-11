/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase que pertenece al paquete controlador la cual es manejada por el Administrador
 * y permite capturar los campos del formulario  para el registro de los docentes
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//necesario cuando se utilizan elementos de la interfaz de usuario en scripts

public class CreateTeacher : MonoBehaviour
{
    GameObject gameObjectMistakes;

    string id;
    string names;
    string lastNames;
    string email;
    string password;
    int degree;
    int degreeOne;
    int degreeTwo;
    int[] intArray = new int[2];
    bool degreeCuarto;
    bool degreeQuinto;
    public Text idCreateTeacher;
    public Text namesCreateTeacher;
    public Text lastNamesCreateTeacher;
    public Text emailCreateTeacher;
    public InputField passwordCreateTeacher;
    public Toggle degreeCreateTeacher1;
    public Toggle degreeCreateTeacher2;

    void Start()
    {
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaEmptyFields");
    }
    /* en el siguiente metodo methodCreateTeacher()
     * hace uso de corutinas en este caso  StartCoroutine
     * esta nos permite hacer uso de los metodos alojados en la clase Admin en el modelo
     * se utiliza para procesos asicronos es decir que suceden en momentos de tiempo diferentes
      */
    public void methodCreateTeacher()
    {
        //en las siguientes 7 lineas de codigo igulamos nuestras variables al texto contenido dentro del formulario
        id = idCreateTeacher.text;
        names = namesCreateTeacher.text;
        lastNames = lastNamesCreateTeacher.text;
        email = emailCreateTeacher.text;
        password = passwordCreateTeacher.text;
        degreeCuarto = degreeCreateTeacher1.isOn;
        degreeQuinto = degreeCreateTeacher2.isOn;

        //condicionales para verificar que ninguno de los campos del formulario este vacio
        if (string.IsNullOrEmpty(names) || string.IsNullOrEmpty(lastNames) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(id))

        {

            gameObjectMistakes.gameObject.SetActive(true);
            Debug.Log("Todos los campos son obligatorios");

        }
        else
        {
            int idNumber = int.Parse(id);
            //los siguientes condicionales validan la seleccion de los curso en los cuales dictara el docente
            if (degreeCuarto == true && degreeQuinto == false)
            {
                degree = 4;
                StartCoroutine(Main.Instance.admin.CreateTeacher(idNumber, names, lastNames, email, password, degree));
                StartCoroutine(Main.Instance.admin.UpdateDegree(idNumber, degree));
            }
            else if (degreeQuinto == true && degreeCuarto == false)
            {
                degree = 5;
                StartCoroutine(Main.Instance.admin.CreateTeacher(idNumber, names, lastNames, email, password, degree));
                StartCoroutine(Main.Instance.admin.UpdateDegree(idNumber, degree));
            }
            else if (degreeCuarto == true && degreeQuinto == true)
            {
                degreeOne = 4;
                degreeTwo = 5;
                StartCoroutine(Main.Instance.admin.CreateTeacherTwoDegree(idNumber, names, lastNames, email, password, degreeOne, degreeTwo));
            }
        }
    }
}
