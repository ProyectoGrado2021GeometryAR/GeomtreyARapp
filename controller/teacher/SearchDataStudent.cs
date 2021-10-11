/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑIO
 * Esta es una clase perteneciente al paquete controlador la cual es manejada por el Docente
 * y contiene los metodos para buscar la inforacion del estudiante
 * y el ethodo para buscar las calificaciones 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchDataStudent : MonoBehaviour
{
    GameObject gameObjectMistakes;
    public InputField getNumberDocumentStudent;
    string number;
    int numberDocument;

    void Start()
    {
        getNumberDocumentStudent.text = "";
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaEmptyFields");
    }
    //permite visualizar el panel de datos del estudiante y envia los parametros de bsuquesa al modelo
    public void viewDataStudent()
    {
        number = getNumberDocumentStudent.text;
        if (string.IsNullOrEmpty(number))
        {
            gameObjectMistakes.gameObject.SetActive(true);
        }
        else
        {
            numberDocument = int.Parse(number);
            Debug.Log(numberDocument + "metodo datos");
            StartCoroutine(Main.Instance.teacher.SearchDataStudentById(numberDocument));
            getNumberDocumentStudent.text = "";
        }
    }
    //permite visualizar el panel de calificaciones del estudiante y envia los parametros de bsuquesa al modelo
    public void viewDataQualificationteStudent()
    {
        number = getNumberDocumentStudent.text;
        if (string.IsNullOrEmpty(number))
        {
            gameObjectMistakes.gameObject.SetActive(true);
        }
        else
        {
            numberDocument = int.Parse(number);
            Debug.Log(numberDocument + "metodo calificaciones");
            StartCoroutine(Main.Instance.teacher.QualificationByDocumentStudent(numberDocument));
            getNumberDocumentStudent.text = "";
        }
    }
}
