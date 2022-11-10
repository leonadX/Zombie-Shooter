using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject player;
    bool collided = false;
    public float maxDistance;
    public GameObject explosionEffect;
    public GameEvent explosionSoundEvent;
    public GameEvent PlayerexplosionSoundEvent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 0.75f)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxDistance * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject, 0.5f);
                if (!collided)
                {
                    collided = true;
                    GameManager.instance.health -= 1;
                    GameManager.instance.UpdateHealth();
                    GameObject clone = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                    Destroy(clone, 2.5f);
                    PlayerexplosionSoundEvent.Raise();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.instance.score += 1;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            GameObject clone = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(clone, 2.5f);
            explosionSoundEvent.Raise();
        }
    }


   
}
