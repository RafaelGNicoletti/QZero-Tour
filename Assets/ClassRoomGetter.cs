using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ClassRoomGetter : MonoBehaviour
{
    public TextAsset archive;

    public ClassRoomCollection LoadClassRoom()
    {
        return JsonUtility.FromJson<ClassRoomCollection>(archive.text);
    }

    /*Criado para referência futura, qualquer coisa
    private void SaveClassRoom(ClassRoomCollection classList)
    {
        string classListJson = JsonUtility.ToJson(classList);
        File.WriteAllText(UnityEditor.AssetDatabase.GetAssetPath(archive), classListJson);
        UnityEditor.EditorUtility.SetDirty(archive);
    }*/

}
