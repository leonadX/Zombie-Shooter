using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject player;
    bool collided = false;
    public float maxDistance;
    public Animator zombie;
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
                Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, maxDistance * Time.deltaTime);
                /*Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, targetPosition);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * .5f);*/
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
        if(GameManager.instance.scoreText.color == Color.green)
        {

            
            Invoke("ChangeScoreColorWhite",0.5f);
        }
    }
    void ChangeScoreColorGreen()
    {
        
        GameManager.instance.scoreText.color= Color.green;
    
        
    }
    void ChangeScoreColorWhite()
    {
        GameManager.instance.scoreText.color= Color.white;
        
        
    }
    public void UpdateScore()
    {
        GameManager.instance.score += 1;
        Invoke("ChangeScoreColorGreen",0f);
        
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            UpdateScore();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            GameObject clone = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(clone, 2.5f);
            explosionSoundEvent.Raise();
        }
    }


   
}
