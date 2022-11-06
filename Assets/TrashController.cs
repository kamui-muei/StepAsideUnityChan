using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityaちゃんと壁の距離
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find ("unitychan");
        //Unityちゃんと壁の位置(z座標)の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせて壁の位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z-difference);
    }

    //ほかのオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other)
    {
        //障害物に衝突した場合
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
        {
            //接触したオブジェクトの削除
            Destroy(other.gameObject);
        }
        
    }
}
