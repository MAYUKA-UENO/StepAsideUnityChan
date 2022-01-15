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
        this.transform.position = new Vector3(0, 2.5f, this.unitychan.transform.position.z - this.difference);

    }
    //他のオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトを破棄
        Destroy(other.gameObject);
    }
}
