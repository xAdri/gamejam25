using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler_Script : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI[] countText;
    public GameObject[] pauseUI;
    public void TransitionScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Pause() 
    {
        Time.timeScale = 0;
        pauseUI[0].SetActive(false);
        pauseUI[1].SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseUI[0].SetActive(true);
        pauseUI[1].SetActive(false);

    }
}


