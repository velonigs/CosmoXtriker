using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{   
    [SerializeField]
    private GameObject _TutorialPanel;

    public void StartTutorial() {
        StartCoroutine(TutorialPanel());
    }

    IEnumerator TutorialPanel() {
        yield return new WaitForSeconds(0.5f);
        _TutorialPanel.SetActive(true);
    }
}
