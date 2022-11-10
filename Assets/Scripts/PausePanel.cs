using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public static PausePanel pausePanel;

    private void Awake()
    {
        pausePanel = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<RectTransform>().localScale = Vector3.zero;
        LeanTween.scale(transform.GetChild(0).gameObject, new Vector3(1, 1, 1), .5f).setEase(LeanTweenType.easeOutBack);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Timer.Register(.33f, () =>
        {
            SceneManager.LoadScene("GameScene");
        });
    }

    public void GoToMenu()
    {
        Timer.Register(.33f, () =>
        {
            SceneManager.LoadScene("MainMenuScene");
        });
    }

    public void Resume()
    {
        Timer.Register(.33f, () =>
        {
            gameObject.SetActive(false);
        });
    }
}
