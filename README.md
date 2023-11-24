## bug encyclopedia
# description of bug, what you think could be causing it, what you think might fix it

# major bugs (need to be fixed)
- [ ] Shop price for damage upgrade is broken. I think the amount of shops spawning changes the price. move the pausemenu.cs(this is the store script essentially) script to the canvas instead of the shop.

- [ ] the despawn breaks the walls so if a player goes swims down then up they can leave the cave entirely. a easy way to fix would be to move the invisible walls down to the new top of the cave

- [ ] magnet buff no longer works. looked at all the code and there seems to be no reason the magnet should be broken. 

# minor bugs (would like to be fixed)

- [ ] over spawning. if the player don't move down and just swims around the same area then nothing gets de spawned and we have major performance issues. need to update the spawner to take look at how many of its object are spawned and have a limit to how many it will spawn. 

- [ ] things spawning on the player. the spawner don't take the players location in to consideration so things will spawn on top of them. need to look at players y coords and spawn below them far enough so off screen.

- [ ] things appearing in the wall. think the way null tiles are determined means things on the boundry of the wall go on the wrong side. tough fix need to refine spawn algo to cosider these edge cases which is tricky. likely no time for this.