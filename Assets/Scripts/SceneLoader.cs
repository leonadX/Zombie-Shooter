using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField] RectTransform fader;
    public static SceneLoader instance;
    void Awake()
    {
        instance = this;
        
    }
    public void OpenMenuScene()
    {
        
        fader.gameObject.SetActive(true);
        
        LeanTween.scale(fader, Vector3.zero,0f);
        LeanTween.scale(fader,new Vector3(1,1,1),0.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
            {
                SceneManager.LoadScene(0);
                });
    }
    public void OpenGameScene()
    {
    
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero,0f);
        LeanTween.scale(fader,new Vector3(1,1,1),0.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
            {
                SceneManager.LoadScene(1);
                });
    }

    }