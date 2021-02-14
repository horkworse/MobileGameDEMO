using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    public void LoadMenu() //Загрузка сцены главного меню
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(2);
    }

    public void LoadLevel() //Загрузка сцены уровня
    {
        SceneManager.LoadScene(1);
    }
}
