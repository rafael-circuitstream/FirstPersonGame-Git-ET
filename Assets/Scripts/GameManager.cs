using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerInput playerInput;

    public int levelNumber;
    public float timer;


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    private void Update()
    {
        timer += Time.deltaTime;

    }

    public void LockPlayerInput()
    {
        playerInput.enabled = false;
    }

    public void UnlockPlayerInput()
    {
        playerInput.enabled = true;
    }


}
