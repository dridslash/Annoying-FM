using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamThirdPersonControl : MonoBehaviour
{
    public static CamThirdPersonControl instance;
    public Transform target;
    float cameraAngle;
    float cameraAngleSpeed = 0.2f;
    // CinemachineVirtualCamera vCam;
    // CinemachineBasicMultiChannelPerlin vCamNoise;
    public CinemachineVirtualCamera vThirdPersonCam;
    public CinemachineVirtualCamera vLastHitCam;
    public CinemachineVirtualCamera vDeathCam;
    CinemachineBasicMultiChannelPerlin vLastHitCamNoise;

    private void Awake()
    {
        instance = this;
        // vCam = GetComponent<CinemachineVirtualCamera>();
        // vCamNoise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    IEnumerator Start()
    {
        while (!vLastHitCam)
        {
            yield return null;
        }

        // vLastHitCamNoise = vLastHitCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    //private void LateUpdate()
    //{
    //    OnLook(UIManager.instance.lookTouchField.TouchDist);
    //}

    public Vector3 cameraPosition = new Vector3(0, 7, 12);
    public void OnLook(Vector2 direction)
    {
        int dir = 0;
        float keyboardCameraSpeed = 5;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -1;
        }
        // Debug.Log("direction.x: " + direction.x);
        cameraAngle += (direction.x + (dir * keyboardCameraSpeed)) * cameraAngleSpeed;

        vThirdPersonCam.transform.position = target.position + Quaternion.AngleAxis(cameraAngle, Vector3.up) * cameraPosition;
        vThirdPersonCam.transform.rotation = Quaternion.LookRotation(target.position + Vector3.up * 2 - vThirdPersonCam.transform.position, Vector3.up);
    }

    public void ShakeCam(float amplitudeGain, float frequencyGain, float shakeTiming)
    {
        StartCoroutine(_ProcessShake(amplitudeGain, frequencyGain, shakeTiming));
    }

    public void SpawnCam()
    {
        //should get cam rotation from current spawn
        // cameraAngle = 0;
        // vThirdPersonCam.transform.position = target.position + Quaternion.AngleAxis(cameraAngle, Vector3.up) * cameraPosition;
        // vThirdPersonCam.transform.rotation = SpawnManager.instance.CurrentSpawn().rotation;
    }

    private IEnumerator _ProcessShake(float amplitudeGain, float frequencyGain, float shakeTiming)
    {
        Noise(amplitudeGain, frequencyGain);
        yield return new WaitForSeconds(shakeTiming);
        Noise(0, 0);
    }

    public void Noise(float amplitudeGain, float frequencyGain)
    {
        vLastHitCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitudeGain;
        vLastHitCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequencyGain;
    }
}
