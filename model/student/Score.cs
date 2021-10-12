/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVÑO
 * Esta es una clase perteneciente al paquete modelo la cual es manejada por el estudiante
 * y contiene como methodos principales de
 * calificaciones por tematicas de cuarto y quinto
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Score : MonoBehaviour
{
    public GameObject panelStarsFourth;
    public GameObject panelThemesFourth;
    public GameObject panelStarsFifth;
    public GameObject panelThemesFifth;
    void Start()
    {
       
    }

    /*metodo para cargar las notas de capacida
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator QualificationStudentCapacity()
    {
        int capacityOne = PlayerPrefs.GetInt("CapacityAnswer1");
        int capacityTwo = PlayerPrefs.GetInt("CapacityAnswer2");
        int capacityQualificaty = (capacityOne + capacityTwo) / 2;
        string starCapacity = capacityQualificaty.ToString();
        PlayerPrefs.DeleteKey("totalStarsCapacity");//limpiando el registro de la nota total
        PlayerPrefs.SetString("totalStarsCapacity", starCapacity);//nota total del tema de capacidad
        Debug.Log(capacityQualificaty);
        int idStundetQualification = PlayerPrefs.GetInt("IdStudent");
        Debug.Log(capacityQualificaty + " " + idStundetQualification);
        WWWForm form = new WWWForm();
        form.AddField("Nota", capacityQualificaty);
        form.AddField("idStundetQualification", idStundetQualification);
        int idTematic = 41;
        form.AddField("idTematic", idTematic);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/Score.php", form))//esta server
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                Debug.Log(www.downloadHandler.text);

            }
        }
    }
    /*metodo para cargar las notas de longitud
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator QualificationStudentLength()
    {
        int lengthOne = PlayerPrefs.GetInt("LengthAnswer1");
        int lengthTwo = PlayerPrefs.GetInt("LengthAnswer2");
        int lengthQualifity = (lengthOne + lengthTwo) / 2;
        string starLength = lengthQualifity.ToString();
        PlayerPrefs.DeleteKey("totalStarsLength");//limpiando el registro de la nota total
        PlayerPrefs.SetString("totalStarsLength", starLength);//nota total del tema de longitudes
        int idStundetQualification = PlayerPrefs.GetInt("IdStudent");
        Debug.Log(lengthQualifity + " " + idStundetQualification);
        WWWForm form = new WWWForm();
        form.AddField("Nota", lengthQualifity);
        form.AddField("idStundetQualification", idStundetQualification);
        int idTematic = 42;
        form.AddField("idTematic", idTematic);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/Score.php", form))//esta server
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                Debug.Log("datos almacenados");

            }
        }
    }
    /*metodo para cargar las notas de prismas
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator QualificationStudentPrims()
    {
        int primsOne = PlayerPrefs.GetInt("PrimsAnswer1");
        int primsTwo = PlayerPrefs.GetInt("PrimsAnswer2");
        int primsQualifity = (primsOne + primsTwo) / 2;
        string starPrims = primsQualifity.ToString();

        PlayerPrefs.DeleteKey("totalStarsPrims");//limpiando el registro de la nota total
        PlayerPrefs.SetString("totalStarsPrims", starPrims);//nota total del tema de prisma

        int idStundetQualification = PlayerPrefs.GetInt("IdStudent");
        Debug.Log(primsQualifity + " " + idStundetQualification);
        WWWForm form = new WWWForm();

        form.AddField("Nota", primsQualifity);
        form.AddField("idStundetQualification", idStundetQualification);
        int idTematic = 43;
        form.AddField("idTematic", idTematic);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/Score.php", form))//esta server
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                Debug.Log("datos almacenados");
            }
        }
    }
    //metodo para activar el panel de estrellas optenidas por el estudiante de 4
    public void StarsByTheFourth()
    {
        PlayerPrefs.SetInt("starsForuthStop", 1);
        panelStarsFourth.gameObject.SetActive(true);
        panelThemesFourth.gameObject.SetActive(false);
    }



    /*metodo para cargar las notas de angulos
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator QualificationStudentAngles()
    {
        int anglesOne = PlayerPrefs.GetInt("AnglesAnswer1");
        int anglesTwo = PlayerPrefs.GetInt("AnglesAnswer2");
        int anglesQualification = (anglesOne + anglesTwo) / 2;
        string starAngles = anglesQualification.ToString();
        PlayerPrefs.DeleteKey("totalStarsAngles");//limpiando el registro de la nota total
        PlayerPrefs.SetString("totalStarsAngles", starAngles);//nota total del tema de Angulos
        int idStundetQualification = PlayerPrefs.GetInt("IdStudent");
        WWWForm form = new WWWForm();
        form.AddField("Nota", anglesQualification);
        form.AddField("idStundetQualification", idStundetQualification);
        int idTematic = 51;
        form.AddField("idTematic", idTematic);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/Score.php", form))//esta server
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("datos almacenados");
            }
        }

    }
    /*metodo para cargar las notas de Cono
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator QualificationStudentCone()
    {


        int coneOne = PlayerPrefs.GetInt("ConeAnswer1");
        int coneTwo = PlayerPrefs.GetInt("ConeAnswer2");
        int coneQualification = (coneOne + coneTwo) / 2;
        string starCone = coneQualification.ToString();
        PlayerPrefs.DeleteKey("totalStarsCone");//limpiando el registro de la nota total
        PlayerPrefs.SetString("totalStarsCone", starCone);//nota total del tema de Conos
        int idStundetQualification = PlayerPrefs.GetInt("IdStudent");
        Debug.Log(coneQualification + "|" + idStundetQualification);
        WWWForm form = new WWWForm();

        form.AddField("Nota", coneQualification);

        form.AddField("idStundetQualification", idStundetQualification);
        int idTematic = 52;
        form.AddField("idTematic", idTematic);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/Score.php", form))//esta server
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                Debug.Log("datos almacenados");
            }
        }
    }
    /*metodo para cargar las notas de Simetria
    *El objetivo principal del sistema de UnityWebRequest es permitirle a los juegos de Unity interactuar con backends Web modernos,
    * srive para componer peticiones HTTP y manejar respuestas HTTP
    */
    public IEnumerator QualificationStudentSymmetry()
    {
        int symmetryOne = PlayerPrefs.GetInt("SymmetryAnswer1");
        int symmetryTwo = PlayerPrefs.GetInt("SymmetryAnswer2");
        int symmetryQualification = (symmetryOne + symmetryTwo) / 2;
        string starSymmetry = symmetryQualification.ToString();
        PlayerPrefs.DeleteKey("totalStarsSymmetry");//limpiando el registro de la nota total
        PlayerPrefs.SetString("totalStarsSymmetry", starSymmetry);//nota total del tema de Conos
        int idStundetQualification = PlayerPrefs.GetInt("IdStudent");
        WWWForm form = new WWWForm();
        form.AddField("Nota", symmetryQualification);
        form.AddField("idStundetQualification", idStundetQualification);
        int idTematic = 53;
        form.AddField("idTematic", idTematic);

        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/Score.php", form))//esta server
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                Debug.Log("datos almacenados");

            }
        }
    }
    //metodo para activar el panel de estrellas optenidas por el estudiante de 5
    public void StarsByTheFifth()
    {
        PlayerPrefs.SetInt("starsFifthStop", 1);
        panelStarsFifth.gameObject.SetActive(true);
        panelThemesFifth.gameObject.SetActive(false);
    }
}
