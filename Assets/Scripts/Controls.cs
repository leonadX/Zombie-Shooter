using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    public GameObject hand;
    public GameObject text;
    public bool handOnScreen;

    // Start is called before the first frame update
    void Awake()
    {
        handOnScreen = false;
    }

    // Update is called once per frame
    void Start()
    {
        /*if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            hand.SetActive(true);
            text.SetActive(true);
            StartCoroutine(HandAnimation());
            PlayerPrefs.SetInt("FirstTime", 0);
        }*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        handOnScreen = true;
        //hand.SetActive(false);
        //text.SetActive(false);
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (!GameManager.instance.isGameOver)
        {
            Vector2 a = eventData.delta - (Vector2)MainPlayerController.instance.player.transform.position;
            a = new Vector2(a.x, 0);
            float angle = Mathf.Atan(a.x / a.y);
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, a);
            //targetRotation = Quaternion.Euler(0, angle * 57.296f, 0);
            MainPlayerController.instance.player.transform.rotation = Quaternion.Slerp(MainPlayerController.instance.player.transform.rotation, targetRotation, Time.deltaTime * 1.5f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!GameManager.instance.isGameOver)
            MainPlayerController.instance.SpawnArrow();
        //PlayerController.instance.player.transform.rotation = Quaternion.Euler(0, 0, 0);
        //handOnScreen = false;
    }

    public IEnumerator HandAnimation()
    {
        while(handOnScreen != true)
        {
            LeanTween.moveLocal(hand, new Vector3(270, hand.GetComponent<RectTransform>().anchoredPosition.y, 0), 1.5f).setEase(LeanTweenType.easeInOutQuint);
            yield return new WaitForSeconds(1.6f);
            LeanTween.moveLocal(hand, new Vector3(-270, hand.GetComponent<RectTransform>().anchoredPosition.y, 0), 1.0f).setEase(LeanTweenType.easeInOutQuint);
            yield return new WaitForSeconds(.6f);
        }
    }
}
