using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

// �ڵ��ϼ����� ��������� �����̴� ����Ʈ 2D�� ���� 
//RigidBody�� ������� ���� ���� ������Ʈ�� �������� �������� �̲������� �ϴ� ������ �Ҷ� ���
//ex) �̴��̹�

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider BGMVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    private void Awake()
    {
        MasterVolumeSlider.onValueChanged.AddListener(SetMasterVol);
        BGMVolumeSlider.onValueChanged.AddListener(SetBgmVol);
        SFXVolumeSlider.onValueChanged.AddListener(SetSfxVol);
    }

    private void SetSfxVol(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    private void SetBgmVol(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }

    private void SetMasterVol(float volume)
    {
        // ����� �ͼ��� ������ �ִ� �Ķ������ (Expose)�� ��ġ�� �����ϴ� ���
        audioMixer.SetFloat("Master",Mathf.Log10(volume)*20);
        // ���ֻ��Ǵ� Mathf�Լ�
        //1. Mathf.Deg2Rad
        //degree 60�й��� ���� Radian(ȣ����)�� ����ϴ� �ڵ�
        // --> ��������ڵ�
        // PI/180
        // 2. Mathf.Rad2Deg
        // ���Ȱ��� ��׸� ������ �ٲ��ݴϴ�.
        // 360/(pi*2)
        // 1 ������ �� 57��


        //3. Mathf.Abs()
        // ���� ���� ������ִ� ���

        //4.Mathf.Atan
        // ��ũ ź��Ʈ ���� ����մϴ�.

        //5. Mathf. Ceil
        //�Ҽ��� �ø� ��� 

        //6.Mathf.Clamp(value,min,max)
        //value�� min�� max������ ������ �����ϴ� ���

        //7.Mathf.Log10
        //���̽��� 10���� �����Ǿ��ִ� ���� �α׸� ��ȯ���ִ� ���
        //Mathf.Log10(100)

        //�̹� ���������� ������ͼ��� �ּ�~�ִ� ������������ �α� �Լ��� ���Ǿ����ϴ�.
        // �ּҰ� -80 �ִ밡 0
        // �׷��� ��ġ ����� Mathf.Log10((�����̴� ��ġ)*20);�� ���� ������ �����ϰ�
        // �����̴��� �ּҰ���0.01�ϰ�� -80�� 1�ϰ�� 0�� ���˴ϴ�.

    }

}
