using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    Button NewGame, Exit;
    // Start is called before the first frame update
    void Start()
    {
        NewGame = transform.Find("NewGame").GetComponent<Button>();
        Exit = transform.Find("Exit").GetComponent<Button>();

        NewGame.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        });

        Exit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
