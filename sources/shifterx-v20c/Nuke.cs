function NuclearExplosion(%this, %client)
{
	%team = gamebase::getTeam(%client);
                %obj = newobject("","Mine","NBase");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
		GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NRing1");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NRing2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NRing3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NRing4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NRing5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 45.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NCloud1");
                addToSet("MissionCleanup", %obj);
                %padd = "15.0 0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NCloud2");
                addToSet("MissionCleanup", %obj);
                %padd = "-15.0 0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NCloud3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 15.0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NCloud4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -15.0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);

                %obj = newobject("","Mine","NCloud5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 75.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
			GameBase::setTeam(%obj, %team);
                GameBase::setPosition(%obj, %pos);
}
