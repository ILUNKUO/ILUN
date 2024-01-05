using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform player;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public float switchSpeed = 5f;

    private bool isFirstPerson = true;
    private Vector3 firstPersonCameraPosition;
    private Vector3 thirdPersonCameraPosition;
    private Quaternion firstPersonCameraRotation;
    private Quaternion thirdPersonCameraRotation;

    void Start()
    {
        // 記錄攝影機的初始位置和旋轉
        firstPersonCameraPosition = firstPersonCamera.transform.localPosition;
        firstPersonCameraRotation = firstPersonCamera.transform.localRotation;

        thirdPersonCameraPosition = thirdPersonCamera.transform.localPosition;
        thirdPersonCameraRotation = thirdPersonCamera.transform.localRotation;

        // 開始時啟用第一人稱視角
        SwitchToFirstPerson();
    }

    void Update()
    {
        // 按下切換按鈕（例如，Tab鍵）來切換視角
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isFirstPerson)
            {
                SwitchToThirdPerson();
            }
            else
            {
                SwitchToFirstPerson();
            }
        }
    }

    void SwitchToFirstPerson()
    {
        // 啟用第一人稱相機，禁用第三人稱相機
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;

        // 平滑過渡攝影機的位置和旋轉
        StartCoroutine(LerpCameraTransform(firstPersonCamera, firstPersonCameraPosition, firstPersonCameraRotation));

        isFirstPerson = true;
    }

    void SwitchToThirdPerson()
    {
        // 啟用第三人稱相機，禁用第一人稱相機
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = true;

        // 平滑過渡攝影機的位置和旋轉
        StartCoroutine(LerpCameraTransform(thirdPersonCamera, thirdPersonCameraPosition, thirdPersonCameraRotation));

        isFirstPerson = false;
    }

    IEnumerator LerpCameraTransform(Camera camera, Vector3 targetPosition, Quaternion targetRotation)
    {
        float elapsedTime = 0f;

        while (elapsedTime < switchSpeed)
        {
            camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, targetPosition, elapsedTime / switchSpeed);
            camera.transform.localRotation = Quaternion.Lerp(camera.transform.localRotation, targetRotation, elapsedTime / switchSpeed);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 確保最終位置和旋轉的精確性
        camera.transform.localPosition = targetPosition;
        camera.transform.localRotation = targetRotation;
    }
}