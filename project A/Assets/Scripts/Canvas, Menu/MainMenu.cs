using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ExitGame()
    {
        
        Application.Quit();
    }
    public void LoadDemo()
    {
        SceneManager.LoadScene(1);
    }
}
