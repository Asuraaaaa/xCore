xCore is simple FiveM library made for RolePLay servers. but... can be used anywhere i guess ?

####TO DO

- [ ] Inventory system
- [ ] Notifications
- [ ] Property system
- [x] Sound system
- [x] Group system
- [x] Job system
- [x] Money system

### SoundSystem functions

Class name: **_PlayerSound_**

**1. Functions (client side)**
------------
   - PLayUrl(name, url, volume)
     Will play sound from url
      
   - PLayUrl(name, url, volume, Vector3 vec)
     Will play sound from url at x,y,z location 
     
   - PLay(name, url, volume)
     Will play sound that is defined in html/scripts/config.js
      
   - PLay(name, url, volume, Vector3 vec)
     Will play sound that is defined in html/scripts/config.js at x,y,z location      

   - Position(name, Vector3 vec)
     Will update location of sound
     
   - Stop(name)
     Will stop completly sound
     
   - Pause(name)
     Will pause sound
     
   - Resume(name)
     Will resume sound       
 
------------

 **Example client**       
 
```C#
int npc_seller = 0;
[Command("music")]
void playMusic()
{
     Vector3 pos = Game.Player.Character.Position;
     PlayerSound.Play("clap", 0.5f, pos.X, pos.Y, pos.Z);
     
     Vector3 seller = Game.Player.Character.Position;
     uint hash = (uint)API.GetHashKey("s_m_m_hairdress_01");
     while (!API.HasModelLoaded(hash))
     {
          API.RequestModel(hash);
          await Delay(200);
     }
     npc_seller = API.CreatePed(2, hash, seller.X, seller.Y, seller.Z, 0f, false, true);     
}

[Tick]
async Task followSound()
{
     await Delay(33);
     Vector3 pos = API.GetEntityCoords(npc_seller, true);
     PlayerSound.Position("clap", pos.X, pos.Y, pos.Z);
}

[Command("custommusic")]
void customMusic()
{
     Vector3 pos = Game.Player.Character.Position;
     PlayerSound.PLayUrl("custom", "http://relisoft.cz/assets/gta.mp3", 0.5f);
}

[Command("stopsound")]
void stopSound()
{
     PlayerSound.Stop("custom");
}
``` 

### GroupSystem functions and events

Class name: **_PlayerGroup_**

**1. Functions (client side)**
------------
Class name: **_PlayerGroup_**
   - isAtGroup(string group)
     return true/false   
      
   - getPlayerGroups() 
     return List<string>()    
 
------------
**2. Functions (server side)**
------------
Class name: **_PlayerGroup_**
   - add(string group)
     Will add a new group to player.       
	 
   - remove(string group)
      Will remove group from player.     

   - isAtGroup(string group)
      Will return true/false
	  
   - exists(string group)
      Will return true/false

   - PlayerGroupHolder.getPlayerGroup(int source OR Player player)
      Will return instance for player group class.
------------
**3. Events (server)**     
   - xCore:Server:addPlayerGroup: (Will add group to player)
      Parameters: int source,string group
      
   - xCore:Server:removePlayerGroup: (Will remove group from player)
      Parameters: int source,string group
      
**4. Events (client)**     
   - xCore:Client:GroupAdded: (Will call whenever player receive new group)
      Parameters: string group
      
   - xCore:Client:GroupRemove: (Will call whenever group is removed from player)
      Parameters: string group      
      
 **Example client**       
 
```C#
[Command("heal")]
void healCommand()
{
    PlayerGroup gp = new PlayerGroup();
    if(gp.isAtGroup("vip"))
    {
        API.SetEntityHealth(API.PlayerPedId(),250);
        Screen.ShowNotification("Yeeey... you healed your self... :D");
    }
}
``` 
      
 **Example server**   
 
 ```C#
public void giveMoney([FromSource] Player player,Player target,string type,int money)
{
    PlayerGroup pg = PlayerGroupHolder.getPlayerGroup(player);
    if(pg.isAtGroup("admin"))
    {
        PlayerMoney pMoney = PlayerMoneyHolder.getPlayerMoney(player);
        if(type == "dirtymoney") pMoney.addDirtyMoney(money);
        if(type == "bankmoney") pMoney.addBankMoney(money);
        if(type == "money") pMoney.addMoney(money);       
    }
}
``` 
 
### Teleport functions and events
        

**1. Functions (client side)**
------------
Class name: **_teleport_**
   - teleportPlayer(int entity,Vector3 vec,float head = -999)
   
------------   
**2. Events (client side)**
   - xCore:Client:teleport: (Will teleport player)
      Parameters: int entity,Vector3 vec,float head = -999

 **Example client**       
 
