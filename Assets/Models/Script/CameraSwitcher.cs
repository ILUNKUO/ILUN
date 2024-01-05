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
        // �O����v������l��m�M����
        firstPersonCameraPosition = firstPersonCamera.transform.localPosition;
        firstPersonCameraRotation = firstPersonCamera.transform.localRotation;

        thirdPersonCameraPosition = thirdPersonCamera.transform.localPosition;
        thirdPersonCameraRotation = thirdPersonCamera.transform.localRotation;

        // �}�l�ɱҥβĤ@�H�ٵ���
        SwitchToFirstPerson();
    }

    void Update()
    {
        // ���U�������s�]�Ҧp�ATab��^�Ӥ�������
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
        // �ҥβĤ@�H�٬۾��A�T�βĤT�H�٬۾�
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;

        // ���ƹL����v������m�M����
        StartCoroutine(LerpCameraTransform(firstPersonCamera, firstPersonCameraPosition, firstPersonCameraRotation));

        isFirstPerson = true;
    }

    void SwitchToThirdPerson()
    {
        // �ҥβĤT�H�٬۾��A�T�βĤ@�H�٬۾�
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = true;

        // ���ƹL����v������m�M����
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

        // �T�O�̲צ�m�M���઺��T��
        camera.transform.localPosition = targetPosition;
        camera.transform.localRotation = targetRotation;
    }
}