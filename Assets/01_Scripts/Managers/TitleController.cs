using UnityEngine;

public class TitleController : MonoBehaviour
{

    public void OnStartButton()
    {
        if (GameManager.instance == null)
        {
            Debug.LogError("GameManager가 씬에 없음");
            return;
        }
        GameManager.instance.StartGame();
    }
    //public void OnQuitButton => Application.Quit();
}
