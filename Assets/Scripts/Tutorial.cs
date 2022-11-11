using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour
{
    public TutorialSO tutorials;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI buttonText;
    
    
    public int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();
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
            {
                currentIndex =1;
                Timer.Register(.33f, () =>
                {
                    LeanTween.moveLocal(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 2400, 0), 1.0f).setEase(LeanTweenType.easeInOutBack);
                });
                Timer.Register(1.35f, () => {
                    GameManager.instance.EndTutorial();
                    gameObject.SetActive(false); 
                });
                return;
            }
            else if (currentIndex == tutorials.tutorial_Instructions.Length - 1)
            {
                
                buttonText.text = "Begin";
            }
            else if (currentIndex == 0)
            {
                
                buttonText.text = "Next";
            }
            tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();
        }
    }
    public void ChangePrevious()
    {

        for(int i = 0; i<=tutorials.tutorial_Instructions.Length; i++)
        {
            currentIndex--;
            if (currentIndex == -1)
                currentIndex = 0;
             tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();

            }
    }
}
