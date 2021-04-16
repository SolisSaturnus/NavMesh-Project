using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using TMPro;

public class PlayerController : MonoBehaviour
{
	public ThirdPersonCharacter character;
	public TextMeshProUGUI livesText;
	public TextMeshProUGUI countText;
	public GameObject Collectable;

	public static int lives = 3;
	public Camera cam;
	private Rigidbody rb;
	private int count;

	public NavMeshAgent agent;

	void Start()
	{
		agent.updateRotation = false;

		rb = GetComponent<Rigidbody>();
		count = 0;

		SetCountText();
		Collectable.SetActive(false);
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 10)
		{
			Collectable.SetActive(true);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);

			count = count += 10;

			SetCountText();
		}

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				// MOVE OUR AGENT
				agent.SetDestination(hit.point);
			}

		}
		if (agent.remainingDistance > agent.stoppingDistance)
		{
			character.Move(agent.desiredVelocity, false, false);

		}
		else
		{
			character.Move(Vector3.zero, false, false);
		}

		if (lives <= 0)
		{
			livesText.text = "Lives: 0";
		}
		else
		{
			livesText.text = "Lives: " + lives.ToString();
		}
	}
	

}





