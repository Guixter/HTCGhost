using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Game's constants.
 */
public static class Constants {

	//////// SPAWN CONSTANTS /////////////////////////////////////////////////

	// The distance from the player where the ghosts are spawned
	public const float GHOST_SPAWN_RADIUS = 10.0f;

	// The min vertical angle to spawn a ghost
	public const float GHOST_SPAWN_ANGLE_MIN = -35f;

	// The max vertical angle to spawn a ghost
	public const float GHOST_SPAWN_ANGLE_MAX = 10f;

	// The initial time between 2 spawns
	public const float GHOST_SPAWN_INIT_TIME = 5;

	// The spawn time decrease when a wave is over
	public const float GHOST_SPAWN_TIME_DECR = 1;

	// The minimum time between 2 spawns
	public const float GHOST_MIN_SPAWN_TIME = 1;

	// The number of ghosts in a wave
	public const int GHOST_WAVES_SIZE = 5;

	// The number of red ghosts to spawn before spawning a green ghost
	public const int GHOST_GREEN_TRESHOLD = 5;

	//////// GHOST CONSTANTS /////////////////////////////////////////////////

	// The ghosts' speed
	public const float GHOST_SPEED = 1.0f;
}
