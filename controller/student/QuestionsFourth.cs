/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteeciente al paquete controlador la cual es manejada por el Estudiante en la clase score
 * y permite capturar los campos del los formularios de las preguntas del curso cuarto
 * tambien despliega los paneles pertenecinetes a la respuesta correcta o incorrecta
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsFourth : MonoBehaviour
{
    GameObject fiveStar;
    GameObject oneStar;
    void Start()
    {
        fiveStar = GameObject.Find("/Canvas/Message/PaFiveStar");
        oneStar = GameObject.Find("/Canvas/Message/PaOneStar");
    }

    //preguntas de unidades de capacidad nivel normal
    public void CapacityQuestionOne(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("CapacityAnswer1");
            PlayerPrefs.SetInt("CapacityAnswer1", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);//cumple la funcion de pagar los paneles transcurridos un periodo de tiempo en este caso 5 segundos
            StartCoroutine(Main.Instance.score.QualificationStudentCapacity());
        }
        else
        {
            PlayerPrefs.DeleteKey("CapacityAnswer1");
            PlayerPrefs.SetInt("CapacityAnswer1", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentCapacity());
        }
    }
    //preguntas de unidades de capacidad nivel avanzado
    public void CapacityQuestionTwo(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("CapacityAnswer2");
            PlayerPrefs.SetInt("CapacityAnswer2", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentCapacity());
        }
        else
        {
            PlayerPrefs.DeleteKey("CapacityAnswer2");
            PlayerPrefs.SetInt("CapacityAnswer2", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentCapacity());
        }
    }
    //preguntas de unidades de longitud nivel normal
    public void LengthQuestionOne(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("LengthAnswer1");
            PlayerPrefs.SetInt("LengthAnswer1", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentLength());
        }
        else
        {
            PlayerPrefs.DeleteKey("LengthAnswer1");
            PlayerPrefs.SetInt("LengthAnswer1", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentLength());
        }
    }
    //preguntas de unidades de longitud nivel avanzado
    public void LengthQuestionTwo(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("LengthAnswer2");
            PlayerPrefs.SetInt("LengthAnswer2", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentLength());
        }
        else
        {
            PlayerPrefs.DeleteKey("LengthAnswer2");
            PlayerPrefs.SetInt("LengthAnswer2", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentLength());
        }
    }
    //preguntas de prisma recto nivel normal
    public void PrimsQuestionOne(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("PrimsAnswer1");
            PlayerPrefs.SetInt("PrimsAnswer1", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentPrims());
        }
        else
        {
            PlayerPrefs.DeleteKey("PrimsAnswer1");
            PlayerPrefs.SetInt("PrimsAnswer1", 1);
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentPrims());
        }
    }
    //preguntas de prisma recto avanzado
    public void PrimsQuestionTwo(int answer)
    {
        if (answer == 1)
        {
            PlayerPrefs.DeleteKey("PrimsAnswer2");
            PlayerPrefs.SetInt("PrimsAnswer2", 5);
            FiveStarMethos();
            Invoke("FiveStarMethosInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentPrims());
        }
        else
        {
            PlayerPrefs.DeleteKey("PrimsAnswer2");
            PlayerPrefs.SetInt("PrimsAnswer2", 1);
            OneStarMethod();
            OneStarMethod();
            Invoke("OneStarMethodInactive", 2.5f);
            StartCoroutine(Main.Instance.score.QualificationStudentPrims());
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
