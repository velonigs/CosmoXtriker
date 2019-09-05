using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCore : MonoBehaviour {

    [SerializeField]
    private GameObject _successText;

    [SerializeField]
    private GameObject _striker;

    [SerializeField]
    private GameObject _doingTutorial;

    [SerializeField]
    private TutorialButton _tutorialButton;

    public AudioClip _tutorialDescription;
    public AudioClip _moveTutorial;

    private AudioSource _voice1;
    private AudioSource _voice2;

    private bool _EndMoveTutorial = false;

    public enum TutorialWaves {
        Move,
        Battle,
        Evade,
        Flare
    }
    public TutorialWaves _tutorialWaves;
    
    void Start () {
        _voice1 = gameObject.GetComponent<AudioSource>();
        _voice2 = gameObject.GetComponent<AudioSource>();
        _voice1.clip = _tutorialDescription;
        _voice1.Play();
    }

    // enum TutorialWavesをForで回してチュートリアルのフローを作る
    void Update () {
        if (_tutorialButton._beginTutorial == true) {
            _voice1.Stop();
            _voice2.clip = _moveTutorial;
            _voice2.Play();
            _striker.GetComponent<PlayerController>().enabled = true;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (_striker.gameObject.tag == "EndMoveTutorial") {
            _tutorialButton._beginTutorial = true;
            StartCoroutine(SuccessText());
            _EndMoveTutorial = true;
        }
    }

    IEnumerator SuccessText() {
        _successText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        _successText.SetActive(false);
    }
}