using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CizaTool2D.Utility
{
    public class DataSaveAndLoad : MonoBehaviour
    {
    #region Json

        public static void Save(object data, string path) {
            //檢查位置
            if (!Directory.Exists (Path.GetDirectoryName (path))) {
                //位置不存在，=>產生位置
                Directory.CreateDirectory (Path.GetDirectoryName (path));

                Debug.Log (Path.GetDirectoryName (path));
            }


            StreamWriter stream = new StreamWriter (path);
            string       json   = JsonUtility.ToJson (data);
            stream.Write (json);
            stream.Close();
        }

        public static T Load<T>(string path) {
            T Data;
            //檢查路徑:
            if (File.Exists (path)) {
                StreamReader stream = new StreamReader (path);

                string json = stream.ReadToEnd();
                //解析
                Data = JsonUtility.FromJson<T> (json);

                Debug.Log ("Load:" + Data);

                stream.Close();
                return Data;
            }

            else {
                Debug.LogWarning ("<color=red>找不到檔案</color>");
                return default;
            }
        }

    #endregion


    #region Bin

        public static void Save_bin(object data, string path) {
            //檢查位置
            if (!Directory.Exists (Path.GetDirectoryName (path))) {
                //位置不存在，=>產生位置
                Directory.CreateDirectory (Path.GetDirectoryName (path));

                Debug.Log (Path.GetDirectoryName (path));
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream (path, FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.None);
            formatter.Serialize (stream, data);
            stream.Dispose();
            stream.Close();
        }

        public static T Load_bin<T>(string path)
        {
            //檢查路徑:
            if (File.Exists (path)) {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream      stream    = new FileStream (path, FileMode.Open, FileAccess.Read, FileShare.None);
                T               data      = (T) formatter.Deserialize (stream);
                stream.Dispose();
                stream.Close();
                return data;
            }

            else {
                Debug.LogWarning ("<color=red>找不到檔案</color>");

                Directory.CreateDirectory (Path.GetDirectoryName (path));
                return default;
            }
        }

    #endregion
    }
}