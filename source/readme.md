xCore

xCore is simple FiveM library

### Teleport functions and events

**1. Functions (client side)**
   - teleportPlayer(int entity,Vector3 vec,float head = -999)
   
**2. Events (client side)**
   - xCore:Client:teleport: (Will teleport player)
      - Parameters: int entity,Vector3 vec,float head = -999

### MoneySystem functions and events

**1. Functions (client side)**
   - getMoney()       returns how much money player has in pocket
   - getBankMoney()   returns how much money player has in bank
   - getDirtyMoney()  returns how much dirty money player has in pocket

**2. Functions (server side)**
   - PlayerMoneyHolder.getPlayerMoney(int source)
      - Will return player instance for class money.
      
   - setMoney(int source,int money)
      - will set money
      
   - setBankMoney(int source,int money)   
      - will set money
      
   - setDirtyMoney(int source,int money)  
      - will set money
   
   - getMoney()       returns how much money player has in pocket
   - getBankMoney()   returns how much money player has in bank
   - getDirtyMoney()  returns how much dirty money player has in pocket

**3. Events (server)**
   - xCore:Server:getPlayerMoney: (Will return players money)
      - Parameters: int id,string type, return type in int (if something is wrong it will return int.MinValue)
      
   - xCore:Server:setMoney: (Will set player money)
      - Parameters: int id,string type,int money 
      
   - xCore:Server:addMoney: (Will add balance to player account)
      - Parameters: int id,string type,int money 
   
**4. Events (client side)**
   - xCore:Client:MoneyUpdated: (Will call whenever player earn cash)
      - Parameters: string(typeMoney) , int(MoneyCount)

### PlayerJob functions and events

**1. Functions (client side)**
   - getJobGrade() returns player Job Grade
   - getJobName()  returns player Job Name
   
**2. Functions (server side)**
   - PlayerJobHolder.getPlayerJob(int source)
      - Will return player instance for class job. 
      
   - setPlayerJob(int id,string job,string grade)
   
   - getJobGrade(int id) returns player Job Grade
   
   - getJobName(int id)  returns player Job Name
   
**3. Events (server)**
   - xCore:Server:setJob: (Will set player job)
      - Parameters: int id,string job,string grade      
   
**4. Events (client side)**
   - xCore:client:setJob: (Will call whenever player jobs got updated)
      - Parameters: string job,string grade
      
   - xCore:client:jobLoaded: (Will call when player spawn in game)
      - Parameters: string job,string grade
 
### Other events
 
##### KeyEvent
Simple event that will call whenever player push any key on keyboard.

- xCore:client:keyEvent

Example
```C#
EventHandlers["xCore:client:keyEvent"] += new Action<int>((key)=> 
{
   Debug.WriteLine($"Dang, you pushed key: {key}");
});
```
