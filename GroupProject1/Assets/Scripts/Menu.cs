using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public void StartGame()
  {
    //SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void Credits()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
  }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log ("Quit");
    }
}
