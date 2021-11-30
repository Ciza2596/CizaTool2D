using System;
using System.Collections.Generic;
using CizaTool2D;
using UnityEngine;

namespace ZoeProject
{
    public class PlayerMoveAnim : MonoBehaviour /*,IPlayerMoveAnim*/
    {

        // [SerializeField] private GameObject _facades;
        // [SerializeField] private bool _isEnable = true;
        //
        // private IRigidbody2D _rigidbody2D;
        // private IAnimator _animator;
        //
        // private PlayerMoveSettings _playerMovesSettings;
        //
        // // Start is called before the first frame update
        // void Start()
        // {
        //     _rigidbody2D = _facades.GetComponent<IRigidbody2D>();
        //     _animator = _facades.GetComponent<IAnimator>();
        // }
        //
        // //初始化
        // public void Initial(PlayerMoveSettings playerMoveSettings)
        // {
        //     _playerMovesSettings = playerMoveSettings;
        //     
        //     AddAction((_playerMovesSettings.Rush.Speed - 0.25f), PlayRunning);
        //     AddAction((_playerMovesSettings.Run.Speed- 0.25f), PlayRunning);
        //     AddAction((_playerMovesSettings.Walk.Speed- 0.25f), PlayWalking);
        // }
        //
        // //是否啟用
        // public void IsEnable(bool isEnable)
        // {
        //     _isEnable = isEnable;
        // }
        //
        // //執行
        // public void PlayMoveAnim(bool isGround)
        // {
        //     if (_playerMovesSettings == null)
        //     {
        //         Debug.Log("MoveAnim doesn't be Set.");
        //         return;
        //     }
        //
        //     if(!_isEnable || !isGround) return;
        //
        //     Execute(Mathf.Abs(_rigidbody2D.GetXVelocity()));
        // }
        //
        // #region ActionDictionary
        //
        // private Dictionary<float, Action> _actionDictionary = new Dictionary<float, Action>();
        //
        //
        // private void AddAction(float speed, Action action) {
        //     _actionDictionary.Add(speed, action);
        // }
        //
        // private void Execute(float currentVelocity)
        // {
        //     foreach (var pair in _actionDictionary)
        //     {
        //         var velocity = pair.Key;
        //
        //         if (currentVelocity > velocity) {
        //             var action = pair.Value;
        //             action.Invoke();
        //             return;
        //         }
        //     }
        //     
        //     PlayIdle();
        // }
        //
        //
        // #endregion
        //
        // #region Actions
        //
        // private void PlayRushing()
        // {
        //     _animator.PlayAtNormalizeTime(0, 
        //         NormalizeTimeForRushAndRun(_playerMovesSettings.Run.Anim.Name), 
        //         _playerMovesSettings.Rush.Anim.Name, 
        //         true, 
        //         _playerMovesSettings.Rush.Anim.TimeScale);
        // }
        //
        // private void PlayRunning()
        // {
        //     _animator.PlayAtNormalizeTime(0, 
        //         NormalizeTimeForRushAndRun(_playerMovesSettings.Rush.Anim.Name), 
        //         _playerMovesSettings.Run.Anim.Name, 
        //         true, 
        //         _playerMovesSettings.Run.Anim.TimeScale); 
        // }
        //
        // private void PlayWalking()
        // {
        //     _animator.PlayAtNormalizeTime(0, 
        //         NormalizeTimeForWalk(), 
        //         _playerMovesSettings.Walk.Anim.Name, 
        //         true, 
        //         _playerMovesSettings.Walk.Anim.TimeScale);
        // }
        //
        // private void PlayIdle()
        // {
        //     //站立
        //     _animator.Play(0, 
        //         _playerMovesSettings.Idle.Name, 
        //         true, 
        //         _playerMovesSettings.Idle.TimeScale);
        // }
        // #endregion
        //
        //
        //
        // #region NormalizeTime
        //
        // private float NormalizeTimeForRushAndRun(string rushOrRunName)
        // {
        //     // string name = _animator.GetName(0);
        //     // float normalizeTime = 0;
        //     //
        //     // if (name == rushOrRunName)
        //     // {
        //     //     normalizeTime = _animator.GetNormalizeTime(0);
        //     // }
        //     // else if (name == _playerMovesSettings.Walk.Anim.Name)
        //     // {
        //     //     normalizeTime = _animator.GetNormalizeTime(0);
        //     //     normalizeTime *=2;
        //     // }
        //     //
        //     // return normalizeTime;
        //     return 0;
        // }
        //
        // private float NormalizeTimeForWalk()
        // {
        //     // //走路
        //     // string name = _animator.GetName(0);
        //     // float normalizeTime = 0;
        //     //
        //     // if (name == _playerMovesSettings.Rush.Anim.Name 
        //     //     || name == _playerMovesSettings.Run.Anim.Name)
        //     // {
        //     //     normalizeTime = _animator.GetNormalizeTime(0);
        //     //     normalizeTime /=2;
        //     // }
        //     //
        //     // return normalizeTime;
        //     return 0;
        // }
        //
        // #endregion
    }  
}

