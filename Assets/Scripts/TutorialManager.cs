using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public TutorialSO tutorials;
    public TextMeshProUGUI tutorialText;
    public int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeNext()
    {
        for(int i = 0; i<=tutorials.tutorial_Instructions.Length; i++)
        {
            
        
            currentIndex++;
            if (currentIndex == tutorials.tutorial_Instructions.Length)
                currentIndex= 0;
            tutorialText.text = tutorials.tutorial_Instructions[i].ToString();
        }
    }
    public void ChangePrevious()
    {
        for(int i = 0; i<=tutorials.tutorial_Instructions.Length; i++)
        {
            
        
            currentIndex--;
            if (currentIndex == -1)
                currentIndex = tutorials.tutorial_Instructions.Length - 1;
            tutorialText.text = tutorials.tutorial_Instructions[i].ToString();

            
        }

        
    }
}
