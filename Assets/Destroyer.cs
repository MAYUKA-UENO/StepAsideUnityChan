using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    //デストロイヤーを移動させるコンポーネント
    private Rigidbody myRigidbody;

    //前方向の速度
    private float velocityZ = 16f;


    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyコンポーネント取得
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //デストロイヤーに速度を与える
        this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);

    }

    //Unityちゃんに接触したら消える
    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトのタグがUnityだったら
        if (other.gameObject.tag == "UnityChanTag")
        {
            Destroy(this.gameObject);
        }
    }

}
