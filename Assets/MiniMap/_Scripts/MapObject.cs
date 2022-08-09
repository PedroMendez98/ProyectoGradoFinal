using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour {
	MiniMapEntity linkedMiniMapEntity;
	MiniMapController mmc;
	GameObject owner;
	Camera mapCamera;
	Image spr;
	GameObject panelGO;

	Vector3 viewPortPos;
	RectTransform rt;
	Vector3[] cornerss;

	RectTransform sprRect;
	Vector2 screenPos;
	Transform miniMapTarget;

	void FixedUpdate () {
		if (owner == null)
			Destroy (this.gameObject);
		else
			SetPositionAndRotation ();

	}

	/// <summary>
	/// It sets the values of the MiniMapEntity and the MiniMapController
	/// </summary>
	public void SetMiniMapEntityValues(MiniMapController controller,MiniMapEntity mme, GameObject attachedGO, Camera renderCamera, GameObject parentPanelGO){
		linkedMiniMapEntity = mme;
		owner = attachedGO;
		mapCamera = renderCamera;
		panelGO = parentPanelGO;
		spr = gameObject.GetComponent<Image> ();
		spr.sprite = mme.icon;
		sprRect = spr.gameObject.GetComponent<RectTransform> ();
		sprRect.sizeDelta = mme.size;
		rt = panelGO.GetComponent<RectTransform> ();
		mmc = controller;
		miniMapTarget = mmc.target;
		SetPositionAndRotation ();

	}

	/// <summary>
	/// > Set the parent of the object to the panel, and then set the position and rotation of the object
	/// </summary>
	void SetPositionAndRotation(){
		transform.SetParent (panelGO.transform, false);

		SetPosition ();
		SetRotation ();
	}
	/// <summary>
	/// > The function sets the position of the icon on the minimap
	/// </summary>
	void SetPosition(){
		cornerss = new Vector3[4];
		rt.GetWorldCorners (cornerss);
		screenPos = RectTransformUtility.WorldToScreenPoint (mapCamera, owner.transform.position);
		if (linkedMiniMapEntity.clampInBorder && Mathf.Abs(Vector3.Distance(owner.transform.position, mmc.target.transform.position)) < linkedMiniMapEntity.clampDist) {
			ClampIconColliderWise();
		} else {
			sprRect.anchoredPosition = screenPos-rt.sizeDelta/2f;
		}
	}
	/// <summary>
	/// > If the icon collider is inside the shape collider, move the icon collider to the edge of the
	/// shape collider
	/// </summary>
	void ClampIconColliderWise(){
		sprRect.anchoredPosition = screenPos-rt.sizeDelta/2f;
		Vector2 diff;
		diff = (rt.position - sprRect.position);
		RaycastHit2D[] hits = Physics2D.RaycastAll(sprRect.position, diff);
		if (hits.Length > 0) {
			for(int i=0;i<hits.Length;i++){
				if (hits [i].transform.name == mmc.shapeColliderGO.name) {
					sprRect.position = hits[i].point;
					break;
				}
			}
		}
	}

	/// <summary>
	/// If the entity is set to rotate with the object, then rotate the entity based on the object's
	/// rotation and the camera's rotation. If the entity is not set to rotate with the object, then rotate
	/// the entity based on the entity's rotation
	/// </summary>
	void SetRotation(){
		if (linkedMiniMapEntity.rotateWithObject) {
			if (Mathf.Abs (linkedMiniMapEntity.upAxis.y) == 1) {
				if (mmc.rotateWithTarget)
					sprRect.localEulerAngles = new Vector3 (0, 0, linkedMiniMapEntity.upAxis.y * (miniMapTarget.transform.localEulerAngles.y - mmc.rotationOfCam.z - owner.transform.localEulerAngles.y) + linkedMiniMapEntity.rotation);
				else
					sprRect.localEulerAngles = new Vector3 (0, 0, -linkedMiniMapEntity.upAxis.y * (owner.transform.localEulerAngles.y) + linkedMiniMapEntity.rotation);
					
			} else if (Mathf.Abs (linkedMiniMapEntity.upAxis.z) == 1) {
				if (mmc.rotateWithTarget)
					sprRect.localEulerAngles = new Vector3 (0, 0, linkedMiniMapEntity.upAxis.z * (miniMapTarget.transform.localEulerAngles.z - mmc.rotationOfCam.z - owner.transform.localEulerAngles.z)+ linkedMiniMapEntity.rotation);
				else
					sprRect.localEulerAngles = new Vector3 (0, 0, -linkedMiniMapEntity.upAxis.z * (owner.transform.localEulerAngles.z)+ linkedMiniMapEntity.rotation);
			} else if (Mathf.Abs (linkedMiniMapEntity.upAxis.x) == 1) {
				if (mmc.rotateWithTarget)
					sprRect.localEulerAngles = new Vector3 (0, 0, linkedMiniMapEntity.upAxis.x * (miniMapTarget.transform.localEulerAngles.x - mmc.rotationOfCam.z - owner.transform.localEulerAngles.x)+ linkedMiniMapEntity.rotation);
				else
					sprRect.localEulerAngles = new Vector3 (0, 0, -linkedMiniMapEntity.upAxis.x * (owner.transform.localEulerAngles.x)+ linkedMiniMapEntity.rotation);
			}
		} else {
			if (Mathf.Abs (linkedMiniMapEntity.upAxis.y) == 1) {
				sprRect.localEulerAngles = new Vector3 (0, 0, sprRect.localEulerAngles.y + linkedMiniMapEntity.rotation);
			} else if (Mathf.Abs (linkedMiniMapEntity.upAxis.z) == 1) {
				sprRect.localEulerAngles = new Vector3 (0, 0, sprRect.localEulerAngles.z + linkedMiniMapEntity.rotation);
			} else if (Mathf.Abs (linkedMiniMapEntity.upAxis.x) == 1) {
				sprRect.localEulerAngles = new Vector3 (0, 0, sprRect.localEulerAngles.x + linkedMiniMapEntity.rotation);
			}
		}
	}
}
