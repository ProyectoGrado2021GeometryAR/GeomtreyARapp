/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteeciente al paquete controlador la cual es manejada por el Estudiante en la clase score
 * y permite capturar los campos del los formularios de las preguntas del curso quinto
 * tambien despliega los paneles pertenecinetes a la respuesta correcta o incorrecta
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsFifth : MonoBehaviour
{
    GameObject fiveStar;
    GameObject oneStar;

    void Start()
    {
        fiveStar = GameObject.Find("/Canvas/Message/PaFiveStar");
        oneStar = GameObject.Find("/Canvas/Message/PaOneStar");
    }
    //pregunta de angulos nivel normal
    public void AnglesQuestionOne(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("AnglesAnswer1");
            PlayerPrefs.SetInt("AnglesAnswer1", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);//cumple la funcion de pagar los paneles transcurridos un periodo de tiempo en este caso 5 segundos
            StartCoroutine(Main.Instance.score.QualificationStudentAngles());
        }
        else
        {
            PlayerPrefs.DeleteKey("AnglesAnswer1");
            PlayerPrefs.SetInt("AnglesAnswer1", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentAngles());
        }
    }
    //pregunta de angulos nivel avanzado
    public void AnglesQuestionTwo(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("AnglesAnswer2");
            PlayerPrefs.SetInt("AnglesAnswer2", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentAngles());
        }
        else
        {
            PlayerPrefs.DeleteKey("AnglesAnswer2");
            PlayerPrefs.SetInt("AnglesAnswer2", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentAngles());
        }
    }
    //pregunta de Conos nivel normal
    public void ConeQuestionOne(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("ConeAnswer1");
            PlayerPrefs.SetInt("ConeAnswer1", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentCone());
        }
        else
        {
            PlayerPrefs.DeleteKey("ConeAnswer1");
            PlayerPrefs.SetInt("ConeAnswer1", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentCone());
        }
    }
    //pregunta de conos nivel avanzado
    public void ConeQuestionTwo(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("ConeAnswer2");
            PlayerPrefs.SetInt("ConeAnswer2", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentCone());
        }
        else
        {
            PlayerPrefs.DeleteKey("ConehAnswer2");
            PlayerPrefs.SetInt("ConeAnswer2", 1);

            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentCone());
        }
    }
    //pregunta de simetria nivel normal
    public void SymmetryQuestionOne(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("SymmetryAnswer1");
            PlayerPrefs.SetInt("SymmetryAnswer1", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentSymmetry());
        }
        else
        {
            PlayerPrefs.DeleteKey("SymmetryAnswer1");
            PlayerPrefs.SetInt("SymmetryAnswer1", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentSymmetry());
        }
    }
    //pregunta de simetria nivel avanzado
    public void SymmetryQuestionTwo(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("SymmetryAnswer2");
            PlayerPrefs.SetInt("SymmetryAnswer2", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentSymmetry());
        }
        else
        {
            PlayerPrefs.DeleteKey("SymmetryAnswer2");
            PlayerPrefs.SetInt("SymmetryAnswer2", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentSymmetry());
        }
    }
    //activar o apagar los paneles de estrellas para la puntuacion
    public void FiveStarMethos()
    {
        fiveStar.gameObject.SetActive(true);
    }
    public void FiveStarMethosInactive()
    {
        fiveStar.gameObject.SetActive(false);
    }

    public void OneStarMethod()
    {
        oneStar.gameObject.SetActive(true);
    }
    public void OneStarMethodInactive()
    {
        oneStar.gameObject.SetActive(false);
    }
}
