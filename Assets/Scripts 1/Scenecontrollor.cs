using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenecontrollor : MonoBehaviour
{
    // 요놈은 싱글톤 매니저다 이말이야   
    //public static Scenecontrollor Instance { get; private set; }

    //private void Awake()
    //{
    //    if(Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }

    //}
    private static Scenecontrollor instance;
    public static Scenecontrollor Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<Scenecontrollor>();

                if(instance == null)
                {

                    GameObject obj = new GameObject("Scenecontrollor");
                    instance = obj.AddComponent<Scenecontrollor>();

                }
            }

            return instance;
        }

    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {

            Destroy(instance);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
    
    public void ReloadCurrentscene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        LoadScene(currentSceneName);

    }

}
