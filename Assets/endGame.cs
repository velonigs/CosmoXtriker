using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endGame : MonoBehaviour
{
    [SerializeField] float timer = 5;
    public string level;
    void Start()
    {
        Invoke("goEnd", timer);
    }

    public void goEnd()
    {
        SceneManager.LoadScene(level);
    }
}
