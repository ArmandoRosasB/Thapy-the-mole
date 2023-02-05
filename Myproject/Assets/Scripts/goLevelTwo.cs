using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goLevelTwo : MonoBehaviour
{

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            gameManager.buttonFlags.LvlTwoUnlock = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
