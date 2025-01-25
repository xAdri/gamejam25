using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler_Script : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI[] countText;
    public GameObject[] pauseUI;
    public bool pause, unPause;
    public void TransitionScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Pause()
    {
        if (pauseUI.Length > 1)
        {
            Time.timeScale = 0;
            pauseUI[0].SetActive(false);
            pauseUI[1].SetActive(true);
        }
        else
        {
            Debug.LogError("pauseUI array does not have the expected number of elements.");
        }
    }

    public void UnPause()
    {
        if (pauseUI.Length > 1)
        {
            Time.timeScale = 1;
            pauseUI[0].SetActive(true);
            pauseUI[1].SetActive(false);
        }
        else
        {
            Debug.LogError("pauseUI array does not have the expected number of elements.");
        }
    }
}


