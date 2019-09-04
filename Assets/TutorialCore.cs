using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCore : MonoBehaviour {

    [SerializeField]
    private GameObject _doingTutorial;

    [SerializeField]
    private TutorialButton _tutorialButton;

    public AudioClip _tutorialDescription;
    public AudioClip _moveTutorial;

    private AudioSource _voice1;
    private AudioSource _voice2;

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
        _voice2.clip = _moveTutorial;
        _voice1.Play();
    }

    // enum TutorialWavesをForで回してチュートリアルのフローを作る
    void Update () {
        if (_tutorialButton._beginTutorial == true) {
            _voice1.Stop();
            _voice2.Play();
        }
    }
}