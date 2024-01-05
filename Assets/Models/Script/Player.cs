using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float crouchScale = 0.5f;

    void Update()
    {
        // ������a����J
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �p�Ⲿ�ʤ�V
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // ���ʤ��
        transform.Translate(movement);

        // �B�z�ۤU
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch();
        }
        else
        {
            StandUp();
        }
    }

    void Crouch()
    {
        // �]�m�ۤU�ɪ������ʧ@�A�Ҧp�Y�p������j�p
        transform.localScale = new Vector3(1f, crouchScale, 1f);
    }

    void StandUp()
    {
        // �]�m���_�Ӯɪ������ʧ@�A�Ҧp��_�������l�j�p
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
