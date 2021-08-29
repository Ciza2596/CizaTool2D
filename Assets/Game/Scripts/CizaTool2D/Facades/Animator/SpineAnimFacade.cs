using UnityEngine;
using Spine.Unity;
using Spine;

namespace CizaTools2D
{
    public class SpineAnimFacade : MonoBehaviour, IAnimator
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;

        public string GetName(int index)
        {
            TrackEntry track = _skeletonAnimation.state.GetCurrent(index);

            string name = 
                (track != null) ? 
                    track.Animation.Name : "Null";
            
            if(name == "Null") 
                Debug.Log($"anim index is {index} and null");
            
            return name;
        }
        
        public float GetTime(int index)
        {
            TrackEntry track = _skeletonAnimation.state.GetCurrent(index);
            
            float time = 
                (track != null) ? 
                    track.AnimationTime : -404;
            
            if(time == -404) 
                Debug.Log($"anim index is {index} and null");

            return time;
        }

        public float GetNormalizeTime(int index)
        {
            TrackEntry track = _skeletonAnimation.state.GetCurrent(index);
            
            float normalizeTime = 
                (track != null) ? 
                    track.AnimationTime : -404;

            if (normalizeTime == -404)
                Debug.Log($"anim index is {index} and null");
            else
                normalizeTime /= track.AnimationEnd;

            return normalizeTime; 
        }

        public void Play(int index, string name, bool loop, float timeScale)
        {  
            //確認目前已播放想同動畫
            if(GetName(index) == name) return;

            //播放
            TrackEntry track = _skeletonAnimation.state.SetAnimation(index, name, loop);
            
            track.TimeScale = timeScale;
        }
        
        public void PlayAtTime(int index,float startTime ,string name, bool loop, float timeScale)
        {
            //確認目前已播放想同動畫
            if(GetName(index) == name) return;
            
            //撥放
            TrackEntry track = _skeletonAnimation.state.SetAnimation(index, name, loop);
            
            track.TimeScale = timeScale;
            track.TrackTime = startTime;
        }

        public void PlayAtNormalizeTime(int index, float normalizeTime, string name, bool loop, float timeScale)
        {
            //確認目前已播放想同動畫
            if(GetName(index) == name) return;
            
            //撥放
            TrackEntry track = _skeletonAnimation.state.SetAnimation(index, name, loop);
            
            
            
            track.TimeScale = timeScale;
            track.TrackTime = (normalizeTime * track.AnimationEnd);
        }
    } 
}


