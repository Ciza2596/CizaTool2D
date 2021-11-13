namespace CizaTool2D
{
    public interface IAnimEvent
    {
        //起始
        void AddStartEvent(Spine.AnimationState.TrackEntryDelegate addStartEvent);
        
        //播完
        void AddCompleteEvent(Spine.AnimationState.TrackEntryDelegate addCompleteEvent);

        //離開
        void AddEndEvent(Spine.AnimationState.TrackEntryDelegate addEndEvent);

        //穿插
        void AddEvent(Spine.AnimationState.TrackEntryEventDelegate addEvent);
    } 
}

