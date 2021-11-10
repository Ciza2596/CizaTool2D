using UnityEngine;

namespace ZoeProject
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        public PlayerMoveSettings MoveSettings;

    }  
}
