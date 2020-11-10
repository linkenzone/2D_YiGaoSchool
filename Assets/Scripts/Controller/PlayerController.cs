using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制2D角色的移动
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        // 获取角色的刚体，通过刚体控制角色移动
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");//控制水平移动方向
        float moveY = Input.GetAxisRaw("Vertical");//控制垂直移动方向
        Vector2 moveDir = new Vector2(moveX, moveY); // 获取角色的移动方向
        moveDir.Normalize(); // 执行标准化，到(0,1)区间
        // 角色的移动
        rbody.MovePosition(rbody.position + moveDir * speed * Time.fixedDeltaTime);
    }
}
