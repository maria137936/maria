using Godot;
using System;

public partial class Rules : Control
{
	private bool isRulesDisplayed;
	private bool isControlDisplayed;
	private bool isStoryDisplayed;
	private string title;

	public override void _Ready()
	{
		isStoryDisplayed = true;  // Initial state should be Story
		isRulesDisplayed = false;
		isControlDisplayed = false;
		title = "Story";
		GetNode<Label>("Title").Text = title;
		GetNode<TextureRect>("ControlParchment").Visible = false;
		GetNode<TextureRect>("RulesParchment").Visible = false;
		GetNode<TextureRect>("StoryParchment").Visible = true;

		GetNode<TextureButton>("RightArrowButton").Visible = true;
		GetNode<TextureButton>("LeftArrowButton").Visible = false;
	}

	private void _on_preview_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/menu.tscn");
	}

	private void _on_right_arrow_button_pressed()
	{
		if (isStoryDisplayed)
		{
			isStoryDisplayed = false;
			isRulesDisplayed = true;
			title = "Rules";
			GetNode<Label>("Title").Text = title;
			GetNode<TextureRect>("ControlParchment").Visible = false;
			GetNode<TextureRect>("RulesParchment").Visible = true;
			GetNode<TextureRect>("StoryParchment").Visible = false;

			GetNode<TextureButton>("RightArrowButton").Visible = true;
			GetNode<TextureButton>("LeftArrowButton").Visible = true;
		}
		else if (isRulesDisplayed)
		{
			isRulesDisplayed = false;
			isControlDisplayed = true;
			title = "Control";
			GetNode<Label>("Title").Text = title;
			GetNode<TextureRect>("ControlParchment").Visible = true;
			GetNode<TextureRect>("RulesParchment").Visible = false;
			GetNode<TextureRect>("StoryParchment").Visible = false;

			GetNode<TextureButton>("RightArrowButton").Visible = false;
			GetNode<TextureButton>("LeftArrowButton").Visible = true;
		}
	}

	private void _on_left_arrow_button_pressed()
	{
		if (isControlDisplayed)
		{
			isControlDisplayed = false;
			isRulesDisplayed = true;
			title = "Rules";
			GetNode<Label>("Title").Text = title;
			GetNode<TextureRect>("ControlParchment").Visible = false;
			GetNode<TextureRect>("RulesParchment").Visible = true;
			GetNode<TextureRect>("StoryParchment").Visible = false;

			GetNode<TextureButton>("RightArrowButton").Visible = true;
			GetNode<TextureButton>("LeftArrowButton").Visible = true;
		}
		else if (isRulesDisplayed)
		{
			isRulesDisplayed = false;
			isStoryDisplayed = true;
			title = "Story";
			GetNode<Label>("Title").Text = title;
			GetNode<TextureRect>("ControlParchment").Visible = false;
			GetNode<TextureRect>("RulesParchment").Visible = false;
			GetNode<TextureRect>("StoryParchment").Visible = true;

			GetNode<TextureButton>("RightArrowButton").Visible = true;
			GetNode<TextureButton>("LeftArrowButton").Visible = false;
		}
	}
}
