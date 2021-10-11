/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteeciente al paquete controlador la cual es manejada por el Estudiante
 * y mostramos las estrellas acumuladas de las preguntas del curso cuarto
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsByThemeFifth : MonoBehaviour
{
    public Text starForAngles;
    public Text starForCone;
    public Text starForSymmetry;
    int stopUpdate;

    void Start()
    {

    }

    void Update()
    {
        stopUpdate = PlayerPrefs.GetInt("starsFifthStop", 0);
        while (stopUpdate != 0)
        {
            PlayerPrefs.DeleteKey("starsFifthStop");
            starForAngles.text = PlayerPrefs.GetString("totalStarsAngles", "0");
            starForCone.text = PlayerPrefs.GetString("totalStarsCone", "0");
            starForSymmetry.text = PlayerPrefs.GetString("totalStarsSymmetry", "0");
            stopUpdate = 0;
        }
    }
}
