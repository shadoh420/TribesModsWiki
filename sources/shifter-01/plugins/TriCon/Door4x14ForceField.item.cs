///-----------------------------------------------
/// description = "4x14 Force Field Door";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

$TeamItemMax[doorfourbyfourteenForceFieldPack] = 10;

ItemImageData doorfourbyfourteenForceFieldPackImage
{
        //shapeFile = "forcefield_4x14";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData doorfourbyfourteenForceFieldPack
{
        description = "4x14 Field Door";
        //shapeFile = "forcefield_4x14";
        shapeFile = "AmmoPack";
        className = "Backpack";
          heading = "pDoors";
        imageType = doorfourbyfourteenForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorfourbyfourteenForceFieldPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function doorfourbyfourteenForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfourbyfourteenForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfourbyfourteenForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("doorfourbyfourteenForceFieldPack","StaticShape",doorfourbyfourteenForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"4x14 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"4x14 Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyfourteenForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 4x14 Force Field Door ");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


