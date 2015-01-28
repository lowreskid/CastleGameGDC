if(distance_to_object(instance_nearest(x, y, obj_enemy)) < 100)
{
    if place_meeting(x, y, obj_enemy)
    {
        inst = instance_nearest(x, y, obj_enemy);
        targetx = (inst.x + lengthdir_x(100, image_angle));
        targety = (inst.y + lengthdir_y(100, image_angle));
    } 
}
with (inst)
{
/*
    x = x + (other.targetx - x) * 0.2;
    y = y + (other.targety - y) * 0.2;
*/

    //var pdir;
    //pdir = point_direction(other.x, other.y, x, y);
    speed = -8
    alarm[0] = 5
}
