/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIV�O
 * Esta es una clase perteneciente al paquete controlador la cual es manejada por el docente
 * y permite capturar los campos del formulario  para el inicio de sesion de los Estudiantes
*/
using UnityEngine;
using UnityEngine.UI;

public class LoginTeacher : MonoBehaviour
{
    GameObject gameObjectMistakes;
    string email;
    string password;


    public GameObject activatePanelTeacher;
    public GameObject inaActivatePanel;
    public InputField loginEmail;
    public InputField loginPassword;

    void Start()
    {
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaEmptyFields");
    }
    //methodo utilizado para validad que los campos del formulario para el inicio de sesi�n no esten vacios y enviar a la clase Teacher en el modelo los parametros de busqueda
    public void methodLoginTeacher()
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
            StartCoroutine(Main.Instance.teacher.LoginTeacher(email, password, activatePanelTeacher, inaActivatePanel));
            loginEmail.text = "";
            loginPassword.text = "";
        }
    }
}
