using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    public void LoadMenu() //�������� ����� �������� ����
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel() //�������� ����� ������
    {
        SceneManager.LoadScene(1);
    }
}
