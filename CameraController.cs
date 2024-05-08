using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
     player = GameObject.FindWithTag("Player");
    }
    void LateUpdate()
    {
        transform.LookAt(player.transform.position);
    }
}
