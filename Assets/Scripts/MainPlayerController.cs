using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayerController : MonoBehaviour
{
    public static MainPlayerController instance;
    public GameObject arrow;
    public GameObject player;
    public Transform firePoint;
    public Slider InputSlider;
    public Animator animator;

    private void Awake()
    {
        instance = this;
        player = gameObject;
        InputSlider.value = 0.5f;
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.StartGame)
            StartFiring();
    }

    public void StartFiring()
    {
        InvokeRepeating("SpawnArrow", .5f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, InputSlider.value * 80 - 130, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, .7f);
    }

    public void SpawnArrow()
    {
        Instantiate(arrow, firePoint.position, firePoint.rotation);
    }

    public void StopFiring()
    {
        CancelInvoke("SpawnArrow");
    }
}
