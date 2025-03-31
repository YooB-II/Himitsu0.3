using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject fadePanel; 
    public float fadeDuration = 1f;

    private void Start()
    {
        if (fadePanel != null)
        {
            fadePanel.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex + 1 < totalScenes)
        {
            StartCoroutine(LoadSceneWithFade(currentSceneIndex + 1));
        }
        else
        {
            Debug.Log("No more scenes to load!");
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        if (SceneExists(sceneName))
        {
            StartCoroutine(LoadSceneWithFade(sceneName));
        }
        else
        {
            Debug.LogError("Scene '" + sceneName + "' does not exist in Build Settings!");
        }
    }

    private bool SceneExists(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameFromPath = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            if (sceneNameFromPath == sceneName)
                return true;
        }
        return false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed!");
    }

    private IEnumerator LoadSceneWithFade(int sceneIndex)
    {
        if (fadePanel != null)
        {
            yield return StartCoroutine(FadeOut());
        }
        SceneManager.LoadScene(sceneIndex);
    }

    private IEnumerator LoadSceneWithFade(string sceneName)
    {
        if (fadePanel != null)
        {
            yield return StartCoroutine(FadeOut());
        }
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeIn()
    {
        Image panelImage = fadePanel.GetComponent<Image>();
        Color color = panelImage.color;
        float timer = fadeDuration;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            color.a = timer / fadeDuration;
            panelImage.color = color;
            yield return null;
        }

        fadePanel.SetActive(false);
    }

    private IEnumerator FadeOut()
    {
        fadePanel.SetActive(true);
        Image panelImage = fadePanel.GetComponent<Image>();
        Color color = panelImage.color;
        float timer = 0;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / fadeDuration;
            panelImage.color = color;
            yield return null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))  
        {
            LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            QuitGame();
        }
    }
}