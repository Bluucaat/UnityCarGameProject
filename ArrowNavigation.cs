using UnityEngine;

public class Navigation : MonoBehaviour
{
    public Transform checkPoint;
    public float arrowspeed;

    private void Start()
    {
        checkPoint = GameObject.FindGameObjectWithTag("CheckPoint").transform; 
    }
    void Update()
    {
        try
        {
            Vector3 relativePos = checkPoint.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }
        catch (System.Exception)
        {
            checkPoint = GameObject.FindGameObjectWithTag("CheckPoint").transform;
        }
    }
}
