using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    // Load the next scene in the build index
    public void LoadNextInBuild()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
        else
        {
            Debug.LogWarning("No more scenes to load in build settings.");
        }
    }
}