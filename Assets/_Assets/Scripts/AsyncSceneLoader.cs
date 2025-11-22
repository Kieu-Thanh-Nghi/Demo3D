using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField] ProgressBar progressBar;
    [SerializeField] string sceneName;
    [SerializeField] float fakeDuration;
    AsyncOperation loadingOperation;
    float startTime;

    public void StartLoadingScene()
    {
        gameObject.SetActive(true);
        startTime = Time.unscaledTime;
        DontDestroyOnLoad(this);
        loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (loadingOperation == null) return;
        float fakeProgress = (Time.unscaledTime - startTime) / fakeDuration;
        float finalProgress = Mathf.Min(fakeProgress, loadingOperation.progress);
        progressBar.SetProgressVal(finalProgress);
        if(loadingOperation.isDone && finalProgress >= 1)
        {
            StopLoadingScene();
        }
    }

    void StopLoadingScene()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
