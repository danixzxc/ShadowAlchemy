using UnityEngine;

public class PlayerCheckpointManager : MonoBehaviour
{
    private int current_checkpoint_ID;

    public void UpdateID(int ID){
        current_checkpoint_ID = ID;
    } 
}
