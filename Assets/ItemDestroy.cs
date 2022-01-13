using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //画面外に出たものを消す！
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
