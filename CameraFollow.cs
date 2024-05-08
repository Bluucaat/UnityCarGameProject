using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    void Start()
    {
        player = GameObject.FindWithTag("Player");       
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }
}