using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;
    public Student student;
    public Teacher teacher;
    public Admin admin;
    public ActiveSession activeSession;
    public EditTeacher editTeacher;
    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        student = GetComponent<Student>();
        teacher = GetComponent<Teacher>();
        admin = GetComponent<Admin>();
        activeSession = GetComponent<ActiveSession>();
        editTeacher = GetComponent<EditTeacher>();
        score = GetComponent<Score>();


    }


}
