using UnityEngine;
using UnityEngine.Audio;

public class AudioBoardVisualizer : MonoBehaviour
{

    public float minBoard = 50.0f;
    public float maxBoard = 500f;
    //사용할 오디오 클립
    public AudioClip audioClip;
    // 사용할 오디오소스
    public AudioSource audioSource;
    public Board[] boards;
    public AudioMixer audioMixer;

    public int samples = 64;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    // 오브젝트를 만들어서 등록해주는 코드
    void Start()
    {
        boards = GetComponentsInChildren<Board>();
        if (audioSource == null)
        {
            audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            
        }
        else
        {
            audioSource= GameObject.Find("AudioSource").GetComponent<AudioSource>();
   
        }

        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        //GetSPectruemData(sample,channel, FFTWindow);

        //samples =FFT(신호에 대한 주파수영역)을 저장할 배열, 이 배열값은 2의 제곱수로 표현합니다.
        // 채널은 최대 8개의 채널을 지원해주고 있음. 일반적으로는 0을 사용합닏.
        //FFTWindow는 샘플링 진행할때 쓰는값
        for (int i = 0; i < data.Length; i++)
        {
            var size = boards[i].GetComponent<RectTransform>().rect.size;

            size.y = minBoard +(data[i] *(maxBoard - minBoard))*3.0f;
            boards[i].GetComponent<RectTransform>().sizeDelta = size;
            //sizeDelta는 부모를 기준으로 크기가 얼마나 큰지 작은지를 나타낸 수치를 의미합니다.

        }
    }
}
