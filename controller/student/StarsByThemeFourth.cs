/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteeciente al paquete controlador la cual es manejada por el Estudiante
 * y mostramos las estrellas acumuladas de las preguntas del curso quinto
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarsByThemeFourth : MonoBehaviour
{
    public Text starForUnitsCapacity;
    public Text starForUnitsLength;
    public Text starForUnitsPrims;
    int stopUpdate;

    void Start()
    {
    }
    void Update()
    {
        stopUpdate = PlayerPrefs.GetInt("starsForuthStop", 0);
        while (stopUpdate != 0)
        {
            PlayerPrefs.DeleteKey("starsForuthStop");
            starForUnitsCapacity.text = PlayerPrefs.GetString("totalStarsCapacity", "0");
            starForUnitsLength.text = PlayerPrefs.GetString("totalStarsLength", "0");
            starForUnitsPrims.text = PlayerPrefs.GetString("totalStarsPrims", "0");
            stopUpdate = 0;
        }
    }
}
