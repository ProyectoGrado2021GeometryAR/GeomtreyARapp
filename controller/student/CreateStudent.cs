/*ELABORADO POR PAULA ANDREA SIERRA GOMEZ Y CARLOS EDUARDO LOZANO TRIVIÑO
 * Esta es una clase que pertenece al paquete controlador la cual es manejada por el estudiante
 * y permite capturar los campos del formulario  para el registro de los estudiantes
*/
using UnityEngine;
using UnityEngine.UI;//necesario cuando se utilizan elementos de la interfaz de usuario en scripts
public class CreateStudent : MonoBehaviour
{
    GameObject gameObjectMistakes;

    string id;
    string names;
    string lastNames;
    string email;
    string Password;
    string degree;
    public Text idCreateStudent;
    public Text namesCreateStudent;
    public Text lastNamesCreateStudent;
    public Text emailCreateStudent;
    public InputField passwordCreateStuden;
    public Text gradoCreateStuden;

    void Start()
    {
        gameObjectMistakes = GameObject.Find("/Canvas/Message/PaEmptyFields");
    }
    /* en el siguiente metodo methodCreateStudent()
    * hace uso de corutinas en este caso  StartCoroutine
    * esta nos permite hacer uso de los metodos alojados en la clase Student en el modelo
    * se utiliza para procesos asicronos es decir que sucen en momentos de tiempo diferentes
     */
    public void methodCreateStudent()
    {
        //en las siguientes lineas de codigo igulamos nuestras variables al texto contenido dentro del formulario
        id = idCreateStudent.text;
        names = namesCreateStudent.text;
        lastNames = lastNamesCreateStudent.text;
        email = emailCreateStudent.text;
        Password = passwordCreateStuden.text;
        degree = gradoCreateStuden.text;

        //condicionales para verificar que ninguno de los campos del formulario este vacio
        if (string.IsNullOrEmpty(names) || string.IsNullOrEmpty(lastNames) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(degree) || string.IsNullOrEmpty(id))

        {

            gameObjectMistakes.gameObject.SetActive(true);
            Debug.Log("Todos los campos son obligatorios");

        }
        else
        {
            int idNumber = int.Parse(id);
            Debug.Log(" id " + idNumber + " nombre " + names + " apellido " + lastNames + " correo " + email + " contraseña " + Password + " grado " + degree);
            StartCoroutine(Main.Instance.student.CreateStudent(idNumber, names, lastNames, email, Password, degree));
        }
    }

}
