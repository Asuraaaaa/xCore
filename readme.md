xCore

xCore is simple FiveM library

### PlayerJob functions and Events

**1. Functions (server side)**
   - setPlayerJob(int id,string job,string grade)
   - getJobGrade(int id) returns player Job Grade
   - getJobName(int id)  returns player Job Name
   
**2. Events (client side)**
   - xCore:client:setJob: (Will call whenever player jobs got updated)
      - Parameters: string job,string grade
   - xCore:client:jobLoaded: (Will call when player spawn in game)
      - Parameters: string job,string grade
      
**3. Events (server)**
   - xCore:Server:setJob: (Will set player job)
      - Parameters: int id,string job,string grade      

### KeyEvent
Simple event that will call whenever player push any key on keyboard.

- xCore:client:keyEvent

Example
```C#
EventHandlers["xCore:client:keyEvent"] += new Action<int>((key)=> 
{
   Debug.WriteLine($"Dang, you pushed key: {key}");
});
```
