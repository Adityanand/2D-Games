#pragma strict
var killTimer:float;
var BulletCollid=false;
function Start () {

}

function Update () 
{
killTimer-=Time.deltaTime;
if(killTimer<=0.0)
{
gameObject.Destroy(gameObject);
}
if(BulletCollid==true){
    gameObject.Destroy(gameObject);
}
}
function OnCollisionEnter2D(){
    BulletCollid=true;
}