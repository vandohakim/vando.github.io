<?php
// include database connection file
include_once("connect.php");
$con=mysqli_connect("localhost","root","","forum");
// Get id from URL to delete that user
$id = $_GET['id'];

// Delete user row from table based on given id
$result = mysqli_query($con, "DELETE FROM posts WHERE post_id=$id");

// After delete redirect to Home, so that latest user list will be displayed.
    if($result){header("Location:javascript://history.go(-1)");header("Refresh:3");}
	echo 'Your reply has been saved, check out <a href="topic.php?id=' . htmlentities($_GET['id']) . '">the topic</a>.';
?>