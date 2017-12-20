using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public void level1() {
        Application.LoadLevel("stage1");
    }
    public void level2() {
        Application.LoadLevel("stage2");
    }
    public void Credit() {
        Application.LoadLevel("Credit");
    }
    public void MainMenu() {
        Application.LoadLevel("MainMenu");
    }
    public void QuitApp() {
        Application.Quit();
    }
}
