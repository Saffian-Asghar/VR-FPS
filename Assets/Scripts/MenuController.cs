using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        Debug.Log("I am here");
        SceneManager.UnloadScene("MainMenu");
        SceneManager.LoadScene("Room");
    }


}
