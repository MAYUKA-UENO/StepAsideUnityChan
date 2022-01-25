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
    public GameObject unitychan;

    //アイテム生成スタート地点private int startPos = 80;

    //ゴール地点
    public int goalPos = 360;

    //アイテムを出すx方向の範囲
    public float posRange = 3.4f;

    //【追加】genPos
    public int genPos = 80;

    //【追加】unityちゃんのZ座標を入れるところを初期化
    public float unityZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //【追加】unityちゃんの位置を確認し、（unityちゃん＋Z50）がgenPos＝アイテム生成地点Zラインを超えたら実行
        this.unityZ = (this.unitychan.transform.position.z + 50);

        //【追加】genPos>=GoalPosなら停止したい、ということは、逆にgenPos<=goalPosのときだけ実行する
        if ((genPos <= goalPos) && (unityZ >= genPos))
        {
            Debug.Log(genPos <= goalPos);
            Debug.Log(unityZ >= genPos);
            Debug.Log("unityZは" + unityZ);

            //スタートからゴールまで一気にアイテムを出す場合はfor (int i = startPos; i < this.goalPos; i += 15)

            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
    　        　　if (num <= 2)
      　      　　{
        　      　    //コーンをx軸方向に一直線に生成
          　      　  for (float j = -1; j <= 1; j += 0.4f)
            　    　  {

              　   　 　//コーンを生成
                 　   　GameObject cone = Instantiate(conePrefab);

　              　      //ルート上すべてに出した場合はcone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);

  　          　    　　 //【追加】コーンをgenPos上に生成する
    　      　          cone.transform.position = new Vector3(4 * j, cone.transform.position.y, genPos);

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

                        　　　//ルート上すべてに出した場合はcoin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);

                        　　　//【追加】コインをgenPos上に生成する
                        　　　coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, genPos + offsetZ);

                    　　　}
                  　　　　else if (7 <= item && item <= 9)
                  　　　　{
                        　　　//車を生成
                        　　　GameObject car = Instantiate(carPrefab);

                        　　　//ルート上すべてに出した場合はcar.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);

                        　　　//【追加】車をgenPos上に生成する
                        　　　car.transform.position = new Vector3(posRange * j, car.transform.position.y, genPos + offsetZ);
                  　　　　}
                　　 }
            　　　}

            //【追加】genPosに15を足す
            genPos += 15;
            Debug.Log("genPosは" + genPos);

        }
    }
}