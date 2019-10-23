﻿using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/* This object manages the inventory UI. */

public class InventoryUI : MonoBehaviour {

	public GameObject inventoryUI;	// The entire UI
	public Transform itemsParent;	// The parent object of all the items

	Inventory inventory;	// Our current inventory

	void Start ()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;
		inventory.onItemAdded += ShowforSeconds;
	}

	// Check to see if we should open/close the inventory
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			ToggleUI();
		}
	}

	void ShowforSeconds()
	{
		bool isActive = inventoryUI.activeSelf;
		inventoryUI.SetActive(true);
		UpdateUI();
		
		if(!isActive)
			StartCoroutine(WaitSecondsAndCloseUI(1f));
	
	}
	
	private void ToggleUI()
	{
		inventoryUI.SetActive(!inventoryUI.activeSelf);
		if(inventoryUI.activeSelf)
			UpdateUI();
	}
	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	public void UpdateUI ()
	{
		//update slots
		InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			} else
			{
				slots[i].ClearSlot();
			}
		}

	}
	
	
	IEnumerator WaitSecondsAndCloseUI(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		inventoryUI.SetActive(false);
	}

}