using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;

    //coinPrefabを入れる
    public GameObject coinPrefab;

    //conePrefabを入れる
    public GameObject conePrefab;

    //Unityちゃんのオブジェクトを入れる
    private GameObject unitychan;

    //スタート地点
    private int startPos = 80;

    //ゴール地点
    private int goalPos = 360;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんから前のアイテム生成OKスパン
    private float span;

    //インターバルと経過時間のカウント
    private float interval;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {

        //Unityちゃんのオブジェクトを取得
        unitychan = GameObject.Find("unitychan");

        //１秒間隔で発生
        interval = 1;

    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの前のアイテム生成スパン指定
        span = unitychan.transform.position.z + 50;

        //時間計測
        time += Time.deltaTime;


        //時間がインターバル１秒以上になったときに発動
        if (time > interval)
        { 

        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < span; i += 15)
            {

                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {

                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);

                    }

                }

                else

                {
                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)

                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);

                        //60%コイン配置：30%車配置：10％何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コイン生成
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }

                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }
                    }
                }
            }

　　　　　　　//時間カウントをリセット
            time = 0;

        }
    }


}
