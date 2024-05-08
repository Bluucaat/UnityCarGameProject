using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isColliding = false;
    private float collisionStartTime = 0f;
    private float collisionDuration = 2f;
    public int checkPointCounter;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CLT1"))
        {
            collision.gameObject.tag = "Collided";
            Debug.Log("You have collided with a small object.");
        }
        else if (collision.gameObject.CompareTag("CLT2"))
        {
            Debug.Log("You have collided with a car.");
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
                Destroy(checkpoint);
                Destroy(npc);
                isColliding = false;        
                gameManager.GetComponent<CheckPointUpdate>().GenerateCheckpoint();
            }
        }
    }


    

}
