using UnityEngine;

public class AudioStartDelay : MonoBehaviour
{
    public float delayTime = 35f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.time = delayTime;
    }
}