using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isColliding = false;
    private float collisionStartTime = 0f;
    private float collisionDuration = 3f;
    public int checkPointCounter;
    private GameManager gmScript;
    public AudioSource checkPointSE;

    private void Start()
    {
        checkPointSE = GetComponent<AudioSource>();
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CLT1"))
        {
            collision.gameObject.tag = "Collided";
            Debug.Log("You have collided with a small object.");
            gmScript.setScore(-1);
            gmScript.scoreText.SetText("Current Score: {0}/{1}", gmScript.getScore(), gmScript.goalScore);
        }
        else if (collision.gameObject.CompareTag("CLT2"))
        {
            Debug.Log("You have collided with a car.");
            gmScript.setScore(-3);
            gmScript.scoreText.SetText("Current Score: {0}/{1}", gmScript.getScore(), gmScript.goalScore);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            isColliding = true;
            collisionStartTime = Time.time;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            isColliding = false;
        }
    }
    private void Update()
    {
        if (isColliding && Time.time - collisionStartTime >= collisionDuration)
        {
            GameObject checkpoint = GameObject.FindGameObjectWithTag("CheckPoint");
            GameObject npc = GameObject.FindGameObjectWithTag("ActiveNPC");
            if (checkpoint != null)
            {
                checkPointSE.gameObject.SetActive(true);
                checkPointSE.Play();
                Destroy(checkpoint);
                Destroy(npc);
                isColliding = false;        
                gmScript.GenerateCheckpoint();
            }
        }
    }

    public bool getColliding()
    {
        return isColliding;
    }


    

}
