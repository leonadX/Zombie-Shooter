using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public TutorialSO tutorials;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI buttonText;
    public GameObject hand;
    public GameObject nextButton;
    public GameObject prevButton;
    public int currentIndex;
    // Start is called before the first frame update

    private void Awake()
    {
        PlayerPrefs.SetInt("FirstTime", 0);
        if (PlayerPrefs.GetInt("FirstTime") == 1)
        {
            gameObject.SetActive(false);
        }
        
    }

    void Start()
    {
        LeanTween.moveLocal(gameObject.transform.GetChild(1).gameObject, Vector3.zero, 1.5f).setEase(LeanTweenType.easeInOutBack);
        currentIndex = -1;
        tutorialText.GetComponent<RectTransform>().localScale = Vector3.zero;
        Invoke("ChangeNext", 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeNext()
    {
        /*for(int i = 0; i<=tutorials.tutorial_Instructions.Length; i++)
        {*/
            currentIndex++;
            if (currentIndex + 1 != tutorials.tutorial_Instructions.Length)
                tutorialText.GetComponent<RectTransform>().localScale = Vector3.zero;

            
            if (currentIndex == tutorials.tutorial_Instructions.Length)
            {
                //currentIndex = 0;
                
                Timer.Register(.33f, () =>
                {
                    LeanTween.moveLocal(gameObject.transform.GetChild(1).gameObject, new Vector3(0, 2400, 0), 1.0f).setEase(LeanTweenType.easeInOutBack);
                });
                Timer.Register(1.35f, () => {
                    GameManager.instance.EndTutorial();
                    gameObject.SetActive(false); 
                });
                return;
            }

            if (currentIndex == tutorials.tutorial_Instructions.Length - 1)
            {
                hand.SetActive(true);
                buttonText.text = "Begin";
                StartCoroutine(HandAnimation());
            }

            tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();
            LeanTween.scale(tutorialText.gameObject, Vector3.one, .3f).setEase(LeanTweenType.easeInOutBack);
        //}
    }
    public void ChangePrevious()
    {
        for(int i = 0; i<=tutorials.tutorial_Instructions.Length; i++)
        {
            
        
            currentIndex--;
            if (currentIndex == -1)
                
                currentIndex = tutorials.tutorial_Instructions.Length - 1;

            tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();

            
        }

        
    }

    public IEnumerator HandAnimation()
    {
        while (true)
        {
            LeanTween.moveLocal(hand, new Vector3(506, hand.GetComponent<RectTransform>().localPosition.y, 0), 1.5f).setEase(LeanTweenType.easeInOutQuint);
            yield return new WaitForSeconds(1.6f);
            LeanTween.moveLocal(hand, new Vector3(66, hand.GetComponent<RectTransform>().localPosition.y, 0), 1.0f).setEase(LeanTweenType.easeInOutQuint);
            yield return new WaitForSeconds(1.6f);
        }
    }
}
