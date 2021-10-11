/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑIO
 * Esta es una clase perteneciente al paquete controlador la cual es manejada por el Docente
 * donde se muestra los datos del estudiante id, nombres apellidos y calificaciones por tematica
 * tambien permite captura la activacion del boton para descargar el archivo excel de las notas del estudiante
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualificationStudent : MonoBehaviour
{
    public Text idStudent;
    public Text nameStudent;
    public Text lastNameStudent;
    public Text themeStudent1;
    public Text qualificationStudent1;
    public Text themeStudent2;
    public Text qualificationStudent2;
    public Text themeStudent3;
    public Text qualificationStudent3;
    int stop;
    string idStudentData;
    string namesStudent;
    string lastNamesStudent;
    string themeOne;
    string qualificationOne;
    string themeTwo;
    string qualificationTwo;
    string themeThree;
    string qualificationThree;

    void Start()
    {
        Debug.Log("hola");
    }

    void Update()
    {
        stop = PlayerPrefs.GetInt("stopStudent", 0);
        while (stop != 0)
        {
            PlayerPrefs.DeleteKey("stopStudent");
            idStudent.text = "";
            nameStudent.text = "";
            lastNameStudent.text = "";
            themeStudent1.text = "";
            qualificationStudent1.text = "";
            themeStudent2.text = "";
            qualificationStudent2.text = "";
            themeStudent3.text = "";
            qualificationStudent3.text = "";
            Debug.Log("carga de datos");
            idStudent.text = PlayerPrefs.GetString("documentNumberStundetPNT", "");
            nameStudent.text = PlayerPrefs.GetString("namesStundetPNT", "");
            lastNameStudent.text = PlayerPrefs.GetString("lastNamesStundetPNT", "");
            themeStudent1.text = PlayerPrefs.GetString("nameTematicsStundetThemeOne", "");
            qualificationStudent1.text = PlayerPrefs.GetString("qualificationStudentThemeOne", "");
            themeStudent2.text = PlayerPrefs.GetString("nameTematicsStundetThemeTwo", "");
            qualificationStudent2.text = PlayerPrefs.GetString("qualificationStudentThemeTwo", "");
            themeStudent3.text = PlayerPrefs.GetString("nameTematicsStundetThemeThree", "");
            qualificationStudent3.text = PlayerPrefs.GetString("qualificationStudentThemeThree", "");
            stop = 0;
        }
    }
    public void FileDownload()
    {
        idStudentData = idStudent.text;
        namesStudent = nameStudent.text;
        lastNamesStudent = lastNameStudent.text;
        themeOne = themeStudent1.text;
        qualificationOne = qualificationStudent1.text;
        themeTwo = themeStudent2.text;
        qualificationTwo = qualificationStudent2.text;
        themeThree = themeStudent3.text;
        qualificationThree = qualificationStudent3.text;
        Main.Instance.teacher.csv(idStudentData, namesStudent, lastNamesStudent, themeOne, qualificationOne, themeTwo, qualificationTwo, themeThree, qualificationThree);
    }
}


