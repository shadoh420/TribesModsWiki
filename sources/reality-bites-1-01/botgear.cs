//=========================================================================================================================================
// 																AI::setWeapons()
//=========================================================================================================================================
//
//   Modified by Werewolf
//
//      The AI:setWeapons was removed to this file BotGear for the simple reason of makeing the bots more configurable in an easier manner.
// Mostly for developers of mods that contain bots. This way if you have different weapons and armor types...
//
//  		The following contains the AI::setWeapons and AI::periodic
//
//  		Moved to the BotGear file for configurability by Emo1313...
//
//
//	ALSO REMOVED Setup Bot Armors, FROM BotSpawn.cs to this for the simple reason that the armors should be setup here.
//
//
//=========================================================================================================================================

function Stormbots::CloakBot(%aiId)
{
        %player = Client::getOwnedObject(%aiId);
        %player.cloakPack = 1;
        GameBase::startFadeout(%player);
	Player::setSensorSupression(%player,5);
        schedule("Stormbots::CloakBot(" @ %aiId @ ");",5,%player);
}

function AI::setWeapons(%aiId)
{
	if (%aiId==0)
		return;

	if (!BotFuncs::CheckAlive(%aiId))
		return;
	
	%aiName = Client::GetName(%aiId);

	AI::setVar(%aiName, iq, 90 );

	//== In case some moron ignorant mapmaker (just kidding ;-)) forgot to name the bots according to the readme,
	//== they'll spawn with the ugly-useless standard weapons.
	//== by Werewolf

	Player::setItemCount(%aiId, blaster, 1);
	Player::setItemCount(%aiId, disclauncher, 0);
	Player::setItemCount(%aiId, chaingun, 0);
	Player::setItemCount(%aiId, discammo, 0);
	Player::setItemCount(%aiId, bulletAmmo, 0);

	AI::SetVar(%aiName, triggerPct, 0.03 );
	AI::setVar(%aiName, attackMode, 1);
	AI::setAutomaticTargets( %aiName );
	AI::periodicWeaponChange(%aiName);

	//== If Mission Type Death Match, Set Basics And Return ===================

	if(Game::missionType == "DM")
	{	
		Player::setItemCount(%aiId, blaster, 1);
		Player::mountItem(%aiId, blaster, 0);
		return;
	}

	//== Mortar Bot Set Up ====================================================

	if(String::findSubStr(%aiName, "Mortar") >= 0)
	{
		AI::setVar(%aiName, iq, 90 );
		for(%i = 0; $Spoonbot::MortarGear[%i] != ""; %i++)
			Player::setItemCount(%aiId, $Spoonbot::MortarGear[%i], $SpoonBot::MortarAmmo[%i]);
		Player::useItem(%aiId, $SpoonBot::MortarPack);
		Player::mountItem(%aiId, $SpoonBot::MortarLong, 0);
	}

	//== Guard Bot Set Up======================================================

	else if(String::findSubStr(%aiName, "Guard") >= 0)
	{
		AI::setVar(%aiName, iq, 90 );
		for(%i = 0; $Spoonbot::GuardGear[%i] != ""; %i++)
			Player::setItemCount(%aiId, $Spoonbot::GuardGear[%i], $SpoonBot::GuardAmmo[%i]);
		Player::useItem(%aiId, $SpoonBot::GuardPack);
		Player::mountItem(%aiId, $SpoonBot::GuardLong, 0);
	}
	
	//== Demo Bot Setup =======================================================
	
	else if(String::findSubStr(%aiName, "Demo") >= 0)
	{
		for(%i = 0; $Spoonbot::DemoGear[%i] != ""; %i++)
			Player::setItemCount(%aiId, $Spoonbot::DemoGear[%i], $SpoonBot::DemoAmmo[%i]);
		Player::useItem(%aiId, $SpoonBot::DemoPack);
		Player::mountItem(%aiId, $SpoonBot::DemoLong, 0);

		AI::SetVar(%aiName, spotDist, 50);
		AI::SetVar(%aiName, seekOff , 1);   // Dunno what this does. Werewolf
	}

	//== Painter Bot Setup ========================================================

	else if(String::findSubStr(%aiName, "Painter") >= 0)
	{
		AI::setVar(%aiName, iq, 200 );
   		for(%i = 0; $Spoonbot::PainterGear[%i] != ""; %i++)
 			Player::setItemCount(%aiId, $Spoonbot::PainterGear[%i], $SpoonBot::PainterAmmo[%i]);
		Player::useItem(%aiId, $SpoonBot::PainterPack);
        	Player::mountItem(%aiId, $SpoonBot::PainterLong, 0);
	
		AI::SetVar(%aiName, spotDist, 50);
		AI::SetVar(%aiName, seekOff , 1);   // Dunno what this does. Werewolf
	}

	//== Sniper Bot Setup =============================================================

	else if(String::findSubStr(%aiName, "Sniper") >= 0)
	{
		AI::setVar(%aiName, iq, 80 );
		for(%i = 0; $Spoonbot::SniperGear[%i] != ""; %i++)
	 		Player::setItemCount(%aiId, $Spoonbot::SniperGear[%i], $SpoonBot::SniperAmmo[%i]);
		Player::useItem(%aiId, $SpoonBot::SniperPack);
		Player::mountItem(%aiId, $SpoonBot::SniperLong, 0);
		   
		AI::SetVar(%aiName, spotDist, 1000);		// Make 20-20 vision for snipers ;-) Werewolf
		AI::SetVar(%aiName, seekOff , 1);   // Dunno what this does. Werewolf
	}

	//== Medic Bot Setup =========================================================

	else if(String::findSubStr(%aiName, "Medic") >= 0)
	{
		AI::setVar(%aiName, iq, 70 );
	   	for(%i = 0; $Spoonbot::MedicGear[%i] != ""; %i++)
	 	       Player::setItemCount(%aiId, $Spoonbot::MedicGear[%i], $SpoonBot::MedicAmmo[%i]);
		Player::useItem(%aiId, $SpoonBot::MedicPack);
		Player::mountItem(%aiId, $SpoonBot::MedicLong, 0);
	}

	//== Miner Bot Setup =========================================================

	else if(String::findSubStr(%aiName, "Miner") >= 0)
	{
	   	AI::setVar(%aiName, iq, 70 );
	   	for(%i = 0; $Spoonbot::MinerGear[%i] != ""; %i++)
	 		Player::setItemCount(%aiId, $Spoonbot::MinerGear[%i], $SpoonBot::MinerAmmo[%i]);
		Player::useItem(%aiId, $SpoonBot::MinerPack);
		Player::mountItem(%aiId, $SpoonBot::MinerLong, 0);
	}
	
	//==Runner Bot Setup==========================================================
	
	else if (String::findSubStr(%aiName, "Runner") >=0)
	{
		AI::setVar(%aiName, iq, 80 );
		for(%i = 0; $Spoonbot::RunnerGear[%i] != ""; %i++)
			Player::setItemCount(%aiId, $Spoonbot::RunnerGear[%i], $SpoonBot::RunnerAmmo[%i]);
		Player::useItem(%aiId, $SpoonBot::RunnerPack);
		Player::mountItem(%aiId, $SpoonBot::RunnerLong, 0);
	}

	//== Standard Setup =========================================================

	else 
	{
	   	AI::setVar(%aiName, iq, 50 );
	   	for(%i = 0; %i = ""; %i++)
	 		Player::setItemCount(%aiId, $Spoonbot::StandardGear[%i], $SpoonBot::StandardAmmo[%i]);
		Player::useItem(%aiId, $SpoonBot::StandardPack);
		Player::mountItem(%aiId, $SpoonBot::StandardLong, 0);
	}
	BotGear::CheckBackpack(%aiId);
}

