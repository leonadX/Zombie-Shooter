using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int health;
    public GameEvent GameOver;
    public GameEvent OnEndTutorial;
    public GameObject HealthUI;
    public GameObject ScorePanel;
    public TextMeshProUGUI scoreText;
    public bool isGameOver;
    public bool StartGame;

    void Awake()
    {
        instance = this;
        isGameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        score = 0;
        scoreText.text = score.ToString();

        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            StartGame = false;
            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
            StartGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHealth()
    {
        for(int i = HealthUI.transform.childCount; i > health; i--)
        {
            Debug.Log(i);
            HealthUI.transform.GetChild(i - 1).gameObject.SetActive(false);
        }

        if(health == 0)
        {
            MainPlayerController.instance.StopFiring();
            MainPlayerController.instance.animator.SetTrigger("Death");
            GameObject go = MainPlayerController.instance.InputSlider.gameObject;
            LeanTween.moveLocal(go, go.GetComponent<RectTransform>().localPosition + new Vector3(0, -500, 0), 1.5f);
            LeanTween.moveLocal(ScorePanel, ScorePanel.GetComponent<RectTransform>().localPosition + new Vector3(0, 500, 0), 1.5f);
            isGameOver = true;
            Timer.Register(3.0f, () =>
            {
                GameOver.Raise();
            });
        }
    }

    public void Retry()
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
            SceneLoader.instance.OpenMenuScene();
        });
    }

    public void PauseGame()
    {
        PausePanel.pausePanel.transform.GetChild(0).GetComponent<RectTransform>().localScale = Vector3.zero;
        LeanTween.scale(PausePanel.pausePanel.transform.GetChild(0).gameObject, new Vector3(1, 1, 1), .5f).setEase(LeanTweenType.easeOutBack);
        Timer.Register(.53f, () =>
        {
            Time.timeScale = 0f;
        });
    }
    
    public void EndTutorial()
    {
        OnEndTutorial.Raise();
        StartGame = true;
    }
}
