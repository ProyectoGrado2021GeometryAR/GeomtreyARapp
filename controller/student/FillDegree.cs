/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑIO
 * Esta es una clase perteeciente al paquete controlador la cual es manejada por el Estudiante
 * y permite visualizar los datos registrados en la base de datos
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FillDegree : MonoBehaviour
{
    public Text TextBox;

    void Start()
    {
        StartCoroutine(loadigDropDown());
    }
    public IEnumerator loadigDropDown()
    {
        WWWForm form = new WWWForm();
        using (UnityWebRequest www = UnityWebRequest.Post("https://geometry2021.000webhostapp.com/fillDegress.php", form))//esta en el server
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                var dropdown = transform.GetComponent<Dropdown>();
                dropdown.options.Clear();
                List<string> itemns = new List<string>();

                string a = www.downloadHandler.text;

                string[] grados = a.Split('|', ' ');

                string asa = "";

                string asw = "";
                for (int i = 0; i < grados.Length; i++)
                {

                    if (grados[i] == "estono")
                    {
                        break;
                    }
                    else
                    {
                        asa = grados[i];
                        i++;
                        asw = grados[i];
                        itemns.Add(asw);
                    }
                }
                foreach (var item in itemns)
                {
                    dropdown.options.Add(new Dropdown.OptionData() { text = item });
                }
                DropdownItemSelected(dropdown);
                dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
            }
        }
    }


    void DropdownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        TextBox.text = dropdown.options[index].text;
    }
}
