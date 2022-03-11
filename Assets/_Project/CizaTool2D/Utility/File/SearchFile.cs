using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace CizaTool2D.Utility.File
{
    public class SearchFile 
    {
        public static string GetRelativePath(string fullPath)
        {
            var      info    = new FileInfo(fullPath);
            string   absPath = info.FullName;
            string[] arr     = AssetDatabase.GetAllAssetPaths();
 
            for (var i = 0; i < arr.Length; i++){
                info          = new FileInfo(arr[i]);
 
                if (info.FullName.Equals(absPath))
                    return arr[i];
            }
 
            return string.Empty;
        }
        
        public static void GetAllFileAsset(string path, ref List<FileInfo> fileList, string extensionName) {
            DirectoryInfo source = new DirectoryInfo(path);

            foreach(var file in source.GetFiles()){
                
                var fileExtensionName = file.Extension;
                if(fileExtensionName == extensionName)
                    fileList.Add(file);
            }
            
            foreach(var directory in source.GetDirectories()){
                GetAllFileAsset(directory.FullName, ref fileList, extensionName);
            }
        }
        
        public static void GetAllUnityObject<T, E>(List<FileInfo> files, ref List<E> datas, Action<T, List<E>> action) where T: UnityEngine.Object {
            foreach(var file in files){
                var gameObject = (T) AssetDatabase.LoadAssetAtPath(SearchFile.GetRelativePath(file.FullName),
                                                                   typeof(T));
                action(gameObject, datas);
            }
        }
    }
}
