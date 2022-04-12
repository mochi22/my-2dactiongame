using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;
    [SerializeField]
    float minScaleX = 4.0f;
    [SerializeField]
    float minScaleY = 3.0f;
    [SerializeField]
    float maxScaleX = 6.0f;
    [SerializeField]
    float maxScaleY = 7.0f;

    bool inCamera = false;
    Rigidbody2D rigidBody2D;

    //初期化
    void Start()
    {
        //コンポーネントを取得
        rigidBody2D = GetComponent<Rigidbody2D>();

        //壁の長さをランダムに変更
        float scaleX = Random.Range(minScaleX, maxScaleX);
        float scaleY = Random.Range(minScaleY, maxScaleY);
        transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
    }

    //物理演算
    void FixedUpdate()
    {
        rigidBody2D.velocity = Vector2.left * speed;
    }

    //消去処理
    public void DestroyBlock()
    {
        Destroy(gameObject);
    }

    //カメラ内外の判定処理
    void OnBecameVisible()
    {
        inCamera = true;
    }

    void OnBecameInvisible()
    {
        //一度画面内に入って、また出たときに消去する
        if (inCamera)
        {
            DestroyBlock();
        }
    }
}