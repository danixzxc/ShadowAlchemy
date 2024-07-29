using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    private int current_checkpoint_ID = 0;
    [SerializeField]
    private List<Vector2> _checkpointTransforms;

    public static CheckpointManager instance;

    public void UpdateID(int ID)
    {
        current_checkpoint_ID = ID;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);
    }
    public Vector2 GetLastCheckpointTransform()
    {
        return _checkpointTransforms[current_checkpoint_ID];
    }

}
