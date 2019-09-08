using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCore : MonoBehaviour {

    [SerializeField]
    private MoveTutorial[] _moveTutorial;

    [SerializeField]
    private GameObject _successText;

    [SerializeField]
    private GameObject _striker;

    [SerializeField]
    private GameObject _doingTutorial;

    [SerializeField]
    private TutorialButton _tutorialButton;

    [SerializeField]
    private GameObject _spawnController;

    [SerializeField]
    private GameObject _enemySpawn;

    [SerializeField]
    private MoveDefault _moveDefault;

    public AudioClip _tutorialDescriptionVoice;
    public AudioClip _moveTutorialVoice;
    public AudioClip _weaponCannonVoice;
    public AudioClip _weaponMissileVoice;
    public AudioClip _evadeTutorialVoice;
    public AudioClip _flareTutorialVoice;

    private AudioSource _voice1;
    private AudioSource _voice2;
    private AudioSource _voice3;
    private AudioSource _voice4;
    private AudioSource _voice5;
    private AudioSource _voice6;

    private bool _spawnTutorialEnemy = false;
    private bool _tutorialDirection = false;
    private bool _returnDefault = false;
    public bool ReturnDefault {
        get {
            return _returnDefault; 
        }
    }
    
    
    
    void Start () {
        _voice1 = gameObject.GetComponent<AudioSource>();
        _voice2 = gameObject.GetComponent<AudioSource>();
        _voice3 = gameObject.GetComponent<AudioSource>();
        _voice4 = gameObject.GetComponent<AudioSource>();
        _voice5 = gameObject.GetComponent<AudioSource>();
        _voice6 = gameObject.GetComponent<AudioSource>();
        _voice1.clip = _tutorialDescriptionVoice;
        _voice1.Play();
    }

    void Update () {
        if (_tutorialButton._beginTutorial == true) {
            _voice1.Stop();
            _voice2.clip = _moveTutorialVoice;
            _voice2.Play();
            _striker.GetComponent<PlayerController>().enabled = true;
        }

        for (int i = 0; i < _moveTutorial.Length; i++) {
            if (_moveTutorial[i].BattleTutorialFlg) {
                StartCoroutine(CannonTutorial());
            }
        }

        if (_moveDefault.EndReturnMove) {
          
            _spawnTutorialEnemy = true;
            _voice3.clip = _weaponCannonVoice;
            _voice3.Play();
            
            
        }

        // if () {
        //     StartCoroutine(CannonTutorial());
        // }
    }

    // 成功表示が出たら初期位置まで自機を誘導してその間は操作不能にする

    // 全ての敵を倒したら次のチュートリアルに移行する
    // 敵一体ずつ配列型に格納して撃破判定はバレットのタグが当たったらにする

    public IEnumerator CannonTutorial() {
        _successText.SetActive(true);
        _returnDefault = true;
        yield return new WaitForSeconds(2.0f);
         _successText.SetActive(false);

        if (_spawnTutorialEnemy) {
            //_enemySpawn = Instantiate(_spawnController, _enemySpawn.transform.position, Quaternion.identity);
            _spawnTutorialEnemy = false;
        }
        
    }

    public IEnumerator MissileTutorial() {
        
        yield return null;
    }

    // public IEnumerator SuccessText() {

    // }
}