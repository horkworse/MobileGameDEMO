using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame() //�����
    {
        Application.Quit();
    }

    public void LoadDemo() //�������� ���� ������
    {
        SceneManager.LoadScene(1);
    }
}