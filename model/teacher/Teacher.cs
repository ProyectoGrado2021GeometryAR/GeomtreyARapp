/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVÑO
 * Esta es una clase perteneciente al paquete modelo la cual es manejada por el docente
 * y contiene como methodos principales 
 * login del docente, consultar las calificaciones del estudiante, editar estudiante y consultar estudiante
*/
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class Teacher : MonoBehaviour
{
    GameObject panelUserNotFound;
    GameObject dataStudentUpdate;
    GameObject downloadFile;
    public GameObject panelQualificationStudent;

    public GameObject panelDataStudent;
    void Start()
    {
        panelUserNotFound = GameObject.Find("/Canvas/Message/PaUserNotFound");
        dataStudentUpdate = GameObject.Find("/Canvas/Message/PaUpdateUser");
        downloadFile = GameObject.Find("/Canvas/Message/PaDownloadFileCSV");
    }
    /*metodo para el inicio de seion del docente
     *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
     * srive para componer peticiones HTTP y manejar respuestas HTTP
     */
    public IEnumerator LoginTeacher(string email, string password, GameObject activatePanelTeacher, GameObject inactivatePanel)
    {

        WWWForm form = new WWWForm();
        form.AddField("loginEmail", email);
        form.AddField("loginPassword", password);


        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/LoginTeacher.php", form))//esta en el server                                                                                                   

        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            if (www.downloadHandler.text == "4")
            {
                PlayerPrefs.DeleteKey("conditionalSearch");
                PlayerPrefs.SetInt("conditionalSearch", 4);
                Debug.Log("Solo cuarto");
                activatePanelTeacher.gameObject.SetActive(true);
                inactivatePanel.gameObject.SetActive(false);
            }
            else if (www.downloadHandler.text == "5")
            {
                PlayerPrefs.DeleteKey("conditionalSearch");
                PlayerPrefs.SetInt("conditionalSearch", 5);
                Debug.Log("Solo quinto");
                activatePanelTeacher.gameObject.SetActive(true);
                inactivatePanel.gameObject.SetActive(false);
            }
            else if (www.downloadHandler.text == "45")
            {
                PlayerPrefs.DeleteKey("conditionalSearch");
                PlayerPrefs.SetInt("conditionalSearch", 45);
                Debug.Log("los dos");
                activatePanelTeacher.gameObject.SetActive(true);
                inactivatePanel.gameObject.SetActive(false);
            }
            else
            {
                panelUserNotFound.gameObject.SetActive(true);
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    /*metodo para consultar las calificaciones del estudiante
     *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
     * srive para componer peticiones HTTP y manejar respuestas HTTP
     */
    public IEnumerator QualificationByDocumentStudent(int notesByDegree)
    {
        int degree;
        degree = PlayerPrefs.GetInt("conditionalSearch");
        Debug.Log("imprimir player prefs " + degree);
        WWWForm form = new WWWForm();
        form.AddField("notesByDegree", notesByDegree);
        form.AddField("degree", degree);
        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/StudentNotes.php", form))//esta en el server                                                                                                   
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string splitMessage = www.downloadHandler.text;
                if (splitMessage == "stop")
                {
                    Debug.Log("eroorr consulta");
                    panelUserNotFound.gameObject.SetActive(true);
                }
                else
                {
                    string[] qualificationDataStudent = splitMessage.Split('|');
                    for (int i = 0; i < qualificationDataStudent.Length; i++)
                    {
                        if (qualificationDataStudent[i] != "stop")
                        {
                            //ciclo de condicionales donde se almacenan las notas del estudiante para transferencia segun el numero de temas respondidos
                            if (qualificationDataStudent[5] == "stop")
                            {
                                Debug.Log("antes de 5");
                                OneTheme(qualificationDataStudent[0], qualificationDataStudent[1], qualificationDataStudent[2], qualificationDataStudent[3], qualificationDataStudent[4]);
                                break;
                            }
                            else if (qualificationDataStudent[10] == "stop")
                            {
                                Debug.Log("antes de 10");
                                TwoTheme(qualificationDataStudent[0], qualificationDataStudent[1], qualificationDataStudent[2], qualificationDataStudent[3], qualificationDataStudent[4], qualificationDataStudent[8], qualificationDataStudent[9]);
                                break;
                            }
                            else if (qualificationDataStudent[15] == "stop")
                            {
                                Debug.Log("antes de 15");
                                ThreeTheme(qualificationDataStudent[0], qualificationDataStudent[1], qualificationDataStudent[2], qualificationDataStudent[3], qualificationDataStudent[4], qualificationDataStudent[8], qualificationDataStudent[9], qualificationDataStudent[13], qualificationDataStudent[14]);
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

        }

    }
    //almacena las datos y notas del estudiante con solo un tema resuelto
    public void OneTheme(string idStudent, string namesStudent, string lastnamesStudent, string nameThemeOne, string qualificationOne)
    {
        PlayerPrefs.DeleteKey("documentNumberStundetPNT");
        PlayerPrefs.DeleteKey("namesStundetPNT");
        PlayerPrefs.DeleteKey("lastNamesStundetPNT");
        PlayerPrefs.DeleteKey("nameTematicsStundetThemeOne");
        PlayerPrefs.DeleteKey("qualificationStudentThemeOne");
        PlayerPrefs.DeleteKey("nameTematicsStundetThemeTwo");
        PlayerPrefs.DeleteKey("qualificationStudentThemeTwo");
        PlayerPrefs.DeleteKey("nameTematicsStundetThemeThree");
        PlayerPrefs.DeleteKey("qualificationStudentThemeThree");
        PlayerPrefs.SetString("documentNumberStundetPNT", idStudent);
        PlayerPrefs.SetString("namesStundetPNT", namesStudent);
        PlayerPrefs.SetString("lastNamesStundetPNT", lastnamesStudent);
        PlayerPrefs.SetString("nameTematicsStundetThemeOne", nameThemeOne);
        PlayerPrefs.SetString("qualificationStudentThemeOne", qualificationOne);
        PlayerPrefs.SetInt("stopStudent", 1);
        panelQualificationStudent.gameObject.SetActive(true);
    }
    //almacena las datos y notas del estudiante con dos temas resuelto
    public void TwoTheme(string idStudent, string namesStudent, string lastnamesStudent, string nameThemeOne, string qualificationOne, string nameThemeTwo, string qualificationTwo)
    {
        PlayerPrefs.DeleteKey("documentNumberStundetPNT");
        PlayerPrefs.DeleteKey("namesStundetPNT");
        PlayerPrefs.DeleteKey("lastNamesStundetPNT");
        PlayerPrefs.DeleteKey("nameTematicsStundetThemeOne");
        PlayerPrefs.DeleteKey("qualificationStudentThemeOne");
        PlayerPrefs.DeleteKey("nameTematicsStundetThemeTwo");
        PlayerPrefs.DeleteKey("qualificationStudentThemeTwo");
        PlayerPrefs.DeleteKey("nameTematicsStundetThemeThree");
        PlayerPrefs.DeleteKey("qualificationStudentThemeThree");
        PlayerPrefs.SetString("documentNumberStundetPNT", idStudent);
        PlayerPrefs.SetString("namesStundetPNT", namesStudent);
        PlayerPrefs.SetString("lastNamesStundetPNT", lastnamesStudent);
        PlayerPrefs.SetString("nameTematicsStundetThemeOne", nameThemeOne);
        PlayerPrefs.SetString("qualificationStudentThemeOne", qualificationOne);
        PlayerPrefs.SetString("nameTematicsStundetThemeTwo", nameThemeTwo);
        PlayerPrefs.SetString("qualificationStudentThemeTwo", qualificationTwo);
        PlayerPrefs.SetInt("stopStudent", 1);
        panelQualificationStudent.gameObject.SetActive(true);
    }
    //almacena las datos y notas del estudiante con tres temas resuelto
    public void ThreeTheme(string idStudent, string namesStudent, string lastnamesStudent, string nameThemeOne, string qualificationOne, string nameThemeTwo, string qualificationTwo, string nameThemeThree, string qualificationThree)
    {
        PlayerPrefs.DeleteKey("documentNumberStundetPNT");
        PlayerPrefs.DeleteKey("namesStundetPNT");
        PlayerPrefs.DeleteKey("lastNamesStundetPNT");
        PlayerPrefs.DeleteKey("nameTematicsStundetThemeOne");
        PlayerPrefs.DeleteKey("qualificationStudentThemeOne");
        PlayerPrefs.DeleteKey("nameTematicsStundetThemeTwo");
        PlayerPrefs.DeleteKey("qualificationStudentThemeTwo");
        PlayerPrefs.DeleteKey("nameTematicsStundetThemeThree");
        PlayerPrefs.DeleteKey("qualificationStudentThemeThree");
        PlayerPrefs.SetString("documentNumberStundetPNT", idStudent);
        PlayerPrefs.SetString("namesStundetPNT", namesStudent);
        PlayerPrefs.SetString("lastNamesStundetPNT", lastnamesStudent);
        PlayerPrefs.SetString("nameTematicsStundetThemeOne", nameThemeOne);
        PlayerPrefs.SetString("qualificationStudentThemeOne", qualificationOne);
        PlayerPrefs.SetString("nameTematicsStundetThemeTwo", nameThemeTwo);
        PlayerPrefs.SetString("qualificationStudentThemeTwo", qualificationTwo);
        PlayerPrefs.SetString("nameTematicsStundetThemeThree", nameThemeThree);
        PlayerPrefs.SetString("qualificationStudentThemeThree", qualificationThree);
        PlayerPrefs.SetInt("stopStudent", 1);
        panelQualificationStudent.gameObject.SetActive(true);
    }
    /*metodo para consultar los datos del estudiante por numero de identificacion
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator SearchDataStudentById(int idStudent)
    {
        int degree;
        degree = PlayerPrefs.GetInt("conditionalSearch");
        WWWForm form = new WWWForm();
        form.AddField("searchStudentById", idStudent);
        form.AddField("degree", degree);
        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/SearchStudent.php", form))//esta en el server                                                                                                   

        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string splitMessage = www.downloadHandler.text;
                if (splitMessage == "stop")
                {
                    Debug.Log("eroorr consulta");
                    panelUserNotFound.gameObject.SetActive(true);
                }
                else
                {
                    string[] dataStudent = splitMessage.Split('|');
                    if (dataStudent[0] != "stop")
                    {
                        setDataStudent(dataStudent[0], dataStudent[1], dataStudent[2], dataStudent[3], dataStudent[4], dataStudent[5], dataStudent[6]);
                    }
                }
            }
        }
    }
    //almacenamos los datos del estudiante para la transferencia entre esenas
    public void setDataStudent(string idStudent, string namesStudent, string lastnamesStudent, string emailStudent, string passwordStudent, string degreeStudent, string statusStudent)
    {
        PlayerPrefs.DeleteKey("idStudentData");
        PlayerPrefs.DeleteKey("namesStundetData");
        PlayerPrefs.DeleteKey("lastNamesStundetData");
        PlayerPrefs.DeleteKey("emailStudentData");
        PlayerPrefs.DeleteKey("passwordStudentData");
        PlayerPrefs.DeleteKey("degreeStudentData");
        Debug.Log(idStudent + namesStudent + lastnamesStudent + emailStudent + passwordStudent + degreeStudent + statusStudent);
        PlayerPrefs.SetString("idStudentData", idStudent);
        PlayerPrefs.SetString("namesStundetData", namesStudent);
        PlayerPrefs.SetString("lastNamesStundetData", lastnamesStudent);
        PlayerPrefs.SetString("emailStudentData", emailStudent);
        PlayerPrefs.SetString("passwordStudentData", passwordStudent);
        PlayerPrefs.SetString("degreeStudentData", degreeStudent);
        PlayerPrefs.SetInt("stopDataStudent", 1);
        panelDataStudent.gameObject.SetActive(true);
    }

    /*metodo para actualizar los datos del estudiante
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator UpdateStudent(string editIdStudent, string editNamesStudent, string editLastNameStudent, string editEmailStudent, string editPasswordStudent, string editDegreeStudent)
    {

        WWWForm form = new WWWForm();
        form.AddField("editIdStudent", editIdStudent);
        form.AddField("editNamesStudent", editNamesStudent);
        form.AddField("editLastNameStudent", editLastNameStudent);
        form.AddField("editEmailStudent", editEmailStudent);
        form.AddField("editPasswordStudent", editPasswordStudent);
        form.AddField("editDegreeStudent", editDegreeStudent);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/UpdateStudent.php", form))//esta server
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            }
            else
            {
                if (www.downloadHandler.text != "error")
                {
                    dataStudentUpdate.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                }
            }
        }
    }
    //metodo para la creacion y el almacenamiento del reporte de notas del estudiante
    public void csv(string idStudent, string namesStudent, string lastNamesStudent, string themeOne, string qualificationOne, string themeTwo, string qualificationTwo, string themeThree, string qualificationThree)
    {
        string filename = Application.persistentDataPath + "/reporteNotas.csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("Identificacion,Nombres,Apellidos,Tematica uno,Nota1,Tematica dos,Nota2,Tematica tres,Nota3");
        tw.Close();
        tw = new StreamWriter(filename, true);
        tw.WriteLine(idStudent + "," + namesStudent + "," + lastNamesStudent + "," + themeOne + "," + qualificationOne + "," + themeTwo + "," + qualificationTwo + "," + themeThree + "," + qualificationThree);
        tw.Close();
        downloadFile.gameObject.SetActive(true);
    }
}
