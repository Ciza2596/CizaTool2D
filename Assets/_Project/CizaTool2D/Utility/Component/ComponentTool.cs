using System;
using System.Collections.Generic;
using System.Reflection;
using CizaTool2D.Utility.RandomNumber;

namespace CizaTool2D.Utility.Component
{
    public static class ComponentTool
    {
        public static T GetCopyOf<T>(this UnityEngine.Component comp, T other) where T : UnityEngine.Component {
            Type type = comp.GetType();
            if(type != other.GetType()) 
                return null; // type mis-match
            
            BindingFlags flags = BindingFlags.Public  | BindingFlags.NonPublic  | BindingFlags.Instance |  
                                 BindingFlags.Default | BindingFlags.DeclaredOnly;
            
            PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach(var pinfo in pinfos){
                if(pinfo.CanWrite){
                    try{
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch{ } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }

            FieldInfo[] finfos = type.GetFields(flags);
            foreach(var finfo in finfos){
                finfo.SetValue(comp, finfo.GetValue(other));
            }

            return comp as T;
        }
        
    #region == Random ==
        
        public static T GetRandomComponent<T>(this List<T> audioClipPlayers, IRandomNumber randomNumber) where T : UnityEngine.Component {
            var count = audioClipPlayers.Count;
            if(count == 1){
                return audioClipPlayers[0];
            }
            else if(count == 2){
                return audioClipPlayers[randomNumber.GetRandomNumberForTwo()];
            }
            else if(count >= 3){
                return audioClipPlayers[randomNumber.GetRandomNumberForMoreThree(count)];
            }
            else{
                return null;
            }
        }
        
    #endregion
    }
}
