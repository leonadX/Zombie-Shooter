using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public GameObject arrow;
    public GameObject player;
    public Transform firePoint;

    private void Awake()
    {
        instance = this;
        player = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnArrow()
    {
        Instantiate(arrow, firePoint.position, firePoint.rotation);
    }
}
