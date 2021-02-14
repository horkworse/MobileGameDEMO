using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame() //Выход
    {
        Application.Quit();
    }

    public void LoadDemo() //Загрузка демо уровня
    {
        SceneManager.LoadScene(1);
    }
}