//=====================================================================================
//	AI::periodicWeaponChange()
//=====================================================================================
//modified by Werewolf

function ai::periodicWeaponChange(%aiName)
{
	%aiId = BotFuncs::GetId(%aiName);
	if (%aiId==0)
		return;

	if (!BotFuncs::CheckAlive(%aiId))
		return;

	if ($pacified[%aiId] || $scrambled[%aiId] || $Spoonbot::MortarBusy[%aiId])
	{
		schedule("ai::periodicWeaponChange(" @ %aiName @ ");", 4);
//		echo("Aborting weapon change");
		return;
	}

	BotFuncs::checkForPaint(%aiName);

	%curTarget = BotFuncs::NearestAttacker(%aiId, 300, 0);

	%targLoc = GameBase::getPosition(Client::getOwnedObject(%curTarget));
	%aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
	%targetDist = Vector::getDistance(%aiLoc, %targLoc);

	if(%targetDist <= 0)
		%targetDist = 300;
	
	//== Mortar Weapons ==========================================================================

	if(String::findSubStr(%aiName, "Mortar") >= 0)
	{
		if(%targetDist > 50)
		{
			if(Player::isJetting(%curTarget))
			{	
				Player::mountItem(%aiId, $SpoonBot::MortarJet, 0);
				AI::SetVar(%aiName, triggerPct, 0.6 );
			}
			else
			{
				Player::mountItem(%aiId, $SpoonBot::MortarLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.5 );
			}   
		}   
		else
		{
			Player::mountItem(%aiId, $SpoonBot::MortarClose, 0);  
			AI::SetVar(%aiName, triggerPct, 1 );
		}
	}

	//== Guard Weapons ==========================================================================

	else if(String::findSubStr(%aiName, "Guard") >= 0)
	{
		if(%targetDist > 50)
		{
			if(Player::isJetting(%curTarget))
			{	
				Player::mountItem(%aiId, $SpoonBot::GuardJet, 0);
				AI::SetVar(%aiName, triggerPct, 0.6 );
			}
			else
			{
				Player::mountItem(%aiId, $SpoonBot::GuardLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.5 );
			}   
		}   
		else
		{
			Player::mountItem(%aiId, $SpoonBot::GuardClose, 0);  
			AI::SetVar(%aiName, triggerPct, 1 );
		}
	}
	
	//== Demo Weapons ==========================================================================

	else if(String::findSubStr(%aiName, "Demo") >= 0)
	{
		if(%targetDist > 100)
		{
			if(Player::isJetting(%curTarget))
			{	
				Player::mountItem(%aiId, $SpoonBot::DemoJet, 0);
				AI::SetVar(%aiName, triggerPct, 0.6 );
			}
			else
			{
				Player::mountItem(%aiId, $SpoonBot::DemoLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.5 );
			}   
		}   
		else
		{
			Player::mountItem(%aiId, $SpoonBot::DemoClose, 0);  
			AI::SetVar(%aiName, triggerPct, 1 );
		}
	}
	
	//== Painter Weapons ==========================================================================

	else if(String::findSubStr(%aiName, "Painter") >= 0)
	{
		if(%targetDist > 20)
		{
			if(Player::isJetting(%curTarget))
			{	
				Player::mountItem(%aiId, $SpoonBot::PainterJet, 0);
				AI::SetVar(%aiName, triggerPct, 0.1 );
			}
			else
			{
				Player::mountItem(%aiId, $SpoonBot::PainterLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.1 );
			}   
		}   
		else
		{
			Player::mountItem(%aiId, $SpoonBot::PainterClose, 0);  
			AI::SetVar(%aiName, triggerPct, 0.1 );
		}
	}
	
	//== Sniper Weapons ==========================================================================

	else if(String::findSubStr(%aiName, "Sniper") >= 0)
	{
		Player::setDetectParameters(%aiId, 0.0001, 0.00001);

		if(%targetDist > 50)
		{
			if(Player::isJetting(%curTarget))
			{	
				Player::mountItem(%aiId, $SpoonBot::SniperJet, 0);
			        AI::SetVar(%aiName, triggerPct, 0.005 );
			}
			else
			{
				Player::mountItem(%aiId, $SpoonBot::SniperLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.005 );
			}   
		}   
		else
		{
			Player::mountItem(%aiId, $SpoonBot::SniperClose, 0);  
			AI::SetVar(%aiName, triggerPct, 1 );
		}
	}
	
	//== Miner Weapons ==========================================================================

	else if(String::findSubStr(%aiName, "Miner") >= 0)
	{
		if(%targetDist > 50)
		{
			if(Player::isJetting(%curTarget))
			{	
				Player::mountItem(%aiId, $SpoonBot::MinerJet, 0);
		        	AI::SetVar(%aiName, triggerPct, 0.6 );
			}
			else
			{
		        	Player::mountItem(%aiId, $SpoonBot::MinerLong, 0);  
				AI::SetVar(%aiName, triggerPct, 0.03 );
			}   
		}   
		else
		{
			Player::mountItem(%aiId, $SpoonBot::MinerClose, 0);  
			AI::SetVar(%aiName, triggerPct, 0.03 );
		}
	}

	//== Medic Weapons ==========================================================================

	else if(String::findSubStr(%aiName, "Medic") >= 0)
	{
		if(%targetDist > 20)
		{
			if(Player::isJetting(%curTarget))
			{	
				Player::mountItem(%aiId, $SpoonBot::MedicJet, 0);
		         	AI::SetVar(%aiName, triggerPct, 0.6 );
			}
			else
			{
		         	Player::mountItem(%aiId, $SpoonBot::MedicLong, 0);  
		         	AI::SetVar(%aiName, triggerPct, 0.03 );
			}   
		}   
		else
		{
			Player::mountItem(%aiId, $SpoonBot::MedicClose, 0);
			AI::SetVar(%aiName, triggerPct, 1 );
			Player::useItem(%aiId, repairkit);
		}
	}
	
	//===Set Runner Weapons=========================================================================== 
	else if(String::findSubStr(%aiName, "Runner") >= 0)
	{
		   if(%targetDist > 30)
		   {
		      if(Player::isJetting(%curTarget))
		      {	
		         	Player::mountItem(%aiId, $SpoonBot::RunnerJet, 0);
		         	AI::SetVar(%aiName, triggerPct, 0.5 );
		      }
		      else
		      {
		         	Player::mountItem(%aiId, $SpoonBot::RunnerLong, 0);  
		         	AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::RunnerClose, 0);
//		         AI::SetVar(%aiName, triggerPct, 1 );
		         Player::useItem(%aiId, repairkit);
		   }
	}
	//== Set Standard Weapons If Bot Is Not Any Of The Presets ==========================================================================

	else 
	{	
		if(%targetDist > 100)
		{
			Player::mountItem(%aiId, $SpoonBot::StandardLong, 0);
			AI::SetVar(%aiName, triggerPct, 0.03 );
		}   
		else
		{
			if(Player::isJetting(%curTarget))
			{	
				Player::mountItem(%aiId, $SpoonBot::StandardJet, 0);
				AI::SetVar(%aiName, triggerPct, 0.6 );
			}
			else
			{
				Player::mountItem(%aiId, $SpoonBot::StandardLong, 0);  
				AI::SetVar(%aiName, triggerPct, 0.03 );
			}   
		}
	}

	schedule("ai::periodicWeaponChange(" @ %aiName @ ");", 4);

}

