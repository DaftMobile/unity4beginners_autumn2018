using System.IO;
using UnityEngine;

public class MovingComponent : MonoBehaviour
{
	[SerializeField] private float shipSpeedPerSecond;
		
	private Transform mytranTransform;
	private ExampleScript exampleScript;
	private IInput input;

	public void Initialize(float speed, IInput input)
	{
		this.input = input;
		shipSpeedPerSecond = speed;
	}
	
	private void Start()
	{
		mytranTransform = transform;
		exampleScript = gameObject.GetComponent<ExampleScript>();
		exampleScript.enabled = false;
	}
	// Update is called once per frame
	void Update()
	{
		UpdatedPosition("d", Vector3.right);
		UpdatedPosition("a", Vector3.left);
		UpdatedPosition("w", Vector3.up);
		UpdatedPosition("s", Vector3.down);
	}

	private void UpdatedPosition(string key ,Vector3 moveVector)
	{	
		if (input.GetKey(key))
		{
			mytranTransform.position += moveVector * shipSpeedPerSecond * Time.deltaTime;
		}
	}
}
