/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteneciente al paquete modelo la cual es manejada por el estudiante
 * y contiene como methodos principales 
 * estado de sesion, comfirmacion de estado sesion y cerrar sesion
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSession : MonoBehaviour
{
    GameObject gameOInaxtivatePanelLogin;
    GameObject gameOInactivatePanelWallpaper;
    GameObject gameOActivatePanelThematics;
    GameObject gameOActivatePanelFourth;
    GameObject gameOActivatePanelFifth;
    GameObject gameImageTargetFourth;
    GameObject gameImageTargetFifth;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
    }
    //metodo para la busqueda de objetos de la interfaz de unity
    public void FindObjects()
    {
        gameOActivatePanelFourth = GameObject.Find("/Canvas/ThematicsByDegrees/ThematicsDegreeFourth");
        gameOActivatePanelFifth = GameObject.Find("/Canvas/ThematicsByDegrees/ThematicsDegreeFifth");
        gameOInaxtivatePanelLogin = GameObject.Find("/Canvas/ImageWallPaperGeneral/LoginStudent");
        gameOInactivatePanelWallpaper = GameObject.Find("/Canvas/ImageWallPaperGeneral");
        gameImageTargetFourth = GameObject.Find("/GroupImageTargetFourth");
        gameImageTargetFifth = GameObject.Find("/GroupImageTargetFifth");
    }
    //este methodo almacena los datos del logeo del estudiante
    public void ActiveSessionSave(int degreeSession)
    {
        PlayerPrefs.SetInt("activeSession", 0);
        if (degreeSession == 4)
        {
            Debug.Log(degreeSession);
            PlayerPrefs.SetInt("degreeSession", degreeSession);
        }
        else if (degreeSession == 5)
        {
            Debug.Log(degreeSession);
            PlayerPrefs.SetInt("degreeSession", degreeSession);
        }
    }
    /*metodo para la comfirmacion del estado de sesion, 
     * donde se evalua los datos almacenados del estudiante que realizo el inicio de sesion y cerro el aplicativo
     * si el estudiante que cerro el aplicativo es de grado cuarto se activaran las tematicas de cuarto en otro caso quinto
     * tiene encuentas datos vitales como la identificacion del estudiante y el curso
    */
    public void ComfirmSessionActive()
    {
        if (PlayerPrefs.GetInt("degreeSession", 0) == 4)
        {   Debug.Log("Entra a cuarto");
            gameImageTargetFifth.gameObject.SetActive(false);
            gameOInactivatePanelWallpaper.gameObject.SetActive(false);
            gameOActivatePanelFourth.gameObject.SetActive(true);
            Debug.Log("Id del estudiante 4: " + PlayerPrefs.GetInt("IdStudent", 0));

        }
        else if (PlayerPrefs.GetInt("degreeSession", 0) == 5)
        {
            Debug.Log("Entra a Quinto");
            gameImageTargetFourth.gameObject.SetActive(false);
            gameOInactivatePanelWallpaper.gameObject.SetActive(false);
            gameOActivatePanelFifth.gameObject.SetActive(true);
            Debug.Log("Id del estudiante 5: " + PlayerPrefs.GetInt("IdStudent", 0));
        }
    }
    //este metodo elimina los datos almacenado al momento del logeo y forza al que el estudiante se loge nuevamente se activa al cerrar sesion
    public void DeleteSessionActive()
    {
        Debug.Log("borradooo");
        if (PlayerPrefs.GetInt("degreeSession", 0) == 4)
        {
            gameImageTargetFifth.gameObject.SetActive(true);
            PlayerPrefs.DeleteKey("degreeSession");
            PlayerPrefs.DeleteKey("IdStudent");
        }
        else if (PlayerPrefs.GetInt("degreeSession", 0) == 5)
        {
            gameImageTargetFourth.gameObject.SetActive(true);
            PlayerPrefs.DeleteKey("degreeSession");
            PlayerPrefs.DeleteKey("IdStudent");
        }

    }
}
