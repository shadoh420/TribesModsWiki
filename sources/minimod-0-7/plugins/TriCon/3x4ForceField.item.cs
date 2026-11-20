///-----------------------------------------------
/// description = "3x4 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

$TeamItemMax[threebyfourForceFieldPack] = 10;

ItemImageData threebyfourForceFieldPackImage
{
        //shapeFile = "forcefield_3x4";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData threebyfourForceFieldPack
{
        description = "3x4 Force Field";
        //shapeFile = "forcefield_3x4";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "oForce Fields";
        imageType = threebyfourForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function threebyfourForceFieldPack::onUse(%player,%item)
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

function threebyfourForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (threebyfourForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function threebyfourForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("threebyfourForceFieldPack","StaticShape",threebyfourForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"3x4 ForceField#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"3x4 Force Field deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "threebyfourForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 3x4 Force Field ");
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

