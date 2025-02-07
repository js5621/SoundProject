using UnityEngine;

public class SoundCountrol : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip; 

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void soundPlay()
    {
        audioSource.Play();
        Debug.Log("음악 플레이중 ");

    }

    void SoundPause()
    {
        audioSource.Pause();
        Debug.Log("일시정지");
    }

    void SoundStop()
    {
        audioSource.Stop();
        Debug.Log("음악정지");

    }
}
