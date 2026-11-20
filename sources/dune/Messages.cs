$M[1] = "The sleeper must awaken.";
$M[2] = "O you who know what we suffer here, do not forget us in your prayers.";
$M[3] = "He who controls the Spice, controls the universe...";
$M[4] = "There exists no separation between gods and men; one blends softly casual to the other.";
$M[5] = "Once more the drama begins.";
$M[6] = "O Paul,/thou Muad'Dib,/Mahdi of all men,/Thy breath exhaled/Sent forth the huricen.";
$M[7] = "You do not beg the sun for mercy.";
$M[8] = "A Fremen dies when he is too long from the desert; this we call \"the water sickness.\"";
$M[9] = "I give you the desert chameleon, whose ability to blend itself into the background tells you all you need to know about the roots of ecology and the foundations of a personal identity.";
$M[10] = "One small bird has called thee/From a beak streaked crimson./It cried once over Sietch Tabr/And thou went forth unto Funeral Plain.";
$M[11] = "Time does not count itself. You have only to look at a circle and this is apparent.";
$M[12] = "Uproot your questions from their ground and the dangling roots will be seen. More questions!";
$M[13] = "You cannot manipulate a marionette with only one string.";
$M[14] = "Ultimately, all things are known because you want to believe you know.";
$M[15] = "Answers are a perilous grip on the universe. They can appear sensible yet explain nothing.";
$M[16] = "Paired opposites define your longings and those longings imprison you.";
$M[17] = "The writing of history is largely a process of diversion. Most historical accounts distract attention from the secret influences behind great events.";
$M[18] = "The true warrior often understands his enemy better than he understands his friends. A dangerous pitfall if you let understanding lead to sympathy as it will naturally do when left unguided.";
$M[19] = "Battle? There is always a desire for breathing space motivating it somewhere.";
$M[20] = "Here lies a toppled god --/His fall was not a small one./We did but build his pedestal,/A narrow and a tall one.";
$M[21] = "Every civilization must contend with an unconscious force which can block, betray or countermand almost any conscious intention of the collectivity.";
$M[22] = "Corruption wears infinite disguises.";
$M[23] = "When are the witches to be trusted? Never! The dark side of the magic universe belongs to the Bene Gesserit and we must reject them.";
$M[24] = "What do Holy Accidents teach? Be resilient. Be strong. Be ready for change, for the new. Gather many experiences and judge them by the steadfast nature of our faith.";
$M[25] = "Many things we do naturally become difficult only when we try to make them intellectual subjects. It is possible to know so much about a subject that you become ignorant.";
$M[26] = "Truth suffers from too much analysis";
$M[27] = "We say of Muad'Dib that he has gone on a journey into that land where we walk without footprints.";
$M[28] = "You have loved Caladan/And lamented its lost host --/But pain discovers/New lovers cannot erase/Those forever ghost.";
$M[29] = "To know a thing well, know its limits. Only when pushed beyond its tolerances will true nature be seen.";
$M[30] = "Look at one way, the universe is Brownian movement, nothing predictable at the elemental level. Muad'dib and his Tyrant son closed the cloud chamber where movement occurred.";
$M[31] = "Those who would repeat the past must control the teaching of history.";
$M[32] = "Rules build up fortifications behind which small minds create satrapies. A perilous state of affairs in the best of times, disastrous during crises.";
$M[33] = "We tend to become like the worst in those we oppose.";
$M[34] = "Laws to suppress tend to strengthen what they would prohibit. This is the fine point on which all the legal professions of history have based their job security.";
$M[35] = "All states are abstractions.";
$M[36] = "Do not depend only on theory if your life is at stake.";
$M[37] = "Major flaws in government arise from a fear of making radical internal changes even though a need is clearly seen.";
$M[38] = "The best art imitates life in a compelling way. If it imitates a dream, it must be a dream of life. Otherwise, there is no place where we can connect. Our plugs don't fit.";
$M[39] = "No sweeteners will cloak some forms of bitterness. If it tastes bitter, spit it out. That's what our earliest ancestors did.";
$M[40] = "Religion must be accepted as a source of energy. It can be directed for our purposes, but only within limits that experience reveals. He is the secret meaning of Free Will.";
$M[41] = "Spend energies on those who make you strong. Energy spent on weaklings drags you to doom.";
$M[42] = "Seek freedom and become captive of your desires. Seek discipline and find your liberty.";
$M[43] = "There's no secret to balance. You just have to feel the waves.";
$M[44] = "There is a legend that the instant the Duke Leto Atreides died a meteor streaked across the skies above his ancestral palace on Caladan.";
$M[45] = "\"Yueh! Yueh! Yueh!\" goes the refrain. \"A million deaths were not enough for Yueh!\"";
$M[46] = "At the age of fifteen, he had already learned silence.";
$M[47] = "What do you despise? By this are you truly known.";
$M[48] = "O Seas of Caladan,/O people of Duke Leto --/Citadel of Leto fallen,/Fallen forever. . .";
$M[49] = "\"There is no escape -- we pay for the violence of our ancestors.\"";
$M[50] = "There should be a science of discontent. People need hard times and oppression to develop psychic muscles.";
$M[51] = "Arrakis teaches the attitude of the knife -- chopping off what's incomplete and saying: \"Now, it's complete because it's ended here.\"";
$M[52] = "The concept of progress acts as a protective mechanism to shield us from the terrors of the future.";
$M[53] = "Deep in the unconscious is a pervasive need for a logical universe that makes sense. But the real universe is always one step beyond logic.";
$M[54] = "How often it is that the angry man rages denial of what his inner self is telling him.";
$M[55] = "Empires do not suffer emptiness of purpose at the time of their creation. It is when they have become established that aims are lost and replaced by vague ritual.";
$M[56] = "God created Arrakis to train the faithful";
$M[57] = "When law and duty are one, united by religion, you never become fully conscious, fully aware of yourself. You are always a little less than an individual.";
$M[58] = "And that day dawned when Arrakis lay at the hub of the universe with the wheel poised to spin.";

// Add in your new message useing the next number, and make sure to increase this counter.
$NumM = 58;




function displayMessage(%playerId)
{

	if ( !$FirstClassMessageExists[%playerId] ) {
		%num = floor(getRandom() * ($NumM + 1)) + 1;
		if(%num == ($NumM + 1))
			%message = "You spawn time is currently at " @ GetSpawnTime(%playerId) @ " seconds. Use the tab menue option to check it at any time.";
		else
			%message = $M[%num];
		$FirstClassMessageExists[%playerId] = false;
	} else {
		%message = $FirstClassMessage[%playerId];
		$FirstClassMessageExists[%playerId] = false;	
	}
	
	%spawnTime = GetSpawnTime(%playerId);	

	Centerprint(%playerId, "<jc>"@ %message, %spawnTime );
	
}


