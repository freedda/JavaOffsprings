using Photon.Pun;
using UnityEngine;
using System.IO;
public class PrefabsPlayerManager : MonoBehaviour
{
    PhotonView view;
    
    void Awake()
    {
        view = GetComponent< PhotonView >();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //if photon vie is mine then call Initialize Player
        if (view.IsMine)  InitializePlayer();
    }

    void InitializePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"),new Vector3(81,30,-112), Quaternion.identity);
    }
}
