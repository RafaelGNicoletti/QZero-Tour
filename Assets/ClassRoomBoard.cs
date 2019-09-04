using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomBoard : MonoBehaviour
{
    [System.Serializable]
    public class ClassRoom
    {
        public string codSala;
        [SerializeField]
        private string bloco;
        [SerializeField]
        private string torre;
        [SerializeField]
        private string andar;
        [SerializeField]
        private string sala;

        public (bool, List<string>) GetVerification(string bloco, string torre, string andar, string sala)
        {
            List<string> camposErrados = new List<string>();
            bool errado = false;

            if (!bloco.Equals(this.bloco))
            {
                errado = true;
                camposErrados.Add("bloco");
            }
            if (!torre.Equals(this.torre))
            {
                errado = true;
                camposErrados.Add("torre");
            }
            if (!andar.Equals(this.andar))
            {
                errado = true;
                camposErrados.Add("andar");
            }
            if (!sala.Equals(this.sala))
            {
                errado = true;
                camposErrados.Add("sala");
            }

            return (!errado, camposErrados);
        }
    }

    public List<ClassRoom> salas;
    private int currentClass;


}
