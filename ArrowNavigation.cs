
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public Transform checkPoint;
    public float arrowspeed;

    private void Start()
    {
        try
        {
            checkPoint = GameObject.FindGameObjectWithTag("CheckPoint").transform;
        }catch(System.Exception)
        {
        }
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
