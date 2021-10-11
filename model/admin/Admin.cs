/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVÑO
 * Esta es una clase perteneciente al paquete modelo la cual es manejada por el administrador
 * y contiene como methodos principales crecion del docente
 * busqueda de docente, editar docente y metodo de logeo del administrador se explicara a detalle en el emcabezado de cada metodo
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Admin : MonoBehaviour
{
    public GameObject panelSearchTeacher;
    public GameObject panelEditTeacher;
    GameObject panelUserNotFound;
    GameObject gameObjectMistakes;
    GameObject messsageTeacherUpdate;
    GameObject messsageTeacherCreate;
    EditTeacher edt = new EditTeacher();

    void Start()
    {
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaUserYaRegistrados");
        panelUserNotFound = GameObject.Find("/Canvas/Message/PaUserNotFound");
        messsageTeacherUpdate = GameObject.Find("/Canvas/Message/PaUpdateUser");
        messsageTeacherCreate = GameObject.Find("/Canvas/Message/PaUserCreated");

    }
    /*metodo para la creacion del docente recibe los parametros capturados en el formulario de creacion
     *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
     * srive para componer peticiones HTTP y manejar respuestas HTTP
     */
    public IEnumerator CreateTeacher(int idTeacher, string namesTeacher, string lastNamesTeacher, string emailTeacher, string passwordTeacher, int degree)
    {
        WWWForm form = new WWWForm();
        form.AddField("createIdTeacher", idTeacher);
        form.AddField("createNamesTeacher", namesTeacher);
        form.AddField("createLastNamesTeacher", lastNamesTeacher);
        form.AddField("createEmailTeacher", emailTeacher);
        form.AddField("createPasswordTeacher", passwordTeacher);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/CreateTeacher.php", form))//esta servidor
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text != "stop")
                {
                    StartCoroutine(UpdateDegree(idTeacher, degree));
                }
                else
                {
                    Debug.Log("este correo o id ya existen");
                }
            }
        }

    }
    /*metodo para la creacion del docente con dos cursos asigandos recibe los parametros capturados en el formulario de creacion
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
     * srive para componer peticiones HTTP y manejar respuestas HTTP
     */
    public IEnumerator CreateTeacherTwoDegree(int idTeacher, string namesTeacher, string lastNamesTeacher, string emailTeacher, string passwordTeacher, int degree1, int degree2)
    {

        WWWForm form = new WWWForm();
        form.AddField("createIdTeacher", idTeacher);
        form.AddField("createNamesTeacher", namesTeacher);
        form.AddField("createLastNamesTeacher", lastNamesTeacher);
        form.AddField("createEmailTeacher", emailTeacher);
        form.AddField("createPasswordTeacher", passwordTeacher);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/CreateTeacher.php", form))//conexion con el servidor
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text != "stop")
                {
                    int[] arrayDegree = new int[2];
                    arrayDegree[0] = degree1;
                    arrayDegree[1] = degree2;
                    for (int i = 0; i < arrayDegree.Length; i++)
                    {
                        StartCoroutine(UpdateDegree(idTeacher, arrayDegree[i]));
                    }
                }
                else
                {
                    Debug.Log("este correo o id ya existen");
                    gameObjectMistakes.gameObject.SetActive(true);
                }
            }
        }
    }
    /*metodo para la actualizacion de la llave foranea para relacionar los docentes y cursos
     *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
     */
    public IEnumerator UpdateDegree(int idTeacher, int degreeTeacher)
    {
        WWWForm form = new WWWForm();
        form.AddField("createIdTeacher", idTeacher);
        form.AddField("updateDegreeTeacher", degreeTeacher);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/UpdateDegree.php", form))//conexion con el servidor
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            }
            else
            {

                Debug.Log(www.downloadHandler.text);
                messsageTeacherCreate.gameObject.SetActive(true);

            }
        }

    }

    /*metodo para consultar los datos de los docentes en la base de datos y almacenarlos en playerPrefs para su transeferencia entre escenas
      *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
      * srive para componer peticiones HTTP y manejar respuestas HTTP
      */
    public IEnumerator PreviewRegisteredTeachers()
    {

        WWWForm form = new WWWForm();
        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/SearchTeacher.php", form))//esta en el server
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string splitMessage = www.downloadHandler.text;
                string[] teacherPanelPreview = splitMessage.Split('|');
                for (int i = 0; i < teacherPanelPreview.Length; i++)
                {
                    if (teacherPanelPreview[i] != "stop" && i < 4)
                    {
                        preViewTeacher(teacherPanelPreview[0], teacherPanelPreview[1], teacherPanelPreview[2], teacherPanelPreview[3]);
                    }
                    else if (teacherPanelPreview[i] != "stop")
                    {
                        /// aqui inicia el llenado del panel del seguno docente registrado en la vista previa
                        preViewTeacherTwo(teacherPanelPreview[4], teacherPanelPreview[5], teacherPanelPreview[6], teacherPanelPreview[7]);
                        break;
                    }
                }
            }
        }
    }
    /*metodo para consultar los docentes compuesto de condicionales para mostrar los docentes segun la cantidad de cursos asignados o la ausencia de ellos
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator TearcherAndDegree(int numbDocument)
    {
        CleanPlayerPrefs();
        WWWForm form = new WWWForm();

        form.AddField("numbDocument", numbDocument);
        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/SearchTeacherAndDegree.php", form))//esta en el server
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string splitMessage = www.downloadHandler.text;
                if (splitMessage == "Inactive")
                {
                    Debug.Log("consultar docente");
                    StartCoroutine(SearchTeacherById(numbDocument));
                }
                else
                {
                    string[] teacherGradee = splitMessage.Split('|');
                    for (int i = 0; i < teacherGradee.Length; i++)
                    {
                        if (teacherGradee[i] != "stop")
                        {
                            if (teacherGradee[5] == "stop")
                            {
                                TeacherWithOneDegree(teacherGradee[0], teacherGradee[1], teacherGradee[2], teacherGradee[3], teacherGradee[4]);
                            }
                            else if (teacherGradee[10] == "stop")
                            {
                                TeacherWithTwoDegree(teacherGradee[0], teacherGradee[1], teacherGradee[2], teacherGradee[3], teacherGradee[4], teacherGradee[9]);
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
    //metodo para la transferencia de los datos a los paneles de previsualizacion, primer docente
    public void preViewTeacher(string numberDocumentOne, string namesOne, string lastNamesOne, string emailOne)
    {
        PlayerPrefs.DeleteKey("numberDocumentOne");
        PlayerPrefs.DeleteKey("namesOne");
        PlayerPrefs.DeleteKey("lastNamesOne");
        PlayerPrefs.DeleteKey("emailOne");
        PlayerPrefs.SetString("numberDocumentOne", numberDocumentOne);
        PlayerPrefs.SetString("namesOne", namesOne);
        PlayerPrefs.SetString("lastNamesOne", lastNamesOne);
        PlayerPrefs.SetString("emailOne", emailOne);
    }
    //metodo para la transferencia de los datos a los paneles de previsualizacion, segundo docente
    public void preViewTeacherTwo(string numberDocumentTwo, string namesTwo, string lastNamesTwo, string emailTwo)
    {

        PlayerPrefs.DeleteKey("numberDocumentTwo");
        PlayerPrefs.DeleteKey("namesTwo");
        PlayerPrefs.DeleteKey("lastNamesTwo");
        PlayerPrefs.DeleteKey("emailTwo");
        ///
        PlayerPrefs.SetString("numberDocumentTwo", numberDocumentTwo);
        PlayerPrefs.SetString("namesTwo", namesTwo);
        PlayerPrefs.SetString("lastNamesTwo", lastNamesTwo);
        PlayerPrefs.SetString("emailTwo", emailTwo);

    }
    /*metodo para consultar un doncente median el numero de identificacion 
   *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
   * srive para componer peticiones HTTP y manejar respuestas HTTP
   */
    public IEnumerator SearchTeacherById(int searchTeacherById)
    {

        WWWForm form = new WWWForm();
        form.AddField("searchTeacherById", searchTeacherById);


        //  using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Geo2/UpdateDegree.php", form))//esta em xamp
        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/SearchTeacherById.php", form))//esta server
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            }
            else if (www.downloadHandler.text != "stop")
            {
                Debug.Log("borrraaa esto" + www.downloadHandler.text);
                string splitMessage = www.downloadHandler.text;

                string[] teacherNoDegree = splitMessage.Split('|');
                for (int i = 0; i < teacherNoDegree.Length; i++)
                {

                    if (teacherNoDegree[i] != "stop")
                    {

                        TeacheNoDegrees(teacherNoDegree[0], teacherNoDegree[1], teacherNoDegree[2], teacherNoDegree[3]);
                    }


                }


            }
            else if (www.downloadHandler.text == "stop")
            {

                panelUserNotFound.gameObject.SetActive(true);
            }
        }

    }
    //almacena los datos en playerPrefs de un docente sin cursos asignados
    public void TeacheNoDegrees(string numberDocumentTnD, string namesTnD, string lastNamesTnD, string emailTnD)
    {
        panelSearchTeacher.gameObject.SetActive(false);
        panelEditTeacher.gameObject.SetActive(true);
        PlayerPrefs.DeleteKey("conditional1");
        PlayerPrefs.SetInt("conditional1", 1);
        PlayerPrefs.SetString("numberDocumentTnD", numberDocumentTnD);
        PlayerPrefs.SetString("namesTnD", namesTnD);
        PlayerPrefs.SetString("lastNamesTnD", lastNamesTnD);
        PlayerPrefs.SetString("emailTnD", emailTnD);
        Debug.Log("sn cursos");
        PlayerPrefs.SetInt("stop", 1);

    }
    //almacena los datos en playerPrefs de un docente con un unico cursos 
    public void TeacherWithOneDegree(string numberDocumentTwD, string namesTwD, string lastNamesTwD, string emailTwD, string idDegreeOneTwD)
    {
        panelSearchTeacher.gameObject.SetActive(false);
        panelEditTeacher.gameObject.SetActive(true);
        PlayerPrefs.DeleteKey("conditional2");
        PlayerPrefs.SetInt("conditional2", 2);
        PlayerPrefs.SetString("numberDocumentTwD", numberDocumentTwD);
        PlayerPrefs.SetString("namesTwD", namesTwD);
        PlayerPrefs.SetString("lastNamesTwD", lastNamesTwD);
        PlayerPrefs.SetString("emailTwD", emailTwD);
        PlayerPrefs.SetString("idDegreeOneTwD", idDegreeOneTwD);
        PlayerPrefs.SetInt("stop", 1);


    }
    //almacena los datos en playerPrefs de un docente con dos cursos asignados
    public void TeacherWithTwoDegree(string numberDocumentTwoTwD, string namesTwoTwD, string lastNamesTwoTwD, string emailTwoTwD, string idDegreeTwoTwD, string idDegreeTwo2TwD)
    {
        panelSearchTeacher.gameObject.SetActive(false);
        panelEditTeacher.gameObject.SetActive(true);
        PlayerPrefs.DeleteKey("conditional3");
        PlayerPrefs.SetInt("conditional3", 3);
        PlayerPrefs.SetString("numberDocumentTwoTwD", numberDocumentTwoTwD);
        PlayerPrefs.SetString("namesTwoTwD", namesTwoTwD);
        PlayerPrefs.SetString("lastNamesTwoTwD", lastNamesTwoTwD);
        PlayerPrefs.SetString("emailTwoTwD", emailTwoTwD);
        PlayerPrefs.SetString("idDegreeTwoTwD", idDegreeTwoTwD);
        PlayerPrefs.SetString("idDegreeTwo2TwD", idDegreeTwo2TwD);


        PlayerPrefs.SetInt("stop", 1);


    }
    //limpia las playerPrefs usado para detener ciclos update
    public void CleanPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("conditional1");
        PlayerPrefs.DeleteKey("conditional2");
        PlayerPrefs.DeleteKey("conditional3");
    }
    /*metodo para editar los datos del docente
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator EditTeacher(int editIdTeacher, string editNamesTeacher, string editLastNamesTeacher, string editEmailTeacher)
    {
        Debug.Log("datos" + editIdTeacher + editLastNamesTeacher + editLastNamesTeacher + editEmailTeacher);
        WWWForm form = new WWWForm();
        form.AddField("editIdTeacher", editIdTeacher);
        form.AddField("editNamesTeacher", editNamesTeacher);
        form.AddField("editLastNamesTeacher", editLastNamesTeacher);
        form.AddField("editEmailTeacher", editEmailTeacher);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/UpdateTeacher.php", form))//esta server
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                messsageTeacherUpdate.gameObject.SetActive(true);
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    /*metodo para el logeo del administrador
   *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
   * srive para componer peticiones HTTP y manejar respuestas HTTP
   */
    public IEnumerator LoginAdmin(string email, string password, GameObject activatePanelAdmin, GameObject inactivatePanel)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginEmail", email);
        form.AddField("loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/LoginAdmin.php", form))//esta en el server                                                                                                   

        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else if (www.downloadHandler.text == "false")
            {
                Debug.Log(www.downloadHandler.text);
                Debug.Log("Admin");
                activatePanelAdmin.gameObject.SetActive(true);
                inactivatePanel.gameObject.SetActive(false);
            }
            else
            {
                panelUserNotFound.gameObject.SetActive(true);
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
