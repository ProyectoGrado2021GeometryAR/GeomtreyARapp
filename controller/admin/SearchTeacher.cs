/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteneciente al paquete controlador la cual es manejada por el Administrador
 * y visualizar de manera breve en dos paneles los docente registrados con anterioridad en la base de datos
 * tambien perminte capturar el numero de documento de un docente para buscar sus datos de manera especifica
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//necesario cuando se utilizan elementos de la interfaz de usuario en scripts

public class SearchTeacher : MonoBehaviour
{

    public Text numbDocumentTeacherOne;
    public Text namesTeacherOne;
    public Text lastNamesTeacherOne;
    public Text emailTeacherOne;
    public Text numbDocumentTeacherTwo;
    public Text namesTeacherTwo;
    public Text lastNamesTeacherTwo;
    public Text emailTeacherTwo;
    public InputField getNumbDocumentTeacher;
    public GameObject panelSecondTeacher;

    string documentNumberCaptured;
    int documentNumberCapturedToInt;
    string documentNumberPreviewOne;
    int documentNumberPreviewOneToInt;
    string documentNumberPreviewTwo;
    int documentNumberPreviewTwoToInt;


    /*el siguiente metodo carga en el primer panel los datos de un docente registrado en la base de datos 
     * para su previzualizacion a su vez rectifica que exista mas de un docente registrado, si encuentra mas de uno
     * activa el segundo panel para la previzualicion de los docente y lo carga con los datos obtenidos de la base de datos y 
     * que se encuentran almacenados el los playerPrefs utilizados para la trasferencia de datos entre escenas y sesiones
     */
    void Start()
    {
        StartCoroutine(Main.Instance.admin.PreviewRegisteredTeachers());
        numbDocumentTeacherOne.text = PlayerPrefs.GetString("numberDocumentOne", "");
        namesTeacherOne.text = PlayerPrefs.GetString("namesOne", "");
        lastNamesTeacherOne.text = PlayerPrefs.GetString("lastNamesOne", "");
        emailTeacherOne.text = PlayerPrefs.GetString("emailOne", "");

        string a = PlayerPrefs.GetString("numberDocumentTwo", "");
        if (a != "")
        {
            panelSecondTeacher.gameObject.SetActive(true);
            numbDocumentTeacherTwo.text = PlayerPrefs.GetString("numberDocumentTwo", "");
            namesTeacherTwo.text = PlayerPrefs.GetString("namesTwo", "");
            lastNamesTeacherTwo.text = PlayerPrefs.GetString("lastNamesTwo", "");
            emailTeacherTwo.text = PlayerPrefs.GetString("emailTwo", "");
        }
    }
    /*metodo utilizado para buscar un docente por el numero de identificacion
     * hace uso de corutinas en este caso  StartCoroutine
     * esta nos permite hacer uso de los metodos alojados en la clase Admin en el modelo
     * se utiliza para procesos asicronos es decir que sucen en momentos de tiempo diferentes
      */
    public void CapturedNumberInputField()
    {
        documentNumberCaptured = getNumbDocumentTeacher.text;
        documentNumberCapturedToInt = int.Parse(documentNumberCaptured);
        StartCoroutine(Main.Instance.admin.TearcherAndDegree(documentNumberCapturedToInt));
    }
    /*metodo utilizado para buscar un docente mediante el primer panel de previsualizacion
    * hace uso de corutinas en este caso  StartCoroutine
    * esta nos permite hacer uso de los metodos alojados en la clase Admin en el modelo
    * se utiliza para procesos asicronos es decir que sucen en momentos de tiempo diferentes
     */
    public void PreviewFirtsTeacher()
    {
        documentNumberPreviewOne = numbDocumentTeacherOne.text;
        documentNumberPreviewOneToInt = int.Parse(documentNumberPreviewOne);
        StartCoroutine(Main.Instance.admin.TearcherAndDegree(documentNumberPreviewOneToInt));
    }
    /*metodo utilizado para buscar un docente mediante el segundo panel de previsualizacion
   * hace uso de corutinas en este caso  StartCoroutine
   * esta nos permite hacer uso de los metodos alojados en la clase Admin en el modelo
   * se utiliza para procesos asicronos es decir que sucen en momentos de tiempo diferentes
    */
    public void PreviewSecondTeacher()
    {
        documentNumberPreviewTwo = numbDocumentTeacherTwo.text;
        documentNumberPreviewTwoToInt = int.Parse(documentNumberPreviewTwo);
        StartCoroutine(Main.Instance.admin.TearcherAndDegree(documentNumberPreviewTwoToInt));
    }

}