//== End Of Bot Setup Functions ============================================================================================================

//	 Setup Bot Armors, Moved here. Ganvit.

function BotsArmor::SetupArmor(%aiName)
{
	if (%aiName == "")
	{
  		return;
	}
		
	    if(String::findSubStr(%aiName, "Female") >= 0)        //All the IFs are from Werewolf
	    {
		      $AI::defaultArmorType = $SpoonBot::StandardFArmor;
		      %voice = "female1";
	    }
	    else
	    {
		      $AI::defaultArmorType = $SpoonBot::StandardMArmor;
		      %voice = "male1";
	    }
	
	
	    if(String::findSubStr(%aiName, "Mortar") >= 0)
	    {
		    if(String::findSubStr(%aiName, "Female") >= 0)
		    {
			      $AI::defaultArmorType = $SpoonBot::MortarFArmor;
			      %voice = "female5";
		    }
		    else
		    {
			      $AI::defaultArmorType = $SpoonBot::MortarMArmor;
			      %voice = "male5";
		    }
	    }


	    if(String::findSubStr(%aiName, "Guard") >= 0)
	    {
		    if(String::findSubStr(%aiName, "Female") >= 0)
		    {
			      $AI::defaultArmorType = $SpoonBot::GuardFArmor;
			      %voice = "female5";
		    }
		    else
		    {
			      $AI::defaultArmorType = $SpoonBot::GuardMArmor;
			      %voice = "male5";
		    }
	    }
	
	
	    if(String::findSubStr(%aiName, "Demo") >= 0)
	    {
		    if(String::findSubStr(%aiName, "Female") >= 0)
		    {
			      $AI::defaultArmorType = $SpoonBot::DemoFArmor;
			      %voice = "female4";
		    }
		    else
		    {
			      $AI::defaultArmorType = $SpoonBot::DemoMArmor;
			      %voice = "male4";
		    }
	    }
	

	    if(String::findSubStr(%aiName, "Medic") >= 0)
	    {
		    if(String::findSubStr(%aiName, "Female") >= 0)
		    {
			      $AI::defaultArmorType = $SpoonBot::MedicFArmor;
			      %voice = "female2";
		    }
		    else
		    {
			      $AI::defaultArmorType = $SpoonBot::MedicMArmor;
			      %voice = "male4";
		    }
	    }
	
	
	    if(String::findSubStr(%aiName, "Sniper") >= 0)
	    {
		    if(String::findSubStr(%aiName, "Female") >= 0)
		    {
			      $AI::defaultArmorType = $SpoonBot::SniperFArmor;
			      %voice = "female2";
		    }
		    else
		    {
			      $AI::defaultArmorType = $SpoonBot::SniperMArmor;
			      %voice = "male2";
		    }
	    }
	
	
	    if(String::findSubStr(%aiName, "Painter") >= 0)
	    {
		    if(String::findSubStr(%aiName, "Female") >= 0)
		    {
			      $AI::defaultArmorType = $SpoonBot::PainterFArmor;
			      %voice = "female1";
		    }
		    else
		    {
			      $AI::defaultArmorType = $SpoonBot::PainterMArmor;
			      %voice = "male1";
		    }
	    }
	
	
	    if(String::findSubStr(%aiName, "Miner") >= 0)
	    {
		    if(String::findSubStr(%aiName, "Female") >= 0)
		    {
			      $AI::defaultArmorType = $SpoonBot::MinerFArmor;
			      %voice = "female2";
		    }
		    else
		    {
			      $AI::defaultArmorType = $SpoonBot::MinerMArmor;
			      %voice = "male4";
		    }
	    }
	    //ADDED RUNNER BOT.
	    if(String::findSubStr(%aiName, "Runner") >= 0)
	    {
		    if(String::findSubStr(%aiName, "Female") >= 0)
		    {
			      $AI::defaultArmorType = $SpoonBot::RunnerFArmor;
			      %voice = "female2";
		    }
		    else
		    {
			      $AI::defaultArmorType = $SpoonBot::RunnerMArmor;
			      %voice = "male3";
		    }
	    }
}

function BotGear::CheckBackpack(%aiId)
{
	%aiobj = Client::getOwnedObject(%aiId);
	if (Player::getMountedItem(%aiId,$BackpackSlot) == "shieldpack")
	{
		%aiobj.shieldStrength = 0.012;
		echo("Bot's shield is on.");
	}
	else if (Player::getMountedItem(%aiId,$BackpackSlot) == "SensorJammerPack")
	{
		Player::setSensorSupression(%aiobj,25);
		echo("Bot's sensor jammer is on.");
	}
	else if (Player::getMountedItem(%aiId,$BackpackSlot) == "RepairPack")
	{
		GameBase::setAutoRepairRate(%aiobj,0.01);
		echo("Bot is auto-repairing.");
	}
	else if (Player::getMountedItem(%aiId,$BackpackSlot) == "CloakingDevice")
        {
                Stormbots::CloakBot(%aiId);
                echo("Bot's cloaking device is on.");
        }
}
