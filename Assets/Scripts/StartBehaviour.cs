using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Credits(bool show)
    {
        panel.SetActive(show);
    }


}
