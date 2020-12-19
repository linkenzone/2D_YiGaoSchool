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

    // 人物朝向
    private Vector2 lookDirection;

    // 人物移动的方向
    private Vector2 moveDir;
    
    // 动画组件
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // 初始化人物朝向
        lookDirection = new Vector2(0, -1);

        // 获取角色的刚体，通过刚体控制角色移动
        rbody = GetComponent<Rigidbody2D>();

        // 获取动画组件
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");//控制水平移动方向
        float moveY = Input.GetAxisRaw("Vertical");//控制垂直移动方向
        moveDir = new Vector2(moveX, moveY); // 获取角色的移动方向
        moveDir.Normalize(); // 执行标准化，到(0,1)区间

        if (moveDir.x != 0 || moveDir.y != 0)
        {
            lookDirection = moveDir;
        }
        else
        {
            // do someting...
        }

        anim_setting();
        Movement();
    }

    private void FixedUpdate()
    {

    }

    void Movement()//移动
    {
        rbody.MovePosition(rbody.position + moveDir * speed * Time.fixedDeltaTime);
    }

    //动画的设置
    void anim_setting()
    {
        anim.SetFloat("Look X", lookDirection.x);
        anim.SetFloat("Look Y", lookDirection.y);
        anim.SetFloat("Speed", moveDir.magnitude);
    }
}
