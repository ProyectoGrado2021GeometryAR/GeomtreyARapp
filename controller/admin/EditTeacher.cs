/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteeciente al paquete controlador la cual es manejada por el Administrador
 * y permite visualizar y editar los datos del docente
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//necesario cuando se utilizan elementos de la interfaz de usuario en scripts 

public class EditTeacher : MonoBehaviour
{
    GameObject gameObjectMistakes;
    public Text idEditTeacher;
    public InputField namesEditTeacher;
    public InputField lastNamesEditTeacher;
    public Text emailEditTeacher;
    public Toggle degreeEditTeacher4;
    public Toggle degreeEditTeacher5;
    int conditionalOne;
    int conditionalTwo;
    int conditionalThree;
    string tgFourth;
    string tgFifth;
    string tgIdDegree;
    string cleanInputFields = "  ";
    string id;
    string names;
    string lastNames;
    string email;
    int[] intArray = new int[2];
    bool degreeCuarto;
    bool degreeQuinto;
    int stop;

    void Start()
    {
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaEmptyFields");



    }
    /* acontinuacion hacemos uso del metodo update el cual es creado por defecto en C# al utilizar Unity
     * obtenemos los datos mediante la clase PlayerPrefs
     * la cual nos permite la tranferencia de datos entre escenas y sesiones 
     */
    private void Update()
    {
        stop = PlayerPrefs.GetInt("stop", 0);
        while (stop != 0)
        {
            conditionalOne = PlayerPrefs.GetInt("conditional1", 0);
            conditionalTwo = PlayerPrefs.GetInt("conditional2", 0);
            conditionalThree = PlayerPrefs.GetInt("conditional3", 0);
            ///limpiamos el formulario
            idEditTeacher.text = cleanInputFields;
            namesEditTeacher.text = cleanInputFields;
            lastNamesEditTeacher.text = cleanInputFields;
            emailEditTeacher.text = cleanInputFields;
            degreeEditTeacher4.isOn = false;
            degreeEditTeacher5.isOn = false;
            PlayerPrefs.DeleteKey("stop");

            if (conditionalOne == 1)
            {


                idEditTeacher.text = PlayerPrefs.GetString("numberDocumentTnD", "");
                namesEditTeacher.text = PlayerPrefs.GetString("namesTnD", "");
                lastNamesEditTeacher.text = PlayerPrefs.GetString("lastNamesTnD", "");
                emailEditTeacher.text = PlayerPrefs.GetString("emailTnD", "");
                degreeEditTeacher4.isOn = false;
                degreeEditTeacher5.isOn = false;
                PlayerPrefs.DeleteKey("conditional1");

            }
            else if (conditionalTwo == 2)
            {
                PlayerPrefs.DeleteKey("conditional2");

                tgIdDegree = PlayerPrefs.GetString("idDegreeOneTwD", "");

                idEditTeacher.text = PlayerPrefs.GetString("numberDocumentTwD", "");
                namesEditTeacher.text = PlayerPrefs.GetString("namesTwD", "");
                lastNamesEditTeacher.text = PlayerPrefs.GetString("lastNamesTwD", "");
                emailEditTeacher.text = PlayerPrefs.GetString("emailTwD", "");
                if (tgIdDegree == "4")
                {
                    degreeEditTeacher4.isOn = true;
                }
                else
                {
                    degreeEditTeacher5.isOn = true;
                }

            }
            else if (conditionalThree == 3)
            {

                PlayerPrefs.DeleteKey("conditional3");

                tgFourth = PlayerPrefs.GetString("idDegreeTwoTwD", "");
                tgFifth = PlayerPrefs.GetString("idDegreeTwo2TwD", "");
                idEditTeacher.text = PlayerPrefs.GetString("numberDocumentTwoTwD", "");
                namesEditTeacher.text = PlayerPrefs.GetString("namesTwoTwD", "");
                lastNamesEditTeacher.text = PlayerPrefs.GetString("lastNamesTwoTwD", "");
                emailEditTeacher.text = PlayerPrefs.GetString("emailTwoTwD", "");
                if (tgFourth == "4" && tgFifth == "5")
                {
                    degreeEditTeacher4.isOn = true;
                    degreeEditTeacher5.isOn = true;
                }



            }
            stop = 0;
        }

    }

    /* acontinuacion hacemosuso del metodo ChangueTeacherData()
     * donde capturamos los campos del formulario para editar al docente
     * hace uso de corutinas en este caso  StartCoroutine
     * esta nos permite hacer uso de los metodos alojados en la clase Admin en el modelo
     * se utiliza para procesos asicronos es decir que sucen en momentos de tiempo diferentes
      */
    public void ChangueTeacherData()
    {
        id = idEditTeacher.text;
        int idInt = int.Parse(id);
        int degree;
        names = namesEditTeacher.text;
        lastNames = lastNamesEditTeacher.text;
        email = emailEditTeacher.text;
        degreeCuarto = degreeEditTeacher4.isOn;
        degreeQuinto = degreeEditTeacher5.isOn;
        Debug.Log(id + names + lastNames + email + degreeCuarto + degreeQuinto);


        if (string.IsNullOrEmpty(names) || string.IsNullOrEmpty(lastNames) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(id))

        {
            gameObjectMistakes.gameObject.SetActive(true);
            Debug.Log("Todos los campos son obligatorios");
        }
        else
        {
            int idNumber = int.Parse(id);

            if (degreeCuarto == true && degreeQuinto == false)
            {
                degree = 4;
                StartCoroutine(Main.Instance.admin.EditTeacher(idInt, names, lastNames, email));
                StartCoroutine(Main.Instance.admin.UpdateDegree(idNumber, degree));
            }
            else if (degreeQuinto == true && degreeCuarto == false)
            {
                degree = 5;
                StartCoroutine(Main.Instance.admin.EditTeacher(idInt, names, lastNames, email));
                StartCoroutine(Main.Instance.admin.UpdateDegree(idNumber, degree));
            }
            else if (degreeCuarto == true && degreeQuinto == true)
            {

                intArray[0] = 4;
                intArray[1] = 5;
                StartCoroutine(Main.Instance.admin.EditTeacher(idInt, names, lastNames, email));
                for (int i = 0; i < intArray.Length; i++)
                {
                    Debug.Log("valores : " + intArray[i]);

                    StartCoroutine(Main.Instance.admin.UpdateDegree(idNumber, intArray[i]));
                }
            }
        }
    }
}
