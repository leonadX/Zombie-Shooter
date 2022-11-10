using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void animate()
    {
        LeanTween.scale(gameObject, new Vector3(.5f, .5f, .5f), .15f).setEase(LeanTweenType.easeOutQuint);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), .15f).setDelay(.15f).setEase(LeanTweenType.easeOutQuint);
    }
}
