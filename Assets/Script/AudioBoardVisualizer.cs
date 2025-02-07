using UnityEngine;
using UnityEngine.Audio;

public class AudioBoardVisualizer : MonoBehaviour
{

    public float minBoard = 50.0f;
    public float maxBoard = 500f;
    //����� ����� Ŭ��
    public AudioClip audioClip;
    // ����� ������ҽ�
    public AudioSource audioSource;
    public Board[] boards;
    public AudioMixer audioMixer;

    public int samples = 64;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    // ������Ʈ�� ���� ������ִ� �ڵ�
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

        //samples =FFT(��ȣ�� ���� ���ļ�����)�� ������ �迭, �� �迭���� 2�� �������� ǥ���մϴ�.
        // ä���� �ִ� 8���� ä���� �������ְ� ����. �Ϲ������δ� 0�� ����Ո�.
        //FFTWindow�� ���ø� �����Ҷ� ���°�
        for (int i = 0; i < data.Length; i++)
        {
            var size = boards[i].GetComponent<RectTransform>().rect.size;

            size.y = minBoard +(data[i] *(maxBoard - minBoard))*3.0f;
            boards[i].GetComponent<RectTransform>().sizeDelta = size;
            //sizeDelta�� �θ� �������� ũ�Ⱑ �󸶳� ū�� �������� ��Ÿ�� ��ġ�� �ǹ��մϴ�.

        }
    }
}
