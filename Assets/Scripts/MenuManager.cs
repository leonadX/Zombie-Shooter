using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject placeHolder;
    public GameObject play;
    public GameObject quit;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocal(placeHolder, new Vector3(0, 0, 0), 1.5f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveLocal(play, new Vector3(0, play.GetComponent<RectTransform>().anchoredPosition.y, 0), 1.5f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveLocal(quit, new Vector3(0, quit.GetComponent<RectTransform>().anchoredPosition.y, 0), 1.5f).setEase(LeanTweenType.easeInOutBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        Timer.Register(.33f, () =>
        {
            SceneManager.LoadScene("GameScene");
        });
    }

    public void Quit()
    {
        Application.Quit();
    }
}
