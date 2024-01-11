using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().name == "TitleScreen") Application.Quit();
            else SceneManager.LoadScene("TitleScreen");
        }

    }

    public static void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
