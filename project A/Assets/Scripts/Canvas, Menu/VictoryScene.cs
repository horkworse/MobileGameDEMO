using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public void LoadMenu() //Загрузка сцены главного меню
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel() //Загрузка сцены уровня
    {
        SceneManager.LoadScene(1);
    }
}
