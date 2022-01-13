using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    //Unityちゃんのオブジェクトの宣言
    private GameObject unitychan;

    //Unityちゃんと見えない壁の距離の宣言
    private float difference;

    //見えない壁を移動させるコンポーネント入れる
    private Rigidbody myRigidbody;

    //前方向の速度
    private float velocityZ = 16f;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        //Unityちゃんと見えない壁の位置Z座標の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;

        //Rigidbodyコンポーネント取得
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせて見えない壁の位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);

        //Unityちゃんに速度を与える
        this.myRigidbody.velocity = new Vector3(0, 0, velocityZ);
    }

}
