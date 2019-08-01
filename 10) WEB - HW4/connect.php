<?php
//connect.php
$server = 'localhost';
$username   = 'root';
$password   = '';
$database   = 'forum';
$con=mysqli_connect("localhost","root","","forum");
 
if(!mysqli_connect($server, $username, $password))
{
 	exit('Error: could not establish database connection');
}
if(!mysqli_select_db($con,$database))
{
 	exit('Error: could not select the database');
}
?>