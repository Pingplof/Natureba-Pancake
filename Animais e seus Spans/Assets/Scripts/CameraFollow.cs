// CASO ESTEJA USANDO ESSE CODIGO NO PROGRAMA PRINCIPAL, POR FAVOR EXLUIR. 
// SE NÂO EXCLUIR ESSE CODIGO PODERÁ GERAR CONFLITO COM A CAMERA DO JOGADOR. 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform cameraSpot1;
    public Transform cameraSpot2;
    // Após cada frame...
    private void FixedUpdate()
    {
        //Se o animal estiver no spawn numero 0...
        if(Vector3.Distance(target1.position, target2.position) < 0.2f)
        {
            //Mova-se para a posição de camera 1.
            transform.position = cameraSpot1.position;
        }
        else
        {
            //Se o animal estiver no spawn numero 1...
            if (Vector3.Distance(target1.position, target3.position) < 0.2f)
            {
                //Mova-se para a posição de camera 1.
                transform.position = cameraSpot2.position;
            }
        }
    }
}
