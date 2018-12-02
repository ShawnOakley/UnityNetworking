using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SetupLocalPlayer : NetworkBehaviour {

    public Text namePrefab;
    public Text nameLabel;
    public Transform namePos;

	public override void OnStartServer()
	{
		Debug.Log("Starting Server"  + isLocalPlayer);
	}

	public override void OnStartClient()
	{
		Debug.Log("Starting Client"  + isLocalPlayer);
	}

	void Awake()
	{
		Debug.Log("Awaking Player " + isLocalPlayer);
	}

	// Use this for initialization
	void Start () 
	{
		if(isLocalPlayer)
		{
			GetComponent<PlayerController>().enabled = true;
            CameraFollow360.player = this.gameObject.transform;
		}
		else
		{
			GetComponent<PlayerController>().enabled = false;
		}
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        nameLabel = Instantiate(namePrefab, Vector3.zero, Quaternion.identity) as Text;
        nameLabel.transform.SetParent(canvas.transform);
		Debug.Log("Starting Player " + isLocalPlayer);
	}

    private void Update()
    {
        Vector3 nameLabelPos = Camera.main.WorldToScreenPoint(namePos.position);
        nameLabel.transform.position = nameLabelPos;
    }
}
