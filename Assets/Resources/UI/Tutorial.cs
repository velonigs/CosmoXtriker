using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{   
    [SerializeField]
    private GameObject _tutorialPanel;

    public void StartTutorial() {
        StartCoroutine(TutorialPanel());
    }

    IEnumerator TutorialPanel() {
        yield return new WaitForSeconds(0.5f);
        _tutorialPanel.SetActive(true);
    }
}