```C#
[Command("spawn")]
void healCommand(string[] args)
{
    PlayerGroup gp = new PlayerGroup();
    if(gp.isAtGroup("admin"))
    {
        teleport.teleportPlayer(API.PlayerPedId(),new Vector3(250,125,1024));
        Screen.ShowNotification("Welcome to spawn i guess ?");
    }
}
```

### MoneySystem functions and events

Class name: **_PlayerMoney_**

**1. Functions (client side)**
------------
Class name: **_PlayerMoney_**
   - getMoney()       returns how much money player has in pocket
   - getBankMoney()   returns how much money player has in bank
   - getDirtyMoney()  returns how much dirty money player has in pocket
------------

**2. Functions (server side)**
------------
Class name: **_PlayerMoney_**
   - PlayerMoneyHolder.getPlayerMoney(int source)
      Will return player instance for class money.
      
   - setMoney(int money)
      will set money
      
   - setBankMoney(int money)   
      will set money
      
   - setDirtyMoney(int money)  
      will set money
      
   - addDirtyMoney(int money)
      will add money
      
   - addBankMoney(int money)   
      will add money
      
   - addMoney(int money)  
      will add money      
   
   - getMoney()  
      returns how much money player has in pocket
   - getBankMoney() 
      returns how much money player has in bank
   
   - getDirtyMoney()  
      returns how much dirty money player has in pocket
------------

**3. Events (server)**
   - xCore:Server:getPlayerMoney: (Will return players money)
      Parameters: int id,string type, return type in int (if something is wrong it will return int.MinValue)
      
   - xCore:Server:setMoney: (Will set player money)
      Parameters: int id,string type,int money 
      
   - xCore:Server:addMoney: (Will add balance to player account)
      Parameters: int id,string type,int money 
   
**4. Events (client side)**
   - xCore:Client:MoneyUpdated: (Will call whenever player earn cash)
      Parameters: string(typeMoney) , int(MoneyCount)

 **Example client**       
 
```C#
[Command("buycar")]
void healCommand(string[] args)
{
    PlayerMoney pMoney = new PlayerMoney();
    if(pMoney.getMoney() >= 600)
    {
        string car = "car_name";
        TriggerServerEvent("Bazar:BuyVehicle",car);
        Screen.ShowNotification($"You bought: {car} cg, you had enough money...");
    }
    else  Screen.ShowNotification("Looool poor boy.. :D");
}
```

 **Example server**       
 
```C#
[EventHandler("Bazar:BuyVehicle")]
void playerCar([FromSource] Player player,string car)
{
    var licenseIdentifier = player.Identifiers["steam"];

    PlayerMoney pMoney = PlayerMoneyHolder.getPlayerMoney(player);
    pMoney.addMoney(-600);
    MYSQL.execute($"INSERT INTO `vehicles` (`steamid`, `car`) VALUES ('{licenseIdentifier}','{car}');");
}
```

### PlayerJob functions and events

**1. Functions (client side)**
------------
Class name: **_PlayerJob_**
   - getJobGrade() returns player Job Grade
   - getJobName()  returns player Job Name
------------ 
   
**2. Functions (server side)**
------------
Class name: **_PlayerJob_**
   - PlayerJobHolder.getPlayerJob(int source)
      Will return player instance for class job. 
      
   - setPlayerJob(int id,string job,string grade)
   
   - getJobGrade(int id) returns player Job Grade
   
   - getJobName(int id)  returns player Job Name
------------   
**3. Events (server)**
   - xCore:Server:setJob: (Will set player job)
      Parameters: int id,string job,string grade      
   
**4. Events (client side)**
   - xCore:client:setJob: (Will call whenever player jobs got updated)
      Parameters: string job,string grade
      
   - xCore:client:jobLoaded: (Will call when player spawn in game)
      Parameters: string job,string grade
 
 **Example client**       
 
```C#
[Command("repair")]
void healCommand(string[] args)
{
    PlayerJob pJob = new PlayerJob();
    if(pJob.getJobName("mechanic"))
    {
        API.SetPlayerVehicleDamageModifier(API.PlayerId(), 1000);        
    }
}
```

 **Example server**       
 
```C#
[EventHandler("BossMenu:setJob:Mechanic")]
void playerCar(Player target,string job,int grade)
{
    PlayerJob pJob = PlayerJobHolder.getPlayerJob(target);
    MYSQL.FetchAll($"SELECT * FROM jobgrades WHERE name = '{job}' AND grade ='{grade}'", null, (List<dynamic> list) =>
    {
        if(list != null)
        {
            pJob.setPlayerJob(list[0].name, list[0].grade);
        }
    });
}
```
 
### Other events
 
##### KeyEvent
Simple event that will call whenever player push any key on keyboard.

- xCore:client:keyEvent

Example
```C#
[EventHandler("xCore:client:keyEvent")]
void keyEvent(int KeyCode)
{
    Debug.WriteLine($"Dang, you pushed key: {KeyCode}");
}
```
