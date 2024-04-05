using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//added using UnityEngine.SceneManagement this allows for scene management functions to be called within the script.
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
