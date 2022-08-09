using UnityEngine;
using UnityEditor;

namespace TTT
{

	public class PlaceOnTerrain : ScriptableObject 
	{

		public Texture2D lmap;
		
		[MenuItem ("Window/Terrain Tools/Drop Selection to Terrain",false,103)]
		/// <summary>
		/// > This function will move the selected object to the terrain
		/// </summary>
		static void PlaceSelectionOnTerrain() 
		{
			foreach (Transform t in Selection.transforms) 
			{
				/* Checking if the selected object is a terrain. If it is not, it will move the object to the
				terrain. */
				if (t.GetComponent<Terrain>()==null)
				{
					Undo.RecordObject(t, "Move " + t.name);
					RaycastHit hit;
					if (Physics.Raycast(t.position, -Vector3.up, out hit)) {
						float distanceToGround = hit.distance;
						t.Translate(-Vector3.up * distanceToGround);
					} else if (Physics.Raycast(t.position, Vector3.up, out hit)) {
						float distanceToGround = hit.distance;
						t.Translate(Vector3.up * distanceToGround);
					}
				}
			}
		}
	 
		[MenuItem ("Window/Terrain Tools/Drop Selection to Terrain", true, 3)]
		/// <summary>
		/// If the user has selected a GameObject in the Hierarchy, then the menu item will be enabled
		/// </summary>
		/// <returns>
		/// A bool.
		/// </returns>
		static bool ValidatePlaceSelectionOnTerrain () {
			return Selection.activeTransform != null;
		}
	}
}