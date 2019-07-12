using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{

    [SerializeField]
    float minVal = -5;
    [SerializeField]
    float maxVal = 5;
// 出現させる敵を入れておく
[SerializeField] GameObject[] enemys;
// 次に敵が出現するまでの時間
[SerializeField] float appearNextTime;
//この場所から出現する敵の数
[SerializeField] int maxNumOfEnemys;
//　今何人の敵を出現させたか
private int numberOfEnemys;
//  待ち時間計測フィールド
private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //　この場所から出現する最大を超えてたら何もしない
        if (numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }
        //　経過時間を足す
        elapsedTime += Time.deltaTime;

        //　経過時間がたったら
        if (elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;

            AppearEnemy ();
        }

        //　敵出現メソッド
        void AppearEnemy() {
	    //　出現させる敵をランダムに選ぶ
	    var randomValue = Random.Range (0, enemys.Length);
	    //　敵の向きをランダムに決定
	    var randomRotationY = Random.value * 360f;
            // randomPosition
            float randomx = Random.Range(minVal, maxVal);
            float randomy = Random.Range(minVal, maxVal);
            
            Vector3 randoPos =new Vector3 (transform.position.x + randomx, transform.position.y + randomy, transform.position.z );
            //GameObject.Instantiate (enemys[randomValue], transform.position, Quaternion.Euler (0f, randomRotationY, 0f));
            GameObject.Instantiate(enemys[randomValue], randoPos, Quaternion.Euler(0f, randomRotationY, 0f));
            numberOfEnemys++;
	    elapsedTime = 0f;
        }
    }
}
