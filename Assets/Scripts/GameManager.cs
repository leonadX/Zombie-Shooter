using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int health;
    public GameEvent GameOver;
    public GameObject HealthUI;
    public TextMeshProUGUI scoreText;
    public bool isGameOver;

    private void Awake()
    {
        instance = this;
        isGameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        score = 0;
        scoreText.text = "score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + score.ToString();
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
            isGameOver = true;
            GameOver.Raise();
        }
    }
}
