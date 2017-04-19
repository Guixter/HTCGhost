using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {

	public const float GHOST_SPAWN_RADIUS = 10.0f;
	public const float GHOST_SPAWN_HEIGHT = 2.0f;
	public const float GHOST_SPEED = 1.0f;

	public const float GHOST_SPAWN_ANGLE_MIN = -35f;
	public const float GHOST_SPAWN_ANGLE_MAX = 10f;
	public const float GHOST_SPAWN_TIME = 5;


	/*
	TODO :
		- sons (mort, ...)
		- prefabs de citrouilles différentes (et système de vague)
		- corriger le problème de collision de la lumière dans la citrouille quand la citrouille est trop proche (à tester)
		- best score à tester
		- vérifier la cohérence du gameover
		- stats du prof
	*/
}
