using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintingManager : MonoBehaviour
{
    string path = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DownLoadGuideFourth()
    {
        path = Application.dataPath; 
        
        Application.OpenURL("https://drive.google.com/drive/folders/1tsHk2iaPveQWKQhupX-2V6dh36iMV-OP?usp=sharing");
        
    }
    public void DownLoadGuideFifth()
    {
        path  = Application.persistentDataPath ;
        
        Application.OpenURL("https://drive.google.com/drive/folders/1MkagLEr3p06oD-Mn4ldiaboVOyUnGiy4?usp=sharing");
     
    }
    
    
}
