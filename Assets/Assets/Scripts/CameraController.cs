using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private Transform player;
   [SerializeField] private float leftLimit, rightLimit, bottomLimit, upperLimit;
   private Vector3 pos;
   private float speed = 5f;

   private void Awake()
   {
      if (!player)
         player = FindObjectOfType<Hero>().transform;
   }

   private void Update()
   {
      pos = player.position;
      pos.z = -10f;
      transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);

      transform.position = new Vector3
      (
         Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
         Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
         transform.position.z
      );
   }

   /*private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
      Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
      Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
      Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, upperLimit));
   }*/

}
