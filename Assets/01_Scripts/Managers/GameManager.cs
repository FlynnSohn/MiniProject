using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private RunState runState;
    /// <summary>
    /// 지연 생성
    /// </summary>
    public RunState Run => runState ??= new();
    // Runstate는 기본적으로 게임매니저에서 접근
    public void StartNewRun() => runState = new();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

}
