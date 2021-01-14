using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    static public string daltonisme;

    private int IndexSceneMenu = 0;
    private int IndexSceneGameplay = 1;
    private int IndexSceneFin = 2;


    public Animator transition;
    public Button playButton = null;
    public Text daltonismeLabel = null;
    public float transitionTime = 1f;
    public Toggle toggle;
    void Update()
    {}

    public void LoadMenu() {
        StartCoroutine(LoadLevel(IndexSceneMenu));
    }
    public void LoadGameplay() {
        StartCoroutine(LoadLevel(IndexSceneGameplay));
    }
    public void LoadFin() {
        StartCoroutine(LoadLevel(IndexSceneFin));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        Debug.Log(levelIndex);
        Debug.Log("le daltonime est : " + daltonisme);
        transmettreInfos();
    }

    public void setDaltonisme()
    {
        if (toggle.isOn)
        {
            daltonisme = daltonismeLabel.text;
        }
        else
        {
            daltonisme = "sans";
        }
    }
    public void transmettreInfos()
    {
        GameController GC = FindObjectOfType<GameController>();
        //GC.AppliquerDaltonisme(daltonisme);
    }

}
