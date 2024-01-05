using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float crouchScale = 0.5f;

    void Update()
    {
        // 獲取玩家的輸入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 計算移動方向
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // 移動方塊
        transform.Translate(movement);

        // 處理蹲下
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
        // 設置蹲下時的相應動作，例如縮小方塊的大小
        transform.localScale = new Vector3(1f, crouchScale, 1f);
    }

    void StandUp()
    {
        // 設置站起來時的相應動作，例如恢復方塊的原始大小
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
