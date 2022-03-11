using System;
using System.Reflection;
using UnityEngine;

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
    }
    
    
    
}
