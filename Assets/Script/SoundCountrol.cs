using UnityEngine;

public class SoundCountrol : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip; 

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void soundPlay()
    {
        audioSource.Play();
        Debug.Log("���� �÷����� ");

    }

    void SoundPause()
    {
        audioSource.Pause();
        Debug.Log("�Ͻ�����");
    }

    void SoundStop()
    {
        audioSource.Stop();
        Debug.Log("��������");

    }
}
