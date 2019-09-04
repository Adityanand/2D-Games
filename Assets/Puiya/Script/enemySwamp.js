#pragma strict
var Enemy:Transform;
var SwampPosition:Transform;
var Timer:float;
var resetTimer:float;
var StopTimer:float;
function Start () {
	
}

function Update () {
//Timer-=Time.deltaTime;
StopTimer-=Time.deltaTime;
if(StopTimer>=0.0)
{
Swamp();
}

/*if (Timer<=0.0)
{
var swamp=Instantiate(Enemy,SwampPosition.transform.position,Quaternion.identity);
Timer+=resetTimer;
}*/
}
function Swamp(){
Timer-=Time.deltaTime;
if (Timer<=0.0)
{
var swamp=Instantiate(Enemy,SwampPosition.transform.position,Quaternion.identity);
Timer+=resetTimer;
}
}
