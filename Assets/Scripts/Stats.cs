using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public GameObject retry;
    public GameObject home;
    public TextMeshProUGUI defeated;

    // Start is called before the first frame update
    void Start()
    {
        defeated.text += GameManager.instance.score;
        LeanTween.moveLocal(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 0, 0), 1.5f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.scale(defeated.gameObject, new Vector3(1, 1, 1), .5f).setDelay(1.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(retry, new Vector3(1, 1, 1), .5f).setDelay(1.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(home, new Vector3(1, 1, 1), .5f).setDelay(1.5f).setEase(LeanTweenType.easeOutBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
