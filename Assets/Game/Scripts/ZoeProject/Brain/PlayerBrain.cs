using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZoeProject;

public class PlayerBrain : MonoBehaviour
{

    [SerializeField] private GameObject _funcs;
    [SerializeField] private PlayerSettings _settings;
    
    private IPlayerMovement _movement;
    private IPlayerMoveAnim _moveAnim;

    // Start is called before the first frame update
    void Start()
    {
        InitialMoveAnim();  //初始化
    }

    // Update is called once per frame
    void Update()
    {
        PlayMoveAnim();
    }

    #region movement

    

    #endregion

    #region moveAnim

    private void InitialMoveAnim()
    {
        _moveAnim = _funcs.GetComponent<IPlayerMoveAnim>();
        _moveAnim.Initial(_settings.MoveSettings);
    }

    private void IsEnableMoveAnim(bool isEnable)
    {
        _moveAnim.IsEnable(isEnable);
    }

    private void PlayMoveAnim()
    {
        _moveAnim.PlayMoveAnim(true);
    }

    #endregion
}
