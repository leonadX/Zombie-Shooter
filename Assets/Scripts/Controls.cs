using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    public bool handOnScreen;

    // Start is called before the first frame update
    void Awake()
    {
        handOnScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        handOnScreen = true;
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (!GameManager.instance.isGameOver)
        {
            Vector2 a = eventData.delta - (Vector2)PlayerController.instance.player.transform.position;
            a = new Vector2(a.x, 0);
            float angle = Mathf.Atan(a.x / a.y);
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, a);
            PlayerController.instance.player.transform.rotation = Quaternion.Slerp(PlayerController.instance.player.transform.rotation, targetRotation, Time.deltaTime * 1.5f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!GameManager.instance.isGameOver)
            PlayerController.instance.SpawnArrow();
        //PlayerController.instance.player.transform.rotation = Quaternion.Euler(0, 0, 0);
        handOnScreen = false;
    }
}
