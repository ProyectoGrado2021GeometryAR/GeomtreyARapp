/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteeciente al paquete controlador la cual es manejada por el Docente
 * en esta clase mostramos los datos del estudiante buscado median su numero de idetificación 
 * ademas capturamos lo campos para la modificacion del mismo
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStudent : MonoBehaviour
{
    GameObject gameObjectMistakes;
    GameObject gameObjectMistakesOneDegree;
    public InputField idStudent;
    public InputField nameStudent;
    public InputField lastNameStudent;
    public InputField emailStudent;
    public InputField passwordStuden;
    public Toggle degreeEditStudent4;
    public Toggle degreeEditStudent5;
    int stop;
    string id;
    string names;
    string lastNames;
    string email;
    string password;
    string degree;
    bool degreeCuarto;
    bool degreeQuinto;
    void Start()
    {
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaEmptyFields");
        gameObjectMistakesOneDegree = GameObject.Find("/Canvas/Message/PaOneDegree");
    }
    //cargamos los datos obtenidos de la base de datos del estudiante buscado
    void Update()
    {
        stop = PlayerPrefs.GetInt("stopDataStudent", 0);
        while (stop != 0)
        {
            PlayerPrefs.DeleteKey("stopDataStudent");
            idStudent.text = "";
            nameStudent.text = "";
            lastNameStudent.text = "";
            emailStudent.text = "";
            passwordStuden.text = "";
            degreeEditStudent4.isOn = false;
            degreeEditStudent5.isOn = false;
            string tgIdDegree;
            Debug.Log("carga de datos");
            tgIdDegree = PlayerPrefs.GetString("degreeStudentData", "");
            Debug.Log(tgIdDegree + "datos del togleeee");
            idStudent.text = PlayerPrefs.GetString("idStudentData", "");
            nameStudent.text = PlayerPrefs.GetString("namesStundetData", "");
            lastNameStudent.text = PlayerPrefs.GetString("lastNamesStundetData", "");
            emailStudent.text = PlayerPrefs.GetString("emailStudentData", "");
            passwordStuden.text = PlayerPrefs.GetString("passwordStudentData", "");

            if (tgIdDegree == "4")
            {
                degreeEditStudent4.isOn = true;
            }
            else
            {
                degreeEditStudent5.isOn = true;
            }
            stop = 0;
        }
    }
    //metodo para capturas los campos del formulario para editar al estudiante
    public void methodEditStudent()
    {
        id = idStudent.text;
        names = nameStudent.text;
        lastNames = lastNameStudent.text;
        email = emailStudent.text;
        password = passwordStuden.text;
        degreeCuarto = degreeEditStudent4.isOn;
        degreeQuinto = degreeEditStudent5.isOn;
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(names) || string.IsNullOrEmpty(lastNames) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))

        {
            gameObjectMistakes.gameObject.SetActive(true);
        }
        else
        {
            if (degreeCuarto == true && degreeQuinto == false)
            {
                degree = "4";
                StartCoroutine(Main.Instance.teacher.UpdateStudent(id, names, lastNames, email, password, degree));
            }
            else if (degreeQuinto == true && degreeCuarto == false)
            {
                degree = "5";
                StartCoroutine(Main.Instance.teacher.UpdateStudent(id, names, lastNames, email, password, degree));
            }
            else if (degreeQuinto == true && degreeCuarto == true)
            {
                gameObjectMistakesOneDegree.gameObject.SetActive(true);
            }
            else
            {
                gameObjectMistakes.gameObject.SetActive(true);
            }
        }
    }
}
