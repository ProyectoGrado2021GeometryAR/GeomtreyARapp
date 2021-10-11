/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase perteneciente al paquete controlador la cual es manejada por el Estudiante
 * y permite capturar los campos del formulario  para el inicio de sesion de los Estudiantes
*/
using UnityEngine;
using UnityEngine.UI;
public class LoginStudent : MonoBehaviour
{
    GameObject gameObjectMistakes;
    string email;
    string password;

    public InputField loginEmail;
    public InputField loginPassword;

    void Start()
    {
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaEmptyFields");
    }
    //methodo utilizado para validad que los campos del formulario para el inicio de sesión no esten vacios y enviar a la clase Student en el modelo los parametros de busqueda
    public void methodLoginStudent()
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
            StartCoroutine(Main.Instance.student.Login(email, password));
            loginEmail.text = "";
            loginPassword.text = "";
        }






    }
    public void capturarCampos()
    {
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaEmptyFields");
        gameObjectMistakes.gameObject.SetActive(true);
    }
}
