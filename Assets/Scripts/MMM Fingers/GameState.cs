public class GameState
{
    public static GameState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameState();
            }

            return _instance;
        }
    }

    public bool IsPaused { get; private set; }
    public bool IsSlowMode { get; private set; }

    private static GameState _instance;

    private GameState()
    {
        IsPaused = false;
        IsSlowMode = false;
    }

    public void PauseGame()
    {
        IsPaused = true;
    }

    public void ResumeGame()
    {
        IsPaused = false;
    }

    public void BeginSlowMode()
    {
        IsSlowMode = true;
    }

    public void StopSlowMode()
    {
        IsSlowMode = false;
    }

}
