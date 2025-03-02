using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

// 자동완성으로 만들어지는 슬라이더 조인트 2D의 경우는 
//RigidBody의 물리제어를 받은 게임 오브젝트가 공간에서 선을따라 미끄러지게 하는 설정을 할때 사용
//ex) 미닫이문

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
        // 오디오 믹서가 가지고 있는 파라미터의 (Expose)의 수치를 설정하는 기능
        audioMixer.SetFloat("Master",Mathf.Log10(volume)*20);
        // 자주사용되는 Mathf함수
        //1. Mathf.Deg2Rad
        //degree 60분법을 통해 Radian(호도법)을 계산하는 코드
        // --> 각도계산코드
        // PI/180
        // 2. Mathf.Rad2Deg
        // 라디안값을 디그리 값으로 바꿔줍니다.
        // 360/(pi*2)
        // 1 라디안은 약 57도


        //3. Mathf.Abs()
        // 절대 값을 계산해주는 기능

        //4.Mathf.Atan
        // 아크 탄젠트 값을 계산합니다.

        //5. Mathf. Ceil
        //소수점 올림 계산 

        //6.Mathf.Clamp(value,min,max)
        //value를 min과 max사이의 값으로 고정하는 기능

        //7.Mathf.Log10
        //베이스가 10으로 지정되어있는 수의 로그를 반환해주는 기능
        //Mathf.Log10(100)

        //이번 예제에서는 오디오믹서의 최소~최대 볼륨값때문에 로그 함수가 사용되었습니다.
        // 최소가 -80 최대가 0
        // 그래서 수치 변경시 Mathf.Log10((슬라이더 수치)*20);을 통해 범위를 설정하고
        // 슬라이더의 최소값이0.01일경우 -80이 1일경우 0이 계산됩니다.

    }

}
