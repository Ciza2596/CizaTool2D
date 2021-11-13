using UnityEngine;
using Spine.Unity;
using Spine;
using AnimationState = Spine.AnimationState;

namespace CizaTool2D.Converter {
    
    public class SpineAnimatorConverter : MonoBehaviour, IAnimator, IAnimEvent, IRootMotion {
        
        [SerializeField] private SkeletonAnimation  _skeletonAnimation;
        [SerializeField] private SkeletonRootMotion _skeletonRootMotion;
        [SerializeField] private Rigidbody2D        _rigidbody2D;

    #region IAnimator

        public string GetName(int index) {
            TrackEntry track = _skeletonAnimation.state.GetCurrent (index);

            string name =
                (track != null) ? track.Animation.Name : "Null";

            if (name == "Null")
                Debug.Log ($"anim index is {index} and null");

            return name;
        }

        public bool GetIsClipNotNull(string  stateName) => throw new System.NotImplementedException();
        public bool GetIsCurrentState(string stateName) => throw new System.NotImplementedException();

        public float GetTime(int index) {
            TrackEntry track = _skeletonAnimation.state.GetCurrent (index);

            float time =
                (track != null) ? track.AnimationTime : -404;

            if (time == -404)
                Debug.Log ($"anim index is {index} and null");

            return time;
        }

        public float GetNormalizeTime(int index) {
            TrackEntry track = _skeletonAnimation.state.GetCurrent (index);

            float normalizeTime =
                (track != null) ? track.AnimationTime : -404;

            if (normalizeTime == -404)
                Debug.Log ($"anim index is {index} and null");
            else
                normalizeTime /= track.AnimationEnd;

            return normalizeTime;
        }

        public void CoverPlay(int index, string name, bool loop, float timeScale) {
            //撥放
            TrackEntry track = _skeletonAnimation.state.SetAnimation (index, name, loop);

            track.TimeScale = timeScale;
            track.TrackTime = 0;
        }

        public void Play(int index, string name, bool loop, float timeScale) {
            //確認目前已播放想同動畫
            if (GetName (index) == name) return;

            //播放
            TrackEntry track = _skeletonAnimation.state.SetAnimation (index, name, loop);

            track.TimeScale = timeScale;
        }

        public void PlayAtTime(int index, float startTime, string name, bool loop, float timeScale) {
            //確認目前已播放想同動畫
            if (GetName (index) == name) return;

            //撥放
            TrackEntry track = _skeletonAnimation.state.SetAnimation (index, name, loop);

            track.TimeScale = timeScale;
            track.TrackTime = startTime;
        }

        public void PlayAtNormalizeTime(int index, float normalizeTime, string name, bool loop, float timeScale) {
            //確認目前已播放想同動畫
            if (GetName (index) == name) return;

            //撥放
            TrackEntry track = _skeletonAnimation.state.SetAnimation (index, name, loop);


            track.TimeScale = timeScale;
            track.TrackTime = (normalizeTime * track.AnimationEnd);
        }

        public void StopPlayAnim(int index) {
            Play (index, "DEFAULT", true, 1);
        }

    #endregion

    #region ISpineEvent

        public void AddStartEvent(AnimationState.TrackEntryDelegate addStartEvent) {
            _skeletonAnimation.AnimationState.Start += addStartEvent;
        }

        public void AddCompleteEvent(AnimationState.TrackEntryDelegate addCompleteEvent) {
            _skeletonAnimation.AnimationState.Complete += addCompleteEvent;
        }

        public void AddEndEvent(AnimationState.TrackEntryDelegate addEndEvent) {
            _skeletonAnimation.AnimationState.End += addEndEvent;
        }

        public void AddEvent(AnimationState.TrackEntryEventDelegate addEvent) {
            _skeletonAnimation.AnimationState.Event += addEvent;
        }

    #endregion

        public void SetRootMotion(bool enable) {
            _skeletonRootMotion.enabled = enable;
            if (enable)
                _rigidbody2D.velocity = new Vector2 (0, 0);
        }

        public void SetPositionX(bool enable) {
            _skeletonRootMotion.transformPositionX = enable;
        }
    }
}