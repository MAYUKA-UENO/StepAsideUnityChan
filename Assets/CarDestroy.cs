using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroy : MonoBehaviour
{

    //carPrefabを入れる
    public GameObject carPrefab;

    //デストロイヤーを入れる
    public GameObject Destroyer;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Destroyerに当たったら消える！
    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトのタグがdestroyerだったら
        if(other.gameObject.tag == "DestroyerTag")
        { 
        Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
