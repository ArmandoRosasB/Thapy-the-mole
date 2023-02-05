using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Button lvl2;
    private Button lvl3;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        lvl2 = GameObject.FindWithTag("Level_2").GetComponent<Button>();
        lvl3 = GameObject.FindWithTag("Level_3").GetComponent<Button>();


        lvl2.interactable = gameManager.buttonFlags.LvlTwoUnlock;
        lvl3.interactable =  gameManager.buttonFlags.LvlThreeUnlock;

    }

    // Update is called once per frame
  
    public void goLevelOne()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void goLevelTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void goLevelThree()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

}
