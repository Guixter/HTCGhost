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
		- sons (mort, ...) (GOOD)
		- prefabs de citrouilles différentes (et système de vague)
		- corriger le problème de collision de la lumière dans la citrouille quand la citrouille est trop proche (GOOD)
		- best score à tester (GOOD)
		- vérifier la cohérence du gameover (affichage de travers et pas de selecction)
		- stats du prof

		- le curseur decale sur le menu
	*/
}
