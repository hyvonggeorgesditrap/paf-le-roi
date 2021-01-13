using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public Button playButton = null;
    public float transitionTime = 1f;
    
    void Update()
    {
        //if(playButton != null)
            //playButton.onClick.AddListener(LoadNextLevel);
        if (Input.GetMouseButtonDown(0))
            LoadNextLevel();

        
    }

    public void LoadNextLevel()
    {
        //playButton.onClick.RemoveAllListeners();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }


}
