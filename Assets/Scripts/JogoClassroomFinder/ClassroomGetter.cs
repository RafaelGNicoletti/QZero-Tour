using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ClassroomGetter : MonoBehaviour
{
    [SerializeField]
    private TextAsset archive; //Arquivo de texto JSON, contendo um dado do tipo ClassroomCollection

    public ClassroomCollection LoadClassRoom()
    {
        return JsonUtility.FromJson<ClassroomCollection>(archive.text);
    }

    /*Criado para referência futura, qualquer coisa
    private void SaveClassRoom(ClassRoomCollection classList)
    {
        string classListJson = JsonUtility.ToJson(classList);
        File.WriteAllText(UnityEditor.AssetDatabase.GetAssetPath(archive), classListJson);
        UnityEditor.EditorUtility.SetDirty(archive);
    }*/

}
