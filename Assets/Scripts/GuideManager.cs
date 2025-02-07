using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuideManager : MonoBehaviour
{
    public Button backButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToHome()
    {
        SceneManager.LoadScene(0);
    }
}
