using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    void Update() {
        // Press enter to begin
        if(Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("MainLevel");
        }
    }
}
