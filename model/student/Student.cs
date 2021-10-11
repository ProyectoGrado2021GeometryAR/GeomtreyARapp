/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVÑO
 * Esta es una clase perteneciente al paquete modelo la cual es manejada por el estudiante
 * y contiene como methodos principales 
 * login del estudiante y registro del mismo
*/
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class Student : MonoBehaviour
{
    GameObject gameObjectUserCreate;
    GameObject gameObjectMistakes;
    GameObject gameObjectMistakesStudentExisting;
    GameObject gameOInaxtivatePanelLogin;
    GameObject gameOInactivatePanelWallpaper;
    GameObject gameOActivatePanelThematics;
    GameObject gameOActivatePanelFourth;
    GameObject gameOActivatePanelFifth;
    GameObject gameImageTargetFourth;
    GameObject gameImageTargetFifth;

    void Start()
    {
        gameOInaxtivatePanelLogin = GameObject.Find("/Canvas/ImageWallPaperGeneral/LoginStudent");
        gameOInactivatePanelWallpaper = GameObject.Find("/Canvas/ImageWallPaperGeneral");
        gameObjectMistakes = GameObject.Find("/Canvas/ImageWallPaperGeneral/LoginStudent/PanelRegisterStudent/Text");
        gameObjectMistakesStudentExisting = GameObject.Find("/Canvas/Message/PaUserYaRegistrados");
        gameObjectUserCreate = GameObject.Find("/Canvas/Message/PaUserCreated");
        gameOActivatePanelFourth = GameObject.Find("/Canvas/ThematicsByDegrees/ThematicsDegreeFourth");
        gameOActivatePanelFifth = GameObject.Find("/Canvas/ThematicsByDegrees/ThematicsDegreeFifth");
        gameImageTargetFourth = GameObject.Find("/GroupImageTargetFourth");
        gameImageTargetFifth = GameObject.Find("/GroupImageTargetFifth");
        Main.Instance.activeSession.FindObjects();
        Main.Instance.activeSession.ComfirmSessionActive();
    }

    /*metodo para el inicio de seion del estudiante
     *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
     * srive para componer peticiones HTTP y manejar respuestas HTTP
     */
    public IEnumerator Login(string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginEmail", email);
        form.AddField("loginPassword", password);
        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/LoginStudent.php", form))//esta es desde el servwer

        {
            int degreeSessionActive;
            int idStudent;
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                Debug.Log("errror de conexion");
            }

            string data = www.downloadHandler.text;
            string[] dataStudent = data.Split('|');
            if (dataStudent[0] == "4")
            {
                gameOInaxtivatePanelLogin.gameObject.SetActive(false);
                gameOInactivatePanelWallpaper.gameObject.SetActive(false);
                gameOActivatePanelFourth.gameObject.SetActive(true);
                gameImageTargetFifth.gameObject.SetActive(false);
                degreeSessionActive = int.Parse(dataStudent[0]);
                idStudent = int.Parse(dataStudent[1]);
                PlayerPrefs.SetInt("IdStudent", idStudent);
                Main.Instance.activeSession.ActiveSessionSave(degreeSessionActive);
            }
            else if (dataStudent[0] == "5")
            {
                gameOInaxtivatePanelLogin.gameObject.SetActive(false);
                gameOInactivatePanelWallpaper.gameObject.SetActive(false);
                gameOActivatePanelFifth.gameObject.SetActive(true);
                gameImageTargetFourth.gameObject.SetActive(false);
                degreeSessionActive = int.Parse(dataStudent[0]);
                idStudent = int.Parse(dataStudent[1]);
                PlayerPrefs.SetInt("IdStudent", idStudent);
                Main.Instance.activeSession.ActiveSessionSave(degreeSessionActive);
            }

            else
            {

                Debug.Log(www.downloadHandler.text);
                gameObjectMistakes.gameObject.SetActive(true);

            }
        }
    }
    /*metodo para el registro del estudiante
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator CreateStudent(int idStudent, string namesStudent, string lastNamesStudent, string emailStudent, string passwordStudent, string degree)
    {
        string e = "1";
        WWWForm form = new WWWForm();
        form.AddField("createIdStudent", idStudent);
        form.AddField("createNamesStudent", namesStudent);
        form.AddField("createLastNamesStudent", lastNamesStudent);
        form.AddField("createEmailStudent", emailStudent);
        form.AddField("createPasswordStudent", passwordStudent);
        form.AddField("createStatus", e);
        form.AddField("createDegree", degree);

        //using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.0.4/Geo2/CreateStundent.php", form))//esta em xamp
        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/CreateStundent.php", form))//esta server
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.downloadHandler.text == "createStudent")
                {
                    Debug.Log(www.downloadHandler.text);
                    gameObjectUserCreate.gameObject.SetActive(true);
                }
                else if (www.downloadHandler.text == "error")
                {
                    gameObjectMistakesStudentExisting.gameObject.SetActive(true);
                }
                else if (www.downloadHandler.text == "errorDB")
                {
                    gameObjectMistakesStudentExisting.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                }
            }
        }
    }
}
