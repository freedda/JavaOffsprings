using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Photon.Voice.Unity;
using Photon.Voice.PUN;
public class VoiceButtonManager : MonoBehaviourPun
{
    // Start is called before the first frame update
    //Disable and enable the transmit
    public Recorder VoiceRecorder;

    private PhotonView view;
    void Start()
    {
        view = photonView;
        VoiceRecorder.TransmitEnabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //WHEN the player push the M button
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Start transmit
            if(view.IsMine) 
                VoiceRecorder.TransmitEnabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {   //stop transmit
            if(view.IsMine)
                VoiceRecorder.TransmitEnabled = false;
        }
    }
}
