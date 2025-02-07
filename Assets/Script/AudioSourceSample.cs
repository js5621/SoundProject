using UnityEngine;

public class AudioSourceSample : MonoBehaviour
{   // 0)�ν����Ϳ��� ���� ���� �ϴ� �ܿ�
    public AudioSource audioSourceBgm;
    //1)�� ��� GetComponet<T>�� �ش� ��ü�� ������ �ִ� ������ҽ����� ����
    public AudioClip bgm;
    public AudioSource audioSourceSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //1)�� ��� GetComponent<T>�� ���� �ش簴ü�� ������ �ִ� ������ҽ� ���ᰡ��
        //own_audioSource = GetComponent<AudioSource>()

        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        audioSourceBgm.clip = bgm;

        audioSourceBgm.Play();
        //audioSourceBgm.Pause();
        //audioSourceSFX.PlayOneShot(bgm);
        //audioSourceBgm.Stop();
        //audioSourceBgm.UnPause();//�Ͻ����� ����
        //audioSourceBgm.PlayDelayed(1.0f);// 1�� �ڿ� ���
       
    }
    // ����� �ҽ� ��ũ��Ʈ ���
    // Update is called once per frame
    void Update()
    {
        
    }
}
