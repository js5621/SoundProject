using UnityEngine;

public class AudioSourceSample : MonoBehaviour
{   // 0)인스펙터에서 직접 연결 하는 겨우
    public AudioSource audioSourceBgm;
    //1)의 경우 GetComponet<T>를 해당 객체가 가지고 있는 오디오소스연결 가능
    public AudioClip bgm;
    public AudioSource audioSourceSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //1)의 경우 GetComponent<T>를 통해 해당객체가 가지고 있는 오디오소스 연결가능
        //own_audioSource = GetComponent<AudioSource>()

        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        audioSourceBgm.clip = bgm;

        audioSourceBgm.Play();
        //audioSourceBgm.Pause();
        //audioSourceSFX.PlayOneShot(bgm);
        //audioSourceBgm.Stop();
        //audioSourceBgm.UnPause();//일시정지 해제
        //audioSourceBgm.PlayDelayed(1.0f);// 1초 뒤에 재생
       
    }
    // 오디오 소스 스크립트 기능
    // Update is called once per frame
    void Update()
    {
        
    }
}
