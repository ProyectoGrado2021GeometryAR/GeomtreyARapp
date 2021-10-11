/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteeciente al paquete controlador la cual es manejada por el Administrador
 * y permite capturar los campos del formulario  para el inicio de sesion de los Administradores
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginAdmin : MonoBehaviour
{
    GameObject gameObjectMistakes;
    string email;
    string password;
    public GameObject activatePanelAdmin;
    public GameObject inaActivatePanel;
    public InputField loginEmail;
    public InputField loginPassword;

    void Start()
    {
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaEmptyFields");
    }
    //methodo utilizado para validad que los campos del formulario para el inicio de sesión no esten vacios y enviar a la clase Admin en el modelo los parametros de busqueda
    public void methodLoginAdmin()
    {
        email = loginEmail.text;
        password = loginPassword.text;
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            gameObjectMistakes.gameObject.SetActive(true);
            Debug.Log("Todos los campos son obligatorios");
        }
        else
        {
            Debug.Log("email :" + email + " password :" + password);
            StartCoroutine(Main.Instance.admin.LoginAdmin(email, password, activatePanelAdmin, inaActivatePanel));
            loginEmail.text = "";
            loginPassword.text = "";
        }
    }
}
